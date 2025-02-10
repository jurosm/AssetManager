# AssetManager

AssetManager is a simple Project used for demonstrating Clean Architecture best practices

## Prerequisites

Use the docker compose file to run Kibana and Elasticsearch

## Setup

Before running the project, ensure that the following environment variables are set:

- `ELASTICSEARCH_URL`, url of the Elasticsearch service
- `SQLLITE_DB_URL`, url of the path for the SQLLite db file

Then go to the Infrastructure project and run `dotnet ef database update`

## Run

Use `dotnet run` in the Api project
