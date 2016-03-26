# BaseAspNetAngularUnity
BaseAspNetAngularUnity - A modern base ASP.NET MVC project

## Overview
This project should be used as a replacement for the default ASP.NET MVC templates provided
by Visual Studio. This project uses the following technologies to successfully launch a new ASP.NET MVC project.

- ASP.NET MVC 5.x
- EF 6.x
- Unity Dependency Injection 4.x
- Angular 1.5
- Bootstrap
- Moq

## Why use this?

The default ASP.NET MVC template is great for learning. However, it's not good for production purposes. Many of the missing features would impede learning ASP.NET MVC. This is an attempt to give developers a better template to use for new projects. The default template include many features the default template lacks:

- Dependency Injection wired up (Unity)
- Front end javascript engine (Angular)
- Separation of the Database access layer refactored into it's own DLL
- Moq for mocking service layers for unit tests
- Build system for integration into Continuous Integration

Notes for success

This project assumes you have SQL server installed as a default instance
