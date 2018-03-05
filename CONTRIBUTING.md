# Contributing to Nager.Date

Guidelines for contributing to the repo.

## Add new Country

Add a new country in this folder Src\Nager.Date\PublicHolidays
Add a link to the source of the informations
The countrycode is ISO 3166-1 ALPHA-2

### Example

	public class NewCountryNameProvider : CatholicBaseProvider
    {
        public override IEnumerable<PublicHoliday> Get(int year)
        {
            //NewCountryName
            //https://en.wikipedia.org/wiki/Public_holidays_in_NewCountryName

            var countryCode = CountryCode.XX;
            var easterSunday = base.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "local name", "english name", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "local name", "english name", countryCode));     
            ...

            return items.OrderBy(o => o.Date);
        }
    }


