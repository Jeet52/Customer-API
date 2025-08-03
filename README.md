# Building a Customer REST API with C# and CI/CD Deployment via GitHub Actions

---

## 📄 Project Overview

This week-long project helped me learn how to build a RESTful Web API using C# and ASP.NET Core, then deploy it to the cloud with automated CI/CD using **GitHub Actions**. I connected the API to an Azure SQL Database, managed source control with Git and GitHub, and deployed the app to Azure App Services using GitHub’s powerful workflow automation. Development was done in Visual Studio Code.

---

## 🎯 What I Accomplished

- Created a Customer REST API with full CRUD functionality (Create, Read, Update, Delete)  
- Connected the API to an Azure SQL Database for secure data storage  
- Developed locally using Visual Studio Code and .NET 8 SDK  
- Used Git and GitHub for version control and repository hosting  
- Set up GitHub Actions workflows to automate build, test, and deployment to Azure App Services  
- Tested the live API endpoints with Swagger UI and Postman  

---

## 🧰 Tools & Technologies I Used

- **Languages & Frameworks:** C#, .NET 8, ASP.NET Core Web API  
- **Database:** Azure SQL Database  
- **IDE:** Visual Studio Code  
- **Version Control:** Git and GitHub  
- **CI/CD:** GitHub Actions  
- **Hosting:** Azure App Services  
- **Command Line:** Azure CLI for managing Azure resources  

---

## 🧑‍💻 How I Built This Project

### Day 1-2: Local Setup & API Development

- Installed all required tools (.NET SDK, VS Code, Azure CLI, Git)  
- Created a new ASP.NET Core Web API project using `dotnet new webapi`  
- Defined the `Customer` data model with properties Id, Name, Email, and Phone  
- Configured Entity Framework’s DbContext to connect to Azure SQL Database  
- Scaffolded the CustomersController with all CRUD endpoints  
- Ran the API locally and tested endpoints using Swagger UI  

### Day 3: Version Control with GitHub

- Initialized a Git repository locally and committed all code  
- Created a GitHub repository and pushed my code to it  

### Day 4-5: GitHub Actions for CI/CD

- Created an Azure App Service to host the API  
- Added a GitHub Actions workflow YAML file (`.github/workflows/dotnet.yml`) to:  
  - Restore dependencies  
  - Build the project  
  - Run tests (if any)  
  - Publish and deploy to Azure App Service automatically on push to main branch  
- Committed and pushed the workflow file to trigger the automated pipeline  
- Monitored the GitHub Actions runs and verified successful deployment  

### Day 6: Testing & Validation

- Tested API endpoints (GET, POST, PUT, DELETE) using Postman and the live Swagger UI  
- Verified data persistence by querying the Azure SQL Database  

### Day 7: Documentation & Presentation

- Documented the entire process in this README  
- Captured screenshots from VS Code, Swagger UI, GitHub Actions workflows, and Azure Portal  
- Prepared presentation slides summarizing the project  

---

## 🔍 What I Learned

- Building REST APIs with ASP.NET Core and C#  
- Integrating Azure SQL Database with .NET applications  
- Source control workflows with Git and GitHub  
- Automating CI/CD pipelines using GitHub Actions  
- Deploying and managing apps in Azure App Services  
- API testing with Swagger UI and Postman  

---

## 🚀 Running the Project Locally (Quick Guide)

1. Clone the repo and open it in VS Code  
2. Install .NET SDK and other tools  
3. Configure `appsettings.json` with your Azure SQL connection string  
4. Run the API locally:  
   ```bash
   dotnet run
5. Open https://localhost:5001/swagger to explore the API

📡 API Endpoints
HTTP Method	Endpoint	Description
GET	/api/customers	Retrieve all customers
GET	/api/customers/{id}	Retrieve customer by ID
POST	/api/customers	Create a new customer
PUT	/api/customers/{id}	Update customer by ID
DELETE	/api/customers/{id}	Delete customer by ID
🎤 Final Thoughts
This project gave me hands-on experience working with modern cloud and DevOps tools. Setting up GitHub Actions for CI/CD helped me automate deployment smoothly, and deploying the API to Azure App Service was a big confidence boost. I’m excited to use these skills in upcoming internships and projects!
Feel free to reach out if you want to know more or collaborate!
