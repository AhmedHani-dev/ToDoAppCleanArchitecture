ToDo web api application in .net 8 following Clean Architecture


The project has 4 layers (Presentation, Application, Infrastructure, Domain)


-Presentation Layer: Api (Controllers) depends on -> Application, Infrastructure

-Applicaton Layer: Application (Services, Interfaces of services, unit of work and generic repository) depends on -> Core

-Infrastructure Layer: Infrastructure (DBContext, Generic Repository, Unit of Work implementation) depends on -> Core, Application

-Domain Layer: Core (Entities and Enums) depends on -> none
