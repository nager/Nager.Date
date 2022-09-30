![Build status](https://github.com/nager/Nager.Date/actions/workflows/dotnet.yml/badge.svg)

# :calendar: Nager.Date - [Official Website](https://date.nager.at)

**Nager.Date** is a popular project to query holidays. We currently **support over 100 countries**.<br>
The project is based on .NET and provides a [public REST Api](https://date.nager.at/Api) for accessing the data.<br>
A docker container or a NuGet package is also available, but for this you need a license key.
You can find an overview of the supported countries [here](https://date.nager.at/Country/Coverage).

## How can I use it?

Using the [Swagger definition](https://date.nager.at/swagger), they can have a client created for their programming language. You can find the information in our Api section.
More Informations about client generation you can find [here](https://openapi-generator.tech)

### Examples

<details>
  <summary>.NET/C# (click to expand)</summary>
	
```cs
using System;
using System.Net.Http;
using System.Text.Json;

var jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

using var httpClient = new HttpClient();
var response = await httpClient.GetAsync("https://date.nager.at/api/v3/publicholidays/2022/US");
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
  <summary>JAVA (click to expand)</summary>

This example use the springframework. Code tested with [onecompiler.com](https://onecompiler.com)
	
`Main.java`
```java
import java.util.*;
import org.springframework.web.client.RestTemplate;
import com.google.gson.*;

public class Main {
    public static void main(String[] args) {
      String json = new RestTemplate().getForObject("https://date.nager.at/api/v3/publicholidays/2022/US", String.class);
      JsonElement rootJsonElement = new JsonParser().parse(json);
      JsonArray publicHolidays = rootJsonElement.getAsJsonArray();
      Iterator<JsonElement> iterator = publicHolidays.iterator();
      while (iterator.hasNext()) {
        JsonElement publicHoliday = (JsonElement)iterator.next();
        System.out.println(publicHoliday);
      }
    }
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
    compile("org.springframework.boot:spring-boot-starter-web:2.6.7");
    compile("com.google.code.gson:gson:2.9");
}
```
	
</details>
	
### For our sponsors, we also offer a Docker container and a NuGet package

With a sponsorship you get the license key to use the variants locally without a dependency to our REST Api.

#### nuget
The nuget package is available via [NuGet](https://www.nuget.org/packages/Nager.Date)<br>

```
PM> install-package Nager.Date
```

<details>
  <summary>Code Examples (click to expand)</summary>
  
## Examples for .NET (nuget package)

### Set the license key
```cs
DateSystem.LicenseKey = "LicenseKey1234";
```

### Get all publicHolidays of a country and year
```cs
var publicHolidays = DateSystem.GetPublicHolidays(2021, "DE");
foreach (var publicHoliday in publicHolidays)
{
    //publicHoliday...
    //publicHoliday.Date -> The date
    //publicHoliday.LocalName -> The local name
    //publicHoliday.Name -> The english name
    //publicHoliday.Fixed -> Is this public holiday every year on the same date
    //publicHoliday.Global -> Is this public holiday in every county (federal state)
    //publicHoliday.Counties -> Is the public holiday only valid for a special county ISO-3166-2 - Federal states
    //publicHoliday.Type -> Public, Bank, School, Authorities, Optional, Observance
}
```

### Get all publicHolidays for a date range
```cs
var startDate = new DateTime(2016, 5, 1);
var endDate = new DateTime(2021, 5, 31);
var publicHolidays = DateSystem.GetPublicHolidays(startDate, endDate, CountryCode.DE);
foreach (var publicHoliday in publicHolidays)
{
	//publicHoliday...
}
```

### Check if a date is a public holiday
```cs
var date = new DateTime(2021, 1, 1);
if (DateSystem.IsPublicHoliday(date, CountryCode.DE))
{
    Console.WriteLine("Is public holiday");
}
```

### Check if a date is a weekend day
```cs
var date = new DateTime(2021, 1, 1);
if (DateSystem.IsWeekend(date, CountryCode.DE))
{
    Console.WriteLine("Is weekend");
}
```
</details>

#### docker
If high availability is important for you and you want to avoid access to the Internet, we can also offer you your own Docker container.

The docker container is available via [Docker Hub](https://hub.docker.com/r/nager/nager-date)<br>
To run a local instance of the docker image run the following command<br>
`docker run -p 80:80 nager/nager-date`


## Areas of Application
- telephone systems
- carrier (land transport)
- time recording

## Blog Posts

[Mark Seemann - Simple holidays](http://blog.ploeh.dk/2017/04/24/simple-holidays/)

## Alternative projects

| Language | Project | Supported Countries (January 2019) |
| ------------- | ------------- | ------------- |
| PHP | [yasumi](https://github.com/azuyalabs/yasumi) | 34 |
| JavaScript | [date-holidays](https://github.com/commenthol/date-holidays) | 142 |
| Java | [jollyday](https://github.com/svendiedrichsen/jollyday) | 64 |
| .NET | [Holiday](https://github.com/martinjw/Holiday) | 21 |
| Python | [python-holidays](https://github.com/ryanss/python-holidays) | 34 |
| Python | [workalendar](https://github.com/peopledoc/workalendar) | 59 |
