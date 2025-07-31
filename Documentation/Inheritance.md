# Inheritance for Code Reuse (10%)

Here you should describe how you have used Inheritance for Code Reuse in your solution.

You should use class diagrams and code snippets where appropriate.
By using inheritance, classes can be created from existing ones, allowing shared methods and properties to be utilised again without requiring code changes. This facilitates maintenance and keeps the code DRY (Don't Repeat Yourself).
The main use of inheritance in my solution is in the representation of staff roles:
All staff members have common properties and methods, such as login credentials and personal data, which are stored in my base class Staff.
Specialised classes like Manager, which inherit these basic traits but can also add new capabilities or override behaviours when necessary, are derived from Staff.
By using this method, the Program class can handle particular circumstances for Manager objects when necessary, such as giving managers access to additional menu items, while still working with a general Staff reference.
```cs
Staff staff = StaffLogin.Authenticate(cinema.Staff);

if (staff == null)
{
    Console.WriteLine("Login failed. Exiting application.");
    return;
}

MainMenu.Display(staff is Manager); // Show extra options if user is a Manager

// Further code that checks if staff is Manager to allow access to more features
if (staff is Manager)
{
    StaffManagementWorkflow.Execute(cinema);
}
+------------------+
|      Staff       |  <--- Base class with common staff properties and methods
+------------------+
| - Name           |
| - StaffId        |
| + Login()        |
+------------------+
          ^
          |
+------------------+
|    Manager       |  <--- Inherits Staff, adds manager-specific methods
+------------------+
| + ManageStaff()  |
| + Login() override|
+------------------+
```



