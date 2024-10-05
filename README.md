# TAN_10042024

This application is a RESTful web service that securely processes uploaded files by using API Key-based security mechanism.

This also provides an example for generating basic report for all the files uploaded.

Also provides an example of fetching data from an entity using EntityFramework Core and proper LINQ.

The codebase applies Clean Architecture layering for better code quality implementation.


## Table of Contents

- [Features](#features)
- [Prerequisites](#prerequisites)
- [Getting Started](#getting-started)
- [Building the Docker Image](#building-the-docker-image)
- [Running the Application](#running-the-application)
- [API Endpoints](#api-endpoints)

## Features

- Runs on ASP.NET Core
- Containerized with Docker


## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker Desktop](https://www.docker.com/get-started)
- [Postman](https://www.postman.com/) (for testing API endpoints)
- [SSMS](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- [SQL Server Express](https://www.microsoft.com/en-us/download/details.aspx?id=104781&lc=1033&msockid=22f712c8b3e26fa7318c060db27f6e03)


## Getting Started

Let's get start by cloning the repository.

	```
	git clone https://github.com/steven-repositories/TAN_10042024.git
	cd TAN_10042024
	```

After cloning the repository, open your SSMS and login into you local server. Usually named as: "localhost".

Create a database; you decide what the database name is. 

After creating a database, you also need to create a login user under the Security > Logins.

Right click the Logins folder and select New Login; you decide what would be the credentials for this login user.

In the codebase, go to the appsettings.json and change the value of "DatabaseName", "User Id", and "Password" for the "CC" connection string.


## Building the Docker Image

You need to execute the "docker build" command with option of using tag "-t" alongside with the name of the image you want to build.

	```
	docker build -t {image_name}:{tag} -f {Dockerfile path} --progress=plain .
	```

And since in this repository, the Dockerfile is located inside the "TAN_10042024" project file.

So when you are going to build your Docker Image with this application, the command you need to execute should be like this:

	```
	docker build -t tan_10042024:1.0 -f ./TAN_10042024/Dockerfile --progress=plain .
	```


## Running the Application

Once the Docker Image is created, you can run the application inside a container by executing the "docker run" command.

You can set your desired host port and the container port when you execute the "docker run" command.

	```
	docker run -p {host_port}:{container_port} {image_name_here}
	```

Based on what is in the Dockerfile, the application will be exposed to port 8080. So the command you need to execute to run the application in Docker should be like this:

	```
	docker run -p 8080:8080 tan_10042024:1.0
	```


## API Endpoints

The endpoints that this application does have are:

1. api/auth/key 
	- Uses for generating new API Key to be set as header for other API Key-based security implemented endpoints.
	
2. api/file/upload/persons
	- Uses to securely upload a JSON file with "persons" in it.
	
3. api/person/{team}/max-score
	- Uses to get the highest score that a single team have in the database.
	
4. api/person/{team}/second-to-least-score
	- Uses to get the second to least score that a single team have in the database.

5. api/person/{team}/union-names
	- Uses to unionized by comma separated all the person names for a single team.

6. api/report/files
	- Uses to generate basic report for all the files that have been processed or saved in the database.