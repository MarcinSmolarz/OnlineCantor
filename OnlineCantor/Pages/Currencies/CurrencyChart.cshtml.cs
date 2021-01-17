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
            //tempId = _db.Currency.Last<Currency>().Id; //potencjalnie lepsze rozwi¹zanie
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

            //potencjalny upgrade: najnowsza waluta przyjmuje ostatni alement z bazy, jednoczeœnie œci¹gamy maksymalne id (zastanowiæ siê czy trzeba)
            //póŸniej szukamy najm³odzszej danej odpowiadaj¹cej tej rz¹danej. Po odszukaniu, na jej podstawie wyszukujemy "œredniej" a w oparciu o ni¹ szukamy najstarszej

            //zapytanie sql znajdŸ wszyystkie gdzie ShortName = tye, order by/sort dateTime, wybierz 3 pierwsze/nastarsze, w zale¿noœci jak ustawi (zastosowaæ ascending i descenfding). 
            //lub select wszystkie currency z ShortName tyle do listy currencies i to samo co wy¿ej zrobiæ na liœcie

            //poczytaæ o Razor w kontekœcie MVC
            

            //microservices - zagadnienie architektoniczne
            //g³owne zagadnienia architektoniczne - monolit, microservice
            //metoda monolitu - wszystkie funkcjonalnoœci (np w serwisie pyszne.pl - w jednym namespace mamy funkcjonalnoœci odpowiedzialne za op³aty, kurierów, zamówienia itp).
            //Ca³a taka paczka jest wrzucana na serwer. W momencie potrzeby zmian trzeba ca³y monolit zgarn¹c, zmieniæ i znowu wrzuciæ na ca³y server
            //metoda microservisów - podzia³ tego co wy¿ej na mniajesze paczi/aplikacje, które ka¿da z osobna zawiera swoj¹ logikê, komunikuj¹c siê z innymi. Tego typu poejœcie
            //u³atwia pracê, bo ³atwo podzieliæ developerów na zespo³y pracuj¹ce nad poszczególnymi serwiami. £atwoœæ zmian. Z wad to to ¿e trzeba zapewniæ po³aczenia sieciowe 
            //miêdzy serwisami 
        }
    }
}

