# UrlShortener

Shotrener application is based on Angular 13 and .Net Core 6.
Client app is a simple angular application working on 4200 host.
The .Net Core app is divided into the following projects:
    API - Application settings, controllers and busines logic. It depends on Data and Domain project.
    Data - Repository - ApplicationDbContext and ShortenerReopsitory. It depends on Domain layer.
    Domain - This project contains all interfaces, enties and models based on which code in Data and API is created.

Business Logic unit tests are located in UrlShortener.API.Tests project inside test folder.

## Prerequisities
.NET Core SDK 6.0
Node.js (version 16.13.1 or higher)

## How to start?
1. Clone repository to your local machine
git clone https://github.com/askakluska/UrlShortener.git

2. Navigate to the root directory of the project
cd task-nix

3. Install the Node.js dependencies for the Angular frontend
cd web/UrlShortener/
npm install

4. Build the Angular frontend
npm run build 

5. Run the Angular frontend
npm run start 

6. Navigate back to the root directory of the project

7. Run the .Net Core backend
cd API
dotnet run

8. Access the application in your web browser.
Angular app: http://localhost:4200
.Net Core app: http://localhost:5000

## Key assumptions 
The application is designed to create short links so that we can use the .Net Core server as a proxy and get to the final destination.

## Future Ideas
If I would have more time I would configure Dockerfile to run application. (I started, but unfortunately, I would have had to change the path of the API project leading to additional testing - the project was nested incorrectly at the very begining)
Instead of using InMemory database I would use SQLServer. 
I would add more security checks.


## Task Description 
>Build a URL shortening service like TinyURL. This service will provide short aliases redirecting to long URLs.
### Why do we use Url shortening?
URL shortening is used to create shorter aliases for long URLs. We call these shortened aliases “short links.” Users are redirected to the original URL when they hit these short links. Short links save a lot of space when displayed, printed, messaged, or tweeted. Additionally, users are less likely to mistype shorter URLs.

For example, if we shorten the following URL: `https://www.some-website.io/realy/long-url-with-some-random-string/m2ygV4E81AR`

We would get something like this: `https://short.url/xer23`

URL shortening is used to optimize links across devices, track individual links to analyze audience, measure ad campaigns’ performance, or hide affiliated original URLs.

### URL shortening application should have:
 - A page where a new URL can be entered and a shortened link is generated. You can use Home page.
 - A page that will show a list of all the shortened URL’s.
### Functional Requirements:
- Given a URL, our service should generate a shorter and unique alias of it. This is called a short link. This link should be short enough to be easily copied and pasted into applications.
- When users access a short link, our service should redirect them to the original link.
- Application should store logs information about requests.
### Non-Functional Requirements:
- URL redirection should happen in real-time with minimal latency.
- Please add small project description to Readme.md file.
### During implementation please pay attention to:
- Application is runnable out of box. If some setup is needed please provide details on ReadMe file.
- Project structure and code smells.
- Design Principles and application testability.
- Main focus should be on backend functionality, not UI.
- Input parameter validation.
- Please, don't use any library or service that implements the core functionality of this test.
### Other recommendation:
- You may change UI technology to any other you are most familiar with.
- You can use InMemory data storage.
- You can use the Internet.
# May the force be with you {username}!