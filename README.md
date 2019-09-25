1. Download source code from the repository.
2. Execute SQL query at your end on the database server, SQL query is present in App_Data folder which is available in ContactInformationAPI project. 
3. Change data source name(to what you have at your end) in connection string in app.config file present in DataAccessLayer project and also in web.config file present in ConatctInformationAPI project.

After performing above steps we are ready to test the application.


------------

1. BusinessLayer is a class library project that has business logic.In case if data manipulation is required we can do that in this layer

2. ContactInformationAPI is a web application Project.
Added ContactController
IOC folder has code for depedency injection that I have implemented using Unity container.
Provider folder has code for token based authentication that is implemented using OWIN middlware.
Added Startup.cs file that has code for OWIN.

3.DataAccessLayer- this project contains code for accesing data.

4.ContactInformationTest-this is a unit test project. I have used Moq framework for implementing test cases. Sorry to say I could not implement unit test cases for all the methods in Contact controller due to shortage of time.

5. I should have written models seperately to map outcome of controller methods but could not do it due to shortage of time.

---


Following are the API uris.

//First get token using below api token generation URI and pass it to the subsequent requests for authentication.
Get api/contact/token

GET api/contact/getContacts

GET api/contact/getContact/{id}	

POST api/contact/addcontact	

PUT api/contact/updateContact/{id}	

DELETE api/contact/deleteContact/{id}
