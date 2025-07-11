# 🐺 Wolverine Sample (.NET)

This repository demonstrates how to use **[Wolverine](https://wolverinefx.net/)** — a modern and high-performance messaging library for the .NET ecosystem — in two key scenarios:

1. **In-Process Messaging**: using Wolverine’s internal bus for local message handling within a single application.
2. **Distributed Messaging**: using **RabbitMQ** as a message broker for communication between producer and consumer applications.

---

## 📦 Project Structure

- `Wolverine.Api`  
  Minimal API sample using Wolverine’s in-process transport.

- `Wolverine.RabbitMQ.Producer`  
  Console app that publishes messages to RabbitMQ periodically.

- `Wolverine.RabbitMQ.Consumer`  
  Console app that listens to a RabbitMQ queue and consumes messages.

- `Wolverine.Message`  
  Shared project containing message contracts (DTOs).

- `rabbitmq-docker-compose.yml`  
  Docker file to spin up a local RabbitMQ container with the management UI.

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/lenerson/Wolverine-Sample.git
cd Wolverine-Sample
```

### 2. Start RabbitMQ via Docker

```bash
docker-compose -f rabbitmq-docker-compose.yml up -d
```

RabbitMQ Management UI will be available at:

```makefile
http://localhost:15672
Username: guest
Password: guest
```

---

### 3. Run the Projects

**In-Process Messaging**

Go to the Wolverine.Api folder and run:

```bash
dotnet run
```

Test with a POST request:

```bash
curl -X POST https://localhost:<PORT>/message -H "Content-Type: application/json" -d "{\"id\":\"<GUID>\",\"content\":\"Hello Wolverine!\"}"
```

> Replace <PORT> with your actual local port (e.g., 7016)

Each `POST` to `/message` publishes a message to Wolverine's in-memory bus, which is handled by the `CreateMessageHandler`.

---

**Distributed Messaging with RabbitMQ**

In two separate terminals:

```bash
# Terminal 1 - Producer
cd Wolverine.RabbitMQ.Producer
dotnet run

```

```bash
# Terminal 2 - Consumer
cd Wolverine.RabbitMQ.Consumer
dotnet run
```

You’ll see messages being produced and consumed every 30 seconds.

---

## 📘 API Documentation with Scalar

The Minimal API project uses [Scalar](https://scalar.com/) for live, interactive API documentation.

**Accessing the API Docs**

Once the API is running locally, open:

```bash
https://localhost:<PORT>/scalar/v1
```

> Replace <PORT> with your actual local port (e.g., 7016)

Scalar provides a beautiful and developer-friendly interface to explore and test endpoints.

---

## 📚 Related Article

This repository is part of the article:

[From MassTransit to Wolverine: A Modern, Lightweight, Performance-Focused Alternative](https://dev.to/lepton_tech/de-masstransit-para-wolverine-uma-alternativa-moderna-leve-e-focada-em-performance-35g4)

---

## ✅ Requirements

- .NET 9.0+

- Docker

- RabbitMQ (via included Docker Compose)

---

## 🧠 About Wolverine

Wolverine is a modern messaging and mediator library for .NET. It offers:

- In-process and distributed messaging in a single package

- High performance with low memory overhead

- First-class support for RabbitMQ, Azure Service Bus, Kafka, and more

- Native Mediator Pattern support (no MediatR needed)

- Sagas, retries, scheduled messages, and more

- Seamless integration with ASP.NET Core and minimal APIs

---

## 🛠 Author

[Lenerson Velho Nunes](https://github.com/lenerson)

[Lepton Tech Solutions](https://lepton.tech) — Custom Digital Solutions

---

## 📄 License

This project is open source and licensed under the [MIT License](https://opensource.org/license/mit).