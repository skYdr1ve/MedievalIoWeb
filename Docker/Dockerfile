FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443
# Copy csproj and restore as distinct layers
COPY . /app
WORKDIR /app
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o out

#Angular build
FROM node as nodebuilder

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH


# install and cache app dependencies
COPY ClientApp/package.json /usr/src/app/package.json
RUN npm install
RUN npm install -g @angular/cli@1.7.0 --unsafe

# add app

COPY ClientApp/. /usr/src/app

RUN npm run build

#End Angular build

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .

# Run the app on container startup
# Use your project name for the second parameter
# e.g. MyProject.dll
RUN mkdir -p /app/ClientApp/dist
COPY --from=nodebuilder /usr/src/app/dist/. /app/ClientApp/dist/
ENTRYPOINT [ "dotnet", "HerokuApp.dll" ]
