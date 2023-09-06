# <p align="center">Jokify</p>
# <p align="center">Project Description<p>
 Jokify is a web-based platform designed to post your own jokes and review other user's joke. It provides a user-friendly interface for all categories of jokes to browse and search, while also allowing for users to comment on each joke (only once)
# <p align="center">Database Diagram<p>
![jokify-database](https://github.com/Tiwua/Jokify/assets/106426081/9a80d414-b100-4407-9b9e-4b9bf5e36ae0)
# Built With
* ASP.NET Core 6 MVC
* Entity Framework Core
* MSSQL Server
* Javascript
* AJAX
* jQuery
* # Tested With
* NUnit
* Moq
* In-Memory Database
# <p align="center">Business logic test coverage<p>
![unit-tests](https://github.com/Tiwua/Jokify/assets/106426081/472eb26f-b66f-4667-b46c-a6e652be4695)
# Functionalities
## For Regular Users
1. **Create, Edit, and Delete Jokes:**
   You can create, edit, and delete your own jokes.

2. **Select Preferred Joke and Like/Dislike it:**
   You can like OTHER(not your own) user's jokes (if you have not liked it) or dislike them (if they have already liked it).

3. **Sort Jokes:**
   You can sort jokes by Title, Most likes or least likes using AJAX request
   
4. **Create, Edit and Delete comment on Joke**
   You can comment on a joke (if you have not commented on it), edit the existing comment using AJAX request or delete your own comment.
   
## For Admins
1. **Regular User Functionalities**
   Admin users have access to all the functionalities listed above.

2. **Edit and Delete other user's joke**
   Admin users can delete every user's joke (admin users excluded - if you are an admin only you can delete your own joke), they can also edit a user's joke

3. **Delete and Forget Users:**
   Admin users have access to All Users Page, allowing them to delete users (set their isDeleted flag to true) or forget them (keep the jokes of the user and make all the other properties null)
   
4. **Home Page:**
   Admin users have access to a modified Home page showing them all the available jokes count included in the web app
   
# <p align="center">Home Page for Admin user<p>

# <p align="center">Login<p>
![login](https://github.com/Tiwua/Jokify/assets/106426081/1a217187-baa3-4577-bcb1-fa6e78bc2fe8)

# <p align="center">Register<p>
![register](https://github.com/Tiwua/Jokify/assets/106426081/ffe2d9e8-5b62-416a-a3ed-8ea565164ad1)

# <p align="center">Joke details with pagination for comments<p>
**<p align="center">Joke details when there are 3 comments<p>**
![long-joke-details](https://github.com/Tiwua/Jokify/assets/106426081/ba4c9641-e24f-47ba-8bb4-46e96d5df630)

**<p align="center">Joke details when 0 comments<p>**
![joke-details](https://github.com/Tiwua/Jokify/assets/106426081/5a991fa1-441f-45c8-a786-99f48674512b)

# <p align="center">Create a Joke<p>
![create-joke](https://github.com/Tiwua/Jokify/assets/106426081/9f8f2d55-501a-4363-a8e9-37c6f322c317)

# <p align="center">Edit a Comment<p>
+ Users can edit their comment as long as its different from the previous comment (save button has an event listener checking on each symbol change - if the comments match the save button is dissabled)
![edit-comment](https://github.com/Tiwua/Jokify/assets/106426081/2393ea88-1705-439d-b675-a1993053b4e2)

# <p align="center">Delete a Jokes<p>
+ Upon deleting anything a confirmation appears and ONLY when confirming it you can delete the entity
![delete-joke](https://github.com/Tiwua/Jokify/assets/106426081/caf91812-5d72-41e9-b7f8-f2b798cadd59)

# <p align="center">All Jokes<p>
+ Guest users and regular users get sent into this page upon clicking "Explore" it includes (pagination, search, sort functunalities)
![all-jokes](https://github.com/Tiwua/Jokify/assets/106426081/3347b53d-52ed-4d2f-8e4e-f0acb6d29bcd)

# <p align="center">Admin Pages<p>
+ Admin Home Page
  ![admin-home](https://github.com/Tiwua/Jokify/assets/106426081/54c17010-e38d-4a52-9080-9091a12e06de)
  
+ Admin can create, edit or remove ANY Joke
![edit-comment](https://github.com/Tiwua/Jokify/assets/106426081/a8383b48-49f0-413e-bdb7-7cbc588bf5b7)

+ Admin can have functionalities upon all Users (with pagination)
![all-users-admin](https://github.com/Tiwua/Jokify/assets/106426081/ea5efe22-1060-474a-a644-7a34241f9d75)

## Template Attribution
The only template used was given by our lecturer Stamo Petkov for the repository pattern (Repository and IRepository)

## Frequently Asked Questions 
Q: Where did you come with this idea from?

A: I have always tried to loosen up the tension in our everyday life, so i came up with a more chill web app idea.



Q: Did you work on the front end?

A: Yes, all of the pages were designed personally by me with HTML and CSS.



Q: What have you implemented outside of the requirements?

A: Many paginations functionalities, AJAX request when editting a comment, AJAX request when sorting jokes in All Jokes page



Q: Have you protected your web app?

A: Yes all the buttons are disabled if the user rules are broken, even if they are, there is validation in the front end, in the backend and database.



Q: What do you mean by user rules?

A: For example if a user is not the owner of the joke edit and delete buttons are not shown. If all the requirements for a button to be shown are met it shows.



Q: Do you keep the passwords in your database?

A: I keep the passwords hashed in my database, keeping the user passwords in raw format is unacceptable!
![db-users](https://github.com/Tiwua/Jokify/assets/106426081/97af1a82-b1a3-4d5c-8cab-2a85afd7178b)

