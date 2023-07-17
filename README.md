![WebApi Template](https://raw.githubusercontent.com/Genocs/genocs-webapi-template/master/icon.png) .NET Microservice WebApi Template by Genocs
=========

[![Build Status](https://app.travis-ci.com/Genocs/genocs-webapi-template.svg?branch=master)](https://app.travis-ci.com/Genocs/genocs-webapi-template) <a href="https://www.nuget.org/packages/Genocs.WebApiTemplate/" rel="Genocs.WebApiTemplate"> ![NuGet](https://buildstats.info/nuget/genocs-webapi-template)</a> [![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/genocs/)

----

This is an WebApi Template that help you create LOB applications. It follows the Microservice Architecture and built on Domain-Driven-Design. This is a useful tool to increase productivity on developing your next microservices solution. 

## How to create a project

Create, build, test and run:

``` sh
dotnet new install Genocs.WebApiTemplate::{version]
dotnet new gnx-webapi -n {CompanyName.ProjectName.ServiceName}
cd {CompanyName.ProjectName.ServiceName}
dotnet build src/{CompanyName.ProjectName.ServiceName}.WebApi

dotnet test
cd src/{CompanyName.ProjectName.ServiceName}.WebApi
dotnet run src/{CompanyName.ProjectName.ServiceName}.WebApi
```


## How to build the package

To build the package run the following commands:

[Official Link](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)


``` PS
cd .\src
.\nuget.exe pack -OutputDirectory nupkgs -NoDefaultExcludes -Version 1.0.{version}
dotnet new -u Genocs.WebApiTemplate
dotnet new install Genocs.WebApiTemplate.1.0.{version}.nupkg
dotnet new gnx-webapi --help
dotnet new gnx-webapi --name {CompanyName.ProjectName.ServiceName}
```


## Sample application

Run `dotnet new -i Genocs.WebApiTemplate` then try the following commands.

``` sh
# Complete suite of use cases.
dotnet new gnx-webapi --use-cases full

# Register account and get customer details.
dotnet new gnx-webapi --use-cases basic

# Read only use cases
dotnet new gnx-webapi --use-cases readonly
```


## Miscellaneous

How to get the list of installed templates

``` sh
dotnet new -u
dotnet --list
```



