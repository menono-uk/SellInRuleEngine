# Automate Inventory Management
![build](https://github.com/menono-uk/SellInRuleEngine.git)


## Overview
The QualityCalculator library is a .Net Core 3.1 library for applying business rules/policies to a supemarket's inventory data. It's purpose is to update an item's quality and sell in values on a daily basis. The library is a simple Rules Engine that applies a set of rules classes implemented in the library. These are loaded at runtime into a rules engine which then applies the relevant rules to a list of inventory data and returns the updated inventory.

## Installation

not applicable

## How to use it

This is a Visual Studio .Net Core solution (requires 2019 v16.9 or higher) which has been created to allow the functionality to be run and tested.  The solution consisting of a Unit Test project of prexisting developent tests. A 'bare bones' Web API service (no https/client authentication etc.. is required to use it) to test/run through a web service.  To run the service, the simplest way is to load the solution into Visual Studio and run it on IISExpress. The service can then be consumed using Postman.  A postman collection file is included with the project root directory (InventoryTest.postman_collection.json).  Call to the web service involves a http POST request with test data set in the request body (see example beloe):

POST http://localhost:6391/itemquality

Example json request body:

[
    {
        "name": "Aged Brie",
        "sellIn": 3,
        "quality": 4
    },
    {
        "name": "Aged Brie",
        "sellIn": -1,
        "quality": 0
    },
    {
        "name": "NO SUCH ITEM",
        "sellIn": 4,
        "quality": 3
    }
]


## How it works
The libary is an implementation of a Rules Pattern.  Using predefined set of rules classes which are loaded dynamically at runtime. 

## Contributing

Not applicable


