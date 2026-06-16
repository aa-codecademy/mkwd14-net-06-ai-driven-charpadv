# 🧠 Class 14 – C# Conventions, Practices, and Principles

Trainer - Tijana Stojanovska  

---

# C# Conventions, Practices, and Principles

---

## Good Practices 🚀

In C# as in any other language, there are some Good Practices or Invisible Rules that we need to follow for our code to be better, more efficient, and for the most part, better understood.

Keeping up with good practices and conventions can result in:
- scalable code  
- readable code  
- easy to maintain code  

Sometimes we find ourselves writing code that doesn't follow some of these practices, but we must always strive to make our code as good as we possibly can.

🤖
```text
Why are coding conventions important in team environments?
```

---

## Naming ☄

- Variables and Parameters → camelCase  
- Classes, Methods, Properties → PascalCase  
- Private fields → _camelCase  

🤖
```text
What problems can inconsistent naming cause in large projects?
```

---

## Properties and Fields ☄

- Use properties for values in any Class  
- Avoid using fields unless they are private  
- Use private fields to hide internal data  
- Boolean names should be readable (IsDeleted, CanLogin, HasCheckedIn)  
- Exception classes should end with "Exception"  
- Interfaces should start with "I"  

🤖
```text
Why do we prefer properties over public fields?
```

---

## Methods ☄

- Group methods in service classes  
- Keep methods short  
- Avoid too many parameters  
- Split large methods into smaller ones  

🤖
```text
How do small methods improve readability and testing?
```

---

## Loops ☄

- Use foreach whenever possible  
- Avoid repeated values inside loops  
- Use break when searching  
- Use simple counters (i, j, k)  

🤖
```text
When is foreach better than for loop?
```

---

## If / Else ☄

- Avoid comparing with true/false  
- Try to simplify conditions  
- Avoid complex one-liners  
- Use switch for complex branching  

🤖
```text
How can simplifying if statements improve code clarity?
```

---

# Programming Principles 🎯

---

## SOLID 🌟

SOLID principles help us build scalable and maintainable code.

---

### Single Responsibility ⭐

Each class should have one responsibility.

👉 One reason to change.

🤖
```text
What happens if one class has too many responsibilities?
```

---

### Open-Closed ⭐

Open for extension, closed for modification.

👉 Extend instead of modifying existing code.

🤖
```text
Why is modifying existing code risky in large systems?
```

---

### Liskov Substitution ⭐

Child classes should behave like parent classes.

🤖
```text
What problems occur if child classes break parent behavior?
```

---

### Interface Segregation ⭐

Small, focused interfaces are better.

🤖
```text
Why is it bad for a class to implement unused methods?
```

---

### Dependency Inversion ⭐

Depend on abstractions, not concrete implementations.

🤖
```text
How does dependency inversion reduce coupling?
```

---

## Other Principles ⚡

---

### DRY (Don’t Repeat Yourself)

Avoid duplicated logic.

🤖
```text
What problems does duplicated code cause?
```

---

### YAGNI (You Aren’t Gonna Need It)

Don’t add code until needed.

🤖
```text
Why can overengineering be harmful?
```

---

### KISS (Keep It Simple Stupid)

Keep solutions simple.

🤖
```text
Why is simple code easier to maintain?
```

---

# 🎯 Summary

- Write readable code  
- Keep things simple  
- Avoid duplication  
- Think about scalability  

---

# ❓ QUESTIONS?

You can find us at  
stojanovska_tijana@outlook.com