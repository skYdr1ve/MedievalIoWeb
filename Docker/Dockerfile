FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_10.x | bash \
    && apt-get install nodejs -yq
WORKDIR /src
COPY ["MedievalIo.Web/MedievalIo.Web.csproj", "MedievalIo.Web/"]
COPY ["MedievalIo.Services/MedievalIo.Services.csproj", "MedievalIo.Services/"]
COPY ["MedievalIo.Server.Client/MedievalIo.Server.Client.csproj", "MedievalIo.Server.Client/"]
RUN dotnet restore "MedievalIo.Web/MedievalIo.Web.csproj"
COPY . .
WORKDIR "/src/MedievalIo.Web"
RUN dotnet build "MedievalIo.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MedievalIo.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet MedievalIoWeb.dll
