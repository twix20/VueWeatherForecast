FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["WeatherForecast.Web/WeatherForecast.Web.csproj", "WeatherForecast.Web/"]
COPY ["WeatherForecast.Application/WeatherForecast.Application.csproj", "WeatherForecast.Application/"]
COPY ["OpenWeathermapApiClient/OpenWeathermapApiClient.csproj", "OpenWeathermapApiClient/"]
COPY ["WeatherForecast.Infra.IoC/WeatherForecast.Infra.IoC.csproj", "WeatherForecast.Infra.IoC/"]
RUN dotnet restore "WeatherForecast.Web/WeatherForecast.Web.csproj"
COPY . .
WORKDIR "/src/WeatherForecast.Web"
RUN dotnet build "WeatherForecast.Web.csproj" -c Release -o /app

FROM node:8.15-alpine as nodeBuild
WORKDIR /src
COPY ["WeatherForecast.Web/ClientApp/package.json", "WeatherForecast.Web/ClientApp/yarn.lock", "./"]
RUN yarn
COPY ["WeatherForecast.Web/ClientApp/", "./"]
RUN yarn build


FROM build AS publish
RUN dotnet publish "WeatherForecast.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
COPY --from=nodeBuild /src/dist /app/ClientApp/dist

ENTRYPOINT ["dotnet", "WeatherForecast.Web.dll"]