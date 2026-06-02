# 🧠 Class 9 – Reading and Writing on File System

Trainer: Ilija Mitev <br>
Contact: ilija.mitev3@gmail.com

---

## 📌 LOOKING BACK AT... 

- What are delegates?  
- What is a method signature and how is it connected to delegates?  
- What are classes that are registered to listen for a change in a publisher class called?  

🤖
```text
Explain delegates and events in simple terms.
```

---

## 📌 AGENDA 

- Working with File system  
- Create file/folder  
- Read  
- Write  
- Working with StreamReader/StreamWriter  
- Read  
- Write  

---

# Working with File System 🥡

---

## MANIPULATING THE FILE SYSTEM

Reading, Writing and Managing the file system, our computer folders and files is possible using C#.

In order to manipulate the file system we need to include the `System.IO` namespace.

There are multiple ways to create, modify, read and edit documents on the file system.

File paths are very important when working with File System.

🤖
```text
Why is System.IO needed when working with files in C#?
```

---

## C# and the File System 🔹

The file system is the computer where the program we are running exists. Since back-end languages are used for building applications on the server-side, they should have no restrictions in manipulating the file system that they are running on for various tasks like writing data, reading data, performing changes to some configurations, working with documents, templates, etc. C# as a language can manipulate the file system by including a special namespace from the .NET framework called `System.IO`. This library has predefined classes and methods that can do things like moving files and folders, reading, writing, deleting, and creating new ones.

🤖
```text
Explain the difference between working with memory and working with the file system.
```

---

## Paths 🔹

If we want to work on the file system we have to know the exact place of the file or folder that we want to work with. For that, we must use paths to specify the address of that particular file or folder. That can be done in 2 ways:

### Absolute Path

A complete path to some location on the file system that does not rely on where your program is executed at the moment.

```csharp
// An absolute path to a file in the folder of our C# console application
// NOTE: If we change or rename the folder location of our console application, this path will not work
string absolutePath = "C:\\SEDC\\CSharpAdv\\FileSystem\\FileSystem.App\\bin\\Debug\\netcoreapp2.1\\file.txt";
// Absolute path to a file in the SEDC folder
string absoluteSedcPath = "C:\\SEDC\\file.txt";
```

🤖
```text
What is the difference between absolute and relative path?
```

---

### Relative Path

```csharp
// A relative path to a file in the folder of our C# console application
// Since the program is already running from the folder path we don't need to write it with a relative path
// NOTE: If we change or rename the folder location of our console application, this path will still work
string relativePath = "file.txt";
// Relative path to a text file in the SEDC folder
string relativeSedcPath = "../../../../../file.txt";
```

🤖
```text
Why are relative paths usually safer for small applications and demos?
```

---

## File and Directory 🔹

The `System.IO` namespace provides 2 very important static classes for helping us manipulate the file system. Those are `File` and `Directory`. These 2 static classes hold static methods which we can call and manipulate certain parts of the File System.

---

## USING THE FILE CLASS

`File` is a class that provides static methods for manipulating the file system.

We can do almost all actions to a file or folder with this class as we could with the operating system UI.

When creating files with the `File` class, it is opening and returning a stream of data which we need to close when we are done.

🤖
```text
Why do we sometimes need to close a file manually after creating it?
```

---

### Directory

The `Directory` static class provides us with methods for manipulating the directories on our computer (mainly the folders and folder structure). This means that we can Create, Rename and Delete folders. We can also lookup directories and their locations (Paths) with this class as well. The main use for `Directory` is working with folders or finding out the path to something such as your current application that is running.

---

#### Current Directory

```csharp
string currentDirectory = Directory.GetCurrentDirectory();
Console.WriteLine(currentDirectory);

// Relative path to our application folder
string appPath = @"..\..\..\";
// Absolute path to our application folder
string appPath2 = @"C:\Users\MyPC\source\repos\SEDC.Adv08\SEDC.Adv08.FileSystem";
```

🤖
```text
What does Directory.GetCurrentDirectory() return and why is it useful?
```

---

#### Check if a folder exists

```csharp
string appPath = @"..\..\..\";
// Using a variable to store the main app path for future use
bool myFolderExists = Directory.Exists(appPath + @"\myFolder");
// Using the whole address of the main app
bool myFolderExistsString = Directory.Exists(@"C:\Users\MyPC\source\repos\SEDC.Adv08\SEDC.Adv08.FileSystem\myFolder");
```

---

#### Create a new folder

```csharp
string appPath = @"..\..\..\";
// We create the path to the future folder that we want to create
// It should be in our main app folder and it should be called newFolder
string newFolder = appPath + @"\newFolder";
// We first check if it exists. If it does, we don't want to call the CreateDirectory method
if (!Directory.Exists(newFolder))
{
  // We create the new folder
  Directory.CreateDirectory(newFolder);
}
```

🤖
```text
Why is it good practice to check if a folder exists before creating it?
```

---

#### Delete a folder

```csharp
string appPath = @"..\..\..\";
// We add the path to the folder we want to delete
string newFolder = appPath + @"\newFolder";
// We check if the folder exists. If it does, we don't want to call the Delete method
if (Directory.Exists(newFolder))
{
  // We delete the new folder
  Directory.Delete(newFolder);
}
```

🤖
```text
What happens if we try to delete a folder that does not exist?
```

---

### File

The `File` static class is filled with static methods that help us manipulate files on the File System. Like the `Directory`, `File` works with paths to find out where and what we need to manipulate and can be used to do a lot of things with files such as read from files, write in them, create new files, delete, copy, etc. The file static class is usually used for reading data or writing data in a file, changing files properties, or just renaming or moving files in general.

> Note: One important thing about the `File` is that some actions like `Create`, make a connection to that file, and don't automatically close it. We must make sure that we close that connection when we are done, otherwise, our application will use the file even if we are not using it anymore, preventing us from doing things to the file in the future.

---

#### Check if a file exists

```csharp
string appPath = @"..\..\..\";
string filesPath = appPath + @"\myFolder";
bool testTxtExists = File.Exists(filesPath + @"\test.txt");
```

---

#### Create a file

```csharp
string appPath = @"..\..\..\";
string filesPath = appPath + @"\myFolder";
if (!File.Exists(filesPath + @"\test.txt"))
{
  // We create the file and close the connection
  File.Create(filesPath + @"\test.txt").Close();
}
```

🤖
```text
Why do we call Close() after File.Create()?
```

---

#### Delete a file

```csharp
string appPath = @"..\..\..\";
string filesPath = appPath + @"\myFolder";
if (File.Exists(filesPath + @"\test.txt"))
{
  File.Delete(filesPath + @"\test.txt");
}
Console.ReadLine();
```

---

#### Write in a file

```csharp
string appPath = @"..\..\..\";
string filesPath = appPath + @"\myFolder";
string testTxtPath = filesPath + @"\test.txt";

if (File.Exists(testTxtPath))
{
    File.WriteAllText(testTxtPath, "Hello SEDC! We are writing in a file");
}
```

🤖
```text
What is the difference between WriteAllText and appending text?
```

---

#### Read from a file

```csharp
string appPath = @"..\..\..\";
string filesPath = appPath + @"\myFolder";
string testTxtPath = filesPath + @"\test.txt";

if (File.Exists(testTxtPath))
{
    string content = File.ReadAllText(testTxtPath);
}
```

🤖
```text
What happens if we try to read a file that does not exist?
```

---

## Reading and Writing with streams 🔹

`File` is great for working with any type of file. But if we have a lot of work with files that consist of text, then `StreamWriter` and `StreamReader` are the way to go. With these two classes, we can easily manipulate text in a file in bulk, with multiple actions and commands at once, without worrying that we are going to lock the file with the many actions. They both create a stream of data to the file and that stream makes it possible for us to do multiple things consecutively. When we are done the stream needs to be closed, but we can use the class itself to wrap it in a code block so the stream can be closed automatically. Like the other classes that work with the file system, we must have a defined path to the file that we want to use.

---

## USING STREAMREADER / STREAMWRITER

`StreamReader` and `StreamWriter` are classes used for reading and writing STRINGS.

With these we can easily write and read text from files.

`StreamReader` and `StreamWriter` stream is closed after we are done with our code.

Very efficient and fast for working with strings since it processes the documents line by line.

🤖
```text
Why are StreamReader and StreamWriter useful for text files?
```

---

### StreamWriter

```csharp
// Writing with StreamWriter
string appPath = @"..\..\..\";
string folderPath = appPath + @"myFolder\";
string filePath = folderPath + @"test.txt";

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
    Console.WriteLine("New directory was created!");
}

// Writing with StreamWriter
using (StreamWriter sw = new StreamWriter(filePath))
{
    sw.WriteLine("Hello SEDC!");
    sw.WriteLine("We are writing text from StreamWriter!");
    Console.WriteLine("Writing is complete!");
}

// Writing without rewriting the document with StreamWriter
using (StreamWriter sw = new StreamWriter(filePath, true))
{
    sw.WriteLine("Hello AGAIN!");
    sw.WriteLine("This is written on top of the previous one!");
    Console.WriteLine("Writing again!");
}

Console.ReadLine();
```

🤖
```text
What does the second parameter true mean in StreamWriter?
```

---

### StreamReader

```csharp
using (StreamReader sr = new StreamReader(filePath))
{
    string firstLine = sr.ReadLine();
    string secondLine = sr.ReadLine();
    string restContent = sr.ReadToEnd();

    Console.WriteLine($"First Line:{firstLine}");
    Console.WriteLine($"Second Line:{secondLine}");
    Console.WriteLine($"Rest of content:{restContent}");
}
```

🤖
```text
What is the difference between ReadLine() and ReadToEnd()?
```

---

# 🧪 EXERCISE 

Create a folder called `Exercise`.

Create a txt file in it called `calculations`.

Create a method that calculates 2 numbers and returns a string in the format:

`num1 + num2 = result`

Example:
`2 + 3 = 5`

Ask the user to enter 2 numbers, call the calculate method and give the result.

After the result is written in the console it should also be written in the `calculations.txt` file with a time stamp next to it.

Call the console 3 times and write 3 results in the txt file.

🤖
```text
How should I structure this exercise step by step without writing full code?
```

```text
What are common mistakes when working with files and folders in console applications?
```

```text
Should I use File methods or StreamWriter for this task, and why?
```

---

## Extra Materials 📘

- [Microsoft - File](https://docs.microsoft.com/en-us/dotnet/api/system.io.file?view=netcore-3.1)
- [Microsoft - Directory](https://docs.microsoft.com/en-us/dotnet/api/system.io.directory?view=netcore-3.1)
- [Microsoft - StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=netcore-3.1)
- [Microsoft - StreamReader](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netcore-3.1)

---

# ❓ QUESTIONS?

You can find us at  
trainer@mail.com  
