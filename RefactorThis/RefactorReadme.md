## Change made

1. framework: .net core 
2. database: use the give .mdf file in localDB
3. Structure: use clean architecture.
4. Model mapping: manual map .
5. Startup: not added. 
6. Exception: use attribute to handle exceptions. 
7. error handling: use FluentValidation to validate models.
9: logging: demo logging in controller.
10: unit test: NA, run out of time.
11: ORM: EF core

## Reasoning and Consideration

1. framework: .net core is more faster than .net framework
2. database: use the give .mdf file in localDB, if needed, can use oncloud SQL db, just need to configure in settings. 
	Another option is use SQLite, but I don't have much knowledge on migrating DB. it may run out of time for the task, if I investigate it.
3. Structure: use clean architecture will be easier to maintain and extend in future.
4. Model mapping: can use automapper. but there's not many classes need to. it will slow down the start and run time. So use manual map instead.
5. Startup: can add startup file in future, if the size increase. 
6. Exception: use attribute to handle exceptions. 
7. error handling: use FluentValidation to validate models.
9: logging: can use Azure App insight to do logging
10: unit test: write unit test for each layer with mock data
11: ORM: use EF core instead of sql statement will be easier to maintain.

## Known issue

1. Since LocalDB is used, it could only run under windows platform for now. To solve the limitation, either use docker or SQLite to make it adapt to Linux platform.
2. No unit testing.
3. response is the db entity, shall use models. If got more time, can define request and response classes for each endpoint.
4. better logging via adding more error/ debug/info logs .

Becasue I've already used 4 hours, so stop it from here.

## Run project

Before you run the project, Please config your code physical path in Program.cs line 23, ex:

var contentRootPath = "C:\\Users\\HelenaL\\Downloads\\RefactorThis\\RefactorThis";