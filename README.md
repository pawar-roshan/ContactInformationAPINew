1. Download soruce code from the repository
2. Execute attached SQL query at database server.
3. Change data source name in connection string in app.config file present in DataAccessLayer project and also in web.config file present in ConatctInformationAPI project.

After performing above steps we are ready to test the application.


------------

BusinessLayer is a class library project that has business logic.In case if data manipulation is required we can do that in this layer

ContactInformationAPI is a web application Project-
Added ContactController
IOC folder has code for depedency injection that i have impleted using Unity container.

Provider folder has code for token based authentication that is implemented using OWIN middlware.

Added Startup.cs file that has code for OWIN

DataAccessLayer- this project contains code for accesing data

ContactInformationTest-this is a unit test project. I have used Moq framework for testing. Sorry to say i could not implement unit test cases for all the methods in controller due to lack of time.

I have used phone number as int in database which should have been string. Could not make changes to update it to string due to lack of time.

---


API	Description
//First get token from below api and pass it to the subsequent requests.
Get api/contact/token

GET api/contact/getContacts

GET api/contact/getContact/{id}	

POST api/contact/addcontact	


PUT api/contact/updateContact/{id}	


DELETE api/contact/deleteContact/{id}
