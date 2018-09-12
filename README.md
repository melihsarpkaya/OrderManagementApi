# OrderManagementApi
Order Management

INTRODUCTION
OrderManagement api documentation for OrderManagement project.
Allowed HTTPs requests:
PUT     : To create resource 
POST    : Update resource
GET     : Get a resource or list of resources
DELETE  : To delete resource
Description Of Usual Server Responses:
•	200 OK - the request was successful (some API calls may return 201 instead).
•	201 Created - the request was successful and a resource was created.
•	204 No Content - the request was successful but there is no representation to return (i.e. the response is empty).
•	400 Bad Request - the request could not be understood or was missing required parameters.
•	401 Unauthorized - authentication failed or user doesn't have permissions for requested operation.
•	403 Forbidden - access denied.
•	404 Not Found - resource was not found.
•	405 Method Not Allowed - requested method is not supported for resource
REFERENCE
Customer
Represents Customer details.
________________________________________
Customer attributes:
•	id (Number) 
•	name (String) 
•	Surname (String) 
•	Address (String) 
CustomerOrder
Represents Customer details.
________________________________________
CustomerOrder attributes:
•	id (Number) 
•	ReceiptNo (String) 
•	CustomerId (String) 
•	ProductId (String)  
•	Quantity (String) 
•	Price (String) 
Product
Represents Customer details.
________________________________________
Product attributes:
•	id (Number) 
•	Barcode (String) 
•	Description (String) 
•	Quantity (String)  
•	Price (String) 




USE API

Session Start
Post   /SessionManagement
FormBody:
string username

Session End
Delete   /SessionManagement
FormBody: 
Guid guiId

Customer Create
Post   /Customer
FormBody: 
Customer customer
Guid guid

Customer Update
Put   / Customer
FormBody: 
Customer customer
Guid guid

Customer Delete
Delete   / Customer
FormBody: 
int customerId
Guid guid

CustomerOrder Create
Post   /CustomerOrder
FormBody: 
CustomerOrder customerOrder
Guid guid

CustomerOrder Update
Put   / CustomerOrder
FormBody: 
CustomerOrder customerOrder
Guid guid

CustomerOrder Delete
Delete   / CustomerOrder
FormBody: 
int customerOrderId
Guid guid

Product Create
Post   /Product
FormBody: 
Product product
Guid guid

CustomerOrder Update
Put   / Product
FormBody: 
Product product
Guid guid

CustomerOrder Delete
Delete   / Product
FormBody: 
int productId
Guid guid





