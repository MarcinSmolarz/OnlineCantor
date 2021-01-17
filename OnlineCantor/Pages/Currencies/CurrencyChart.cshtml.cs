using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OnlineCantor.Data;
using OnlineCantor.Model;

namespace OnlineCantor.Pages.Currencies
{
    public class CurrencyChartModel : PageModel
    {
        private ApplicationDbContext _db;
        public CurrencyChartModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public Currency Currency { get; set; } //YesterayCurrency
        public Currency LatestCurrency { get; set; }
        public Currency ThreeDaysAgoCurrency { get; set; }
        public int tempId = 0;
        public string newest, middle, oldest;
        public async Task OnGet(int id)
        {
            Currency = await _db.Currency.FindAsync(id);
            //tempId = _db.Currency.Last<Currency>().Id; //potencjalnie lepsze rozwi�zanie
            tempId = _db.Currency.Count<Currency>();
            bool foundLast = false;
            bool foundMiddle = false;
            bool foundOldest = false;
            foreach (var r in _db.Currency)
            {
                if (r.Id <= tempId && r.ShortName == Currency.ShortName) 
                {
                    LatestCurrency = r;
                    newest = LatestCurrency.Value.ToString();
                    newest = newest.Replace(',', '.');
                }
            }
            foreach (var r in _db.Currency)
            {
                if (r.Id < LatestCurrency.Id && r.ShortName == Currency.ShortName)
                {
                    Currency = r;
                    middle = Currency.Value.ToString();
                    middle = middle.Replace(',', '.');
                }
            }
            foreach (var r in _db.Currency)
            {
                if (r.Id < Currency.Id && r.ShortName == Currency.ShortName)
                {
                    ThreeDaysAgoCurrency = r;
                    oldest = ThreeDaysAgoCurrency.Value.ToString();
                    oldest = oldest.Replace(',', '.');
                }
            }

            //alternatywny get
            /*
            foreach (var r in _db.Currency)
            {
                if (r.Id <= tempId && r.ShortName == Currency.ShortName)
                {
                    LatestCurrency = r;
                    newest = LatestCurrency.Value.ToString();
                    newest = newest.Replace(',', '.');
                }
                else if (r.Id < LatestCurrency.Id && r.ShortName == Currency.ShortName)
                {
                    Currency = r;
                    middle = Currency.Value.ToString();
                    middle = middle.Replace(',', '.');
                }
                else if (r.Id < Currency.Id && r.ShortName == Currency.ShortName)
                {
                    ThreeDaysAgoCurrency = r;
                    oldest = ThreeDaysAgoCurrency.Value.ToString();
                    oldest = oldest.Replace(',', '.');
                }
            }


            */



            //alternatywny get v2
            //bool foundLast, foundMiddle, foundOldest = false;

            /*while(!foundLast || !foundMiddle || !foundOldest)
            {
                var r = await _db.Currency.FindAsync(tempId);
                if(r.ShortName == Currency.ShortName && r.Id <= tempId && !foundLast)
                {
                    LatestCurrency = r;
                    newest = LatestCurrency.Value.ToString();
                    newest = newest.Replace(',', '.');
                    foundLast = true;
                }
                else if(r.ShortName == Currency.ShortName && r.Id <= tempId && !foundMiddle)
                {
                    Currency = r;
                    middle = Currency.Value.ToString();
                    middle = middle.Replace(',', '.');
                    foundMiddle = true;
                }
                else if(r.ShortName == Currency.ShortName && r.Id <= tempId && !foundOldest)
                {
                    ThreeDaysAgoCurrency = r;
                    oldest = ThreeDaysAgoCurrency.Value.ToString();
                    oldest = oldest.Replace(',', '.');
                    foundOldest = true;
                }
                tempId--;
            }*/

            //potencjalny upgrade: najnowsza waluta przyjmuje ostatni alement z bazy, jednocze�nie �ci�gamy maksymalne id (zastanowi� si� czy trzeba)
            //p�niej szukamy najm�odzszej danej odpowiadaj�cej tej rz�danej. Po odszukaniu, na jej podstawie wyszukujemy "�redniej" a w oparciu o ni� szukamy najstarszej

            //zapytanie sql znajd� wszyystkie gdzie ShortName = tye, order by/sort dateTime, wybierz 3 pierwsze/nastarsze, w zale�no�ci jak ustawi (zastosowa� ascending i descenfding). 
            //lub select wszystkie currency z ShortName tyle do listy currencies i to samo co wy�ej zrobi� na li�cie

            //poczyta� o Razor w kontek�cie MVC
            

            //microservices - zagadnienie architektoniczne
            //g�owne zagadnienia architektoniczne - monolit, microservice
            //metoda monolitu - wszystkie funkcjonalno�ci (np w serwisie pyszne.pl - w jednym namespace mamy funkcjonalno�ci odpowiedzialne za op�aty, kurier�w, zam�wienia itp).
            //Ca�a taka paczka jest wrzucana na serwer. W momencie potrzeby zmian trzeba ca�y monolit zgarn�c, zmieni� i znowu wrzuci� na ca�y server
            //metoda microservis�w - podzia� tego co wy�ej na mniajesze paczi/aplikacje, kt�re ka�da z osobna zawiera swoj� logik�, komunikuj�c si� z innymi. Tego typu poej�cie
            //u�atwia prac�, bo �atwo podzieli� developer�w na zespo�y pracuj�ce nad poszczeg�lnymi serwiami. �atwo�� zmian. Z wad to to �e trzeba zapewni� po�aczenia sieciowe 
            //mi�dzy serwisami 
        }
    }
}

