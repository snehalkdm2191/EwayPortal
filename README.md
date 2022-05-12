# Eway Portal

---

## 1. Setup for Api

These are the instructions to run the project:

1. Run docker.
```bash
docker-compose up -d
```

2. Update database.
```bash
dotnet ef database update
```

3. run sql query in database to get example data.

```bash
insert into ContentGroup
select NEWID() ContentGroupId , cm.ContentId, eg.EmployeeGroupId
from ContentMaster as cm cross join EmployeeGroup as eg
```

4.Add employee data through swagger endpoint. Add eployeegroup id from employeegroup table.

---


## 2. Setup for UI

These are the instructions to run the project:

1. Open the terminal and navigate to the folder where this readme file is located.
2. Install the project dependencies by typing `npm install` on the terminal.
3. Start the project by typing `npm start` on the terminal.

```bash
npm install
npm start
```

---

## 3. Screenshots

Welcome page

![portal-1](https://user-images.githubusercontent.com/72212986/168016130-e32909af-b3fa-4962-b482-3c2f2e300b1b.PNG)

Detail page

![portal-2](https://user-images.githubusercontent.com/72212986/168016213-69bee885-93ee-4cb3-9241-47d91105baf0.PNG)

