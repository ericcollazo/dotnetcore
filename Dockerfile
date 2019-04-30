## Use build image
FROM mcr.microsoft.com/dotnet/core/sdk AS build-env

## Set working directory
WORKDIR /app

# copy everything and build
COPY . ./

RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "docker-dotnetcore.dll"]