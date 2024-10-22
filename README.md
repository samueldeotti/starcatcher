# Consortium Quota Management System

**WORK IN PROGRESS**

This project is currently under development and is not yet ready for production use.  Features and implementation details are subject to change.


This project aims to implement a basic system for managing consortium quotas, leveraging a modern architecture with microfrontends, a GraphQL layer, and a REST API backend.

## Overview

The system is designed with three core components:

1. **Backend API (.NET 8):**  A monolithic API built with .NET 8, providing core business logic and data persistence.  Entity Framework Core is used for database interaction with SQL Server, running within a Docker container.  Database migrations are managed via Entity Framework Core's migration tools.  The API is secured using authentication (Basic/JWT).

2. **BFF (Backend for Frontend - Next.js & GraphQL):**  A Next.js application serves as the Backend for Frontend (BFF), exposing a GraphQL API powered by Apollo Server.  This layer acts as an intermediary between the frontend and the backend API, optimizing data fetching and providing a tailored experience for the client application.

3. **Frontend (Microfrontend - React & Redux Toolkit):**  The user interface is built as a microfrontend using React.  Redux Toolkit is used for state management, providing a predictable and efficient way to handle application data.  Apollo Client facilitates interaction with the GraphQL API exposed by the BFF.  Module Federation is employed to enable the microfrontend architecture.


## Technologies Used

* **Backend:** .NET 8, Entity Framework Core, SQL Server, Docker,  Basic/JWT Authentication
* **BFF:** Next.js, Apollo Server, GraphQL
* **Frontend:** React, Redux Toolkit, Apollo Client, Module Federation


## Key Features (Planned)

* **Quota Management:**  Full CRUD (Create, Read, Update, Delete) operations for managing consortium quotas.
* **Modern Architecture:**  Microfrontend architecture, GraphQL API, and a RESTful backend provide a scalable and maintainable solution.
* **Containerized Database:** SQL Server runs within a Docker container for simplified setup and deployment.
* **State Management:**  Redux Toolkit ensures predictable state management on the frontend.

**Please note that these features are still under development and may not be fully implemented yet.**
