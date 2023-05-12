FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["graphql-demo/graphql-demo.csproj", "graphql-demo/"]
RUN dotnet restore "graphql-demo/graphql-demo.csproj"
COPY . .
WORKDIR "/src/graphql-demo"
RUN dotnet build "graphql-demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "graphql-demo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "graphql-demo.dll"]
