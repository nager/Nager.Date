# Contributing to Nager.Date

Guidelines for contributing to the repo.

## Add a new Country

- Add a new country provider in this folder src\Nager.Date\HolidayProviders
- Add a link to the source of the informations, multiple allowed
- The countrycode is ISO 3166-1 ALPHA-2
- The `Id` must be unique for this HolidayProvider

### Example
```cs
/// <summary>
/// NewCountryName HolidayProvider
/// </summary>
public class NewCountryNameHolidayProvider : AbstractHolidayProvider
{
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// NewCountryName HolidayProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public NewCountryNameProvider(
			ICatholicProvider catholicProvider) : base(CountryCode.??)
        {
            this._catholicProvider = catholicProvider;
        }

        ///<inheritdoc/>
        protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
        {
			var holidaySpecifications = new List<HolidaySpecification>
            {
                new HolidaySpecification
                {
                    Id = "NEWYEARSDAY-01", //Unique key for the holiday
                    Date = new DateTime(year, 1, 1),
                    EnglishName = "english name",
                    LocalName = "local name",
                    HolidayTypes = HolidayTypes.Public
                },
				/// add all public holidays
                this._catholicProvider.EasterSunday("local name", year),
            };

            return holidaySpecifications;
        }
		
        ///<inheritdoc/>
        public override IEnumerable<string> GetSources()
        {
            return
            [
                "https://source-of-the-information"
            ];
        }
}
```
