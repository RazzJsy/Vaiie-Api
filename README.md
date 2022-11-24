
# Vaiie-Demo Api Technical Challenge

This is an Azure Functions solution created using .Net6 to meet the specified requirements laid out in the provided brief.

The application is made up of 3 Projects (Api, Data, Rules) with each specific project allowing for easy separation of responsibilities within the solution.

## Installation

Once you have cloned the repository and loaded the Vaiie.sln ensure that: 

- All required references / packages have installed correctly
- 'Api' project is set be the Startup Project

## Running Api

From inside IDE run the appliction and the Api should load running on Port: 7221

The endpoint can be communicated with by navigating to /api/validate. 

An example of the url might be: http://localhost:7221/api/validate

Using an external application to test Api's (i.e. [Postman](https://www.postman.com/)) load the files found at the root of the Solution folder (data_good.json and data_bad.json) into the body of a POST request.

If successful the Api should response with either and empty object or an object containing a list of errors encountered and related entities