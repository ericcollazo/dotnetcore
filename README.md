# dotnetcore

Instructions:

1. Pull repository.
2. Execute `docker build -t docker-dotnetcore .`.  (will run on Windows or Linux based on OS where it is built)
3. Execute `docker stack deploy -c docker-compose.yml dotnetcore-stack` to run
4. View site at `http://localhost:5000`.

Pre-built image also available on [Docker Hub](https://hub.docker.com/r/ericcollazo/dotnetcore) @ `ericcollazo/dotnetcore`.
