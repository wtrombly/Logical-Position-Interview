# Animal Shelter API

The Animal Shelter API is designed to showcase an example of Onion Architecture, allowing for a decoupled API using interfaces that communicate between the layers of the API (Service Layer, Presentation Layer, and Domain-Repository Layer). This API can work with EFCore as well as other frameworks. In the original version of this API, the EFCore construction and SQL database were developed. However, this was removed due to the importance of decoupling and encapsulating the API. This can easily be recreated.

## Items of note

Two main entities are showcased from the presentation layer: the "Kennels" and the "Animals".  
A controller has been developed for each entity.

Four main calls were developed for the purposes of this development:

1. **Place animals in the best location**: The best location was deemed the largest kennel available for the animal. This business logic is decoupled through a service within the API and can be changed as needed by the business client.

2. **Remove a specific animal by name**: A service to adopt a specific animal is available.  A service to adopt a specific animal is available. This is a no kill shelter.

3. **Return all kennels**

4. **Reorganize animals**


Five projects were developed to allow for decoupling of business logic, data models, and preventing circular dependencies.
1. ** AnimalShelter.Data (Domain Layer)**
2. ** AnimalShelter.Interfaces (To utilize dependency injection between layers) **
3. ** AnimalShelter.Services (Service Layer)**
4. ** AnimalShelter.Models (To model the data) **
