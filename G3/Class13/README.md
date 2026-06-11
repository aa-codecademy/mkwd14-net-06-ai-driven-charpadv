# 🧠 Class 11 – Serializing and Deserializing

Trainer - Tijana Stojanovska 

---

## 📌 LOOKING BACK AT... 

- What was stored on the heap and what on the stack?  
- How would a variable with an instance of a class be stored?  
- How can we dispose classes automatically without calling Dispose()?  

🤖
```text
Explain heap vs stack in simple terms with examples.
```

---

## 📌 AGENDA 

- What is serialization and deserialization?  
- Building our own serializer/deserializer  
- Using NewtonsoftJson  
- Building a DB on file system with json files  

---

# Serializing and Deserializing

---

## WHAT IS SERIALIZATION?

The process of converting a complex structure or object into a simpler format that can be stored or sent somewhere is called serialization.

We serialize objects into a JSON string usually when we need to send them somewhere.

We can also serialize objects into JSON or XML so we can store them locally in a file.

🤖
```text
Why can’t we directly send C# objects between systems?
```

---

## WHAT IS DESERIALIZATION?

Deserialization is the reverse process of serialization.

It converts a simpler data format into a complex one or an object.

Deserialization is usually used when we receive some data from somewhere and want to convert it into a native object.

It can also be used to convert a JSON or XML file back to an object in our application for further use.

🤖
```text
Explain serialization vs deserialization with real-world example.
```

---

## LIBRARIES THAT EASE THE PROCESS

The process of serializing and deserializing manually can sometimes be complex and long.

That is why we can use libraries that do the converting automatically with a simple call of a method.

Newtonsoft.Json is one of the most popular libraries for serializing/deserializing in .NET.

🤖
```text
Why is using a library better than manual serialization?
```

---

## STRING BUILDER

In C#, the string type is immutable. It means a string cannot be changed once created.

With every concatenation we create a new string object in the heap.

The StringBuilder doesn't create a new object in memory but dynamically expands memory.

🤖
```text
Why is StringBuilder more efficient than string concatenation?
```

---

## SERIALIZATION EXAMPLE

```csharp
Student bob = new Student()
{
    FirstName = "Bob",
    LastName = "Bobsky",
    Age = 40,
    IsPartTime = false
};

string json = JsonConvert.SerializeObject(bob);
```

---

## DESERIALIZATION EXAMPLE

```csharp
Student deserialized = JsonConvert.DeserializeObject<Student>(json);
```

🤖
```text
What happens if JSON structure does not match the class?
```

---

## BUILDING A DB WITH JSON

We can simulate a database using JSON files.

- Serialize objects → save to file  
- Deserialize → read from file  
- Data persists even after app restart  

🤖
```text
What are pros and cons of using JSON as a database?
```

---

## 🧪 EXERCISE 

Create a Dog class with:

- Name  
- Age  
- Color  

---

Let the user input these parameters from a console application.

---

Create a new Dog object from the inputs and write it as a JSON in a new file on the file system.

---

Create a method that reads and prints in the console all the dogs from the txt file.

---

🤖
```text
How should I structure reading and writing JSON step by step?
```

```
Should I store one object or a list of objects in the file?
```

```
What are common mistakes when serializing data to files?
```

---

# ADO.NET (Introduction) 🚠

---

## ADO.NET 🍞

ADO.NET is a library for communicating with databases.

It allows:
- opening connections  
- executing queries  
- reading data  
- closing connections  

🤖
```text
Why would we use ADO.NET instead of an ORM?
```

---

## BASIC FLOW

1. Create connection string  
2. Open connection  
3. Create command  
4. Execute  
5. Read data  
6. Close connection  

---

## CONNECTION EXAMPLE

```csharp
SqlConnection connection = new SqlConnection(connectionString);
connection.Open();

// work

connection.Close();
```

🤖
```text
What happens if we don’t close the database connection?
```

---

## SQL COMMAND EXAMPLE

```csharp
SqlCommand cmd = new SqlCommand();
cmd.Connection = connection;
cmd.CommandText = "select count(*) from Authors";

int result = (int)cmd.ExecuteScalar();
```

---

## SQL INJECTION (IMPORTANT)

❌ BAD:
```csharp
cmd.CommandText = "select * from Authors where Name like '%" + input + "%'";
```

✔️ GOOD:
```csharp
cmd.CommandText = "select * from Authors where Name like '%'+@name+'%'";
cmd.Parameters.AddWithValue("@name", input);
```

🤖
```text
Why is SQL injection dangerous and how do parameters prevent it?
```

---

## TRANSACTIONS

Transactions ensure safe database operations.

- Commit → success  
- Rollback → error  

🤖
```text
When should we use transactions in real applications?
```

---

# ❓ QUESTIONS?

You can find us at  
stojanovska_tijana@outlook.com