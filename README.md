# Vehicle Explorer Web Application
This is a web application built with .NET Core that allows users to explore vehicle data using public APIs.
The application provides a user-friendly interface to search for vehicles and view details.

*Live Demo(AWS):
http://car-appt-env.eba-zvjx6pbt.eu-north-1.elasticbeanstalk.com/

*GitHub Repository:
https://github.com/MohammadAlSadawi/Car-App

*Features:
Select car make from a dynamic list
Filter by manufacturing year
Retrieve vehicle types based on selected make
Display available models for selected criteria
AJAX-based dynamic UI (no full page reloads)
Basic performance optimizations (limited results, parallel API calls)

*Technologies Used:
ASP.NET Core MVC (.NET 8)
C#
Bootstrap
AJAX
Docker
AWS Elastic Beanstalk

*APIs Used:NHTSA Vehicle API(Public)
Get All Makes
Get Vehicle Types by Make
Get Models by Make & Year

* Docker
The application is containerized using Docker.

- Build Image
docker build -t car-app .

- Run Container
docker run -p 8080:8080 car-app

-This maps:
Host port 8080 → Container port 8080

- Access the app
http://localhost:8080

*AWS Deployment

The application is deployed using AWS Elastic Beanstalk (Free Tier).

Platform: .NET
Instance Type: t3.micro
Deployment Type: ZIP upload
Note:
The app can be deployed using Docker as well, but for simplicity it is hosted directly on AWS Elastic Beanstalk.

Author:
Mohammad Al-Sadawi


