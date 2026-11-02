# REST API Examples (v4)

Examples for the public [Nager.Date REST API](https://nagerholidays.com/api) version 4.
The complete list of endpoints is available in the [API documentation](https://nagerholidays.com/scalar/#community-api-v4).
You can also generate a client for your programming language with the [OpenAPI Generator](https://openapi-generator.tech).

> [!NOTE]
> API v3 reaches its end of life on **2027-01-31**. Please migrate to v4.
> In v4 the country code comes **before** the year: `/api/v4/Holidays/{countryCode}/{year}`

> [!TIP]
> The [Docker container](https://hub.docker.com/r/nager/nager-date) provides the same REST API on your own infrastructure.
> All examples work unchanged, just replace `https://nagerholidays.com` with the address of your container, e.g. `http://localhost`.

## Endpoint

```
GET https://nagerholidays.com/api/v4/Holidays/{countryCode}/{year}
```

| Parameter     | Description                                   | Example |
| ------------- | --------------------------------------------- | ------- |
| `countryCode` | ISO 3166-1 alpha-2 country code               | `US`    |
| `year`        | Year                                          | `2026`  |

### Response

```json
[
  {
    "date": "2026-01-01",
    "name": "New Year's Day",
    "countryCode": "US",
    "nationalHoliday": true,
    "subdivisionCodes": null,
    "holidayTypes": [ "Public" ]
  }
]
```

| Field              | Description                                                                               |
| ------------------ | ----------------------------------------------------------------------------------------- |
| `date`             | The date of the holiday                                                                   |
| `name`             | English name of the holiday                                                               |
| `countryCode`      | ISO 3166-1 alpha-2 country code                                                           |
| `nationalHoliday`  | `true` if the holiday applies to the entire country                                       |
| `subdivisionCodes` | ISO 3166-2 codes of the subdivisions where the holiday applies (only if not national)     |
| `holidayTypes`     | `Public`, `Bank`, `School`, `Authorities`, `Optional`, `Observance` ([details](../../README.md#holiday-types)) |

## curl

```bash
curl https://nagerholidays.com/api/v4/Holidays/US/2026
```

## .NET / C#

### Option 1: NuGet package Nager.Holiday (recommended)

The official client [Nager.Holiday](https://www.nuget.org/packages/Nager.Holiday)

```bash
dotnet add package Nager.Holiday
```

```cs
using Nager.Holiday;

using var holidayClient = new HolidayClient();
var holidays = await holidayClient.GetHolidaysAsync(2026, "US");

foreach (var holiday in holidays ?? [])
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd} {holiday.Name}");
}
```

### Option 2: HttpClient

No additional package required (.NET 8 or newer)

```cs
using System.Net.Http.Json;

using var httpClient = new HttpClient();
var holidays = await httpClient.GetFromJsonAsync<PublicHoliday[]>(
    "https://nagerholidays.com/api/v4/Holidays/US/2026");

foreach (var holiday in holidays ?? [])
{
    Console.WriteLine($"{holiday.Date:yyyy-MM-dd} {holiday.Name}");
}

record PublicHoliday(
    DateOnly Date,
    string Name,
    string CountryCode,
    bool NationalHoliday,
    string[]? SubdivisionCodes,
    string[] HolidayTypes);
```

## Python

Uses the [requests](https://pypi.org/project/requests/) package (`pip install requests`)

```py
import requests

response = requests.get("https://nagerholidays.com/api/v4/Holidays/US/2026", timeout=10)
response.raise_for_status()

for holiday in response.json():
    print(holiday["date"], holiday["name"], holiday["holidayTypes"])
```

## JavaScript / TypeScript

Works in the browser and in Node.js 18 or newer (built-in `fetch`)

```js
const response = await fetch("https://nagerholidays.com/api/v4/Holidays/US/2026");
if (!response.ok) {
  throw new Error(`Request failed: ${response.status}`);
}

const holidays = await response.json();
for (const holiday of holidays) {
  console.log(holiday.date, holiday.name, holiday.holidayTypes);
}
```

## PHP

Uses [Guzzle](https://github.com/guzzle/guzzle) (`composer require guzzlehttp/guzzle`)

```php
<?php
require_once 'vendor/autoload.php';

$client = new \GuzzleHttp\Client();
$response = $client->request('GET', 'https://nagerholidays.com/api/v4/Holidays/US/2026');

$holidays = json_decode($response->getBody(), true);
foreach ($holidays as $holiday) {
    echo $holiday['date'] . ' ' . $holiday['name'] . PHP_EOL;
}
```

## Java

Java 21 or newer, uses the built-in `java.net.http.HttpClient` and [Gson](https://github.com/google/gson)

`Main.java`
```java
import com.google.gson.Gson;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;

public class Main {

    record PublicHoliday(
        String date,
        String name,
        String countryCode,
        boolean nationalHoliday,
        String[] subdivisionCodes,
        String[] holidayTypes) {}

    public static void main(String[] args) throws Exception {
        var request = HttpRequest.newBuilder()
            .uri(URI.create("https://nagerholidays.com/api/v4/Holidays/CH/2026"))
            .GET()
            .build();

        try (var httpClient = HttpClient.newHttpClient()) {
            var response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());
            if (response.statusCode() != 200) {
                throw new IllegalStateException("Request failed: " + response.statusCode());
            }

            var holidays = new Gson().fromJson(response.body(), PublicHoliday[].class);
            for (var holiday : holidays) {
                var subdivisions = holiday.subdivisionCodes() == null
                    ? ""
                    : String.join(",", holiday.subdivisionCodes());
                System.out.println(holiday.date() + " " + holiday.name() + " " + subdivisions);
            }
        }
    }
}
```

`build.gradle`
```groovy
plugins {
    id 'application'
}

repositories {
    mavenCentral()
}

dependencies {
    implementation 'com.google.code.gson:gson:2.13.1'
}

java {
    toolchain {
        languageVersion = JavaLanguageVersion.of(21)
    }
}

application {
    mainClass = 'Main'
}
```
