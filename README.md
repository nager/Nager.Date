[![Build, Test & Publish](https://github.com/nager/Nager.Date/actions/workflows/dotnet.yml/badge.svg)](https://github.com/nager/Nager.Date/actions/workflows/dotnet.yml)

# :calendar: Nager.Date - [Official Website](https://date.nager.at)

Discover the convenience of easily accessing holidays from **over 100 countries** with Nager.Date. Our popular project utilizes the power of .NET and offers a user-friendly public [REST API](https://date.nager.at/Api) for seamless integration into your application.

You can find an overview of the supported countries [here](https://date.nager.at/Country/Coverage).

Need offline access to our functionality? No problem! We also provide solutions that allow you to use our services on your own infrastructure without an internet connection. Easily integrate our service into your system with the [Docker](https://hub.docker.com/r/nager/nager-date) container or the [NuGet](https://www.nuget.org/packages/Nager.Date) package. Both options require a license key. As a [sponsor of nager](https://github.com/sponsors/nager), you get a license key.

> [!CAUTION]
> The WebApi V2 will be shut down in December 2024<br>
> Please only use the latest WebApi V3

## How can I use it?

Easily create a client in your preferred programming language by utilizing our [Swagger definition](https://date.nager.at/swagger). Find all the necessary information in our API section. Get more details about client generation in the [documentation](https://openapi-generator.tech).

### Examples

<details>
  <summary>.NET/C# (click to expand)</summary>
  
There are two ways to use our service

**[NuGet - Nager.Holiday](https://www.nuget.org/packages/Nager.Holiday)**
```
PM> install-package Nager.Holiday
```

**Copy Code**
```cs
using System;
using System.Net.Http;
using System.Text.Json;

var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

using var httpClient = new HttpClient();
using var response = await httpClient.GetAsync("https://date.nager.at/api/v3/publicholidays/2022/US");
if (response.IsSuccessStatusCode)
{
    using var jsonStream = await response.Content.ReadAsStreamAsync();
    var publicHolidays = JsonSerializer.Deserialize<PublicHoliday[]>(jsonStream, jsonSerializerOptions);
}

class PublicHoliday
{
    public DateTime Date { get; set; }
    public string LocalName { get; set; }
    public string Name { get; set; }
    public string CountryCode { get; set; }
    public bool Fixed { get; set; }
    public bool Global { get; set; }
    public string[] Counties { get; set; }
    public int? LaunchYear { get; set; }
    public string[] Types { get; set; }
}
```
	
</details>	

<details>
  <summary>PHP (click to expand)</summary>

This example use the [guzzle](https://github.com/guzzle/guzzle) project
	
```php
<?php
require_once 'vendor/autoload.php';
$client = new \GuzzleHttp\Client();
$response = $client->request('GET', 'https://date.nager.at/api/v3/publicholidays/2022/US');
if ($response->getStatusCode() == 200) {
    $json = $response->getBody();
    print_r(json_decode($json));
}
?>
```
	
</details>
	
<details>
  <summary>Java (click to expand)</summary>

This example use the springframework. Code tested with [onecompiler.com](https://onecompiler.com)
	
`Main.java`
```java
import java.util.*;
import org.springframework.web.client.RestTemplate;
import com.google.gson.*;

public class Main {
  public static void main(String[] args) {
    System.out.println("get holidays");
    String json = new RestTemplate().getForObject("https://date.nager.at/api/v3/publicholidays/2022/CH", String.class);
    
    Gson gson = new Gson();
    PublicHoliday[] userArray = gson.fromJson(json, PublicHoliday[].class);  

    for(PublicHoliday publicHoliday : userArray) {
      System.out.print(publicHoliday.date);
      System.out.print(" ");
      System.out.print(publicHoliday.name);
      System.out.print(" ");
      System.out.print(String.join(",", publicHoliday.counties ?? new String[0]));
      System.out.print(" ");
      System.out.println(publicHoliday.localName);
    }
  }
}
```

`PublicHoliday.java`
```java
public class PublicHoliday {
  public String date;
  public String localName;
  public String name;
  public String countryCode ;
  public Boolean fixed;
  public Boolean global;
  public String[] counties;
  public String[] types;
}
```
	
`build.gradle`
```java
apply plugin:'application'
mainClassName = 'Main'

run { standardInput = System.in }
sourceSets { main { java { srcDir './' } } }

repositories {
  jcenter()
}

dependencies {
  implementation 'org.springframework.boot:spring-boot-starter-web:2.6.7';
  implementation 'com.google.code.gson:gson:2.10.1';
}
```
	
</details>

<details>
  <summary>Python (click to expand)</summary>

`main.py`
```py
import json
import requests

response = requests.get('https://date.nager.at/api/v3/publicholidays/2022/US')
public_holidays = json.loads(response.content)

for public_holiday in public_holidays:
  print(public_holiday['date'])

```	
</details>
	
## Offline Solution

Don't let internet connectivity issues disrupt your workflow. Our offline solutions enable you to use our services on your own infrastructure without an internet connection. With a sponsorship you get the license key to use the variants locally without a dependency to our REST API.

### NuGet
The NuGet package is available via [NuGet](https://www.nuget.org/packages/Nager.Date)<br>

```
PM> install-package Nager.Date
```

<details>
  <summary>Code Examples (click to expand)</summary>
  
## Examples for .NET (NuGet package)

### Set the license key
```cs
HolidaySystem.LicenseKey = "LicenseKey1234";
```

### Get all holidays of a country and year
```cs
var holidays = HolidaySystem.GetHolidays(2024, "DE");
foreach (var holiday in holidays)
{
    //holiday...
    //holiday.Date -> The date
    //holiday.LocalName -> The local name
    //holiday.EnglishName -> The english name
    //holiday.NationalHoliday -> Is this public holiday in every county (federal state)
    //holiday.SubdivisionCodes -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //holiday.HolidayTypes -> Public, Bank, School, Authorities, Optional, Observance
}
```

### Get all holidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2024, 5, 31);
var holidays = HolidaySystem.GetHolidays(startDate, endDate, CountryCode.DE);
foreach (var holiday in holidays)
{
	//holiday...
}
```

### Check if a date is a public holiday
```cs
var date = new DateTime(2024, 1, 1);
if (HolidaySystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is a public holiday");
}
```

### Checks if the given date falls on a weekend day
```cs
var date = new DateTime(2024, 1, 1);
if (WeekendSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("The date is in the weekend");
}
```
</details>

### Docker

The Docker container is available via [Docker Hub](https://hub.docker.com/r/nager/nager-date)<br>
To run a local instance of the Docker image run the following command<br>
`docker run -p 80:8080 nager/nager-date`


## Holiday types
What variants of holidays are supported by `Nager.Date`

| Type        | Description                                 |
| ----------- | ------------------------------------------- |
| Public      | Public holiday                              |
| Bank        | Bank holiday, banks and offices are closed  |
| School      | School holiday, schools are closed          |
| Authorities | Authorities are closed                      |
| Optional    | Majority of people take a day off           |
| Observance  | Optional festivity, no paid day off         |

## Data precision

There is no generally valid designation for the next administrative level of countries.
"Nager.Date" supports the initial subdivision of a country, but we will not support a detailed level because the effort required is too high.

To keep it generally valid, we will treat this subdivision as `SubdivisionCodes`, this will replace the current designation `Counties`.

- **United States of America** use `States`
- **Germany** use `States`
- **Austria** use `States`
- **Switzerland** use `Cantons`
- **Brazil** use `States`
- **Australia** use `States` or `Territories`
- **Russia** use `Federal districts`
- **Canada** use `Province` or `Territories`

| Precision                                                                    | Supported |
| ---------------------------------------------------------------------------- | --------- |
| Public Holidays for specific Country                                         | Yes       |
| Holidays for Subdivisions based on ISO 3166-2 (first level)                  | Yes       |
| Holidays for Cities                                                          | No        |
| Holidays for Regions                                                         | No        |

## Areas of Application

There are several business fields in which it is important to know the holidays in different countries.

- **E-commerce**: If an online retailer sells its products in different countries, it should know the holidays in these countries to adjust delivery times and customer service accordingly.
- **Travel industry:** A tour operator should know the holidays of the countries to which it offers trips, to alert its customers to special events or closed attractions.
- **Staff scheduling:** Companies with branches in several countries must know the holidays in each country to be able to plan their staff needs accordingly.
- **Financial industry:** Banks and financial institutions should know the holidays in the countries in which they conduct business to ensure that transfers and transactions are performed on time and to estimate the impact of holidays on the foreign exchange market.
- **Logistics and supply chains:** Companies managing logistics or supply chains across several countries, must know the holidays in these countries to adjust planning and supply chain decisions.
- **Telephone systems:** To automatically turn on the answering machine on holidays.
- **Time recording:** To automatically fill the missing hours with the normal working hours.

## Articles about this project

- [Mark Seemann - Simple holidays](http://blog.ploeh.dk/2017/04/24/simple-holidays/)
- [YouTube use the NuGet package](https://www.youtube.com/watch?v=oS_uvbEV4Pw)
- [dotnetpro - Feiertagsrechner (German)](https://www.dotnetpro.de/core/frameworks/feiertagsrechner-2661291.html)
