<p align="center">
  <a href="" rel="noopener">
 <img width=640px height=423px src="./Treat/wwwroot/img/cinnamon_roll.jpg" alt="Project logo"></a>
</p>

<h3 align="center">Pierre's Treats</h3>
<h4 align="center">Micheal Hansen, 8.14.20</h4>
---

<p align="center"> An app for a Sweet Treat shop.
    <br> 
</p>

## 📝 Table of Contents

- [About](#about)
- [Getting Started](#getting_started)
- [Usage](#usage)
- [Built Using](#built_using)
- [Authors](#authors)

## 🧐 About <a name = "about"></a>

This app is for searching through a Treat shop's database of treats to find that flavor you love.

It uses Entity to connect a SQL database containing a many-to-many relationship between treats and flavors, and also uses Identity to log in users and gate specific content behind a login.

## 🏁 Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

To start, you'll need:
1. MySQL Server [Mac](https://dev.mysql.com/downloads/file/?id=484914)/[Windows](https://dev.mysql.com/downloads/file/?id=484919)
2. [.NET framework](https://dotnet.microsoft.com/download/dotnet-core/2.2)
3. A MySQL manager, such as MySQL Workbench (optional)
4. A code editor, such as VS Code or Atom (optional)

### Installing

1. You'll need .NET Framework and MySQL server installed on your machine.
2. Download the repo by either clicking the download button, or running `git clone https://github.com/Sudolphus/Treat.Solution.git`
3. Install the necessary packages by navigating into the Treats directory in your terminal (Powershell works for this) and running `dotnet restore`
4. The {Password} in appsettings.json should be updated to your password for MySQL server.
5. Then, install the database structure. There are three ways to do this:
   * Run the migration using Entity by running `dotnet ef database update` while in the Treats directory.
   * Import the micheal_hansen.sql file included within the Treat.Solution directory using your database manager.
   * Type the commands as listed in the [micheal_hansen.sql](./micheal_hansen.sql) file into a terminal with my_sql running
6. Once the database is installed, `dotnet build` should build the project in a bin/ folder. Alternately, `dotnet run` should make the project viewable in your browser on localhost:5000

## 🎈 Usage <a name="usage"></a>

Assuming the database is installed correctly in MySQL server, the `dotnet run` command should make the app viewable in your brower on localhost:5000

## ⛏️ Built Using <a name = "built_using"></a>

- [.NET Framwork](https://dotnet.microsoft.com/)
- [MySql Server](https://dev.mysql.com/)
- [Bootstrap](https://getbootstrap.com/)

## ✍️ Authors <a name = "authors"></a>

- [Micheal Hansen](https://github.com/Sudolphus)