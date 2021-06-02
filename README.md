**Get All People**
----
  Returns json data for all people in the database.
* **URL**
  /api/people
* **Method**
  `GET`
* **URL Parameters**
  `None`
* **Data Parameters**
  `None`
*	**Successful Response**
  *	**HTTP Status Code** 200 <br />
    **Content:** 
```json
[
    {
        "id":1,
        "firstName":"Jack",
        "lastName":"Cat",
        "address":"127 Elm Street",
        "age":9,
        "interests": [
            {
                "id":1,
                "person_Id":1,
                "value":"Sleeping"
            }
        ]
    }
]
```
*	**Error Response**
  * **HTTP Status Code** 404 Not Found

Or

*	**HTTP Status Code** 400 Unauthorized
*	**Sample Call:**
```/api/people```

**Get Person by Id**
----
  Returns json data for the person with the Id provided in the URL.
* **URL**
  /api/people/{id}
* **Method**
  `GET`
* **URL Parameters**
  Id must be an integer
*	**Data Parameters**
  None
* **Success Response**
  *	**HTTP Status Code** 200 <br />
    **Content:**
```json
[
    {
        "id": 1,
        "firstName": "Jack",
        "lastName": "Cat",
        "address": "127 Elm Street",
        "age": 9,
        "interests": [
            {
                "id": 1,
                "person_Id": 1,
                "value": "Sleeping"
            }
        ]
    },
    {
        "id": 2,
        "firstName": "Jamie",
        "lastName": "Prugh",
        "address": "124 Rocky Brook Road",
        "age": 8,
        "interests": [
            {
                "id": 2,
                "person_Id": 2,
                "value": "Eating"
            },
            {
                "id": 3,
                "person_Id": 2,
                "value": "Running"
            },
            {
                "id": 4,
                "person_Id": 2,
                "value": "Playing"
            }
        ]
    }
];
```

* **Error Response**
  *	**HTTP Status Code** 404 Not Found

Or

  *	**HTTP Status Code** 400 Unauthorized
*	**Sample Call**
```/api/people/1```

**Get Person by Name**
----
  Returns json data for the people with a first or last name that matches the provided name in the URL.
* **URL**
  /api/people/{name}
*	**Method**
  `GET`
* **URL Parameters**
  Name must be alphanumeric
* **Data Parameters**
  None
* **Success Response**
* **HTTP Status Code** 200 <br />
  **Content:**
```json
[
    {
        "id":4,
        "firstName":"Geoff",
        "lastName":"Jack",
        "address":"5 Elm Court",
        "age":87,
        "interests": [
            {
                "id":7,
                "person_Id":4,
                "value":"Reading",
                "person": {
                    "id":4,
                    "firstName":"Geoff",
                    "lastName":"Jack",
                    "address":"5 Elm Court",
                    "age":87,
                    "interests": []
                    }
             }
         ]
    }
];
```
*	**Error Response**
  *	**HTTP Status Code** 404 Not Found

Or

  *	**HTTP Status Code** 400 Unauthorized
*	**Sample Call**
```/api/people/geoff```

**Create Person**
----
  Creates a person based on the provided parameters and data, returns that object wrapped in an HTTP Status Code
*	**URL**
  /api/people
*	**Method**
  `POST`
*	**URL Parameters**
  None
*	**Data Parameters**
  Data must be formatted as such:
```json
{
    "firstName": "alphanumeric string",
    "lastName": "alphanumeric string",
    "address": "alphanumeric string",
    "age": integer,
    "interests" : [
        {
        "value" : "alphanumeric string"
        }
    ]
};
```
*	**Success Response**
  * **HTTP Status Code** 201 <br />
    **Content:**
```json
{
    "firstName": "alphanumeric string",
    "lastName": "alphanumeric string",
    "address": "alphanumeric string",
    "age": integer,
    "interests" : [
        {
            "value" : "alphanumeric string"
        }
    ]
};
```
*	**Error Response**
  *	**HTTP Status Code** 405 Not Found

Or

  *	**HTTP Status Code** 400 Unauthorized
*	**Sample Call**
```json
{
    "firstName": "Glenn",
    "lastName": "Kitten",
    "address": "8579 Water Boulevard",
    "age": 4,
    "interests" : [
        {
            "value" : "Management"
        }
    ]
};
```
