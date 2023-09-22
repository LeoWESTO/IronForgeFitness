# Iron Forge Fitness Gym Management System

Iron Forge Fitness is a gym management system built on ASP.NET Core (.NET 7) using Domain Driven Design (DDD) and Clean Architecture principles. The solution contains Domain, Application, Infrastructure, API, and Unit Test projects. The system uses Postgresql and MongoDB as data stores and Entity Framework Core for data access. The solution is containerized using Docker and docker-compose.

## Getting Started

To get started with Iron Forge Fitness, you will need to have Docker and docker-compose installed on your machine. Once you have these installed, you can clone the repository and run the following command to start the application:

```
docker-compose up
```

This will start the application and the necessary databases.

## Solution Structure

The solution is structured as follows:

- **IronForgeFitness.Domain**: This project contains the domain entities of system.
- **IronForgeFitness.Application**: This project contains the interfaces and implementations of services.
- **IronForgeFitness.Infrastructure**: This project contains the implementation of the domain repositories and services using Entity Framework Core and MongoDB.
- **IronForgeFitness.API**: This project contains the API controllers and configuration.
- **Application.UnitTests**: This project contains the unit tests for the application services.

## Data Stores

The solution uses Postgresql and MongoDB as data stores. Postgresql is used for storing user and transactions information, while MongoDB is used for storing gym equipment information.

## Testing

The solution includes unit tests for the application services using xUnit. The tests are located in the Application.UnitTests project.

## Docker

The solution is containerized using Docker and docker-compose. The docker-compose.yml file defines the services required to run the application, including the API, Postgresql, and MongoDB.