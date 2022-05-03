![Build status](https://github.com/nager/Nager.Date/actions/workflows/dotnet.yml/badge.svg)

# :calendar: Nager.Date - [Official Website](https://date.nager.at)

**Nager.Date** is a popular project to query holidays. We currently **support over 100 countries**.<br>
The project is based on .NET and provides a [public REST Api](https://date.nager.at/Api) for accessing the data.<br>
You can find an overview of the supported countries [here](https://date.nager.at/Country/Coverage).

## :mega: Announcement

Starting May 1, 2022, the Docker container and the NuGet package will require a License Key provided to the sponsors of this project. The public WebApi will remain freely accessible.

## How can I use it?

Using the [Swagger definition](https://date.nager.at/swagger), they can have a client created for their programming language. You can find the information in our Api section.
More Informations about client generation you can find [here](https://openapi-generator.tech)

### For our sponsors, we also offer a Docker container and a NuGet package

#### nuget
The nuget package is available via [NuGet](https://www.nuget.org/packages/Nager.Date)<br>
Examples for the use of the library can be found [here](doc/README-NUGET-PACKAGE.md)
```
PM> install-package Nager.Date
```

#### docker
If high availability is important for you and you want to avoid access to the Internet, we can also offer you your own Docker container.

The docker container is available via [Docker Hub](https://hub.docker.com/r/nager/nager-date)<br>
To run a local instance of the docker image run the following command<br>
`docker run -p 80:80 nager/nager-date`
> `-p 80:80` publish the port 80 from the docker to your host.


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
