![WebApi Template](https://raw.githubusercontent.com/Genocs/webapi-template/master/icon.png) .NET Microservice WebApi Template by Genocs
=========

[![Build Status](https://app.travis-ci.com/Genocs/webapi-template.svg?branch=master)](https://app.travis-ci.com/Genocs/webapi-template) <a href="https://www.nuget.org/packages/Genocs.WebApiTemplate/" rel="Genocs.CleanCode">![NuGet](https://buildstats.info/nuget/genocs.webapi-template)</a> [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/genocs/)

----

This is an WebApi Template built to help you create LOB applications. It follows the MicroservicePrinciples and built on Domain-Driven-Design. This tool is useful to increases productivity on developing your next microservices.

## How to create a project

Create, build, test and run:

``` sh
dotnet new -i Genocs.WebApiTemplate::{version]
dotnet new webapi -n {CompanyName.ProjectName.ServiceName}
cd {CompanyName.ProjectName.ServiceName}
dotnet build src/{CompanyName.ProjectName.ServiceName}.WebApi

dotnet test
cd src/{CompanyName.ProjectName.ServiceName}.WebApi
dotnet run src/{CompanyName.ProjectName.ServiceName}.WebApi
```


## How to build the package

To build the package run the following commands:

[Official Link](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)


```sh
cd ./src
nuget pack -output nupkgs
dotnet new -u Genocs.WebApiTemplate
dotnet new -i Genocs.WebApiTemplate.1.0.{version}.nupkg
dotnet new webapi --help
dotnet new webapi --name {CompanyName.ProjectName.ServiceName}
```


## Sample application

Run `dotnet new -i Genocs.WebApiTemplate` then try the following commands.

``` sh
# Complete suite of use cases.
dotnet new webapi --use-cases full

# Register account and get customer details.
dotnet new webapi --use-cases basic

# Read only use cases
dotnet new webapi --use-cases readonly
```


## Miscellaneous

How to get the list of installed templates

``` sh
dotnet new -u
dotnet --list
```



