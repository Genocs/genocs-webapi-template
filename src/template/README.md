# Genocs.Library.Template service

[![Build status](https://ci.appveyor.com/api/projects/status/0i6s33kw3y87tkb2?svg=true)](https://ci.appveyor.com/project/genocs/genocs-webapi-template)  ![NuGet](https://buildstats.info/nuget/Genocs.Library.Template) 


## Introduction

This service was built with [genocs-webapi-template](https://github.com/Genocs/genocs-webapi-template) and is a part of [Genocs Library](https://genocs-blog.netlify.app/).

To get all the information you need to use it: please check
**[Genocs Library documentation](https://genocs-blog.netlify.app/)**


<img src="https://genocs-blog.netlify.app/library/logo_hu5f84e5ac74e01291dbce57bab350d273_35818_2000x0_resize_box_3.png"
     alt="Genocs Library logo"
     style="float: left; margin-right: 10px; padding-bottom: 50px;" />

---


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

## <span style="color:red; font-size:xxl">**Work in Progress**</span>



>Before start you have to update some values in the project.

This is because MongoDB does support database name with the character `.` (period), so you have to change it with another character like `_` (hyphen or undescore character). 

**FROM**
``` json
  "mongoDb": {
    "connectionString": "mongodb://localhost:27017",
    "database": "genocs.library.template-service",
    "seed": false
  },
```

**TO**

``` json
  "mongoDb": {
    "connectionString": "mongodb://localhost:27017",
    "database": "name_of_service-service",
    "seed": false
  },
```

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

The project will build two different images. One for the the WebApi endpoint and one for the Background Worker.   


To build the docker images:

``` sh
# Manual build
docker build -t genocs/genocs.library.template.webapi -f ./src/WebApi/Dockerfile .
docker build -t genocs/genocs.library.template.worker -f ./src/Worker/Dockerfile .

# Build using docker compose
# Remember to update the .env file with the correct values
docker compose -f ./docker-compose.yml build
```


## Kubernetes

The project contains the Kubernetes manifest to deploy the application in a Kubernetes cluster.
Remember to update the values in the manifest files before deploying the application.
Following the list of the variables to update:

| Variable | Description 
| -------- | -------- | 
| **{{name}}**  | The name of the Kubernetes component  | 
| **{{acr_name}}** | The name of the Azure container registry | 
| **{{application_namespace}}** | The application namespace|
