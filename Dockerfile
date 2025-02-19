# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR ./src

# Copia tudo para dentro do container
COPY . .

# Restaura os pacotes
WORKDIR ./src/Backend/AMSeCommerce.API
RUN dotnet restore

# Publica a aplicação
RUN dotnet publish -c Release -o /app/out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR ./src

# Copia os arquivos publicados para o container final
COPY --from=build-env /app/out .

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "AMSeCommerce.API.dll"]
