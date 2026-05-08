# 🧠 Class 2 – Abstract Classes and Interfaces

Trainer: `Ilija Mitev` <br>
Contact: `ilija.mitev3@gmail.com`

---

## 📌 AGENDA

- What are abstract classes  
- Difference between abstract and standard classes  
- Inheritance with abstract classes  
- What are interfaces  
- Difference between abstract class and interface  

---

# Abstract Classes and Interfaces 🍕

Since C# is an object-oriented language, it was built with classes and objects in mind and they are the main building blocks that we can use to build applications. That is why there are a lot of different keywords that are used for specializing classes for a particular purpose as well as different entities that are not classes, but support and build upon classes. With all these features, an ecosystem is created where it is easier to develop object-oriented applications, structure and organize them.

🤖
```
Explain abstract classes and interfaces in C# in simpler terms.
```

---

## Abstract Classes 🔹

### Why we need it

When using object-oriented programming to translate some business logic concept, there are situations where we need a class that exists in our logic to support other concepts, but has very little meaning by itself. Usually, a class like this represents some base or core idea that other ideas can easily implement on, getting the name base classes. An example would be a Company App with a Human class that implements Employee and Manager classes. We need Employees and Managers, they share a lot of human behavior and properties, so we add the Human class as a parent, but the Human class only exists to support the other classes.

🤖
```
Give me more real-world examples similar to Human -> Employee/Manager.
```

---

### What is it

In C# there is a special class that can make cases like these easier to implement. It's called an Abstract Class. Abstract classes are classes that can have an implementation, they can have methods, properties, constructors but they can't be instantiated. This means that we can't create a new instance out of the class with the new keyword. Now the question is, how can we use it then? Well, we can inherit from it and use it as a base class for our other classes,  without the risk of someone creating a class from it, that makes little sense. Abstract classes can also have abstract members.

🤖
```
Explain abstract classes with a real-world analogy.
```

---

#### Abstract class with abstract member

```csharp
public abstract class Human
{
  public string FullName { get; set; }
  public int Age { get; set; }
  public long Phone { get; set; }
  public abstract string GetInfo();
  public Human(string fullname, int age, long phone)
  {
    FullName = fullname;
    Age = age;
    Phone = phone;
  }
  public void Greet(string name)
  {
    Console.WriteLine($"Hey there {name}! My name is {FullName}!");
  }
}
```

🤖
```
What happens if I remove the abstract keyword from GetInfo()?
```

```
Why does the child class have to override this method?
```

---

#### Standard class implementing the abstract one

```csharp
public class Developer : Human
{
  public List<string> ProgrammingLanguages { get; set; } = new List<string>();
  public int YearsExperience { get; set; }

  public void Code()
  {
    Console.WriteLine("tak tak tak...");
    Console.WriteLine("*Opens Stack Overflow...");
    Console.WriteLine("tak tak tak tak tak...");
  }

  public Developer(string fullname, int age, long phone, List<string> languages, int experience ) 
    : base(fullname, age, phone)
  {
    ProgrammingLanguages = languages;
    YearsExperience = experience;
  }

  public override string GetInfo()
  {
    return $"{FullName} ({Age}) - {YearsExperience} years of experience!";
  }
}
```

🤖
```
What happens if I don't override GetInfo() here?
```

```
Why do we use base(...) in the constructor?
```

---

#### Instances

```csharp
Human person = new Human(); 
Developer dev = new Developer("Bob Bobsky", 44, 38970070070, new List<string>() { "JavaScript", "C#", "HTML", "CSS" }, 6);
```

🤖
```
Why can't we create an instance of Human?
```

---

### Features and comparison

Abstract classes can be inherited from, but not instantiated...

🤖
```
When would I use an abstract method vs a normal method?
```

---

### Abstract class vs Standard class

| Feature                        | Abstract Class | Standard Class |
|--------------------------------|----------------|----------------|
| Constructors                   | Yes            | Yes            |
| Instantiation                  | No             | Yes            |
| Method implementation          | Yes            | Yes            |
| Members without implementation | Yes            | No             |
| Inheritance                    | Yes            | Yes            |
| Multiple Inheritance           | No             | No             |
| Access Modifiers               | Yes            | Yes            |

🤖
```
Give me a real scenario where abstract class is better than standard class.
```

---

## Interfaces 🔹

When we talk about an abstract class we basically create an abstraction that will help us manage our standard classes better...

🤖
```
Explain interfaces in simple terms with analogy.
```

---

### Where are they used

Interfaces are used to set rules for classes...

🤖
```
Why would we use interfaces instead of concrete classes?
```

---

#### Interfaces

```csharp
public interface IDeveloper
{
  void Code();
}
public interface ITester
{
  void TestFeature(string feature);
}
```

🤖
```
What happens if a class implements this interface but does not implement all methods?
```

---

#### Inheriting from interfaces

```csharp
public class QAEngineer : Human, IDeveloper, ITester
{
  public List<string> TestingFrameworks { get; set; }

  public void Code()
  {
    Console.WriteLine("tak tak tak...");
  }

  public override string GetInfo()
  {
    return $"{FullName}";
  }

  public void TestFeature(string feature)
  {
    Console.WriteLine($"Tests for {feature}");
  }
}
```

🤖
```
Why can a class inherit from multiple interfaces but not multiple classes?
```

---

#### Using interface as parameter

```csharp
public void HappyBirthday(IHuman person)
{
    Console.WriteLine($"This is {person.GetInfo()}!");
}
```

🤖
```
Why is it better to use interface as parameter instead of concrete class?
```

---

## Interface vs Abstract class

| Feature                        | Interface | Abstract Class |
|--------------------------------|-----------|----------------|
| Constructors                   | No        | Yes            |
| Instantiation                  | No        | No             |
| Method implementation          | No        | Yes            |
| Members without implementation | Yes       | Yes            |
| Inheritance                    | Yes       | Yes            |
| Multiple Inheritance           | Yes       | No             |
| Access Modifiers               | No        | Yes            |

🤖
```
Give me a scenario where interface is better than abstract class and vice versa.
```

---

# Boxing vs Unboxing

Boxing and Unboxing are processes in C# used to convert between value types...

🤖
```
Why do we need boxing and unboxing in C#?
```

---

## Boxing

```csharp
int number1 = 9000;
object obj1 = number1;
Console.WriteLine(obj1);
```

---

## Unboxing

```csharp
object obj2 = 9000;
int number2 = (int)obj2;
Console.WriteLine(number2);
```

🤖
```
What happens if I try to unbox to the wrong type?
```

---

## Notes

- Casting does NOT change value  
- Converting attempts to change value  
- Casting works only if valid  

🤖
```
Explain difference between casting and converting with examples.
```

---

# 🧪 EXERCISE

Create:

- Interface IUser  
  - Id  
  - Name  
  - Username  
  - Password  
  - PrintUser() - Prints Id, Name and Username  

- Interface IStudent  
  - Grades  
  - Override PrintUser() to show grades  

- Interface ITeacher  
  - Subject  
  - Override PrintUser() to show subject  

---

Create:

- Abstract class User and inherits from IUser  
- Class Student that inherits from User and IStudent  
- Class Teacher that inherits from User and ITeacher  

---

Create:

- 2 teacher objects  
- 2 student objects  

---

Call:

```
PrintUser()
```

---

🤖
```
How should I approach designing this step by step without writing full code?
```

```
What classes and responsibilities should I define first?
```

```
What are common mistakes when combining abstract classes and interfaces?
```

---

# ❓ Questions?

You can find us at  
trainer@mail.com  
