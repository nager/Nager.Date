# Contributing to Nager.Date

Guidelines for contributing to the repo.

## Add a new Country

- Add a new country provider in this folder src\Nager.Date\HolidayProviders

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
    Saturday = date => date.AddDays(2),
    Sunday = date => date.AddDays(1),
}
```

### Subdivision Support

If holidays differ by region:

- Implement `ISubdivisionCodesProvider`
- Assign `SubdivisionCodes` to the holiday

## Complex Holiday Rules

If a holiday has complex logic (e.g. different rules per year, conditional dates, or special cases), it must be extracted into a separate private method.

This improves readability, maintainability, and testability.

Example:
```cs
holidaySpecifications.AddRangeIfNotNull(this.LabourDay(year));

private HolidaySpecification[] LabourDay(int year)
{
    // complex logic here
}
```

## Sources

- Always provide at least one reliable source
- Prefer official government websites
- Wikipedia is allowed

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
	
	/// <inheritdoc/>
	public override IEnumerable<string> GetSources()
	{
		return
		[
			"https://source-of-the-information"
		];
	}
}
```
