# 🧠 Class 3 – Static Classes, Members and Polymorphism

Trainer: `Ilija Mitev` <br>
Contact: `ilija.mitev3@gmail.com`

---

## 📌 LOOKING BACK AT...

- What are abstract classes?  
- Why would we use abstract classes?  
- What is an interface?  
- What’s the difference between an abstract class and an interface?  

🤖
```
Explain the difference between abstract class and interface in simple terms.
```

---

## 📌 AGENDA 

- Static classes  
- Static class members  
- Simulating DB with a static class  
- Introduction to polymorphism  

---

# Static classes, members and polymorphism 🍔

---

## Static Classes 🔹

Until this point, classes were something that we can create an instance and use whenever we need it...

🤖
```
What is the difference between static and non-static classes in simple terms?
```

---

### Static class with static members

```csharp
public static class TextHelper
{
    public static int CapitalLetterUses = 0;

    public static string CapitalFirstLetter(string word)
    {
        if (word.Length == 0)
        {
            return "Empty String";
        } 
        else if (word.Length == 1)
        {
            return char.ToUpper(word[0]).ToString();
        }
        else
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }

        CapitalLetterUses++;
    }
}
```

🤖
```
Why are all members in a static class also static?
```

```
What happens if I try to create an instance of a static class?
```

---

### Using static class

```csharp
Console.WriteLine(TextHelper.CapitalFirstLetter("bob"));
```

🤖
```
Why don’t we need to create an instance to use this method?
```

---

## STATIC CLASSES 

- Static classes cannot be instantiated  
- Static classes are loaded when the program starts and static constructor is called only once  
- Static classes lifetime is until the program is closed  
- There can’t be multiple instances of a static class  
- Can only contain static members  

🤖
```
Why can static classes be accessed from anywhere in the application?
```

---

## Static Members 🔹

Because a static class has only one instance...

🤖
```
What is the difference between static members and instance members?
```

---

## STATIC MEMBERS (from presentation)

- Non-static classes can have static members  
- Static members can only be accessed from the class itself as it was static  
- An instance of a class can’t use the static members of that class  

🤖
```
Why can't instance objects access static members directly?
```

---

### Standard class with a static method

```csharp
public class Order
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }

  public string Print()
  {
    return $"{TextHelper.CapitalFirstLetter(Title)} - {Description}";
  }

  public static bool IsOrderValid(Order order)
  {
    if (order.Id <= 0 && order.Title == "") return false;
    return true;
  }
}
```

🤖
```
Why is IsOrderValid static but Print is not?
```

---

### Using the standard class and static method

```csharp
Order ord = new Order();
Console.WriteLine(ord.Print());

Order.Print(); // Error

Console.WriteLine(Order.IsOrderValid(ord));

ord.IsOrderValid(ord); // Error
```

🤖
```
Why can we call IsOrderValid on the class but not on the instance?
```

---

## Where to use and not to use static classes

Static classes are very convenient when developers are writing logic that is universal...

🤖
```
When should we avoid using static classes?
```

---

# INTRODUCTION TO POLYMORPHISM

One of the main pillar concepts of object-oriented programming...

🤖
```
Explain polymorphism with a real-world example.
```

---

## Polymorphism 🔹

Polymorphism is one of the base concepts of Object-Oriented programming...

🤖
```
Why do we need polymorphism in OOP?
```

---

### Compile time polymorphism (Method overloading)

```csharp
public static void PetStatus(Dog pet, string ownerName)
{
  Console.WriteLine($"Hey there {ownerName}");
}

public static void PetStatus(string ownerName, Dog pet)
{
  Console.WriteLine($"Hey there {ownerName}. Happy to see you again!");
}

public static void PetStatus(Cat pet, string ownerName)
{
  Console.WriteLine($"Hey there {ownerName}");
}

public static void PetStatus(Cat pet)
{
  Console.WriteLine($"Hey, a cat with no owner.");
}
```

🤖
```
How does the compiler decide which method to call?
```

---

```csharp
PetStatus(sparky, "Bob");
PetStatus("Bob", sparky);
PetStatus(meow, "Jill");
PetStatus(meow);
```

🤖
```
What would happen if two methods had identical signatures?
```

---

### Runtime polymorphism (Method overriding)

```csharp
public class Pet
{
  public string Name { get; set; }

  public virtual void Eat()
  {
    Console.WriteLine("Nom nom nom");
  }
}

public class Dog : Pet
{
  public override void Eat()
  {
    Console.WriteLine("Nom nom noming on dog food!");
  }
}

public class Cat : Pet
{
  public override void Eat()
  {
    Console.WriteLine("Nom nom noming on cat food!");
  }
}
```

🤖
```
What is the difference between virtual and override?
```

---

```csharp
sparky.Eat();
meow.Eat();
```

🤖
```
How does runtime decide which method to call?
```

---

## CUSTOM GETTERS/SETTERS

{ get; set; } is a shorthand for the getter and setter methods...

🤖
```
When would we use custom getters and setters?
```

---

# 🧪 EXERCISE

Create a class called Dog that has:

- Id  
- Name  
- Color  
- Bark() - Prints “Bark Bark”  

Create:

- A static method Validate()  
  - Checks if dog has all 3 properties  
  - Id is not less than 0  
  - Name is 2 characters or longer  

---

Create a static class called DogShelter that has:

- List of Dogs  
- PrintAll() - prints all dogs  

---

Create:

- 3 Dog objects  
- Call Validate() on them  
- Add them to the list  
- Call PrintAll()  

---

🤖
```
How should I approach solving this step by step without writing full code?
```

```
What classes and responsibilities should I define first?
```

```
What are common mistakes when using static classes in this scenario?
```

