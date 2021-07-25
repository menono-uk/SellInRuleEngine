# Rules Engine
![build](https://github.com/menono-uk/SellInRuleEngine/tree/main/InventoryCalculator/)


## Overview
Rules Engine is a .net core library for applying business logic/rules/policies to a supemarket's inventory. It's purpose is to update an item's daily quality and sell in values. The library works as a Rules Engine, applying a set of compile time rules objects to a list of inventory data.

## Installation

not applicable

## How to use it

A Visual Studio .Net Core solution (2019 v 16.9 or higher) has been created to allow the functionality to be run and tested.  The solution consisting of a Unit Test project of prexisting developent tests. A 'bare bones' Web API service (no https/client authentication etc.. is required to use it) to test/run the Library;s functionality as a simple web service.  To run the service, the simplest way is to load the solution using Visual Studio and run it on IISExpress.  The service can then be consumed using Postman POST requests with json test data setg in the request body (see example beloe):

Example json request:

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
T
The libary is an implementation of a Rules Pattern.  Using predefined set of rules which are loaded dunamically from the libarary at runtime.

## Contributing

Not applicable


