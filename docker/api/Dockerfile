#############
#### API ####
#############

## API Builder
FROM microsoft/dotnet:2.2.104-sdk AS assignment-api-builder

# Restore all projects
WORKDIR /app
COPY *.sln \
	src/*/*.csproj \
	tests/*/*.csproj \
	./
RUN for file in *Test.csproj; do mkdir -p tests/${file%.*}/ && mv $file tests/${file%.*}/; done
RUN for file in *.csproj; do mkdir -p src/${file%.*}/ && mv $file src/${file%.*}/; done
RUN dotnet restore ./Api.sln

# Copy Code Change
COPY src/. ./src/
COPY tests/. ./tests/
RUN dotnet build Api.sln --no-restore

# Run Test
WORKDIR /app/tests/BlogTest
ENTRYPOINT ["dotnet", "test"]
RUN dotnet test

# Build Migrations script
WORKDIR /app/src/Data
RUN dotnet ef migrations script -i -o migrations.sql -c ApplicationDbContext

# Build Project
WORKDIR /app/src/Api
RUN dotnet publish -o out /p:PublishWithAspNetCoreTargetManifest="false"

## API Runtime Image
FROM microsoft/dotnet:2.2.2-aspnetcore-runtime AS assignment-api-runtime

# Work on app
WORKDIR /app
COPY --from=assignment-api-builder /app/src/Api/out ./
ENV ASPNETCORE_URLS="http://*:5000"
ENV ASPNETCORE_ENVIRONMENT="Production"
EXPOSE 5000/tcp
ENTRYPOINT ["dotnet", "Assignment.Api.dll"]

##################
#### Database ####
##################

FROM postgres:11 AS assignment-database
COPY --from=assignment-api-builder /app/src/Data/migrations.sql /docker-entrypoint-initdb.d/