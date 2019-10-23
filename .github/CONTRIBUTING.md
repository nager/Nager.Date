# Contributing to Nager.Date

Guidelines for contributing to the repo.

## Add new Country

- Add a new country in this folder Src\Nager.Date\PublicHolidays
- Add a link to the source of the informations
- The countrycode is ISO 3166-1 ALPHA-2

### Example
```
public class NewCountryNameProvider : IPublicHolidayProvider
{
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NewCountryNameProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NewCountryNameProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
	public override IEnumerable<PublicHoliday> Get(int year)
	{
		var countryCode = CountryCode.XX;
		var easterSunday = this._catholicProvider.EasterSunday(year);

		var items = new List<PublicHoliday>();
		items.Add(new PublicHoliday(year, 1, 1, "local name", "english name", countryCode));
		items.Add(new PublicHoliday(year, 12, 25, "local name", "english name", countryCode));     
		/// add all public holidays
		
		return items.OrderBy(o => o.Date);
	}
}
```
