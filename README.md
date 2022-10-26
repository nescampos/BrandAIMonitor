# BrandAIMonitor

**BrandAIMonitor** allows you to monitor a set of tweets associated with a brand, through a profile or hashtag, and through the web app to obtain sentiment information about that tweet and its main topics (topics), in order to have an overview of the status of a brand on the social network and, in turn, have the details of each comment.

![image](https://user-images.githubusercontent.com/7274106/198021930-a3409761-a5c6-447f-bf04-abbb1f3f4a11.png)


## Requirements

- [Expert.AI account](https://expert.ai/)
- [Microsoft Azure](https://azure.microsoft.com/)
- Visual Studio 2022 or superior, with .NET 6.0

## How to use it

1. Create a SQL Server database for this app.
2. Open the code in Visual Studio and change the connection string to your new database.
3. Execute the web app for creating automatically the tables.
4. Create a Azure Logic App for listening tweets and inserting in the database: https://youtu.be/bJNS4MmvXyk 
5. Try the app.
