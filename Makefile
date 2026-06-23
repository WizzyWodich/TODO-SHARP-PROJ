include .env
export

PROJECT_ROOT := $(shell pwd)

run:
	@cd src && dotnet run --project Todo.Core/Todo.Core.csproj

env-up:
	@docker compose up -d

env-down:
	@docker compose down

env-down-v:
	@docker compose down -v

env-logs:
	@docker compose logs -f

db-reset:
	@echo "Stopping containers and removing volumes..."
	@docker compose down -v
	@echo "Removing EF migrations..."
	@rm -rf backend/Todo.Infrastructure.PostgreSQL/Migrations
	@echo "DONE: DB + migrations cleared"

env-migration:
	@if [ -z "$(name)" ]; then \
		echo "ERROR: migration name is required"; \
		echo "Example: make env-migration name=InitialCreate"; \
		exit 1; \
	fi
	@dotnet ef migrations add $(name) \
		--project backend/Todo.Infrastructure.PostgreSQL \
		--startup-project backend/Todo.Core

db-update:
	@dotnet ef database update \
		--project backend/Todo.Infrastructure.PostgreSQL \
		--startup-project backend/Todo.Core

db-drop:
	@dotnet ef database drop -f \
		--project backend/Todo.Infrastructure.PostgreSQL \
		--startup-project backend/Todo.Core

dev-reset:
	@make db-reset
	@make env-up
	@sleep 3
	@make env-migration name=InitialCreate
	@make db-update
	@echo "READY: clean dev environment"

k6-run:
	@k6 run load-test.js --summary-export=reports/test.json

k6-test1:
	@k6 run load-test.js --summary-export=reports/test1.json

k6-test2:
	@k6 run load-test.js --summary-export=reports/test2.json

clean:
	@rm -rf reports/*
	@echo "Reports cleaned"
		--project src/Todo.Infrastructure.PostgreSQL \
		--startup-project src/Todo.Core
		
db-update:
	@dotnet ef database update \
		--project src/Todo.Infrastructure.PostgreSQL \
		--startup-project src/Todo.Core
