# DynamixPostgreSQLHandler

CSharp - Npgsql - PostgreSQL (Dynamic SQL Handler Library )

DynamixPostgreSQLHandler is an SQL Handler for C#  built on top of **Npgsql**  that intends to avoid the hustle of writing the same Connection code and inner lying adapter, data reader code again and again. It is targeted for rapid development and to save time while working with PostgreSQL database using CSharp as the language.



## Framework

- .NET Framework 4.5.1 +
- Npgsql Version 3.2.7.0





## Sample Database

This project will be using the [dvdrental](http://www.postgresqltutorial.com/postgresql-sample-database/) database for the examples.



## Setting things up

1. Download the **dvdrental.zip** file from the above mentioned link
2. Extract the zip file and obtain the **dvdrental.tar** file ( You can also find a copy in the **scripts** folder )
3. Instantiate a database named **dvdrental** in your PostgreSQL Server.
4. Execute the following code or something similar to your environment

```bash
pg_restore -U postgres -n public -d dvdrental dvdrental.tar
```

[Here is a link that might help you to setup your database](http://www.postgresqltutorial.com/load-postgresql-sample-database/)

5. Execute the scripts found under the **scripts/functions** folder
6. You are now ready to roll !!





## Basic Usage 

The examples shown below are using data from the dvdrental database.

You can explore the code yourself and customize it to fit to your needs.



### EXECUTE SQL : Basic

##### C# Code :

```c#
try
{
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    DataTable dtCountries = sqlHandler.ExecuteSQL("SELECT * FROM country;");
}
catch(System.Exception ex)
{
     // HANDLE YOUR EXCEPTION HERE
}
```



### EXECUTE AS SCALAR

#### Execute As Scalar : Using A Function Name

Lets say you have a function as below which returns a count of the number of registered users.

##### Function Definition :

```plsql
CREATE OR REPLACE FUNCTION public.getactorscount(
	)
    RETURNS bigint
    LANGUAGE 'plpgsql'
AS $BODY$
  DECLARE 
          total bigint;
  BEGIN
      SELECT COUNT(*) INTO total FROM actor;
	  RETURN total;
  END
$BODY$;
```

You can simply write a short piece of code like this:

##### C# Code :

```c#
try
{
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    long actorsCount = sqlHandler.ExecuteAsScalar<long>("getactorscount");
}
catch(System.Exception ex)
{
    // HANDLE YOUR EXCEPTION HERE
}
```



#### Execute As Scalar : Using A Function Name And Parameters

Lets say you have a function as below which returns an integer and takes an integer as a parameter.

##### Function Definition :

```plsql
CREATE OR REPLACE FUNCTION public.inventory_held_by_customer(
	p_inventory_id integer)
    RETURNS integer
    LANGUAGE 'plpgsql'
AS $BODY$

DECLARE
    v_customer_id INTEGER;
BEGIN
  SELECT customer_id INTO v_customer_id
  FROM rental
  WHERE return_date IS NULL
  AND inventory_id = p_inventory_id;
  RETURN v_customer_id;
END 
$BODY$;
```

##### C# Code :

```c#
try
{
    // DEFINE YOUR LIST OF PARAMETERS AS FOLLOWS
    List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
    lstParams.Add(new KeyValuePair<string, object>("p_inventory_id", inventoryID));

    // EXECUTE THE HANDLER CODE AS SHOWN BELOW
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    int customerID = sqlHandler.ExecuteAsScalar<int>("inventory_held_by_customer", lstParams);
}
catch(System.Exception ex)
{
    // HANDLE YOUR EXCEPTION HERE
}
```



------



### EXECUTE AS LIST

#### Execute As List : Using SQL Query

Say you want to extract a list of cities from your database into your Info class.

##### City Table Sample :

![Cities Table](/images/cities_data.PNG)

Your Class file might look as shown below (Following the Lower Case Convention for PostgreSQL)

##### Class Name : City.cs

```c#
public class City
{
    public int city_id { get; set; }

    public string city { get; set; }

    public int country_id { get; set; }
    
    public DateTime last_update { get; set; }
}
```

##### C# Code :

```c#
try
{
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    List<City> lstCities = sqlHandler.ExecuteAsListUsingQuery<City>("SELECT * FROM city;");
    // <---- THAT WAS AS EASY AS A PIECE OF CAKE HUHH !!
}
catch(System.Exception ex)
{
     // HANDLE YOUR EXCEPTION HERE
}
```

##### Output :

![Cities Data output](/images/coutput.png)





#### Execute As List : Using Function Name

If you want to extract a list of records from your database using just the function name. There is a simpler way for achieving that.

Lets say you have a table with a list of actors :

##### Function Definition :

```plsql
CREATE OR REPLACE FUNCTION getactors(
	)
    RETURNS SETOF actor 
    LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
RETURN query execute 'select * from actor;';
END
$BODY$;
```



##### Actor Table Sample :

![Actors](/images/actortable.png)

The first thing you do is create a class for the Actor table like the following :

##### **Class Name : Actor.cs**

```c#
public class Actor
{
    public int actor_id { get; set; }
    
    public string first_name { get; set; }
    
    public string last_name { get; set; }
    
    public DateTime last_update { get; set; }
}
```

##### C# Code :

```c#
try
{
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    List<Actor> lstActors = sqlHandler.ExecuteAsList<Actor>("getactors");
}
catch(System.Exception ex)
{
     // HANDLE YOUR EXCEPTION HERE
}
```

**Output :**

![Actors Data output](/images/actors_data_output.png)



#### Execute As List : Using Function Name And Parameters

Extracting a list of data using parameters 

##### Function Definition :

```plsql
CREATE OR REPLACE FUNCTION getinventory_by_filmid_and_storeid(
	p_film_id integer,
	p_store_id integer
	)
    RETURNS SETOF inventory
    LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    RETURN QUERY (select * from inventory WHERE film_id = p_film_id AND store_id = p_store_id);
END
$BODY$;
```

##### Inventory Table Sample :

![Inventory Data](/images/inventory_data.png)

##### Class Name : Inventory.cs

```c#
public class Inventory
{
    public int inventory_id { get; set; }
    
    public int film_id { get; set; }
    
    public int store_id { get; set; }
 
    public DateTime last_update { get; set; }
}
```

##### C# Code :

```c#
try
{
     
    // DEFINE YOUR LIST OF PARAMETERS AS FOLLOWS
    List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
    lstParams.Add(new KeyValuePair<string, object>("p_film_id", sample_film_ID));
    lstParams.Add(new KeyValuePair<string, object>("p_store_id", sample_store_ID));
       
    // EXECUTE THE HANDLER CODE AS SHOWN BELOW
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    List<Inventory> lstInventories = sqlHandler.ExecuteAsList<Inventory>("getinventory_by_filmid_and_storeid, lstParams);
}
catch(System.Exception ex)
{
    // HANDLE YOUR EXCEPTION HERE
}
```

##### Output :

![Inventory data output](/images/inventory_data_output.png)



### EXECUTE AS OBJECT

#### Execute As Object : Using SQL Query

If you wish to get a single object from the database. That is when you use the Execute as Object method.

Lets say, you wish to extract the detail related to one specific film.

##### Class Name : Film.cs

```c#
public class Film
{
    public long film_id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int release_year { get; set; }
    public int language_id { get; set; }
    public int rental_duration { get; set; }
    public decimal rental_rate { get; set; }
    public int length { get; set; }
    public decimal replacement_cost { get; set; }
    public string rating { get; set; }
    public DateTime last_update { get; set; }
    public string[] special_features { get; set; }
    public object fulltext { get; set; }
}
```

**C# Code :**

```c#
try
{      
    // EXECUTE THE HANDLER CODE AS SHOWN BELOW
    string query = "SELECT * FROM film WHERE film_id = 384;";
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    Film film= sqlHandler.ExecuteAsObjectUsingQuery<Film>(query);
}
catch(System.Exception ex)
{
    // HANDLE YOUR EXCEPTION HERE
}
```

##### Output :

![Film Data Output](/images/film_data_output.png)





#### Execute As Object : Using Function And Parameters

If you wish to get a single object from the database. That is when you use the Execute as Object method.

Lets say, you wish to extract the detail related to one specific film.

**Function Definition :**

```plsql
CREATE OR REPLACE FUNCTION getactor_detail_by_id(p_actor_id integer)
      RETURNS SETOF actor LANGUAGE 'plpgsql' AS $BODY$
BEGIN
    RETURN QUERY (SELECT * FROM actor WHERE actor_id = p_actor_id );
END
$BODY$;
```

##### Class Name : Actor.cs  (Same as above in the Execute As List : Using Function Name section)

**C# Code :**

```c#
try
{      
    int actor_id = 1;
    List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
    lstParams.Add(new KeyValuePair<string, object>("p_actor_id", actor_id));

    // EXECUTE THE HANDLER CODE AS SHOWN BELOW
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    Actor actor = actor = sqlHandler.ExecuteAsObject<Actor>("getactor_detail_by_id", lstParams);
}
catch(System.Exception ex)
{
    // HANDLE YOUR EXCEPTION HERE
}
```

##### Output :

![Actors](/images/acData.png)





### EXECUTE NON QUERY

#### Execute Non Query : Using Function And Parameters

Suppose you wish to insert a new actor in the actor table by passing in parameters to your function.

##### Function Definition :

```plsql
CREATE OR REPLACE FUNCTION add_new_actor(fname character varying(45),lname character varying(45))
    RETURNS VOID AS
$$
BEGIN
    INSERT INTO actor (first_name,last_name) values(fname, lname);
END
$$
    LANGUAGE 'plpgsql';
```

##### Class Name : Actor.cs  (Same as above in the Execute As List : Using Function Name section)

##### C# Code :

```c#
try
{      
    string firstName = "Ozesh";
    string lastName = "Thapa";
    List<KeyValuePair<string, object>> lstParams = new List<KeyValuePair<string, object>>();
    lstParams.Add(new KeyValuePair<string, object>("fname", firstName));
    lstParams.Add(new KeyValuePair<string, object>("lname", lastName));

    // EXECUTE THE HANDLER CODE AS SHOWN BELOW
    SQLHandler sqlHandler = new SQLHandler("ConnectionString");
    sqlHandler.ExecuteNonQuery("add_new_actor", lstParams);
}
catch(System.Exception ex)
{
    // HANDLE YOUR EXCEPTION HERE
}
```



There are lots and lots of other ways to perform CRUD operations using this library.





## Platform

- Windows