# User Interaction (10%)

You should use a reusable, object oriented menu system to manage user interaction. It should not be possible to crash the program with invalid or unexpected user input.
The primary navigation centre for my cinema app is the Main Menu, which shows up as soon as a staff member checks in. It’s designed to modify slightly based on whether the person is a manager or a typical staff member, which helps keep things simple and relevant for the user.
The two versions are what the managers see and what the general staff see, for example:

Managers see:
Sell Tickets and Concessions
Manage Schedule
Loyalty Scheme
Gold Membership
Staff Management
Exit

General staff only see:
Sell Tickets and Concessions
Loyalty Scheme
Gold Membership
Exit

To do this, the Display() method is passed a boolean called
```cs
isManager,
```
 which then determines which options are displayed. The additional menu item
 ```cs
(Staff Management)
```
is displayed if the user is a manager.
How does the menu work?
Once logged in, the user sees a clear list of actions they can take. The menu is printed using 
```cs
Console.WriteLine().
```
The program waits for the user to input a number and select an option. A utility method that verifies the input's validity is used for this.
After making a selection, the relevant workflow is triggered. 
For example:
Choosing “1” runs the 
```cs 
SellingTicketsWorkflow
```
If they’re a manager and choose “5”, it goes to the 
```cs
StaffManagementWorkflow
```
Exiting the application is always an option, and doing so ends the session and the main loop.
