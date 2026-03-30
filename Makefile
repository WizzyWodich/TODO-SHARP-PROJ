include .env
export

export PROJECT_ROOT=$(shell pwd)


env-up:
	@docker compose up -d todo-database-postgre

env-down:
	@docker compose down todo-database-postgre
env-cleanup:
	@read -p "Clear all volume files data? [y/N]" ans; \
	if [ "$$ans" = "y" ]; then \
		docker compose down todo-database-postgre && \
		rm -rf out/pgdata && \
		echo "Files removed sucses"; \
	else \
		echo "Files removed cancle"; \
	fi
env-migration:
	@dotnet ef database update \
		--project backend/Todo.Infrastructure.PostgreSQL \
		--startup-project backend/Todo.Core