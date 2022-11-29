
## Project Structure     
### Micro Services
Two microservices were created in the project. Configured to run on Kestrel server.
- PhoneBook
- PhoneReport
### Database
Postgresql is used as database. Migration configurations were made for Person Service and Report Service. The appsettings.json file of the projects should be edited for the local server.
### Message Broker
RabbitMq was used as the message broker. RabbitMq Default Port : Assumed to run as 5672. RabbitMq server address can be set in appsettings.json file.

## How to Use  
### Run Project
You will need the following tools:
* [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
* [.Net Core  or later](https://dotnet.microsoft.com/download/dotnet-core/5)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)
```sh
docker-compose up -d
``` 
You can **launch microservices** as below urls:
* **PhoneBook API -> http://localhost:8081/swagger/index.html**
* **Reporting API -> http://localhost:8082/swagger/index.html**
### Example of Self Running Requests
#### PhoneBook.Api
- Creating a contact in the phone book
```sh 
curl -X POST "https://localhost:8081/api/persons" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"firstName\":\"string\",\"lastName\":\"string\",\"company\":\"string\",\"contactDetails\":[{\"contactType\":0,\"value\":\"string\",\"personId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}]}"
```
- Deleting a contact in the phone book
```sh 
curl -X DELETE "https://localhost:8081/api/persons/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H  "accept: */*"
```
- Listing the contacts in the phone book 
```sh
curl -X GET "https://localhost:8081/api/persons" -H  "accept: */*"
```
- Adding contact information in the phone book
```sh 
curl -X POST "https://localhost:8081/api/contactdetail" -H  "accept: */*" -H  "Content-Type: application/json" -d "{\"contactType\":1,\"value\":\"string\",\"personId\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"}"
```
- Deleting the contact information from a contact
```sh 
curl -X DELETE "https://localhost:8081/api/contactdetail/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H  "accept: */*"
```
#### Reporting.Api
- List of All Reports
```sh 
curl -X GET "https://localhost:8082/api/reports" -H  "accept: */*"
```
- Listing Reports with Phonebook Contact Id
```sh 
curl -X GET "https://localhost:8082/api/reports/personId/3fa85f64-5717-4562-b3fc-2c963f66afa6" -H  "accept: */*"
 ```
 - Getting Report by Report Id
```sh 
 curl -X GET "https://localhost:8082/api/reports/2c963f66afa6-4562-5717-b3fc-3fa85f64" -H  "accept: */*"
 ```
