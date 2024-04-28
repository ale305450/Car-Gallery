# Car Gallery Website

This is a car gallery website that allows users to view cars and their prices. Users can browse through the gallery, view car details. The website also provides administrative functionality to add new cars, companies, and manage the gallery.

## Features

- User Registration and Authentication: The website utilizes Microsoft Identity for user registration and authentication. Users can create an account, log in, and access personalized features.

- Car Gallery: The main feature of the website is the car gallery. Users can browse through a collection of cars, view their details such as images, descriptions, and prices.

- Admin Management: Administrators can manage the car gallery, add new cars, add companies, and update the gallery.

- Delete API: The website provides a delete API endpoint to remove cars, companies, or gallery items from the database. This API ensures secure deletion of data.

## Technologies Used

- ASP.NET Core MVC: The web application is built using the ASP.NET Core MVC framework. It provides a robust and scalable architecture for building web applications.

- Microsoft Identity: Microsoft Identity is used for user registration, authentication, and authorization. It ensures secure access to the website's features.

- Entity Framework Core: The website uses Entity Framework Core as the ORM (Object-Relational Mapping) tool to interact with the database and perform CRUD operations.

- SQL Server: The website stores data in a SQL Server database. It provides a reliable and scalable storage solution for managing car and user data.

### Getting Started

1. Clone the repository:
   ```
   git clone https://github.com/your/repository.git
   ```

2. Open the solution in Visual Studio.

3. Open the Package Manager Console:
   - Go to `Tools` > `NuGet Package Manager` > `Package Manager Console`.

4. Update the database:
   - Run Entity Framework Core migrations to create the database schema:
     ```
      Update-Database
     ```

5. Run the application:
   - Press `F5` or click on the green "Play" button in Visual Studio.

6. Use the website:
   - Browse available cars on the website.

## Contributions

Contributions to the car gallery website are welcome. If you encounter any issues or have suggestions for improvements, please open an issue on the repository.

## License

The car gallery website is open-source and released under the [MIT License](https://opensource.org/licenses/MIT). Feel free to modify and distribute the code as per the license terms.


## Contact

For any inquiries or support, please contact ale305450@gmail.com .





