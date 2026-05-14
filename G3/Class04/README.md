# 🧠 Class 4 – Generics and Extension Methods

Trainer - Tijana Stojanovska

---

## 📌 LOOKING BACK AT... 

- What are static classes?  
- Can you use a non static member in a static class?  
- Can you use a static member in a non static class?  
- Give an example of (types of) polymorphism  

🤖
```
Explain static vs non-static members with examples.
```

---

## 📌 AGENDA 

- Introduction to generic methods  
- Introduction to generic classes  
- Extension methods and how to use them  
- Using generics and extension methods to build scalable and reusable code  

---

# Generics and Extension methods 🥪

---

## Generics 🔹

As we know, C# is a strictly typed language...

🤖
```
Why do generics exist in strongly typed languages like C#?
```

---

## INTRODUCTION TO GENERICS 

- Generics are used to create implementation where the type of an entity that we are using is not known yet or is defined as a wider range of types  
- The type will be specified only when the class or method is invoked or instantiated (during runtime)  
- A convention for this placeholder type is the letter T  
- The type can be constraint to a class and it’s inheritance tree  

🤖
```
Explain generics in simple terms with a real-world example.
```

---

### Generic methods

Generic methods work exactly the same as standard methods but have one extra feature...

🤖
```
Why would we use a generic method instead of multiple methods?
```

---

## GENERIC METHODS

- A generic method is defined by adding <T> after the name  
- With that, T can be used as a type anywhere in the method, including the parameters  
- When calling the method, <> brackets are used and T is replaced with the desired type  

---

#### Non generic example

```csharp
public void GoThroughStrings(List<string> strings)
{
    foreach (string str in strings)
    {
        Console.WriteLine(str);
    }
}

public void GoThroughInts(List<int> ints)
{
    foreach (int num in ints)
    {
        Console.WriteLine(num);
    }
}
```

🤖
```
What problem do we see with this approach?
```

---

#### Generic example

```csharp
public static void GoThrough<T>(List<T> items)
{
    foreach (T item in items)
    {
        Console.WriteLine(item);
    }
}
```

🤖
```
How does this method work for different types?
```

---

### Generic classes

Generic classes share the idea of generic code...

🤖
```
When should I use a generic class instead of a generic method?
```

---

## GENERIC CLASSES

- A generic class is defined by adding <T> after the name  
- With that, T can be used as a type anywhere in the method, including the parameters  
- When instantiating the class, <> brackets are used and T is replaced with the desired type  
- A generic class can inherit from another generic class taking the T from the parent  

---

```csharp
public class GenericListHelper<T>
{
    public static void GoThrough(List<T> items)
    {
        foreach (T item in items)
        {
            Console.WriteLine(item);
        }
    }

    public static void GetInfo(List<T> items)
    {
        T first = items[0];
        Console.WriteLine($"This list has {items.Count} members and is of type {items.GetType().FullName}!");
    }
}
```

🤖
```
Why can we use T inside the whole class without redefining it?
```

---

### Using generics within a certain scope

Generic classes and methods can also be used in a certain scope...

🤖
```
Why would we restrict a generic type with constraints?
```

---

```csharp
public abstract class BaseEntity
{
  public int Id { get; set; }
  public abstract string GetInfo();
}
```

---

```csharp
public void PrintAll<T>(List<T> list) where T : BaseEntity
{
  foreach (T item in list)
  {
    Console.WriteLine(item.GetInfo());
  }
}
```

🤖
```
What does "where T : BaseEntity" mean?
```

---

```csharp
public class GenericDb<T> where T : BaseEntity
{
  private List<T> Db;

  public GenericDb()
  {
    Db = new List<T>();
  }

  public void PrintAll()
  {
    foreach (T item in Db)
    {
      Console.WriteLine(item.GetInfo());
    }
  }

  public void Insert(T item)
  {
    Db.Add(item);
    Console.WriteLine($"Item was added in the {item.GetType().Name} Db!");
  }
}
```

🤖
```
Why is this design reusable for multiple entities?
```

---

## Extension methods 🔹

Extension methods are one of the most interesting methods you can use in C#...

🤖
```
Why would we extend an existing type instead of creating a new class?
```

---

## EXTENSION METHODS

- Extension methods are methods that can be "appended" to an existing type without changing its implementation  
- Extension methods ALWAYS reside in a static class and are always static  
- They are called as if they exist in the class that the extension method was appended to  
- This keyword is used before the first parameter  

🤖
```
Why do extension methods require a static class?
```

---

### How to use them

```csharp
public static class StringHelper
{
    public static string Shorten(this string str, int numberOfWords)
    {
        // code
    }

    public static string QuoteString(this string text)
    {
        return '"' + text + '"';
    }
}
```

🤖
```
What does the keyword "this" do in extension methods?
```

---

## THE CONCEPT OF PIGGYBACKING

- Extension methods can be used only if there is a reference to their namespace  
- It is possible to use the extension method together with the type it is extending  
- This is done by changing the namespace  
- This method is called piggybacking  

🤖
```
What are risks of using piggybacking?
```

---

# 🧪 EXERCISE

Create 4 classes:

- Pet (abstract) with Name, Type, Age and abstract PrintInfo()  
- Dog (from Pet) with GoodBoy and FavoriteFood  
- Cat (from Pet) with Lazy and LivesLeft  
- Fish (from Pet) with color, size  

---

Create a PetStore generic class with:

- Generic list of pets  
- Generic method printsPets()  
- BuyPet() method  

---

Create:

- Dog, Cat and Fish store  
- Add 2 pets in each  

---

Execute:

- Buy a dog and a cat  
- Call PrintPets()  

---

🤖
```
How should I break this problem into smaller steps?
```

```
What should be generic and what should not?
```

```
What are common mistakes when using generics?
```

---

# ❓ QUESTIONS?

You can find us at  
stojanovska_tijana@outlook.com 
