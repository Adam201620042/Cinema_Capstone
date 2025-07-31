# Selling Tickets Workflow (10%)

In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

This workflow should do the following things:

- Load information about the cinema without allowing invalid data
- Load information about the schedule of screenings without allowing invalid data
- Select a film screening
- Select a number of tickets to buy
- Select standard or premium tickets
- Select concessions
- Select popcorn and/or soda
- Calculate the total price of the transaction
- Demonstrate the number of tickets available has updated
-Save updated information about screenings

This process ensures that all data is imported and confirmed accurately while guiding the user through the ticket and concession sales process.
Load Cinema and Screening Data
After loading the cinema and screening information, any screenings that have already begun are filtered out.
The user is informed if there aren't any screenings scheduled.
Select a Screening
A list of forthcoming screenings is displayed to the user, together with the film title, rating, screen number, start time, and number of seats available.
If the customer is a member of a loyalty program, the user is prompted.
If so, the member is chosen from a list that includes the number of visits.
How many tickets to purchase is entered by the user.
They select either ordinary or premium seats for each ticket.
Alternatives are offered if necessary, and seat availability is verified.
The movie's age rating is compared to the customer's age.
Concessions like popcorn and soda can be added by the user, who can choose how much is needed.
After calculating the entire cost, a thorough receipt that includes a breakdown of the tickets, concessions, and total price is displayed.
The user confirms the sale.
On confirmation, seat availability is updated and member data saved.
If cancelled, no changes are applied.
```cs
Load Cinema & Screenings
          ↓
 Display Upcoming Screenings
          ↓
   Select Screening
          ↓
 Check Member Status? → Yes → Select Member
          ↓ No
  Enter Number of Tickets
          ↓
Select Ticket Type & Age
          ↓
 Add Concessions? → Yes → Select Items & Quantity
          ↓ No
 Show Receipt & Total
          ↓
 Confirm Transaction? → Yes → Finalise & Save
          ↓ No
       Cancel Transaction
```
