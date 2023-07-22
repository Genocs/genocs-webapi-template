![WebApi Template](https://raw.githubusercontent.com/Genocs/genocs-webapi-template/master/icon.png) .NET Microservice Template by Genocs
=========

[![Build status](https://ci.appveyor.com/api/projects/status/0i6s33kw3y87tkb2?svg=true)](https://ci.appveyor.com/project/genocs/genocs-webapi-template)
![NuGet](https://buildstats.info/nuget/Genocs.WebApiTemplate)
[![All Contributors](https://img.shields.io/badge/all_contributors-1-yellow.svg?style=flat-square)](#contributors)
<a href="https://www.nuget.org/packages/Genocs.WebApiTemplate/" rel="Genocs.WebApiTemplate"></a>
[![Gitter](https://img.shields.io/badge/chat-on%20gitter-blue.svg)](https://gitter.im/genocs/)
[![Discord](https://img.shields.io/discord/1106846706512953385?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square)](https://discord.com/invite/fWwArnkV)
[![Twitter](https://img.shields.io/twitter/follow/genocs?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square)](https://twitter.com/genocs)

## Introduction

Genocs.WebApiTemplate is part of the Genocs.Library project.

<img src="https://genocs-blog.netlify.app/library/logo_hu5f84e5ac74e01291dbce57bab350d273_35818_2000x0_resize_box_3.png"
     alt="Genocs Library logo"
     style="float: left; margin-right: 10px; padding-bottom: 50px;" />

To get all the information you need to use it: please check
**[Genocs Library documentation](https://genocs-blog.netlify.app/)**

This is an WebApi Template that help you create LOB applications. It follows the Microservice Architecture and built on Domain-Driven-Design. This is a useful tool to increase productivity on developing your next microservices solution. 

## How to create a project

Create, build, test and run:

``` sh
dotnet new install Genocs.WebApiTemplate::{{semver}}
dotnet new gnx-webapi -n {{CompanyName.ProjectName.ServiceName}}
cd {{CompanyName.ProjectName.ServiceName}}
dotnet build src/{{CompanyName.ProjectName.ServiceName}}.WebApi

dotnet test
cd src/{{CompanyName.ProjectName.ServiceName}}.WebApi
dotnet run src/{{CompanyName.ProjectName.ServiceName}}.WebApi
```


## How to build the package

To build the package run the following commands:

[Official Link](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)


``` PowerShell
cd .\src
.\nuget.exe pack -OutputDirectory nupkgs -NoDefaultExcludes -Version {{semver}}
dotnet new install .\nupkgs\Genocs.WebApiTemplate.{{semver}}.nupkg
dotnet new gnx-webapi --help
dotnet new gnx-webapi --name {{CompanyName.ProjectName.ServiceName}}

# To get a list of the installed templetes
dotnet new list

# To get a list of templates that can be removed
dotnet new -u

# To uninstall the template
dotnet new uninstall Genocs.WebApiTemplate
```


## Sample application

Run `dotnet new install Genocs.WebApiTemplate` then try the following commands.

``` sh
dotnet new gnx-webapi
```


## Miscellaneous

How to get the list of installed templates

``` sh
dotnet new -u
dotnet --list
```