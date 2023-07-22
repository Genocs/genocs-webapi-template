# .NET Core Microservice template 


Template for **Microservice Architecture with .NET Core**. Use cases as central organizing structure, decoupled from frameworks and technology details. Built with small components that are developed and tested in isolation.

----

[![Build status](https://ci.appveyor.com/api/projects/status/0i6s33kw3y87tkb2?svg=true)](https://ci.appveyor.com/project/genocs/clean-architecture-template)  ![NuGet](https://buildstats.info/nuget/Genocs.CleanArchitectureTemplate)  [![All Contributors](https://img.shields.io/badge/all_contributors-12-yellow.svg?style=flat-square)](#contributors)
<a href="https://www.nuget.org/packages/Genocs.CleanArchitectureTemplate/" rel="Genocs.CleanArchitectureTemplate"></a>


## Usage

```sh
dotnet new install Genocs.WebApiTemplate::{semver}
dotnet new gnx-webapi -n "CompanyName.ProjectName.ServiceName"
```

To get the Genocs WebApi Template updates hit the `WATCH` button.

Would you like to show Genocs WebApi Template on your GitHub profile? Hit the `FORK` button.

Really interested in designing modular applications? Support this project with a hit on the `STAR` button. Share with a friend!


Run the Docker container in less than 2 minutes using Play With Docker:

<a href="https://labs.play-with-docker.com/?stack=https://raw.githubusercontent.com/genocs/clean-architecture-template/master/docker-compose.yml&amp;stack_name=clean-architecture-template" rel="nofollow"><img src="https://raw.githubusercontent.com/play-with-docker/stacks/master/assets/images/button.png" alt="Try in PWD" style="max-width:100%;"></a>


## Motivation

> Learn how to design modular applications.
>
> Explore the .NET Core features.

### Learn how to design modular applications

Learning how to design modular applications will help you become a better engineer. Designing modular applications is the holy grail of software architecture, it is hard to find engineers experienced in designing applications which allows adding new features in a steady speed. 

### Explore the .NET Core features

.NET Core brings a sweet development environment, an extensible and cross-platform framework. We will explore the benefits of it in the infrastructure layer and we will reduce its relevance in the application layer. The same rule is applied for modern C# language constructions.

### Learn from the open source community

This is continually updated, open source project.

[Contributions](#contributors-) are welcome!


## Persistance layer

This example contains the implementation related to three different storage type:

- InMemoryDataAccess (usefull only for development) 
- Microsoft SQL Server (The popular Relational database developed by Microsoft) 
- MongoDB (The popular Document DB) 

## Containers and orchestrators

The example is ready to create the docker images for both WebApi and BusWorker


## Contributing

> Learn from the community.

Feel free to submit pull requests to help:

* Fix errors
* Improve sections
* Add new sections
* Submit questions and bugs

## Flow of Control

The flow of control begins in the controller, moves through the use case, and then winds up executing in the presenter.

### Register Flow of Control

1. An request in received by the `CustomersController` and an action `Post` is invoked.
2. The action creates an `RegisterInput` message and the `Register` use case is executed.
3. The `Register` use case creates a `Customer` and an `Account`. Repositories are called, the `RegisterOutput` message is built and sent to the `RegisterPresenter`.
4. The `RegisterPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.


### Get Customer Details Flow of Control

1. An request in received by the `CustomersController` and an action `GetCustomer` is invoked.
2. The action creates an `GetCustomerDetailsInput` message and the `GetCustomerDetails` use case is executed.
3. The `GetCustomerDetails` use case asks the repositories about the `Customer` and the `Account`. It could call the `NotFound` or the `Default` port of the `GetCustomerDetailsPresenter` depending if it exists or not.
4. The `GetCustomerDetailsPresenter` builds the HTTP Response message.
5. The `CustomersController` asks the presenter the current response.





## Test-Driven Development (TDD)

> You are not allowed to write any production code unless it is to make a failing unit test pass.
>
> You are not allowed to write any more of a unit test than is sufficient to fail; and compilation failures are failures.
>
> You are not allowed to write any more production code than is sufficient to pass the one failing unit test.

http://butunclebob.com/ArticleS.UncleBob.TheThreeRulesOfTdd

### Fakes

> Fake it till you make it

## SOLID

### Single Responsibility Principle

> A class should have one, and only one, reason to change.

### Open-Closed Principle

> You should be able to extend a classes behavior, without modifying it.

### Liskov Substitution Principle

> Derived classes must be substitutable for their base classes.

### Interface Segregation Principle

> Make fine grained interfaces that are client specific.

### Dependency Inversion Principle

> Depend on abstractions, not on concretions.

### Running the Tests Locally

Run the following command at the root folder:



## Docker

The project build two different images. One for the the WebAapi endpoint and one for the worker.   

```sh
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Copy everything else and build
COPY . .
RUN dotnet publish src/{MyCompany.MyProject}.WebApi -c release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS http://*:80
ENV ASPNETCORE_ENVIRONMENT Docker
ENTRYPOINT dotnet {MyCompany.MyProject}.WebApi.dll
```

To build the docker images

```sh
docker build -t mycompany/myproject.webapi -f .\src\Genocs.MicroserviceLight.Template.WebApi\Dockerfile .
docker build -t mycompany/myproject.worker -f .\src\Genocs.MicroserviceLight.Template.BusWorker\Dockerfile .
```




## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:END -->

This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!


