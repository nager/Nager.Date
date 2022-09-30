# Contributing to Nager.Date

Guidelines for contributing to the repo.

## Add a new Country

- Add a new country provider in this folder src\Nager.Date\PublicHolidays
- Add a link to the source of the informations
- The countrycode is ISO 3166-1 ALPHA-2

### Example
```
/// <summary>
/// NewCountryName
/// </summary>
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

        ///<inheritdoc/>
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
		
        ///<inheritdoc/>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://source-of-the-information"
            };
        }
}
```
