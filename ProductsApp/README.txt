http://www.asp.net/web-api/overview/older-versions/build-restful-apis-with-aspnet-web-api
-- older, Visual Studio 2012 tutorial
1. Add ASP.NET WEb application
	Web API
2. Add Empty Controller 

3. Get method -- return an array of strings

4. navigate to http://localhost:36871/api/contact -- was supposed to work out of the box, does not work
-----------------------------------------------

Try the 2013 tutorial, maybe it works
http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api

Create
	Web Application
	Template -- Empty
		Add folders for: Web API
		
	This creates a project structure
		- WebApiConfig
		- App_Start 
			folders

	- Added a model - Product class
	- added a controller - empty Web API controller
		--> Make sure the type is ApiController
	- Get Method has to return something that implements IHttpActionResult
	- The WebApiConfig (created by default makes sure that requests are mapped to)
	/api/{controller}
	or
	/api/{controller}/{id}
	go to: http://localhost:38223/api/products/4		-- or whatever it is by default -- depends on your Visual studio and IIS Express


Routing
1. Attribute routing -- marking the methods with [HttpGet] + route attributes
2. Convention-based routing -- putting the routes in WebApiConfig
3. Can also use a query string, as described here:
	http://stackoverflow.com/questions/31759979/web-api-2-get-by-query-parameter

	
	


TODO:
	- custom parameters
	- custom output
	- stored procedure call