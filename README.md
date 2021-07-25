# Automate Inventory Management
![build](https://github.com/menono-uk/SellInRuleEngine.git)


## Overview
The QualityCalculator library is a .Net Core 3.1 library for applying business rules/policies to a supemarket's inventory. It's purpose is to automate the process of updating an inventory item's quality and sell in values on a daily basis. The library is based on a simple Rules Engine architecture consisting of an engine that manages a collection of rules objects and applies them to the inventory data. 

## Installation

not applicable

## How to use it

This repository is a Visual Studio .Net Core solution (requires 2019 v16.9 or higher) which has been created to allow the QualityCalculator library to be run and tested.  The solution consisting of a Unit Test project of prexisting developent tests. A 'bare bones' Web API service (no https/client authentication etc.. is required to use it) for end-to-end testing through a web service.  To run the service, the simplest way is to load and run the solution in Visual Studio/local IISExpress. The service can then be consumed using Postman.  A postman collection file is included with the repository root directory (InventoryTest.postman_collection.json).  Call to the web service involves a http POST request with test data set in the request body (see example below):

POST http://localhost:6391/itemquality

Example json request body:

[
    {
        "name": "Aged Brie",
        "sellIn": 3,
        "quality": 4
    },
    {
        "name": "INVALID ITEM",
        "sellIn": 4,
        "quality": 3
    }
]

Expected json response:

[
    {
        "name": "Aged Brie",
        "sellIn": 2,
        "quality": 5
    },
    {
        "name": "NO SUCH ITEM",
        "sellIn": 4,
        "quality": 3
    }
]


## How it works
The libary is an implementation of a Rules Pattern.  Using predefined set of rules classes which are loaded dynamically at runtime. The engine then applies the relevant rule to each inventory item and returns the updated inventory data to the client.
 

## Contributing

Not applicable


