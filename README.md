<p align="center">
  <a href="" rel="noopener">
 <img width=200px height=200px src="https://i.imgur.com/6wj0hh6.jpg" alt="Project logo"></a>
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
- [TODO](../TODO.md)
- [Authors](#authors)

## 🧐 About <a name = "about"></a>

This app is for searching through a Treat shop's database of treats to find that flavor you love.

It uses Entity to connect a SQL database containing a many-to-many relationship between treats and flavors, and also uses Identity to log in users and gate specific content behind a login.

## 🏁 Getting Started <a name = "getting_started"></a>

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

To start, you'll need:
1. MySQL Server
2. .NET
3. A MySQL manager, such as MySQL Workbench (optional)
4. A code editor, such as VS Code or Atom (optional)
   

```
Give examples
```

### Installing

1. You'll need .NET Framework and MySQL server installed on your machine.
2. Install the necessary packages by navigating into the Treats directory in your terminal (Powershell works for this) and running `dotnet restore`
3. The {Password} in appsettings.json should be updated to your password for MySQL server.
4. Then, install the database structure. There are three ways to do this:
   * Run the migration using Entity by running `dotnet ef database update` while in the Treats directory.
   * Import the micheal_hansen.sql file included within the Treat.Solution directory using your database manager.
   * Run the following code in a terminal that has mysql running:
```
Give the example
```
  
5. Once the database is installed, `dotnet build` should build the project in a bin/ folder. Alternately, `dotnet run` should make the project viewable in your browser on localhost:5000

## 🎈 Usage <a name="usage"></a>

Assuming the database is installed correctly in MySQL server, the `dotnet run` command should make the app viewable in your brower on localhost:5000

## ⛏️ Built Using <a name = "built_using"></a>

- [MongoDB](https://www.mongodb.com/) - Database
- [Express](https://expressjs.com/) - Server Framework
- [VueJs](https://vuejs.org/) - Web Framework
- [NodeJs](https://nodejs.org/en/) - Server Environment

## ✍️ Authors <a name = "authors"></a>

- [Micheal Hansen](https://github.com/Sudolphus)