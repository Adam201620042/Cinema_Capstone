# Encapsulation and Cohesion (10%)

Here you should describe how you have used Encapsulation and Cohesion in your solution.

You should use class diagrams and code snippets where appropriate.
The goal of encapsulation is to conceal internal details from the rest of the program while concentrating related data and the functions that manipulate it in a single location, typically a class. This keeps things structured and stops other code segments from directly altering internal states.
In my approach, I organised various application components into distinct classes and procedures using encapsulation. For instance:
The Cinema class holds all the cinema-related data.

The Staff class manages staff details and login.
The logic for certain activities is hidden from the main Program class in each workflow, such as SellingTicketsWorkflow, LoyaltySchemeWorkflow, and GoldMembershipWorkflow.
This implies that the main program doesn't have to care about the specifics of each step; it only needs to call the relevant workflow.
Cohesion is the degree to which a class or module is centred around a single duty or job. When a code has high cohesiveness, every component performs a single task effectively.
Regarding my project:
To make things clear and manageable, each workflow class performs a single task, such as selling tickets or overseeing the loyalty program.
To keep the primary business logic clear, helper classes like Utilities handle general tasks like input validation.
Staff authentication is handled exclusively by the StaffLogin class.
My code remains simple thanks to this method, making it easier to update or correct as necessary.
```cs
// Program.cs

bool exit = false;

while (!exit)
{
    Console.Clear();

    // Show menu based on whether staff is a manager
    MainMenu.Display(staff is Manager);

    // Get user's choice, making sure it’s a valid input
    int choice = Utilities.GetIntegerInput("Enter your choice: ", 1, staff is Manager ? 5 : 4);

    switch (choice)
    {
        case 1:
            // Ticket selling handled inside its own workflow
            SellingTicketsWorkflow.Execute(cinema, staff);
            break;

        case 2:
            if (staff is Manager)
            {
                // Schedule management workflow for managers
                StaffManagementWorkflow.ManageSchedule(cinema);
            }
            break;

        case 3:
            // Loyalty scheme managed by its dedicated workflow
            LoyaltySchemeWorkflow.Execute(cinema, staff);
            break;

        case 4:
            // Gold membership upgrades handled here
            GoldMembershipWorkflow.Execute(cinema, staff);
            break;

        case 5:
            if (staff is Manager)
            {
                // Staff management workflow for managers only
                StaffManagementWorkflow.Execute(cinema);
            }
            break;

        case 6:
            exit = true;
            break;
    }
}
+------------------+
|     Program      |
+------------------+
| - Main()         |
+------------------+
        |
        v
+-------------------------+
|         Cinema          |  // Stores cinema data
+-------------------------+

+-------------------------+
|         Staff           |  // Manages staff details and roles
+-------------------------+

+-----------------------------+
|   SellingTicketsWorkflow    |  // Handles ticket sales (single responsibility)
+-----------------------------+

+-----------------------------+
|   StaffManagementWorkflow   |  // Manages staff and schedules
+-----------------------------+

+-----------------------------+
|   LoyaltySchemeWorkflow     |  // Manages loyalty scheme members
+-----------------------------+

+-----------------------------+
|   GoldMembershipWorkflow    |  // Handles gold membership upgrades
+-----------------------------+
```
