# Workshop Approach Guide – TryBeingFit

This guide helps you approach the problem step by step.

It does NOT contain a solution.

---

## 🎯 Main Goal

Build a console application that simulates a fitness platform with:

- users
- trainers
- trainings
- roles
- menus

---

## 🧠 How to Think About the Problem

Do NOT try to build everything at once.

Split the problem into logical parts.

---

## 🧩 1. IDENTIFY MAIN ENTITIES

From the requirements :contentReference[oaicite:1]{index=1}, identify:

- User (Standard / Premium)
- Trainer
- Training (Live / Video)

Think:

- What properties does each need?
- What behavior is expected?

---

## 🧩 2. UNDERSTAND ROLES

There are 3 main roles:

- Standard User
- Premium User
- Trainer

Each role has:
- different permissions
- different menu options

👉 Important:
Do NOT mix all logic together.

---

## 🧩 3. START SIMPLE

Before complex logic:

- create models
- create sample data
- create basic menu

---

## 🧩 4. BUILD FEATURES STEP BY STEP

Do NOT implement everything together.

Order suggestion:

1. Register user  
2. Login  
3. Menu (based on role)  
4. Trainings (list + access)  
5. Upgrade logic  
6. Trainer features  

---

## 🧩 5. VALIDATION COMES LATER

After basic flow works:

Add validation:

- name length  
- username length  
- password rules  
- role restrictions  

---

## 🧩 6. ROLE-BASED THINKING

Ask:

- What can Standard do?
- What can Premium do?
- What can Trainer do?

Design logic around permissions.

---

## 🧩 7. REFACTOR (LATER)

When code grows:

- split into smaller methods  
- group logic  
- remove duplication  

---

## 🤖 How AI Can Help You

Use AI for:

- understanding requirements  
- breaking the problem  
- explaining concepts  
- generating small code parts  
- debugging  

---

## ✅ GOOD AI USAGE

Examples:

- How to design a User class?
- How to validate password rules?
- How to implement role-based menu?
- How to check permissions?

---

## ❌ BAD AI USAGE

Avoid:

- Build full TryBeingFit app
- Generate full solution
- Give me complete code

---

## 💡 SMART WORKFLOW

1. Think first  
2. Try yourself  
3. Ask AI for help  
4. Improve code  
5. Test  

---

## 🎯 FINAL GOAL

You should:

- understand the app  
- be able to explain it  
- improve it later  

Not just copy it.