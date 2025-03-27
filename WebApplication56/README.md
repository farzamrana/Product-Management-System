# Product Management System

A web-based product management system built with ASP.NET Core Web API and HTML/CSS/JavaScript. This system allows users to manage products, brands, and categories with a modern and responsive user interface.

## Features

### Product Dashboard
- View all products in a table format
- Filter products by:
  - Brand
  - Category
  - Price range
  - Date range
- View statistics including:
  - Total number of products
  - Average price
  - Total value of inventory

### Product Creation
- Add new products with:
  - Name
  - Description
  - Price
  - Brand selection
  - Category selection
  - Image upload

### Data Management
- Manage brands and categories
- Seed data functionality for initial setup
- RESTful API endpoints for all operations

## Technologies Used

- Backend:
  - ASP.NET Core Web API
  - Entity Framework Core
  - SQL Server

- Frontend:
  - HTML5
  - CSS3
  - JavaScript (ES6+)
  - Fetch API for HTTP requests

## Setup Instructions

1. Clone the repository:
```bash
git clone https://github.com/yourusername/product-management-system.git
```

2. Open the solution in Visual Studio 2022 or later

3. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
  }
}
```

4. Run the following commands in Package Manager Console:
```powershell
Add-Migration InitialCreate
Update-Database
```

5. Run the application

6. Seed the database using the following endpoints in Swagger UI:
   - POST `/api/Categories/seed`
   - POST `/api/Brands/seed`
   - POST `/api/Products/seed`

7. Access the web interface:
   - Dashboard: `https://localhost:44309/index.html`
   - Create Product: `https://localhost:44309/create-product.html`

## API Endpoints

### Products
- GET `/api/Products` - Get all products
- GET `/api/Products/report` - Get product report with filters
- POST `/api/Products` - Create new product
- GET `/api/Products/{id}` - Get product by ID
- PUT `/api/Products/{id}` - Update product
- DELETE `/api/Products/{id}` - Delete product

### Brands
- GET `/api/Brands` - Get all brands
- POST `/api/Brands` - Create new brand
- GET `/api/Brands/{id}` - Get brand by ID
- PUT `/api/Brands/{id}` - Update brand
- DELETE `/api/Brands/{id}` - Delete brand

### Categories
- GET `/api/Categories` - Get all categories
- POST `/api/Categories` - Create new category
- GET `/api/Categories/{id}` - Get category by ID
- PUT `/api/Categories/{id}` - Update category
- DELETE `/api/Categories/{id}` - Delete category

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- ASP.NET Core team for the excellent framework
- All contributors who help improve this project 