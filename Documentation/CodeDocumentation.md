# Self commenting code and explicit comments (5%)

Describe how you have documented your code in terms of naming conventions for member variables and member methods, explicit comments (that add value and not clutter) and summary comments.
I've deliberately tried to keep the code documentation in my solution as simple and helpful as possible, minimising unnecessary information but yet offering understanding where it's required. I took three main approaches to this:
In order to make the code readable without the need for a lot of comments, I stuck to simple and useful names. For instance:
The PascalCase class names (SellingTicketsWorkflow, MainMenu, DataLoader, etc.) make it obvious what each class is in charge of.
Additionally, method names (such as Execute, Authenticate, and LoadCinema) are in PascalCase and explicitly state their function.
CamelCase is used to write variable names, which are chosen to be descriptive (e.g., cinema, staff, choice, exit) rather than confusing ones like x or temp unless the context suggests otherwise.
This method reduces the requirement for continuous inline comments and helps make the code self-explanatory.
Where the code's intent might not be obvious right away, I added comments, especially around:
Important choices about the logic flow (e.g., where the menu changes according to the role of the user).
loading cinema data from a resource file, for example, requires external dependencies or file paths.
Workflow triggers include the conditional operation of a manager-only functionality.
Example:
```cs
// Load initial data
Cinema cinema = DataLoader.LoadCinema("../../../Resources/cinema.txt");
// Staff login
Staff staff = StaffLogin.Authenticate(cinema.Staff);
```
I added XML-style summary comments where I could (or would in larger classes and methods), particularly for methods that are visible to the public. These make it easier for other developers to comprehend each method's goal without having to read the full code.
```cs
/// <summary>
/// Authenticates a staff member from the list of available staff.
/// Returns null if authentication fails.
/// </summary>
public static Staff Authenticate(List<Staff> staffList)
{
    // Method logic here
}
```

For larger teams, future maintenance, or when utilising IntelliSense in Visual Studio, this type of summary documentation is helpful.
In order to properly and simply document my code, I used:

understandable code with descriptive names that don't require further explanation.

specific remarks that provide light on unclear reasoning, particularly in relation to role-specific aspects and the program's structure.

Method and class summaries are provided to enhance code comprehension and maintainability.

I tried to write code that would be simple to understand for myself and anyone else who might use it in the future by emphasising readability and insightful comments.
