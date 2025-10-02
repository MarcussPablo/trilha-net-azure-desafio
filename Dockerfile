# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia só o csproj e restaura dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o resto do código e publica
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expõe a porta padrão do ASP.NET
EXPOSE 5000
EXPOSE 5001

# Comando para rodar a API
ENTRYPOINT ["dotnet", "trilha-net-azure-desafio.dll"]
