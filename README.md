# number8_coding_challenge
Coding challenge *Sales Taxes* solution in NetCore 3.1

## Description of solution

- Was used swagger UI to test differents inputs
- Was used repository pattern emulating the use of DB with EF in memory
- Was created an unit test for the input of challenge and 3 tests more

## Important
- I assumed that all product must have an unique code, so if one code is used more that onces, the system get the max price of boths to calculate the tax
- The departmentId property must exist in system, so the first step is run Endpoint of Departments that get the information from DB.

## Tests bodies
Input 1
`
{
  "products": [
    {
	  "Code":"book",
      "description": "Book",
      "price": 12.49,
      "isImported": false,
      "departmentID": 1
    },
	{
	  "Code":"book",
      "description": "Book",
      "price": 12.49,
      "isImported": false,
      "departmentID": 1
    },
	{
			  "Code":"cd",
      "description": "Music CD",
      "price": 14.99,
      "isImported": false,
      "departmentID": 4
    },
	{
		 "Code":"chbar",
      "description": "Chocolate bar",
      "price": 0.85,
      "isImported": false,
      "departmentID": 2
    }
  ]
}`

--

Input 2
`
{
  "products": [
    {
	  "Code":"perfume",
      "description": "bootle of perfume",
      "price": 47.50,
      "isImported": true,
      "departmentID": 4
    },
	{
		 "Code":"chbar",
      "description": "Chocolate bar",
      "price": 10,
      "isImported": true,
      "departmentID": 2
    }
  ]
}`

--

Input 3
`
{
  "products": [
    {
	  "Code":"perfume",
      "description": "bootle of perfume",
      "price": 27.99,
      "isImported": true,
      "departmentID": 4
    },
	{
	  "Code":"perfume",
      "description": "bootle of perfume",
      "price": 18.99,
      "isImported": false,
      "departmentID": 4
    },
	{
	  "Code":"headache",
      "description": "Packet of headache",
      "price": 9.75,
      "isImported": false,
      "departmentID": 3
    },	
	{
		 "Code":"chbar",
      "description": "Chocolate bar",
      "price": 11.25,
      "isImported": true,
      "departmentID": 2
    },	
	{
		 "Code":"chbar",
      "description": "Chocolate bar",
      "price": 11.25,
      "isImported": true,
      "departmentID": 2
    }
  ]
}
`


## Dependencies
- Swagger
- EntityFrameworkCore
- xunit