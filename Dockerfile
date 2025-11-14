FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["SampleAPI/SampleAPI.csproj", "SampleAPI/"]
RUN dotnet restore "SampleAPI/SampleAPI.csproj"
COPY . .
WORKDIR "/src/SampleAPI"
RUN dotnet build "SampleAPI.csproj" -c Release -o /app/build
RUN dotnet publish "SampleAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "SampleAPI.dll"]
