#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:2.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:2.1 AS build
WORKDIR /src
COPY . ./
RUN dotnet restore "TRPG_bot/TRPG_bot.csproj"
COPY . .
WORKDIR "/src/TRPG_bot"
RUN dotnet build "TRPG_bot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TRPG_bot.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TRPG_bot.dll"]