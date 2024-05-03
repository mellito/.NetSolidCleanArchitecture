# VSCODE COMMAND LINE

this is the command line for create all .net code need

```
# Create  blank solution
dotnet new sln --name MYSolution
# Create class library
dotnet new classlib -o classLibName
# Add reference project
dotnet add app/app.csproj reference lib/lib.csproj
# create new web api
dotnet new webapi -o nameapi
# craete migration entityfrawork
dotnet ef migrations add NewMigration --project WebApplication1.Migrations
# update database entityframework
dotnet ef database update
```

# USE ONION ARCHITECTURE FOLDER STEPS

- create a blank solution
- create the respective folder for each layer.
  - core (entities,application interface, core)
  - api (rest api)
  - infrastructure (third application lie email logging)
  - test (unit integration)
- create class library domain or model this is to create a please that is only propose is hold the models in our project
- create class library Application here is where we going to manage contracts(interfaces)
- add mediator and automapper nugets in application
- set a application services that is a static class to set mediatr and automapper
- create a folder for mapping profile this is the place where we are going to create our mapping using automapper
- create a folder Feature this one is more relative to behavior and not types inside we can create folder for each model and then create folder for commands(update,create,delete) purpose and queries (read) purpose this is for que cqrs pattern inside of queries create a new folder to specify the purpose of and inside we can create all file referent to this purpose
- implement mediatr for this need to use IRequest and IRequestHandler to segregate and make that each one of the classes do one thing
- create validator for validate incoming data and don't have dirty information
- create class library persistence to add project for the interfaces
- add entityframework nuget and microsoft.extension.options.configurationextensions
- create the persistenceServiceRegistration to set all the services of the library
- create folder databasecontext and create dbcontextclass to set the table connection also set the other config need it
- create infrastructure project is where is going be third party services like Sendgrid for email or logging for logs
- create new api project and add entity framework nugets

# Notes

## SOLID PRINCIPLES

Is acronym

- S SINGLE-responsibility Principle (a peace of code should only have one responsibility a method only should do one think)
  a class only should to one think
- O OPEN-closed Principle object or entities or classes should open for extension but close to modification (abstraction, base classes)
- L Liskov Substitution Principle every class or derive class should be substitutable for the base or parent class (a class should be similar enough to do not present eny problem)
- I Interface Segregation Principle a client should never force to apply method or functionality that do not need
- D - Dependency Inversion Principle entities should depend of abstraction and not implementation

## SEPARATION OF CONCERNS AND SINGLE RESPONSIBILITY

we don't want a place for everything

- S in solid
- foundation of object oriented programming
- concept of splitting functionality into block
  - Each addressing a specific concern
  - One block of code shouldn't be trying to do many different things
- promotes modularity
- each module encapsulates all logic for the specific feature set.

## DRY - DON'T REPEAT YOURSELF

- Lest code repetition
- one implementation point for code in your application
- easier to maintain and make changes
- the single responsibility principle relies on DRY
- the open/closed principle (O in SOLID) only works when DRY is followed
- write code that doesn't have to be changed every time the requirements code

## DEPENDENCY INVERSION

- The D in solid
- promotes loose-Coupling in application
- Dependencies should point to abstractions
  - Allows for easier maintenance and modifications to function logic
  - Allows for easier code sharing between dependent classes

## UNDERSTANDING CLEAN ARCHITECTURE

### All-in-one Architecture

- Pros

  - easier to deliver
  - can be stable and a long term solution

- Cons

  - Hard to enforce Solid principles
  - Harder to maintain as project grows
  - Harder to test

### Layered Architecture

- Pros

  - Better enforcing of SOLID principles
  - Easier to maintain larger code base

- Cons

  - Layers are dependent
  - Still act as one application
  - Logic is sometimes scattered across layers

### Onion Architecture

- Pros

  - It provides better testability as unit test can be created for separated layers
  - Easier to maintain changes in code base without directly affecting other modules
  - Promotes loose coupling

- Cons

  - Learning curve
  - time consuming

#### TAKE IN COUNT

- be careful!! not every application needs clean architecture

- do you really need it?
  - good software meets the business needs
  - maintainable software increase the lifespan of the software
- what is the scale of the application?
  - not every project needs clean architecture from day one
  - start small and extend as needed

## NOTES FOR C# CODE

- abstract class can be stand by him self is always use in inherit
- IGenericRepository<T> where T : class this is a generic type and the where help me to let know to the code that only class can be pass as generic

### AUTOMAPPER

allow us to map easily data

- Converts complex data type with ease
- Can be used in several parts of the application
- saves time spent on writing manual mapping code
- might lead to performance and debugging issues

### MEDIATOR

allows to implement CQRS patter by using IRequest and IRequestHandler method to separate query and commands

### CQRS(COMMAND QUERY RESPONSIBILITY SEGREGATION) PATTERN

this is a pattern that help us to separate the request in command(change data) and query(get information)

### FLUENTVALIDATION

Help us to save the integrity data

### LOGGING

- Logs are block of text that most applications produce during runtime
- Human readable mini reports about what is happening in the application
- Allow us to be able to track and trace errors that occur in our applications
- type of logs
  - information: standard log level used when something has happened as expected
  - Debug: a very informational log level that is more than we might need for everyday use
  - Warning: this log level indicates that something has happened that isn't an error but isn't normal
  - Error: an error is an error this type of log entry is usually created when an exception is encountered
