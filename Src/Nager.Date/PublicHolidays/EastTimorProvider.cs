using Nager.Date.Contract;
using Nager.Date.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nager.Date.PublicHolidays
{
    //class EastTimorProvider : IPublicHolidayProvider
    //{
    //    public IEnumerable<PublicHoliday> Get(int year)
    //    {
    //        var countryCode = CountryCode.TL;
    //        var easterSunday = EasterSunday(year);
    //        //East TImor Official Goverment links
    //        //http://www.mj.gov.tl/jornal/?q=node/910
    //        //http://timor-leste.gov.tl/?p=17138
    //        var items = new List<PublicHoliday>();
    //        items.Add(new PublicHoliday(year, 1, 1, "Dia de ano novo", "New Year's day", countryCode));
    //        items.Add(new PublicHoliday(year, 5, 1, "Dia do Trabalhador", "Labour Day", countryCode));
    //        items.Add(new PublicHoliday(year, 5, 20, "Dia da Restauração da Independência", "Restauration Day", countryCode));
    //        items.Add(new PublicHoliday(year, 8, 30, "Dia da Consulta Popular", "Popular Consultation Day", countryCode));
    //        items.Add(new PublicHoliday(year, 11, 1, "Dia de Todos-os-Santos", "All Saints Day", countryCode));
    //        items.Add(new PublicHoliday(year, 11, 2, "Dia de Todos-os-Fiéis Defuntos", "Day of All-Faithful Dead", countryCode));
    //        items.Add(new PublicHoliday(year, 11, 12, "Dia Nacional da Juventude", "National Youth Day", countryCode));
    //        items.Add(new PublicHoliday(year, 11,28, "Dia da Proclamação da Independência", "Indepence Day", countryCode));
    //        items.Add(new PublicHoliday(year,12,7,"Dia dos Heróis Nacionais", "National Hero's Day", countryCode));
    //        items.Add(new PublicHoliday(year, 12, 8, "Dia da Nossa Senhora da Imaculada Conceição e Padroeira de Timor-Leste", "Immaculate Conception - Protector of East Timor", countryCode));
    //        items.Add(new PublicHoliday(year, 12, 25, "Natal", "Christmas Day", countryCode, null));
    //        a) A Sexta-Feira Santa, inserida nas comemorações cristãs da Páscoa;



    //        b) O Idul Fitri, como o dia que marca, para os muçulmanos, o fim do Ramadão;




    //        c) A Festa do Corpo de Deus;



    //        d) O Idul Adha, como dia de sacrifício para os muçulmanos.
    //    }

    //    private DateTime EasterSunday(int year)
    //    {
    //        //http://stackoverflow.com/questions/2510383/how-can-i-calculate-what-date-good-friday-falls-on-given-a-year

    //        var g = year % 19;
    //        var c = year / 100;
    //        var h = (c - c / 4 - (8 * c + 13) / 25 + 19 * g + 15) % 30;
    //        var i = h - (h / 28) * (1 - (h / 28) * (29 / (h + 1)) * ((21 - g) / 11));

    //        var day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
    //        var month = 3;

    //        if (day > 31)
    //        {
    //            month++;
    //            day -= 31;
    //        }

    //        return new DateTime(year, month, day);
    //    }
    //}
}
