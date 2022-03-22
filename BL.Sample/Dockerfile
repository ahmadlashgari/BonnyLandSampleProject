#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BL.Sample/BL.Sample.csproj", "BL.Sample/"]
COPY ["BL.Sample.Infrastructure/BL.Sample.Infrastructure.csproj", "BL.Sample.Infrastructure/"]
COPY ["BL.Sample.ApplicationServices/BL.Sample.ApplicationServices.csproj", "BL.Sample.ApplicationServices/"]
COPY ["BL.Sample.Domain/BL.Sample.Domain.csproj", "BL.Sample.Domain/"]
RUN dotnet restore "BL.Sample/BL.Sample.csproj"
COPY . .
WORKDIR "/src/BL.Sample"
RUN dotnet build "BL.Sample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BL.Sample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BL.Sample.dll"]
