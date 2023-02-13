# <div align="center">Desktop Application for Warehouse Proccess in Plastics Company</div>

### ⭕The Mission: 

***Target:*** 
 - Design the Application to automatic control the warehouse
 - Tracking all status of product and inventory automatically
 - Communicate with Server of company to store the important data
 

***Scope:*** The application for all small and medium manufacturing company.

### ⭕The Reality:
The company control all data by paper and the worker have to deal with the task by manual action
Disadvantages:
- Lost data
- Missing Materials
- Time-consuming

![alt text](https://github.com/DungNguyen0209/Warehouse_Management_DesktopApp/tree/main/Assert/IMG_1789.jpg =250x250)
![alt text](https://github.com/DungNguyen0209/Warehouse_Management_DesktopApp/tree/main/Assert/Reality.png =250x250)

### ⭕Solution and design Model:
After the survey in factory in two month. I have the design for the database to store the information in all process. It must start from mini item to the fully item.
Moreover, The database should have clear phase.

![alt text](https://github.com/DungNguyen0209/Warehouse_Management_DesktopApp/tree/main/Assert/uml.png =250x250)

### ⭕Main design of Application:
**Application Architecture**: MVVM
The App is seperate to three mini project:
- WarehouseManagementDesktopApp: Contains all UI page and the custom component
- WarehouseManagementDesktopApp.Core: Contains the main logic to execute of project
- Infrastructure.SqliteDB: Contains all infrastructure to store data at SQLite

**Pattern**: IOC Container
Using: using Microsoft.Extensions.DependencyInjection
- Control all life cycle of any View Model
- Automatic dependency inject by the library

![alt text](https://github.com/DungNguyen0209/Warehouse_Management_DesktopApp/tree/main/Assert/IOC.png =250x250)


### 💻Techniques: C#, WPF, MVVM, Entity Framework, XML, SignalR EPPLus library, Restfull API, IOC

#### 📰 Document by myself: <a href="https://docs.google.com/document/d/13omfPOKXVdKNevfmOzXdDiz1iWZ8hwlh/edit" target="_blank">Warehouse management Application document</a>

#### 🔗 Demo: <a href="https://www.youtube.com/watch?v=L_-mhe4PxEY" target="_blank">Product_Vertification_DesktopApp</a>
