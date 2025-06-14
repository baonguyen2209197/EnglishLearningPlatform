# EnglishLearningPlatform

A professional, production-grade C# .NET 8 platform for English course management, learning progress tracking, assessments, points/rankings, lesson suggestions, and user management.

## Features
- Clean Architecture (DDD, Modular Monolith)
- EF Core + PostgreSQL
- Serilog logging
- JWT authentication
- Swagger + API versioning
- Docker & docker-compose
- Unit & integration tests
- GitHub Actions CI/CD
- Sample data seeding
- Full CRUD for Course module
- User registration/login (email, Google, Facebook)
- User roles (Admin, User)
- Learning progress, points, rankings, test/assessment modules, lesson suggestion scaffolding

## Getting Started
1. Clone the repo
2. Update `docker-compose.yml` with your environment variables if needed
3. Run `docker-compose up --build`
4. Access the API at `http://localhost:5000/swagger`

## Documentation
- See `docs/API_DOCUMENTATION.md` for API details
- See `docs/openapi.json` for OpenAPI spec
- See `docs/postman_collection.json` for Postman collection

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

## License
MIT
