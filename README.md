# Animal Shelter API

The Animal Shelter API is designed to showcase an example of Onion Architecture, allowing for a decoupled API using interfaces that communicate between the layers of the API (Service Layer, Presentation Layer, and Domain-Repository Layer). This API can work with EFCore as well as other frameworks. In the original version of this API, the EFCore construction and SQL database were developed. However, this was removed due to the importance of decoupling and encapsulating the API. This can easily be recreated.

## Solution Breakdown

.NET6.0

### Controllers
Two main entities are showcased from the presentation layer: the "Kennels" and the "Animals".  
A controller has been developed for each entity.

### Calls
Four main calls were developed for the purposes of this development:

1. **Place animals in the best location**: The best location was deemed the largest kennel available for the animal. This business logic is decoupled through a service within the API and can be changed as needed by the business client.

2. **Remove a specific animal by name**: A service to adopt a specific animal is available.  A service to adopt a specific animal is available. This is a no kill shelter.

3. **Return all kennels**

4. **Reorganize animals**

### Projects
Five projects were developed to allow for decoupling of business logic, data models, and preventing circular dependencies.
1. **AnimalShelter.Data** (Domain Layer)
2. **AnimalShelter.Interfaces** (To utilize dependency injection between layers)
3. **AnimalShelter.Services** (Service Layer)
4. **AnimalShelter.Models** (To model the data)
5. **AnimalShelterAPI** (Presentation Layer)

In addition, a project for testing was also created. This is a work in progress and is not yet complete.
1. **AnimalShelterAPI.Services.Tests** / You will note that the tests cover the services layer. This is because all business logic is contained within this layer.
This allows for better maintainability of code and gives opportunity for deploying new **Versions of Services** in the event that business logic changes. This API also showcases the ability to be decoupled in a manner that allows for future **Feature Flagging** in the event that data models concerning the presentation layer need to be updated.


