# Overview

In this repository, I wrote a program that is designed for inventory management. The program is implemented as a console application, allowing users to interact with it via a command-line interface. It provides various functionalities for managing inventory, including adding physical and digital products, viewing existing products, updating product quantities, and removing products from the inventory. The application employs object-oriented principles, with classes representing different types of products and inheritance used to model their common properties. For example, the PhysicalProduct and DigitalProduct classes inherit from a base Product class, which encapsulates properties shared by all products, such as name, description, price, and quantity. This inheritance hierarchy allows for code reuse, enhances maintainability, and provides a clear and organized structure to the application.

The purpose of writing this algorithm is to establish a solid foundation for developing a web-based user interface (UI) for interacting with a cloud database using the C# programming language. By implementing the inventory management system as a console application first, I aim to ensure that the core functionalities for managing inventory, such as adding, viewing, updating, and removing products, are robustly implemented and tested. This console application serves as the backend logic for the eventual web UI, providing the necessary functionality to interact with the cloud database. By building upon this foundation, I intend to create a seamless and intuitive web interface that enables users to efficiently manage inventory data stored in the cloud, enhancing accessibility, scalability, and usability of the inventory management system.


[Software Demo Video](https://youtu.be/GGlESvJeOnk)

# Development Environment

For developing the software, I primarily used Visual Studio Code. Visual studio was able to set up the project for me through the command line. Additionally, I utilized Git for version control to track changes and collaborate with team members. To manage dependencies and packages, I relied on NuGet, a package manager for .NET.

The programming language used for developing the console application is C#. C# is a modern, object-oriented language developed by Microsoft, specifically designed for building applications on the .NET framework.

# Useful Websites

- [ASP .NET Documentation](https://dotnet.microsoft.com/en-us/learn/dotnet/architecture-guides?utm_source=aspnet-start-page&utm_campaign=vside)
- [C# Microsoft inheritance](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/object-oriented/inheritance)
- [C# w3 Schools](https://www.w3schools.com/cs/cs_classes.php)


# Future Work

- Choose a Web Framework: I need to decide on a web framework for building my UI on the web. Since I'm using C#, I can choose from frameworks like ASP.NET Web Forms, ASP.NET MVC, ASP.NET Core MVC, or Blazor.
- Create Project Structure: I'll set up the project structure for my web application. This involves creating folders for controllers, views, models, static files (CSS, JavaScript), and any other resources.
- Convert Console UI to Web UI: I'll rewrite my console UI using C# and HTML. Each menu option or interaction in my console application should correspond to a server-side action or component in my web UI. I'll use C# to handle server-side logic, generate dynamic HTML content using Razor syntax (if using ASP.NET), and interact with the backend to perform actions such as adding, viewing, updating, and removing products from the inventory.
