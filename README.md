# Customer Management Application

This repository contains a Customer Management application with two projects:

1. **Customer API** - A RESTful API for managing customer data.
2. **Customer MVC** - A web application for interacting with the API through a user interface.

## Ports

- **Customer API**: The API listens on port `5035`. You can access it at `http://localhost:5035`.
- **Customer MVC**: The MVC application listens on port `5201`. You can access it at `http://localhost:5201`.

## Running the Application

To start the application:

1. Navigate to the `CustomerApi` directory and run the API using `dotnet run`. The API will be available at `http://localhost:5035`.

2. Navigate to the `CustomerMvc` directory and run the MVC application using `dotnet run`. The web interface will be available at `http://localhost:5201`.

## Description

- The **Customer API** provides endpoints for creating, retrieving, updating, and deleting customer records. It operates independently and serves as the backend for customer data management.

- The **Customer MVC** application is a web-based front-end that allows users to interact with the Customer API. It provides forms and views for managing customer information through a browser interface.

## Troubleshooting

Ensure both the API and MVC applications are running simultaneously. Check that the API is listening on port `5035` and the MVC application is on port `5201`. If you encounter issues, verify the terminal outputs for errors and confirm that the URLs are correctly configured.


