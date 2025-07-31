# Polymorphism (10%)

Here you should describe how you have used Polymorphism in your solution.

You should use class diagrams and code snippets where appropriate.
While allowing each object to behave in accordance with its own class, polymorphism enables several object types to be treated uniformly. As a result, the code is easier to extend and more adaptable.

I've mostly utilised inheritance in my project to implement polymorphism, whereby subclasses override base class functions to offer particular behaviour. This eliminates the need to worry about the specifics of each subclass, allowing the remainder of the program to interact with objects using their common base type.
My base Staff class, for example, is inherited by classes such as Manager. To return role-specific data, each subclass can override methods like GetRole(). The Transaction class and other classes can now use staff objects without having to determine whether they are interacting with a manager or a regular employee.
```cs
// Base Staff class
public class Staff
{
    public virtual string GetRole()
    {
        return "Staff";
    }
}

// Manager class inheriting Staff and overriding GetRole()
public class Manager : Staff
{
    public override string GetRole()
    {
        return "Manager";
    }
}

// Using this in Transaction to display staff role
public void PrintStaffRole()
{
    Console.WriteLine($"Handled by: {Staff.GetRole()}");
}


```cs
public Staff Staff { get; }
```
When Staff.GetRole() is called, the actual method executed depends on the runtime type — whether the staff member is a manager or not — showcasing polymorphism in action.

```cs
+-------------------+
|       Staff       |
+-------------------+
| + GetRole()       |
+-------------------+
          ^
          |
+-------------------+
|      Manager      |
+-------------------+
| + GetRole()       |  (overrides Staff)
+-------------------+
```



