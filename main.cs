To understand the new operator, you have to understand the significance of classes and objects in C# and similar object-oriented languages. Words like “type” and “instance” are useful, too. Object-oriented languages make a crucial distinction between referring to the class or type of something vs referring to specific instances of that something — whatever it is. The word “instance” is analogous with “object.”

The new operator is a general-purpose way to bring a type to life. Think of it as a word that “summons” an instance of a class (i.e. type) into being so you can act on it.

Let’s say you have a program that does something with … I don’t know…. cars. Or calendars. Or cacti. Or echo-cardiograms. It doesn’t matter. Let’s go with cars.

class Car 
{ 
	public string Color { get; set; } 
	public int TopSpeed { get; set; } 
} 
To do anything with a Car in our C# program, we need an instance of a car. We can’t do much referring to cars in the abstract. We need specific instances of cars to be useful in our program. We need some code like this somewhere:

var car1 = new Car() { Color = "red", TopSpeed = 200 }; 
var car2 = new Car() { Color = "beige", TopSpeed = 67 }; 
Now we have two cars, car1 and car2. The new operator makes this possible. Without it, we would simply have the idea or concept of cars in our program, but no actual cars that can race or crash or drive, or whatever. In other words, without new, we would have no instances or Car — no Car objects.

So, the “new” operator in C# really only makes sense if you understand why there are classes and objects in C#. It’s tough to explain in isolation, but I think the term sort of falls into place if those other concepts make sense.

987 viewsView 4 Upvoters
Related Questions
More Answers Below
Why is C# so hard to understand?
What's C# actually useful for? What exactly is written in C#?
What does [] mean in C#?
In C#, what does "atomic" mean?
Why don't you use C#?

Dan Jackson, Head of Software Development (2017-present)
Answered November 7, 2017
In C# (and many other languages) you will find that you use new often as it is fundamental to using types and classes. The new keyword does pretty much what it says: it will create a new instance of a class or type, assigning it a location in memory.

Let me try and illustrate this.

Company company; 
Here we have created a variable of the Company class, but note that it isn't assigned to anything. If you try to use this now you will get an exception as it is currently null.

Let's create a new instance of Company instead:

Company company = new Company(); 
This line is much more useful. First of all we are assigning the variable company to a new instance of the type Company. The new keyword instructs the application to instantiate a new instance of Company. Note that we are required to add parentheses to the end of the class name as this is calling a special function known as a constructor.

The constructor can contain logic that allows the class to be instantiated to support any desired functionality of the class.

A basic example of a constructor:

public class Company { 
 
    // Public properties 
    public int CompanyID; 
    public string CompanyName; 
    public List<Employee> Employees; 
 
    // Constructor 
    public Company() { 
        Employees = new List<Employee>; 
    } 
 
    ... 
 
} 
Here, the constructor is being used to instantiate the list of employees to ensure that when using the property that you do not get a NullReferenceException.

You can create multiple constructors, as long as they have unique signatures (the parameters in the constructor cannot match the pattern of parameters in another constructor).

public class Company { 
 
    // Public properties 
    public int CompanyID; 
    public string CompanyName; 
    public List<Employee> Employees; 
 
    // Constructor 
    public Company() { 
        Employees = new List<Employee>; 
    } 
 
    public Company(int companyId) { 
        LoadCompany(companyId); 
    } 
 
    ... 
 
} 
You can now see that we've got two constructors. Calling new and passing an integer to the constructor will call the second constructor, which in this case will call a function that will load the company data (just an example, you can load data in other ways).

When you want to use this constructor, change your code, simply, to (passing the relevant integer):

Company company = new Company(1337); 
One special thing about constructors is that they can be used to do things that you cannot do with an already instantiated class: you can write to readonly properties.

So, whenever you want to create a new instance of a type, you will need to call new. It is a very simple keyword, but is very powerful as it essentially does all of the heavy lifting of object creation for you.