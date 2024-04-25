# QuorumChallenge

1. Discuss your strategy and decisions implementing the application. Please, considertime
complexity, effort cost, technologies used and any other variable that you understand
important on your development process.

I could do everything on the front-end React project. Since the position is for a .Net engineer, I decided to implement a simple API to get the manipulated data.
I've tried to separate each sector as much as I can and still keep it as simple as possible. 

2. How would you change your solution to account forfuture columns that might be
requested, such as “Bill Voted On Date” or“Co-Sponsors”?

Since I've implemented API models, I would just add those columns on the relevant Models and add the code to get the data on the Service class.

3. How would you change your solution if instead ofreceiving CSVs of data, you were given a
list of legislators or bills that you should generate a CSV for?

Assuming I already have the list, I would apply similar logic as before to iterate through the list, extract relevant information, and format it appropriately for CSV output. Finally, I would generate the CSV file containing the information about legislators or bills based on the data retrieved and parsed.

4. How long did you spend working on the assignment?
2H 41M (it can checked in the Git repository)
