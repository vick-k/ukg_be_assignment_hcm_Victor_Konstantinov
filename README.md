# 👥 Human Capital Management App

A role-based ASP.NET Core MVC application for managing people records within an organization.

---

## 📖 About the Project

The **Human Capital Management App** is designed to store and manage **people records**.

It offers full CRUD operations for:
- **People**
- **Departments** (admin only)
- **Job Titles** (admin only)

### 🔐 Role-Based Permissions

- **Employee**  
  - Can view *only their own* profile.

- **Manager**  
  - Can view and edit *all people in their department*.

- **HR Admin**  
  - Has full access to *all people records*, *departments*, and *job titles*.

The app features a login module with pre-defined user roles and access control through ASP.NET Core's Identity system.

---

## 🛠 Tech Stack

- **Language:** C# (.NET 8)
- **Framework:** ASP.NET Core (MVC)
- **ORM:** Entity Framework Core
- **Database:** MS SQL Server
- **Frontend:** Razor Views, Bootstrap

---

## 🚀 Getting Started

### 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MS SQL Server](https://www.microsoft.com/en-us/sql-server)
- IDE (e.g., Visual Studio 2022+, or VS Code with C# extensions)

---

### 📥 Installation

```bash
# Clone the repository
git clone https://github.com/vick-k/ukg_be_assignment_hcm_Victor_Konstantinov.git

# Or download the ZIP
https://github.com/vick-k/ukg_be_assignment_hcm_Victor_Konstantinov/archive/refs/heads/main.zip

```
---

## ⚙️ Setup Instructions

1. Open the solution in Visual Studio or your preferred IDE.

2. Add your connection string in `appsettings.json` under the key **`DefaultConnection`**:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=HCMAppDb;Trusted_Connection=True;"
   }
3. Run the following command to apply EF Core migrations:
   ```bash
   dotnet ef database update
4. Start the application.

---

## 🔐 Login Details

Once the app is running, log in using the seeded administrator account:

- **Username:** `admin`  
- **Password:** `Password1!`

> All other seeded users also use the same password: `Password1!`  
> You can view and manage them from inside the application.
