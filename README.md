# BookingService

BookingService.sln
│
├── BookingService.Api                  (ASP.NET Core Web API)
│   ├── Controllers
│   │   └── BookingController.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── launchSettings.json
│   └── Program.cs
│
├── BookingService.Application          (Business/Application Logic)
│   ├── Clients
│   │   └── IInventoryServiceClient.cs
│   ├── Commands
│   │   ├── CancelBookingCommand.cs
│   │   └── CreateBookingCommand.cs
│   ├── Handlers
│   │   ├── CancelBookingCommandHandler.cs
│   │   └── CreateBookingCommandHandler.cs
│   ├── Validators
│   │   ├── CancelBookingCommandValidator.cs
│   │   │ 
│   └── └── CreateBookingCommandValidator.cs
│
├── BookingService.Domain               (Domain Entities +  Shared Protos)
│   ├── Booking.cs
│   └── inventory.proto                 
│
├── BookingService.Grpc                 (gRPC Service)
│   ├── Protos
│   │   └── booking.proto
│   ├── Properties
│   │   └── launchSettings.json
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   └── BookingGrpcService.cs
│
├── BookingService.Infrastructure       (Data Access, EF Core, External Service Implementations)
│   ├── BookingDbContext.cs
│   ├── BookingRepository.cs
│   └── InventoryServiceClient.cs
│
└── BookingService.Tests                (Unit Tests)
    ├
    └── CreateBookingCommandHandlerTests.cs
    
   ![image](https://github.com/user-attachments/assets/2f578d4e-4544-4927-9cde-45cc29805137)
 
- Built using an N-Tier architecture that separates the Domain, Application, Infrastructure, API, and gRPC layers.
- Uses MediatR to decouple request handling (with commands and handlers)
-  FluentValidation to enforce business rules before handlers process requests.
- The API layer exposes REST endpoints, and a dedicated gRPC project provides remote access.
- Integrates with InventoryService via gRPC using a central client wrapper (IInventoryServiceClient) to perform inventory and member data operations.
- Unit tests are implemented using MSTest.

# InventoryService

InventoryService.sln
│
├── InventoryService.Api                   (ASP.NET Core gRPC API)
│   ├── Protos
│   │   └── inventory.proto                // gRPC proto definitions
│   ├── ServiceHandler                     // gRPC service handlers
│   │   ├── InventoryServiceHandler.cs
│   │   └── MemberServiceHandler.cs
│   ├── appsettings.json
│   ├── appsettings.Development.json
│   ├── launchSettings.json
│   └── Program.cs                         // Configures gRPC, DI, etc.
│
├── InventoryService.Application           (Business Logic Layer)
│   ├── Interfaces                         // Contracts for services
│   │   ├── IInventoryService.cs
│   │   └── IMemberService.cs
│   ├── Mapping                            // AutoMapper profiles
│   │   ├── MappingProfile.cs
│   │   └── MappingService.cs             
│   ├── Services
│   │   ├── InventoryService.cs
│   │   └── MemberService.cs
│   └── (Additional classes or helpers as needed)
│
├── InventoryService.Domain                (Domain Models)
│   ├── Models
│   │   ├── BulkInventoryRequest.cs
│   │   ├── BulkInventoryResponse.cs
│   │   ├── BulkMemberRequest.cs
│   │   ├── BulkMemberResponse.cs
│   │   ├── Inventory.cs
│   │   ├── InventoryUpdateResult.cs
│   │   ├── Member.cs
│   │   ├── MemberDTO.cs
│   │   └── MemberUpdateResult.cs
│   └── (Additional domain objects if needed)
│
└── InventoryService.Infrastructure        (Data Access Layer, EF Core)
    ├── Interfaces
    │   ├── IInventoryRepository.cs
    │   └── IMemberRepository.cs
    ├── InventoryDbContext.cs
    ├── InventoryRepository.cs            
    └── MemberRepository.cs

    
![image](https://github.com/user-attachments/assets/06f93a0d-30f8-4492-8ea4-19427111bb35)

- Organized into three layers: Domain, Application, and Infrastructure.
- The Domain layer holds pure models such as Inventory, Member, BulkInventoryRequest, BulkInventoryResponse, InventoryUpdateResult, and MemberUpdateResult.
- The Application layer implements business logic through services (e.g., InventoryService and MemberService) and uses AutoMapper to map between DTOs and Domain models.
- The Infrastructure layer uses the Repository Pattern with interface segregation to manage data access using EF Core (configured with an in-memory database).
- Exposes gRPC endpoints defined in a proto file (inventory.proto) for operations like checking availability, decrementing/increasing inventory, bulk updating inventory, and bulk adding/updating members.
- The gRPC contracts are designed to be shared, allowing easy integration with other services.

# CsvService
CsvService.sln
└── CsvService.Api (ASP.NET Core Web API)
    ├── Connected Services
    ├── Dependencies
    ├── Properties
    │    └── launchSettings.json
    ├── Controllers
    │    └── CsvController.cs        // Handles HTTP endpoints for CSV upload
    ├── Models
    │    ├── InventoryRecord.cs      // Represents a single inventory CSV record
    │    └── MemberRecord.cs         // Represents a single member CSV record
    ├── Protos
    │    └── inventory.proto         // Proto definitions for InventoryService gRPC
    ├── Services
    │    ├── CsvManager.cs           // Orchestrates CSV parsing & gRPC calls
    │    ├── CsvParserService.cs     // Parses CSV files using CsvHelper
    │    └── InventoryClientService.cs // gRPC client wrapper calling InventoryService
    ├── appsettings.Development.json
    ├── appsettings.json
    └── Program.cs                   // Configures ASP.NET Core, DI, gRPC client, etc.
    
![image](https://github.com/user-attachments/assets/7671b9f1-c5a6-48bc-a1c1-fb9eb8ffa269)

- An independent ASP.NET Core Web API project dedicated to reading CSV files.
- Utilizes CsvHelper to parse CSV files efficiently by streaming data, ensuring proper disposal of file streams.
- Contains a CsvParserService for converting CSV file data into in-memory objects (e.g., MemberRecord, InventoryRecord).
- Implements a dedicated CsvManager that encapsulates the business logic of CSV processing and coordinates gRPC calls to InventoryService.
- The CsvController is kept thin, delegating the complex CSV parsing and remote service calls to the CsvManager.
- This design promotes responsibility segregation and makes the service easily extendable to support additional read/write operations.
