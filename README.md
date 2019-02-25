# EA Take Home Assignment

Take home assignment that does following:

  - User can read posts
  - Each post can have multiple comments
  - User can write posts
  - User can comment on a post
  - User can register

### Tech

EA Assignment was built with:

* .NET Core - Cross platform framework for C#
* Angular - Javascript framework for Gui
* Postgresql - RDBMS

Libraries:
* Entity Framework Core - ORM for api project to interact with postgresql.
* Autofac - IoC container for .NET Core
* Moq - C# testing framework
* Devextreme - Angular UI framework
* Swagger - API documentation

### Installation

To run locally, the app requires:
* Node - v8+
* NPM - v6+
* .NET Core SDK - 2.2
* Postgresql - v10+, with role name: admin, password: admin with create privilege


To start Gui, install the dependencies and start the server.

```sh
$ cd ea-assignment/web/gui
$ npm install
$ npm run-script build-prod
```

To start backend, restore packages, build the solution then migrate the database.

```sh
$ cd ea-assignment/src/api
$ dotnet restore
$ dotnet build
$ cd ../data
$ dotnet ef database update
$ cd ../api
$ dotnet run
```
To run on another host built with docker, the app requires:

* Docker - Recommended v18.02.0+
* Docker Compose - v1.20+

To run:

```sh
$ cd ea-assignment
$ docker-compose build
$ docker-compose up
```

### Testing

To run backend tests:

```sh
$ cd ea-assignment/tests/blogtest
$ dotnet test
```

To run frontend tests:

```sh
$ cd ea-assignment/web/gui
$ npm test
```

### API Documentation

Assuming running on docker, API Documentation can be found at:

http://localhost:5000/swagger/index.html

### Todos

 - Write GUI Test
 - Add Authentication
 - More Features to utilize APIs
