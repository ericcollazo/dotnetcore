## Use build image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

## Set working directory
WORKDIR /app

# copy everything and build
COPY . ./

RUN dotnet publish -c Release -o out

# build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1

WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "dotnetcore.dll"]