# Support Ticketing API

A REST API for managing support tickets, built with ASP.NET Core, EF Core, and SQLite.

## Endpoints
| Method | URL | Description |
|---|---|---|
| GET | /api/tickets | List all tickets |
| GET | /api/tickets/{id} | Get one ticket (404 if not found) |
| POST | /api/tickets | Create a ticket (400 if title is empty) |
| PUT | /api/tickets/{id} | Update a ticket |
| DELETE | /api/tickets/{id} | Delete a ticket |

## Run it
1. Install the .NET SDK
2. `dotnet ef database update`
3. `dotnet run`
4. Test with Postman at http://localhost:5052/api/tickets

## What I learned
- How requests flow from URL to controller to database
- Reading HTTP status codes (200, 201, 204, 400, 404) to find where a problem is
- Checking API results against the database with SQL
