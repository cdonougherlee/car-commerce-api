# CarCommerceAPI

## Description
 
The purpose of this project is to display my understanding of ASP.NET Core and object-oriented programming by expanding on what I learnt from CS335, CS235, and CS230. The web api is to be used in a simple page that gives the user CRUD functionality of different categories of cars, similar to what might be seen on a carsales or trademe site.

## Instructions 

## OOP

All four principles of OOP are used in the project.

#### Encapsulation

Car classes have private properties, constructors, and feature setter methods for updating data (oppose to accessing the fields directly).

#### Abstraction

Repository classes all have interfaces 

#### Inhertance

Van, Ute and Electric classes are all derived from the Car base class.

#### Polymorphism

Static polymorphism can be seen in the UpdatePrice methods in the Car class.

Dynamic polymorhism was used for the DisplayDetails method found in each derived class.

## Web API

Using ASP.NET 6 and the Entity framework, the api uses the repository pattern and dependency injection. It is RESTful and has features CRUD functionality.

#### Repository Pattern

Each car has it's own repository context that the controllers interact with. This pretty much acts as another abstraction for the Entity Framework core to implement, as to keep persistance responsibilities away from the domain model.

#### Dependency Injection

-AddScoped service after using interfaces for Repository. So dont have to make lots of modifications in controller

## Endpoint documentation

## UML diagram


