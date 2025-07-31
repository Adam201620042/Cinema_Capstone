In my solution, I used inheritance as a way to reduce code duplication and keep things more organised. A clear example of this is the relationship between the Staff class and the Manager class. Manager inherits from Staff, which means it automatically gains all of the properties and methods defined in the Staff class. This allowed me to reuse common functionality without having to rewrite it.
Here is an example : 
'''cs
if (staff is Manager)

This line checks whether the current staff object is actually a Manager, which only works because Manager is a subclass of Staff. If the user is a manager, the program unlocks additional options, like managing the schedule or overseeing other staff members.
+-------------+         +----------------+
|   Staff     |◄────────|    Manager     |
+-------------+         +----------------+
| - Username  |         |                |
| - Password  |         |                |
+-------------+         +----------------+
| +PerformDuties()      | +ManageStaff() |
+-------------+         +----------------+
