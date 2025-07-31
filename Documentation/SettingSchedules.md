# Setting Schedules Workflow (10%)

In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

This workflow should do the following things:

- Load information about cinema staff who can either be managers or workers without allowing invalid data
- Select a staff member at the start of the application
- A manager should be able to edit the schedule of screenings
- The schedule must conform to the scheduling rules
    - You cannot schedule two screenings in the same screen at the same time
    - You must leave enough time between films for "turnaround" (15 minutes for 50 seats or less, 30 minutes for 51 - 100 seats, 45 minutes for more than 100 seats)
- A manager should be able to save the schedule of screenings in a format of your choosing with the extension .fs
    - one file should contain the schedule for one day, with the date indicated in the filename 
- Any staff member should be able to load the schedule from a list of dates
The workflow explains how to manage the cinema’s screening schedule while following all necessary rules.
To avoid mistakes, staff information is loaded and verified at startup; names must begin with a capital letter and staff IDs must be six digits:
```cs
newStaff.StaffId = staffId;  // Validates ID format
newStaff.FirstName = firstName;  // Checks name format
newStaff.LastName = lastName;
```
Staff are required to log in, with managers having the ability to make changes to the schedule and others having restricted access.
Using a straightforward menu, managers can add or delete screenings:
```cs
StaffManagementWorkflow.ManageSchedule(cinema);
```
They choose the film, screen, start time, and date when adding a screening. The technique uses screen size to determine turnaround time and end time, including trailers:
```cs
screeningEnd = screeningEnd.AddMinutes(20); // Trailers
screeningEnd = screeningEnd.AddMinutes(screen.TurnaroundTime); // Turnaround
```
Before confirming a new screening, the app checks for overlaps on the same screen to avoid clashes:
```cs
foreach (var existing in cinema.Screenings)
{
    if (existing.Screen.ScreenId == screen.ScreenId &&
        ((screeningStart >= existing.StartTime && screeningStart < existing.EndTime) ||
         (screeningEnd > existing.StartTime && screeningEnd <= existing.EndTime) ||
         (screeningStart <= existing.StartTime && screeningEnd >= existing.EndTime)))
    {
        Console.WriteLine($"Conflict with existing screening: {existing.Movie.Title} ...");
        return;
    }
}
```
After the changes, the schedule is saved to a .fs file named by the date:
```cs
cinema.SaveSchedule(date.ToString("dd/MM/yyyy"));
```
To view or control screenings, any staff member can load schedules from a list of dates.
