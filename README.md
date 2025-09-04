🎬 MovieSelect API

A RESTful API for managing movies and genres. Built with C# (ASP.NET Core Web API) using in-memory data storage. This project was developed as a school assignment and demonstrates backend development skills such as API design, routing, and CRUD operations.


🚀 Features

Manage movies and genres with full CRUD operations.

Retrieve movie details by ID.

Search and filter movies by title, genre.

In-memory data storage (no external database required).

API tested with Postman.


🛠️ Tech Stack

Language/Framework: C# (ASP.NET Core Web API)

IDE: Visual Studio

Data Storage: In-Memory Collection (InMemoryDatabase.cs)

Testing: Postman / .http file inside solution

Configuration: appsettings.json

📂 Project Structure 

<img width="600" height="400" alt="Screenshot 2025-09-04 114430" src="https://github.com/user-attachments/assets/04fb1695-80e2-40ea-a456-0f08b8e0c867" />


⚙️ Getting Started

Clone the repository

git clone https://github.com/Dera-25/MovieSelectProject.git
cd MovieSelectProject


Open in Visual Studio

Open the .sln file in Visual Studio.

Run the project

Press F5 or use dotnet run.

The API will be available at:

https://localhost:7039/api/movies
https://localhost:7039/api/genres


Test with Postman

Example: GET https://localhost:7039/api/movies

📸 Screenshots with API Endpoints

<img width="658" height="849" alt="Screenshot 2025-09-04 112239" src="https://github.com/user-attachments/assets/f22a2813-bfca-4b2e-bdf7-1ae799583baa" />


📌 Future Improvements

Add persistence with a real database (SQL Server, PostgreSQL, or MongoDB).

Implement authentication and role-based access (Admin/User).

Add pagination and sorting for large datasets.

👨‍💻 Author

Chidera Nnamani

GitHub: @Dera-25

Email: deranoel25@gmail.com
