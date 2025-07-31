# Expanding the Loyalty Scheme to Include Gold Membership (10%)
In the workflow sections you must give clear instructions as to how to perform this workflow in your applcation. Use images and diagrams where necessary. Failure to give adequate instructions here may result in loss of marks.

This workflow should do the following things:
- Load information about members
- Sell an annual membership to turn a loyalty scheme member into a gold member
- Gold members get a 25% discount on all concessions
By offering them an annual subscription, this process enables staff to upgrade current loyalty members to Gold membership. For the duration of their membership, gold members receive a 25% discount on all concessions.
Go to the Gold Membership Menu.
Select Gold Membership from the main menu after logging in.
You will receive a notification requesting you to sign up people for the loyalty program first if there aren't any members yet.
Select a Member to Upgrade
If there are any members available, a list with their names, membership numbers, and Gold or Standard status will appear.
To improve a member, pick them.
Upgrade to Gold
If the member is already Gold, you won't be able to upgrade them again when the system notifies you when their membership expires.
You will be asked how many years (between one and five) they would like to purchase their Gold membership for if they are not already Gold.
Confirmation and Benefits
The member is promoted to Gold level once the amount of years has been entered.
The updated expiration date will appear in a confirmation message.
Inform the member that while their Gold membership is active, they will receive 25% off all concessions.
Then , The member’s updated details are saved automatically.
Important Information:
Prior to upgrading, members must have already registered through the loyalty program.
Gold memberships can be sold by staff for one to five years.
When selling concessions in other areas of the app, the 25% discount is immediately applied.
```cs
Start
 ↓
Check for members
 ↓
+----------------------------+
| No members?               | → Show message to sign up first → End
+----------------------------+
| Members found?            | → Show member list with current status
+----------------------------+
         ↓
Pick a member
 ↓
+----------------------------+
| Already Gold?             | → Show expiry date → End
+----------------------------+
| Not Gold?                | → Ask for number of years (1-5)
+----------------------------+
         ↓
Upgrade member to Gold
 ↓
Show confirmation + expiry date
 ↓
Save data
 ↓
End
```
