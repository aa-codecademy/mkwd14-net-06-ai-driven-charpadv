# Class 7 Homework 📒

## Task 1

Create console application TeacherNotificator. 

Create folder Models and add 2 classes in it: 

1. Students with the following properties:
- Name  
- Age  
- Email  
- Subject  

and one method:
- void GetNotification(string) which will print Name of the student + text from parameter  

---

2. Teacher with the following properties:
- Name  
- Age  
- Email  
- Subject  

Add:
- event  
- 2 methods subscribe and unsubscribe and print text for the action  
  example: "Alice subscribed to Professor John's notifications."  

Add method:
- void SendNotification()  
  - prints "Sending Notifications to all students..."  
  - invokes the event  

---

In the program class:

- create 1 professor and 3 students  
- subscribe all students to the event  
- execute professor.SendNotification()  
- unsubscribe 2 students  
- execute professor.SendNotification() again  

---

### Expected output:

```
Alice subscribed to Professor John's notifications.
Bob subscribed to Professor John's notifications.
Charlie subscribed to Professor John's notifications.

Sending notifications....
Alice: Notification from Professor John: Class for Math will start at 10 AM.
Bob: Notification from Professor John: Class for Math will start at 10 AM.
Charlie: Notification from Professor John: Class for Math will start at 10 AM.

Alice unsubscribed from Professor John's notifications.
Charlie unsubscribed from Professor John's notifications.

Sending notifications....
Bob: Notification from Professor John: Class for Math will start at 10 AM.
```

---

## Task 2

Write a program for Online Classes. The conditions are as follow:

- User provides their name as input  
- Application shows message: “Welcome [Name]”  

BUT:

- Bob, Jill, and Alice do NOT have permission  
- When these users are entered:
  - raise an event  
  - send email to administration  
  - start alarm  

---

### Expected output

Case 1:
```
Welcome Charlie.
```

Case 2:
```
Alice Users Found. Sending Email to Administration.
Email Sent.
Warning Alarm Started.
Loging out.
```

---

## 🤖 Using AI in Homework

You are allowed to use AI tools (ChatGPT, Copilot, etc.) while working on this homework.

This homework focuses on **delegates and events**, which can be confusing at first.

---

### 🧠 How to use AI effectively

- Ask AI to explain how events work step by step  
- Ask what happens when you subscribe/unsubscribe  
- Use AI to understand the flow, not generate full code  
- Test your understanding by explaining it back  

---

### ⚙️ Suggested approach

1. Start with Task 1  
2. Create delegate and event first  
3. Implement subscription logic  
4. Test event trigger  
5. Add unsubscribe logic  
6. Then move to Task 2  

---

### ❌ What to avoid

- Copy/pasting full solution  
- Not understanding event flow  
- Skipping testing  
- Mixing responsibilities in classes  

---

### 💡 Key mindset

Think of events as:

- “Something happened”  
- “Notify everyone listening”  

Publisher = sender  
Subscriber = listener  

---

### 🤖 Example prompts

```
Explain how events and delegates work step by step.
```

```
What happens when I subscribe a method to an event?
```

```
Why do we need delegates for events?
```

```
What happens if no one is subscribed to an event?
```

```
Here is my code: [paste code]. What is wrong?
```

---

### 🎯 Goal

The goal is to:

- Understand delegates  
- Understand events  
- Learn communication between classes  

AI should help you **understand the flow**, not replace your thinking.