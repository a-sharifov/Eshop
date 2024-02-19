# [Eshop](https://github.com/a-sharifov/Eshop) [![GitHub license](https://img.shields.io/badge/license-Apache-blue.svg)](https://github.com/a-sharifov/Eshop/blob/master/LICENSE)

## 🚀 Project Overview

Eshop: Microservices E-commerce with .NET and DDD

## 🎯 Objective

The main objective of this project is to demonstrate the implementation of various design patterns and architectural principles in the development of microservices-based applications using cloud technologies. Below are the key concepts and patterns highlighted in this project:

### Domain-Driven Design (DDD)
Domain-Driven Design is employed to model the domain logic of the application, focusing on the core business concepts and their relationships. By adopting DDD, we aim to create a clear and expressive domain model that reflects real-world scenarios.

### Command Query Responsibility Segregation (CQRS)
CQRS separates the responsibility for handling commands (write operations) from queries (read operations). This pattern allows for better scalability, performance optimization, and maintenance of the application by segregating the concerns of reads and writes.

### Outbox Pattern
The Outbox Pattern is utilized to ensure consistency between the primary data store and secondary systems or event-driven architectures. It involves the use of an outbox table to store domain events, which are later processed and dispatched to external systems or message brokers.

### Onion Architecture
Onion Architecture emphasizes the separation of concerns and the dependency inversion principle. It organizes the application into concentric layers, with the domain model at the core surrounded by layers representing application services, interfaces, and infrastructure.

### Event Sourcing
Event Sourcing is employed to capture all changes to the application state as a sequence of events. Instead of storing the current state of the entity, Event Sourcing retains the history of events that led to the current state. This approach enables auditing, debugging, and rebuilding the application state at any point in time.

### Result Pattern
The Result Pattern is used to handle the outcome of operations in a structured and consistent manner. It provides a standardized way to communicate success, failure, or exceptional conditions, making the codebase more readable, maintainable, and resilient.

## 🌟 Enjoyed my project?

- Please consider starring the repository.
- You can donate on [Patreon](https://www.patreon.com/a_sharifov).

## 📝 Documentation

Check out our [documentation](/docs) for more details on the project setup and usage.

## 📫 Contact

If you have any questions or suggestions, feel free to reach out to me.

This project is licensed under the [Apache 2.0 License](LICENSE).
