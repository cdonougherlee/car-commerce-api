# CarCommerceAPI

## Description

The purpose of this project is to display my understanding of ASP.NET Core and object-oriented programming and expand on what I learnt from CS335, CS235, and CS230. The web api can be used to for CRUD functionality of different categories of cars in a database, similar to what might be seen on a carsales or trademe site.

## Obeject-oriented programming

All four principles of OOP are used in the project.

#### Encapsulation

Car classes have private properties, constructors, and feature setter methods for updating data (oppose to accessing the fields directly).

```shell
public int Price { get; private set; }

public void updatePrice(int price) { Price = price; }
```

#### Abstraction

Repository classes all have interfaces

```shell
...
public class CarRepository: ICarRepository
...
```

#### Inhertance

Van, Ute and Electric classes are all derived from the Car base class.

```shell
...
public class Van: Car
...
```

#### Polymorphism

Dynamic polymorhism is used for the DisplayDetails method found in each derived class e.g., Van.

```shell
 public new string displayDetails()
  {
      return base.displayDetails() + $" and has {this.CargoVolume}m3 of cargo volume capacity.";
  }
```

## Web API

Using ASP.NET 6 and the Entity framework, the api uses the repository pattern and dependency injection. It is RESTful and has features CRUD functionality.

#### Repository Pattern

Each car has it's own repository context that the controllers interact with. This pretty much acts as another abstraction for the Entity Framework core to implement, as to keep persistance responsibilities away from the domain model.

#### Dependency Injection

Program class uses AddScoped services for Repository interfaces, and is very loosely coupled to controllers

```shell
...
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IUteRepository, UteRepository>();
builder.Services.AddScoped<IVanRepository, VanRepository>();
builder.Services.AddScoped<IElectricRepository, ElectricRepository>();
....
```

## Endpoint documentation

_General_

All categories of cars have the following endpoints. e.g., vans.

### vans/all GET

Returns a list of all vans

Successful response: 200

### vans/{id} GET

Returns the van of the parameter id

Successful response: 200

id not found response: 404

### vans/{id} DELETE

Deletes the van of the parameter id from the database

Successful response: 204

id not found response: 404

### vans POST

Adds a new van to the database

Request body schema:

```shell
{
  "brand": string,
  "model": string,
  "colour": string,
  "engine": string,
  "numSeats": int,
  "price": int,
  "auction": bool,
  "cargoVolume": int
}
```

Successful response: 204

Bad request response: 400

Note that in place of cargoVolume:

-Electrics has chargeType

-Utes has towingCapactity

### vans/{id}/updateprice PUT

Update the price of van associated with parameter id

Successful response: 204

_Additionally_

There are two endpoints that query all the cars in the database, no matter the category. These readonly responses only retrieve the properties of Car superclass (i.e., does not include cargoVolume, chargeType or towingCapacity). The purpose being a search response with no filters on, before the user has clicked on a particular car or category.

### cars/all GET

Returns a list of all cars

Successful response: 200

### cars/{id} GET

Returns the car of the parameter id

Successful response: 200

id not found response: 404

## UML diagram

![UML diagram](https://github.com/cdonougherlee/car-commerce-api/blob/main/UMLdiagram.jpeg?raw=true)
