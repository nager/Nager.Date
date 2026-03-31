# Contributing to Nager.Date

Thank you for considering contributing to Nager.Date! Please follow these guidelines to ensure a smooth integration of your changes.

## Adding a New Country

To add support for a new country, create a new provider class in the following directory: `src/Nager.Date/HolidayProviders`

### Validation Rules

- The `Id` must be unique for this HolidayProvider and must be uppercase.

### Naming Conventions

- Use PascalCase for class names: `AustriaHolidayProvider`
- File name must match the class name
- Use ISO 3166-1 alpha-2 country codes
- Keep English names consistent (e.g. always "New Year's Day", not variations)

### Observed Rules

If a holiday is moved when it falls on a weekend, use `ObservedRuleSet`.

Example:
```cs
var observedRuleSet = new ObservedRuleSet
{
    Saturday = date => date.AddDays(2), // Move to Monday
    Sunday = date => date.AddDays(1), // Move to Monday
}
```

### Subdivision Support

If holidays differ by region:

- Implement `ISubdivisionCodesProvider`
- Assign `SubdivisionCodes` to the holiday

### Complex Holiday Rules

For holidays involving complex logic (e.g., year-dependent rules, specific conditions, or astronomical calculations), **extract the logic into a separate private method.**

Example:
```cs
holidaySpecifications.AddRangeIfNotNull(this.LabourDay(year));

private HolidaySpecification[] LabourDay(int year)
{
    // Implementation of complex logic
}
```

### Sources

Every new provider must include reliable sources to verify the dates.

- **Priority**: Official government websites or national laws.
- **Fallback**: Wikipedia is acceptable if no official source is available.

### Implementation Example
Use the following template for a new country provider:

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
		ICatholicProvider catholicProvider) : base(CountryCode.XX)// Replace XX with ISO code
	{
		this._catholicProvider = catholicProvider;
	}
	
	/// <inheritdoc/>
	protected override IEnumerable<HolidaySpecification> GetHolidaySpecifications(int year)
	{
		var holidaySpecifications = new List<HolidaySpecification>
		{
			new HolidaySpecification
            {
                Id = "NEWYEARSDAY-01",
                Date = new DateTime(year, 1, 1),
                EnglishName = "New Year's Day",
                LocalName = "Local Name",
                HolidayTypes = HolidayTypes.Public
            },

			// Add other public holidays...

			this._catholicProvider.EasterSunday("Easter Sunday Local Name", year),
		};
	
		return holidaySpecifications;
	}
	
	/// <inheritdoc/>
	public override IEnumerable<string> GetSources()
	{
		return
		[
			"https://official-government-source.gov",
            "https://en.wikipedia.org/wiki/Public_holidays_in_NewCountryName"
		];
	}
}
```
