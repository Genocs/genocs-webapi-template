<!-- PROJECT SHIELDS -->
[![License][license-shield]][license-url]
[![Build][build-shield]][build-url]
[![Packages][package-shield]][package-url]
[![Downloads][downloads-shield]][downloads-url]
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![Discord][discord-shield]][discord-url]
[![Gitter][gitter-shield]][gitter-url]
[![Twitter][twitter-shield]][twitter-url]
[![Twitterx][twitterx-shield]][twitterx-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

[license-shield]: https://img.shields.io/github/license/Genocs/genocs-library-template?color=2da44e&style=flat-square
[license-url]: https://github.com/Genocs/genocs-library-template/blob/main/LICENSE
[build-shield]: https://github.com/Genocs/genocs-library-template/actions/workflows/build_and_test.yml/badge.svg?branch=main
[build-url]: https://github.com/Genocs/genocs-library-template/actions/workflows/build_and_test.yml
[package-shield]: https://img.shields.io/badge/nuget-v.1.1.1-blue?&label=latests&logo=nuget
[package-url]: https://github.com/Genocs/genocs-library-template/actions/workflows/build_and_test.yml
[downloads-shield]: https://img.shields.io/nuget/dt/Genocs.Library.Template.svg?color=2da44e&label=downloads&logo=nuget
[downloads-url]: https://www.nuget.org/packages/Genocs.Library.Template
[contributors-shield]: https://img.shields.io/github/contributors/Genocs/genocs-library-template.svg?style=flat-square
[contributors-url]: https://github.com/Genocs/genocs-library-template/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/Genocs/genocs-library-template?style=flat-square
[forks-url]: https://github.com/Genocs/genocs-library-template/network/members
[stars-shield]: https://img.shields.io/github/stars/Genocs/genocs-library-template.svg?style=flat-square
[stars-url]: https://img.shields.io/github/stars/Genocs/genocs-library-template?style=flat-square
[issues-shield]: https://img.shields.io/github/issues/Genocs/genocs-library-template?style=flat-square
[issues-url]: https://github.com/Genocs/genocs-library-template/issues
[discord-shield]: https://img.shields.io/discord/1106846706512953385?color=%237289da&label=Discord&logo=discord&logoColor=%237289da&style=flat-square
[discord-url]: https://discord.com/invite/fWwArnkV
[gitter-shield]: https://img.shields.io/badge/chat-on%20gitter-blue.svg
[gitter-url]: https://gitter.im/genocs/
[twitter-shield]: https://img.shields.io/twitter/follow/genocs?color=1DA1F2&label=Twitter&logo=Twitter&style=flat-square
[twitter-url]: https://twitter.com/genocs
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/
[twitterx-shield]: https://img.shields.io/twitter/url/https/twitter.com/genocs.svg?style=social
[twitterx-url]: https://twitter.com/genocs


<p align="center">
    <img src="./assets/genocs-library-logo.png" alt="icon">
</p>

# Genocs Library Template 
Built for .NET8. Incorporates the most essential Packages your projects will ever need. Follows Clean Architecture Principles.

## Goals

The goal of this repository is to help developers/companies kickstart their Web Application Development with a pre-built Web Api Template based on Genocs Library nuget Packages. It includes several much needed components and features.

> Note that this is a backend application only! The frontend for this application is available in a seperate repository. 
> - Find Genocs's .NET Web API template here - [genocs-library-template](https://github.com/Genocs/genocs-library-template)

## Prerequisites
- [.NET 8.x](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/vs2022/)(optional)
- [Visual Studio Code](https://code.visualstudio.com/download)(optional)
- [Rider](https://www.jetbrains.com/rider/)(optional)


## Getting Started

Open up your *Command Prompt* or *PowerShell* or "bash" and run the following command.

``` bash
# To clone the repository
git clone https://github.com/Genocs/genocs-library-template

# To build the nuget package
nuget pack ./src/Package.Template.nuspec -NoDefaultExcludes -OutputDirectory ./out -Version 1.1.0

# To install the template
dotnet new install ./out/Genocs.Library.Template.1.1.0.nupkg

# To 
dotnet new gnx-librawebapi --help
dotnet new gnx-librawebapi --name {MyCompany.MyProject}


```


``` bash
# To install the template from nuget
dotnet new install Genocs.Library.Template

# To install a specific version of the template
dotnet new install Genocs.Library.Template::1.1.0
```


This would install the `Genocs Library Web Api Template` globally on your machine. Do note that, at the time of writing this documentation, the latest available version is **1.1.0** which is also one of the first stable release version of the package. It is highly likely that there is already a newer version available when you are reading this.

> *To get the latest version of the package, visit [nuget.org](https://www.nuget.org/packages/Genocs.Library.Template/)*
>

For more details on getting started, [read the documentation](https://genocs-blog.netlify.app/library/)

Please check the [documentation](https://learn.microsoft.com/en-us/visualstudio/ide/how-to-locate-and-organize-project-and-item-templates?view=vs-2022) for more details. 


## How to create a project

Create, build, test and run:

``` bash
dotnet new i Genocs.Library.Template
dotnet new gnx-librawebapi -n {CompanyName.ProjectName.ServiceName}
cd {CompanyName.ProjectName.ServiceName}
dotnet build ./src/{CompanyName.ProjectName.ServiceName}.WebApi
dotnet build ./src/{CompanyName.ProjectName.ServiceName}.Worker

dotnet test
dotnet run ./src/{CompanyName.ProjectName.ServiceName}.WebApi
```


## How to build the package

To build the package run the following commands:

[Official Link](https://docs.microsoft.com/en-us/dotnet/core/tools/custom-templates)


``` bash
cd ./src
nuget pack
dotnet new u Genocs.Library.Template
dotnet new install ./out/Genocs.Library.Template.1.1.0.nupkg
dotnet new gnx-librawebapi --help
dotnet new gnx-librawebapi --name {MyCompany.MyProject}
```


## Sample application

Run `dotnet new -i Genocs.Library.Template` then try the following commands.


``` bash
dotnet new gnx-librawebapi
```


## Miscellaneous

Useful commands:

``` bash
# How to get the list of installed templates
dotnet new -u

dotnet --list
```
## License

This project is licensed with the [MIT license](LICENSE).

## Changelogs

View Complete [Changelogs](https://github.com/Genocs/genocs-library-template/blob/main/CHANGELOG.md).

## Community

- Discord [@genocs](https://discord.com/invite/fWwArnkV)
- Facebook Page [@genocs](https://facebook.com/Genocs)
- Youtube Channel [@genocs](https://youtube.com/c/genocs)


## Support

Has this Project helped you learn something New? or Helped you at work?

Here are a few ways by which you can support.

- ⭐ Leave a star!
- 🥇 Recommend this project to your colleagues.
- 🦸 Do consider endorsing me on LinkedIn for ASP.NET Core - [Connect via LinkedIn](https://www.linkedin.com/in/giovanni-emanuele-nocco-b31a5169/)
- ☕ If you want to support this project in the long run, consider [buying me a coffee](https://www.buymeacoffee.com/genocs)!


[![buy-me-a-coffee](./assets/buy-me-a-coffee.png "buy me a coffee")](https://www.buymeacoffee.com/genocs)

## Code Contributors

This project exists thanks to all the people who contribute. [Submit your PR and join the team!](CONTRIBUTING.md)

[![genocs contributors](https://contrib.rocks/image?repo=Genocs/genocs-library-template "genocs contributors")](https://github.com/Genocs/genocs-library-template/graphs/contributors)

## Financial Contributors

Become a financial contributor and help me sustain the project.

**Support the Project** on [Opencollective](https://opencollective.com/genocs)

<a href="https://opencollective.com/genocs"><img src="https://opencollective.com/genocs/individuals.svg?width=890"></a>


## Acknowledgements
