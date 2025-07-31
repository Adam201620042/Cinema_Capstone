# Creating a Loyalty Scheme (10%)

In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

This workflow should do the following things:
- Load information about members
- Any worker can add a member by providing a first name, surname and email address
- When a member visits 10 times their next standard ticket is free

Any employee can manage cinema loyalty members using this feature. New members can be added, their information checked, and their visits tracked. Members receive a complimentary standard ticket on their subsequent visit after ten visits.
After logging in, pick Loyalty Scheme from the main menu. You’ll see three options:

1. Register New Member

2. View Member Details

3. Back to Main Menu

Choose 1 to add someone new.
When prompted, provide their email address, first and last names.
The program determines whether the email address is already registered. You won't be allowed to add them twice and will receive a warning if it is.
The new member will be saved and you will receive a notification with their membership number if everything is okay.
Pick 2 to look at member info.
A list of members will appear; select one.
Their whole name, email address, membership number, number of visits, and status as a Gold or standard member are displayed.
The app notifies you that they are eligible for a complimentary regular ticket the next time they visit if they are not Gold but have been there ten or more times.
Once a member hits 10 visits, the app marks them as eligible for a free ticket on their next visit.
Staff can apply this discount when selling tickets.
Hit 3 anytime to return to the main menu.
When the program launches, member information is loaded, and when new members join, it is saved to a file.
No special permissions are required; any staff member can add new members.
Loyal clients are rewarded and encouraged to return with this workflow.
```cs
Start
 ↓
Show Loyalty Scheme Menu
 ↓
+---------------------------+
| 1. Register Member         | → Enter details → Check email → Save → Confirmation → Back to menu
+---------------------------+
| 2. View Member Details     | → Select member → Show info → Free ticket notice if eligible → Back to menu
+---------------------------+
| 3. Back to Main Menu       | → Exit loyalty workflow
+---------------------------+
```
