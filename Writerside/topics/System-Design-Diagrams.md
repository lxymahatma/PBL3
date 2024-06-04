# System Design Diagrams

## Classes

### User Class

| **Attributes**    | **Methods**            |
|-------------------|------------------------|
| - string UserName | + void Register()      |
| - string Password | + void Login()         |
| - string Email    | + void ResetPassword() |
| - bool IsAdmin    | + void DeleteAccount() |

### Student Class (inherits from User)

| **Attributes**  | **Methods**                  |
|-----------------|------------------------------|
| - int StudentId | (inherits methods from User) |

### Admin Class (inherits from User)

| **Attributes**             | **Methods**                  |
|----------------------------|------------------------------|
| (no additional attributes) | (inherits methods from User) |

### UserService Class

| **Attributes**                     | **Methods**                               |
|------------------------------------|-------------------------------------------|
| - ILogger Logger                   | + bool Register(User user)                |
| - IDatabaseService DatabaseService | + bool Login(string key, string password) |
| - User User                        | + bool Delete()                           |
|                                    | + bool ResetPassword()                    |

### DatabaseService Class

| **Attributes**   | **Methods**                     |
|------------------|---------------------------------|
| - ILogger Logger | + User[] GetUsersFromDatabase() |
|                  | + User GetUserByKey(string key) |
|                  | + bool SaveUser(User user)      |

### RegisterPage Class

| **Attributes**                 | **Methods**                               |
|--------------------------------|-------------------------------------------|
| - IRegisterViewModel ViewModel | + void DisplayRegistrationForm()          |
|                                | + void CaptureUserInput()                 |
|                                | + void ShowErrorMessage(string message)   |
|                                | + void ShowSuccessMessage(string message) |

### RegisterViewModel Class (implements IRegisterViewModel)

| **Attributes**             | **Methods**           |
|----------------------------|-----------------------|
| - string UserName          | + void RegisterUser() |
| - string Password          |                       |
| - string Email             |                       |
| - IUserService UserService |                       |

### IRegisterViewModel Interface

| **Methods**           |
|-----------------------|
| + void RegisterUser() |

### LoginPage Class

| **Attributes**              | **Methods**                               |
|-----------------------------|-------------------------------------------|
| - ILoginViewModel ViewModel | + void DisplayLoginForm()                 |
|                             | + void CaptureUserInput()                 |
|                             | + void ShowErrorMessage(string message)   |
|                             | + void ShowSuccessMessage(string message) |

### LoginViewModel Class (implements ILoginViewModel)

| **Attributes**             | **Methods**        |
|----------------------------|--------------------|
| - string UserName          | + bool LoginUser() |
| - string Password          |                    |
| - IUserService UserService |                    |

### ILoginViewModel Interface

| **Methods**        |
|--------------------|
| + bool LoginUser() |

### PasswordResetPage Class

| **Attributes**                      | **Methods**                               |
|-------------------------------------|-------------------------------------------|
| - IPasswordResetViewModel ViewModel | + void DisplayPasswordResetForm()         |
|                                     | + void CaptureUserInput()                 |
|                                     | + void ShowErrorMessage(string message)   |
|                                     | + void ShowSuccessMessage(string message) |

### PasswordResetViewModel Class (implements IPasswordResetViewModel)

| **Attributes**             | **Methods**            |
|----------------------------|------------------------|
| - string Email             | + bool ResetPassword() |
| - IUserService UserService |                        |

### IPasswordResetViewModel Interface

| **Methods**            |
|------------------------|
| + bool ResetPassword() |

### EmailService Class

| **Attributes**   | **Methods**                                     |
|------------------|-------------------------------------------------|
| - ILogger Logger | + bool SendResetLink(string email, string link) |

## Component Diagram

## Use cases

![UseCaseDiagram](UseCaseDiagram.png)

| Number | Name                                    | Description                                            |
|--------|-----------------------------------------|--------------------------------------------------------|
| U1     | Register Account                        | Register an account on the system.                     |
| U2     | Log In                                  | Log into the system.                                   |
| U3     | View and Edit Account Information       | View and edit account information.                     |
| U4     | Reset Account Password                  | Reset and recover account password.                    |
| U5     | Delete Account                          | Delete account from the system.                        |
| U6     | View Academic Calendar                  | View school's academic calendar.                       |
| U7     | View and Bookmark Course Pathways       | View and bookmark wanted course.                       |
| U8     | Filter Courses                          | Filter course based on chosen property.                |
| U9     | Obtain Course Recommendation from Query | Gain course recommendations from query.                |
| U10    | Submit Course Feedback                  | Submit course feedback in the system.                  |
| U11    | Access and Analyze User Data            | University officials can access and analyze user data. |
| U12    | Create and Delete Thread                | Users can create and delete threads.                   |
| U13    | Create, Edit, Reply, and Delete Post    | Users can create, edit, reply and delete posts.        |

### Use Case "Register Account" (U1)

**Class Diagram**

![ClassDiagramU1.png](ClassDiagramU1.png)

| **Use Case ID**          | U1                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|--------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Use Case Name**        | Register Account                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| **Description**          | This use case allows a user to register a new account in the system. The user provides necessary details, which are validated and stored in the system.                                                                                                                                                                                                                                                                                                                                                                                                                           |
| **Actors**               | User, UserService, DatabaseService, RegisterPage, RegisterViewModel, IRegisterViewModel                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| **Preconditions**        | The user is on the registration page.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **Postconditions**       | The user account is created and stored in the database. The user is informed of successful registration.                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **Normal Flow**          | 1. User selects "Register" option on the application interface.<br>2. System presents a registration form on the User Interface.<br>3. User enters registration details.<br>4. User Interface captures the data and validates the input.<br>5. User Interface sends data to UserService.<br>6. UserService validates the data.<br>7. UserService sends validated data to DatabaseService.<br>8. DatabaseService stores the user data.<br>9. UserService confirms the successful registration to the User Interface.<br>10. User Interface displays a success message to the user. |
| **Alternative Flow**     | **Invalid Input**:<br>1. If the input data is invalid, UserService returns an error message.<br>2. User Interface displays the error message and prompts the user to correct the input.<br>3. User corrects the input and resubmits the form.<br>4. The system processes the corrected input as described in the Normal Flow.                                                                                                                                                                                                                                                     |
| **Exceptions**           | **System Error**:<br>1. If there is a system error during the registration process, an error message is displayed to the user.<br>2. The user may try to register again later.                                                                                                                                                                                                                                                                                                                                                                                                    |
| **Special Requirements** | The system should ensure the registration form is easy to use and accessible. The data should be validated for correctness and completeness before submission.                                                                                                                                                                                                                                                                                                                                                                                                                    |
| **Assumptions**          | The user has access to the registration page and intends to create a new account.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |

**Associations and Multiplicities**

- **UserService** is associated with **DatabaseService** (1:1).
- **UserService** can manage multiple **User** instances (1:many).
- **RegisterPage** is associated with **RegisterViewModel** (1:1).
- **RegisterViewModel** is associated with **UserService** (1:1).

**Sequence Diagram**

![SequenceDiagramU1.png](SequenceDiagramU1.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

| Step | Description                                                                                                                           |
|------|---------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User initiates the registration process by accessing the registration form on the User Interface.                                     |
| 2    | User fills out the registration form with necessary details (username, password, email, etc.).                                        |
| 3    | User Interface sends the filled-out registration form data to the AuthenticationService.                                              |
| 4    | AuthenticationService receives the registration data and performs initial validations:                                                |
|      | - Validates the format of the email.                                                                                                  |
|      | - Checks if the password meets the security criteria.                                                                                 |
|      | - Ensures the username is not already taken (involves a quick check with the Database).                                               |
| 5    | If any validation fails, AuthenticationService sends an error message back to the User Interface, which then displays it to the User. |
| 6    | If all validations pass, AuthenticationService hashes the password and prepares the data for database entry.                          |
| 7    | AuthenticationService sends the validated and processed data to the Database to create a new user record.                             |
| 8    | Database attempts to create a new record:                                                                                             |
|      | - Checks for uniqueness constraints again (to prevent race conditions).                                                               |
|      | - If successful, confirms the creation of the user account.                                                                           |
|      | - If it fails (e.g., due to a username now being taken), it sends a failure message back to the AuthenticationService.                |
| 9    | AuthenticationService receives the response from the Database:                                                                        |
|      | - If the account creation is successful, it sends a success notification to the User Interface.                                       |
|      | - If the account creation fails, it sends the appropriate error message to the User Interface.                                        |
| 10   | User Interface receives the final response and informs the User:                                                                      |
|      | - Displays a success message and possibly directs the user to a login page or a confirmation email is sent.                           |
|      | - Displays an error message if the registration failed, asking the user to try different credentials or contact support.              |

**Activity Diagram**

![ActivityDiagramU1.jpg](ActivityDiagramU1.jpg)

**Activity Steps**:

| Step | Description                                                                                             |
|------|---------------------------------------------------------------------------------------------------------|
| 1    | Open the register account page.                                                                         |
| 2    | Users will be prompted to enter basic information such as email, password, username, and other details. |
| 3    | The system will verify the email address entered by the user.                                           |
| 4    | If the email exists, the user can go to the next step.                                                  |
| 5    | If not, the system will go back to the register account day.                                            |
| 6    | The system will ask the user whether they agree to our terms of use.                                    |
| 7    | If the user agrees to the terms, account registration will be completed.                                |
| 8    | If the user does not agree to the sales, registration will fail and return to the register account day. |

### Use Case "Log In" (U2)

**Class Diagram**

![ClassDiagramU2.png](ClassDiagramU2.png)

| **Use Case ID**          | U2                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
|--------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Use Case Name**        | Log In                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| **Description**          | This use case allows a user to log into the system using their credentials. The user provides their username and password, which are validated against stored data.                                                                                                                                                                                                                                                                                                                                                                                                    |
| **Actors**               | User, UserService, DatabaseService, LoginPage, LoginViewModel, ILoginViewModel                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| **Preconditions**        | The user has an existing account and is on the login page.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **Postconditions**       | The user is authenticated and granted access to the system.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| **Normal Flow**          | 1. User selects "Log In" option on the application interface.<br>2. System presents a login form on the User Interface.<br>3. User enters their username and password.<br>4. User Interface captures the data and sends it to UserService.<br>5. UserService validates the credentials.<br>6. UserService sends a request to DatabaseService to verify the user.<br>7. DatabaseService checks the credentials and confirms authentication.<br>8. UserService confirms successful authentication to the User Interface.<br>9. User Interface grants access to the user. |
| **Alternative Flow**     | **Invalid Credentials**:<br>1. If the credentials are invalid, UserService returns an error message.<br>2. User Interface displays the error message and prompts the user to try again.<br>3. User re-enters credentials and resubmits the form.<br>4. The system processes the new input as described in the Normal Flow.                                                                                                                                                                                                                                             |
| **Exceptions**           | **System Error**:<br>1. If there is a system error during the login process, an error message is displayed to the user.<br>2. The user may try to log in again later.                                                                                                                                                                                                                                                                                                                                                                                                  |
| **Special Requirements** | The system should ensure the login form is secure and protects against common security vulnerabilities such as SQL injection and brute force attacks.                                                                                                                                                                                                                                                                                                                                                                                                                  |
| **Assumptions**          | The user has valid login credentials.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |

## Associations and Multiplicities

- **UserService** is associated with **DatabaseService** (1:1).
- **UserService** can manage multiple **User** instances (1:many).
- **LoginPage** is associated with **LoginViewModel** (1:1).
- **LoginViewModel** is associated with **UserService** (1:1).

**Sequence Diagram**

![SequenceDiagramU2.png](SequenceDiagramU2.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

| Step | Description                                                                                                                                                                                                                  |
|------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User accesses the login form on the User Interface.                                                                                                                                                                          |
| 2    | User enters their username and password into the form.                                                                                                                                                                       |
| 3    | User Interface sends the login credentials to the AuthenticationService.                                                                                                                                                     |
| 4    | AuthenticationService receives the credentials and performs initial checks:<br/>- Validates the format of the username and password.<br/>- If the format is incorrect, it sends an error message back to the User Interface. |
| 5    | If the formats are correct, AuthenticationService hashes the password and sends the username and hashed password to the Database for verification.                                                                           |                                                                                                                 |
| 6    | Database checks the hashed password against the stored hash for the given username:                                                                                                                                          |
|      | - If the username does not exist, it returns a "user not found" response.                                                                                                                                                    |
|      | - If the password does not match, it returns a "wrong password" response.                                                                                                                                                    |
|      | - If both match, it returns a "login successful" response along with user data if necessary.                                                                                                                                 |
| 7    | AuthenticationService receives the response from the Database:                                                                                                                                                               |
|      | - If the login is successful, it may generate a session token or other security credentials and sends a success message along with any user data to the User Interface.                                                      |
|      | - If the login fails, it sends the appropriate error message (e.g., "wrong username or password") to the UserInterface.                                                                                                      |
| 8    | User Interface receives the final response and informs the User:                                                                                                                                                             |
|      | - Displays a welcome message and transitions the user to the dashboard or homepage if login is successful.                                                                                                                   |
|      | - Displays an error message if the login failed, offering the user the option to try again or reset their password.                                                                                                          |

**Activity Diagram**

### Use Case "View and Edit Account Information" (U3)

**Class Diagram**

![ClassDiagramU3.png](ClassDiagramU3.png)

| **Use Case ID**          | U3                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
|--------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Use Case Name**        | View and Edit Account Information                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
| **Description**          | This use case allows a user to view and edit their account information. The user can update details such as username, password, and email, which are then validated and stored in the system.                                                                                                                                                                                                                                                                                                                                                                                                                     |
| **Actors**               | User, UserService, DatabaseService, AccountPage, AccountViewModel, IAccountViewModel                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| **Preconditions**        | The user is logged into the system and is on the account page.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| **Postconditions**       | The user's account information is updated and stored in the database. The user is informed of successful update.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| **Normal Flow**          | 1. User navigates to the account page on the application interface.<br>2. System presents the account information form on the User Interface.<br>3. User views current account details.<br>4. User updates their account information.<br>5. User Interface captures the updated data and sends it to UserService.<br>6. UserService validates the updated data.<br>7. UserService sends the validated data to DatabaseService.<br>8. DatabaseService updates the user data.<br>9. UserService confirms the successful update to the User Interface.<br>10. User Interface displays a success message to the user. |
| **Alternative Flow**     | **Invalid Input**:<br>1. If the updated data is invalid, UserService returns an error message.<br>2. User Interface displays the error message and prompts the user to correct the input.<br>3. User corrects the input and resubmits the form.<br>4. The system processes the corrected input as described in the Normal Flow.                                                                                                                                                                                                                                                                                   |
| **Exceptions**           | **System Error**:<br>1. If there is a system error during the update process, an error message is displayed to the user.<br>2. The user may try to update their information again later.                                                                                                                                                                                                                                                                                                                                                                                                                          |
| **Special Requirements** | The system should ensure the account information form is secure and protects against common security vulnerabilities such as SQL injection and XSS.                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| **Assumptions**          | The user has valid account credentials and is authorized to update their account information.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |

**Associations and Multiplicities**

**UserService** is associated with **DatabaseService** (1:1).
**UserService** can manage multiple **User** instances (1).
**AccountPage** is associated with **AccountViewModel** (1:1).
**AccountViewModel** is associated with **UserService** (1:1).

**Sequence Diagram**

![SequenceDiagramU3.png](SequenceDiagramU3.png)

**Actor**: User

**System Components**: User Interface, UserProfile, Database

**Sequence Steps:**

**Viewing Account Information**

| Step | Description                                                                                           |
|------|-------------------------------------------------------------------------------------------------------|
| 1    | User logs into the system and navigates to the account information page.                              |
| 2    | User Interface sends a request to UserProfile to retrieve the user's information.                     |
| 3    | UserProfile sends a query to the Database to fetch the user's details.                                |
| 4    | Database retrieves the information and returns it to UserProfile.                                     |
| 5    | UserProfile receives the data and sends it to the User Interface.                                     |
| 6    | User Interface displays the user's account information (e.g., username, email, name, academic level). |

**Editing Account Information**

| Step | Description                                                                                     |
|------|-------------------------------------------------------------------------------------------------|
| 1    | User selects the option to edit their account information on the same page.                     |
| 2    | User Interface allows the user to edit fields such as email, name, and academic level.          |
| 3    | User makes changes and submits the updated information.                                         |
| 4    | User Interface sends the updated details to UserProfile.                                        |
| 5    | UserProfile validates the new information and sends an update request to the Database:          |
|      | - Checks for the format of the email.                                                           |
|      | - Validates that the name does not contain invalid characters.                                  |
|      | - Ensures that the academic level is within the allowed range.                                  |
| 6    | Database updates the user's information and confirms the update back to UserProfile.            |
| 7    | UserProfile receives the confirmation and notifies the User Interface of the successful update. |
| 8    | User Interface informs the User that their information has been successfully updated.           |

**Activity Diagram**

![ActivtyDiagramU3.1.png](ActivtyDiagramU3.1.png)

### Use Case "Reset Account Password" (U4)

**Class Diagram**

![ClassDiagramU4.png](ClassDiagramU4.png)

| **Use Case ID**          | U4                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
|--------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Use Case Name**        | Reset Account Password                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| **Description**          | This use case allows a user to reset their account password. The user provides their email, receives a reset link, and sets a new password.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| **Actors**               | User, UserService, DatabaseService, PasswordResetPage, PasswordResetViewModel, IPasswordResetViewModel, EmailService                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| **Preconditions**        | The user has access to the password reset page.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| **Postconditions**       | The user's password is reset and updated in the database. The user is informed of the successful password reset.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
| **Normal Flow**          | 1. User navigates to the password reset page on the application interface.<br>2. System presents the password reset form on the User Interface.<br>3. User enters their email address.<br>4. User Interface captures the email address and sends it to UserService.<br>5. UserService validates the email address.<br>6. UserService sends a request to DatabaseService to verify the user.<br>7. DatabaseService confirms the user's existence.<br>8. UserService generates a password reset link and sends it to the user's email via EmailService.<br>9. User receives the email and clicks on the password reset link.<br>10. System presents the password reset form on the User Interface.<br>11. User enters and confirms the new password.<br>12. User Interface captures the new password and sends it to UserService.<br>13. UserService validates the new password.<br>14. UserService sends the updated password to DatabaseService.<br>15. DatabaseService updates the user's password.<br>16. UserService confirms the successful password reset to the User Interface.<br>17. User Interface displays a success message to the user. |
| **Alternative Flow**     | **Invalid Email**:<br>1. If the email address is invalid, UserService returns an error message.<br>2. User Interface displays the error message and prompts the user to enter a valid email address.<br>3. User re-enters the email address and resubmits the form.<br>4. The system processes the new input as described in the Normal Flow.<br>**Invalid Password**:<br>1. If the new password is invalid, UserService returns an error message.<br>2. User Interface displays the error message and prompts the user to enter a valid password.<br>3. User re-enters the password and resubmits the form.<br>4. The system processes the new input as described in the Normal Flow.                                                                                                                                                                                                                                                                                                                                                                                                                                                              |
| **Exceptions**           | **System Error**:<br>1. If there is a system error during the password reset process, an error message is displayed to the user.<br>2. The user may try to reset their password again later.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
| **Special Requirements** | The system should ensure the password reset form is secure and protects against common security vulnerabilities such as SQL injection and XSS.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| **Assumptions**          | The user has access to their email account and can receive the password reset link.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |

**Associations and Multiplicities**

- **UserService** is associated with **DatabaseService** (1:1).
- **UserService** is associated with **EmailService** (1:1).
- **UserService** can manage multiple **User** instances (1:many).
- **PasswordResetPage** is associated with **PasswordResetViewModel** (1:1).
- **PasswordResetViewModel** is associated with **UserService** (1:1).

**Sequence Diagram**

![SequenceDiagramU4.png](SequenceDiagramU4.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

| Step | Description                                                                                               |
|------|-----------------------------------------------------------------------------------------------------------|
| 1    | User navigates to the login page and clicks on the "Forgot Password" link.                                |
| 2    | User Interface prompts the User to enter their email address.                                             |
| 3    | User enters their email and submits the request.                                                          |
| 4    | User Interface sends the email address to AuthenticationService.                                          |
| 5    | AuthenticationService validates the email format:                                                         |
|      | - If invalid, it sends an error message back to the User Interface, which then displays it to the User.   |
| 6    | If the email format is valid, AuthenticationService checks with the Database to confirm the existence of  |
|      | the account associated with the email.                                                                    |
| 7    | Database returns a response:                                                                              |
|      | - If no account is associated, it sends a "no account found" response to AuthenticationService.           |
|      | - If found, it sends a "user verified" response.                                                          |
| 8    | AuthenticationService:                                                                                    |
|      | - If the user is verified, it generates a password reset link with a unique, time-limited token.          |
|      | - Sends the reset link to the User's email.                                                               |
| 9    | User receives the email and clicks on the password reset link, which redirects them to a password reset   |
|      | page.                                                                                                     |
| 10   | User Interface displays the password reset form where the User can enter a new password.                  |
| 11   | User enters a new password and submits the form.                                                          |
| 12   | User Interface sends the new password to AuthenticationService.                                           |
| 13   | AuthenticationService validates the new password against security criteria:                               |
|      | - If the password does not meet the criteria, sends an error message back to the User Interface.          |
|      | - If it meets the criteria, hashes the password and sends it to the Database for updating.                |
| 14   | Database updates the password and confirms the update to AuthenticationService.                           |
| 15   | AuthenticationService notifies the User Interface of the successful password reset.                       |
| 16   | User Interface informs the User that their password has been successfully reset and redirects them to the |
|      | login page.                                                                                               |

**Activity Diagram**

![ActivityDiagramU4.jpg](ActivityDiagramU4.jpg)

| Step | Description                                                                                                 |
|------|-------------------------------------------------------------------------------------------------------------|
| 1    | Open the forgot password page.                                                                              |
| 2    | The user can enter an email address or username to connect the account.                                     |
| 3    | The system will confirm whether the account exists.                                                         |
| 4    | If the account does not exist, the system will return to the beginning.                                     |
| 5    | If the account exists, the system will send a password reset link to the user’s email address. The password |
|      | reset link will be valid for one hour.                                                                      |
| 6    | If the user enters it in time, then they can reset the password.                                            |
| 7    | If not, the user will not be able to reset the password and will go back to the forgot password page.       |
| 8    | After resetting the password, the system will show the confirm password reset message.                      |

### Use Case "Delete Account" (U5)

**Class Diagram**

![ClassDiagramU5.png](ClassDiagramU5.png)

**Sequence Diagram**

![SequenceDiagramU5.png](SequenceDiagramU5.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

Sequence Steps:

| Step | Description                                                                                                      |
|------|------------------------------------------------------------------------------------------------------------------|
| 1    | User logs into the system and navigates to the account settings or profile page.                                 |
| 2    | User selects the option to delete their account.                                                                 |
| 3    | User Interface prompts the User to confirm their decision:                                                       |
|      | - This may include entering their password again for verification and clicking a "Confirm Deletion" button.      |
| 4    | User enters their password and confirms the deletion.                                                            |
| 5    | User Interface sends the password and deletion request to AuthenticationService.                                 |
| 6    | AuthenticationService verifies the password with the Database:                                                   |
|      | - If the password is incorrect, it sends an "invalid password" response to the User Interface, which informs the |
|      | User.                                                                                                            |
|      | - If the password is correct, it proceeds with the deletion process.                                             |
| 7    | AuthenticationService sends a command to the Database to delete the user's account.                              |
| 8    | Database performs the deletion:                                                                                  |
|      | - Removes all records associated with the user's account (personal information, settings, data, etc.).           |
|      | - Confirms the deletion to AuthenticationService.                                                                |
| 9    | AuthenticationService receives confirmation of the deletion.                                                     |
| 10   | AuthenticationService informs the User Interface that the account has been successfully deleted.                 |
| 11   | User Interface notifies the User that their account has been deleted and logs them out of the system.            |

**Activity Diagram**

### Use Case "View Academic Calendar" (U6)

**Class Diagram**

**Sequence Diagram**

![SequenceDiagram6.png](SequenceDiagram6.png)

**Actor**: User

**System Components**: User Interface, System, Database

**Sequence Steps**:

| Step | Description                                                                                                                                                                                          |
|------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User logs into the system and navigates to the section where the academic calendar is available.                                                                                                     |
| 2    | User Interface sends a request to the System to retrieve the academic calendar.                                                                                                                      |
| 3    | System sends a query to the Database to fetch the academic calendar data.                                                                                                                            |
| 4    | Database retrieves the calendar details and sends them back to the System.                                                                                                                           |
| 5    | System processes the calendar data, organizing it into a user-friendly format.                                                                                                                       |
| 6    | System sends the formatted academic calendar to the User Interface.                                                                                                                                  |
| 7    | User Interface displays the academic calendar to the User, allowing them to view important academic dates, such as semester start and end dates, exam periods, holidays, and registration deadlines. |

**Activity Diagram**

![ActivityDiagramU6.png](ActivityDiagramU6.png)

| Step | Description                              |
|------|------------------------------------------|
| 1    | User requests to view academic calendar. |
| 2    | System gets academic calendar data.      |
| 3    | System displays academic calendar.       |

### Use Case "View and Bookmark Course Pathways" (U7)

**Class Diagram**

**Sequence Diagram**

![SequenceDiagramU7.png](SequenceDiagramU7.png)

**Actor**: User

**System Components**: User Interface, Course, CourseBookmark, Database

**Sequence Steps**:

Viewing Course Pathways

| Step | Description                                                                                                                                           |
|------|-------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User logs into the system and navigates to the section where course pathways are available.                                                           |
| 2    | User Interface sends a request to the Course component to retrieve the available courses and their pathways.                                          |
| 3    | Course component queries the Database to fetch the course details and pathways.                                                                       |
| 4    | Database returns the requested course data to the Course component.                                                                                   |
| 5    | Course component formats the course data and sends it back to the User Interface.                                                                     |
| 6    | User Interface displays the course pathways to the User, allowing them to explore various courses and their prerequisites, credits, and descriptions. |

Bookmarking Courses

| Step | Description                                                                                                                 |
|------|-----------------------------------------------------------------------------------------------------------------------------|
| 1    | User selects specific courses they are interested in and chooses to bookmark them for future reference.                     |
| 2    | User Interface captures the user's selection and sends the course IDs to the CourseBookmark component.                      |
| 3    | CourseBookmark component processes the request and sends it to the Database to save the bookmarks under the user’s profile. |
| 4    | Database stores the bookmark details and confirms the successful bookmarking back to the CourseBookmark component.          |
| 5    | CourseBookmark component confirms the successful bookmarking to the User Interface.                                         |
| 6    | User Interface notifies the User that the courses have been successfully bookmarked.                                        |

**Activity Diagram**

![ActivityDiagramU7.png](ActivityDiagramU7.png)

| Step | Description                                                                                                 |
|------|-------------------------------------------------------------------------------------------------------------|
| 1    | User views recommended courses.                                                                             |
| 2    | User selects a course to bookmark.                                                                          |
| 3    | System saves the course to the bookmark list.                                                               |
| 4    | User accesses the bookmark section.                                                                         |
| 5    | System displays bookmarked courses.                                                                         |
| 6    | If the user removes a course from the bookmark, the system returns to the viewing recommended courses page. |
| 7    | If the user adds courses to the bookmark, the system updates the bookmark list.                             |

### Use Case "Filter Courses" (U8)

**Class Diagram**

**Sequence Diagram**

![SequenceDiagramU8.png](SequenceDiagramU8.png)

**Actor**: User

**System Components**: User Interface, CourseRecommendation, Database

Sequence Steps:

| Step | Description                                                                                                                                                         |
|------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User accesses the course browsing or recommendation section of the application.                                                                                     |
| 2    | User Interface displays various filter options (e.g., department, level, availability).                                                                             |
| 3    | User selects desired filter criteria and submits the filter request.                                                                                                |
| 4    | User Interface captures the filter choices and sends them to the CourseRecommendation component.                                                                    |
| 5    | CourseRecommendation processes the request, formulating a query based on the selected criteria.                                                                     |
| 6    | CourseRecommendation sends the query to the Database to retrieve relevant courses.                                                                                  |
| 7    | Database executes the query and retrieves courses that match the filter criteria.                                                                                   |
| 8    | Database sends the filtered course results back to the CourseRecommendation component.                                                                              |
| 9    | CourseRecommendation processes the results, perhaps ordering or further refining them based on additional logic (like prioritizing by popularity or prerequisites). |
| 10   | CourseRecommendation sends the processed course list back to the User Interface.                                                                                    |
| 11   | User Interface updates the display to show the filtered courses to the User.                                                                                        |

**Activity Diagram**

![ActivityDiagramU8.png](ActivityDiagramU8.png)

### Use Case "Obtain Course Recommendation from Query" (U9)

**Class Diagram**

**Sequence Diagram**

![SequenceDiagramU9.png](SequenceDiagramU9.png)

**Actor**: User

**System Components**: User Interface, Query, OpenAIAPI, CourseRecommendation, Database

Sequence Steps:

| Step | Description                                                                                                                                                    |
|------|----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User logs into the system and navigates to the course recommendation feature.                                                                                  |
| 2    | User inputs a natural language query describing their course interests or requirements in the search field provided on the User Interface.                     |
| 3    | User Interface captures the query and sends it to the Query component.                                                                                         |
| 4    | Query component parses the query to extract essential keywords and search parameters, then sends this refined data to the OpenAIAPI.                           |
| 5    | OpenAIAPI analyzes the refined query to further understand the context and intent, extracting key topics and terms relevant to courses.                        |
| 6    | OpenAIAPI sends the analysis results back to the Query component.                                                                                              |
| 7    | Query component forwards these results to the CourseRecommendation system.                                                                                     |
| 8    | CourseRecommendation uses the received keywords and terms to formulate a database search query.                                                                |
| 9    | CourseRecommendation sends the search query to the Database to find matching courses.                                                                          |
| 10   | Database retrieves courses that fit the criteria and sends them back to the CourseRecommendation system.                                                       |
| 11   | CourseRecommendation processes the list, possibly ranking the courses based on relevance to the query, popularity, and other criteria.                         |
| 12   | CourseRecommendation sends the final list of recommended courses to the User Interface.                                                                        |
| 13   | User Interface displays the recommended courses to the User, providing detailed information such as course descriptions, prerequisites, and possible pathways. |

**Activity Diagram**

![ActivityDiagramU9.png](ActivityDiagramU9.png)

### Use Case "Submit Course Feedback" (U10)

**Class Diagram**

**Sequence Diagram**

![SequenceDiagramU10.png](SequenceDiagramU10.png)

**Actor**: User

**System Components**: User Interface, Feedback, Database

**Sequence Steps**:

| Step | Description                                                                                                                                                     |
|------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User completes a course and decides to provide feedback.                                                                                                        |
| 2    | User navigates to the feedback section of the course in the User Interface.                                                                                     |
| 3    | User Interface provides a form for submitting feedback, which includes rating and comment fields.                                                               |
| 4    | User fills out the form, providing a numerical rating and optional textual comments.                                                                            |
| 5    | User Interface captures the feedback and sends it to the Feedback component.                                                                                    |
| 6    | Feedback component validates the input to ensure it meets any specified criteria (e.g., rating within valid range, comments do not contain prohibited content). |
| 7    | If validation fails, Feedback component sends an error message back to the User Interface, which then displays it to the User.                                  |
| 8    | If validation passes, Feedback component sends the feedback data to the Database.                                                                               |
| 9    | Database stores the feedback, linking it with the user's ID and the course ID.                                                                                  |
| 10   | Database confirms the successful storage of feedback to the Feedback component.                                                                                 |
| 11   | Feedback component notifies the User Interface of the successful feedback submission.                                                                           |
| 12   | User Interface displays a confirmation message to the User thanking them for their feedback.                                                                    |

**Activity Diagrams**

![ActivityDiagramU10.png](ActivityDiagramU10.png)

| Step | Description                                                                          |
|------|--------------------------------------------------------------------------------------|
| 1    | User completes a course.                                                             |
| 2    | User enters a rating from a scale of 1 to 5.                                         |
| 3    | Users have the option to leave written reviews.                                      |
| 4    | User submits course feedback.                                                        |
| 5    | System filters inappropriate language/spam.                                          |
| 6    | If feedback is inappropriate, the system goes back to the leave written review page. |
| 7    | If feedback is appropriate, the feedback will be stored by the system.               |
| 8    | System aggregates ratings.                                                           |
| 9    | System displays ratings and reviews.                                                 |

### Use Case "Access and Analyze User Data" (U11)

**Class Diagram**

**Sequence Diagram**

![SequenceDiagramU11.png](SequenceDiagramU11.png)

**Actor**: Admin

**System Components**: User Interface, SystemAnalytics, Database

**Sequence Steps**:

| Step | Description                                                                                                                                                                                              |
|------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | Admin logs into the system and navigates to the dashboard for user data analysis.                                                                                                                        |
| 2    | User Interface presents options for selecting specific data sets (e.g., user engagement metrics, feedback, course completion rates) and criteria for analysis (e.g., time period, user demographics).    |
| 3    | Admin selects the desired data sets and criteria, and submits the query.                                                                                                                                 |
| 4    | User Interface sends the request to the SystemAnalytics component.                                                                                                                                       |
| 5    | SystemAnalytics formulates the query based on the selected parameters and sends it to the Database.                                                                                                      |
| 6    | Database executes the query and retrieves the relevant user data.                                                                                                                                        |
| 7    | Database sends the raw data back to the SystemAnalytics.                                                                                                                                                 |
| 8    | SystemAnalytics processes the raw data, performing necessary calculations and transformations to produce actionable insights (e.g., statistical analysis, trend detection, pattern recognition).         |
| 9    | SystemAnalytics sends the analyzed data back to the User Interface.                                                                                                                                      |
| 10   | User Interface displays the analyzed results in an accessible format (e.g., graphs, charts, tables) to the Admin.                                                                                        |
| 11   | Admin reviews the results, gaining insights into user behavior and system performance which can be used to make informed decisions about system improvements, policy changes, or targeted interventions. |

**Activity Diagram**

![ActivityDiagramU11.jpg](ActivityDiagramU11.jpg)

| Step | Description                                                                                         |
|------|-----------------------------------------------------------------------------------------------------|
| 1    | University official opens the access user data page.                                                |
| 2    | The user selects which data they want to access (User data or Course data).                         |
| 3    | Selecting user data, the user can view user information and user data analyzed by the system.       |
| 4    | Selecting course data, the user can view course information and course data analyzed by the system. |
| 5    | Users end this access.                                                                              |
| 6    | The user can choose to access other data or end visit to the access user data page.                 |
| 7    | If user wants to access other data, the system will return to select data stage.                    |
| 8    | If user wants to end visit, the activity ends.                                                      |

### Use Case "Create and Delete Thread" (U12)

**Class Diagram**

**Creating a Thread**

**Sequence Diagram**

![SequenceDiagramU12.1.png](SequenceDiagramU12.1.png)

**Actor**: User

**System Components**: User Interface, Forum Management, Database

**Sequence Steps**:

| Step | Description                                                                                                                                                      |
|------|------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User Authentication: The user logs into the system.                                                                                                              |
| 2    | Access Community Forum: The user navigates to the community forums section of the interface.                                                                     |
| 3    | Initiate Thread Creation: The user clicks on the "Create New Thread" button or link.                                                                             |
| 4    | Enter Thread Details: The user enters the title and description of the thread. Additional options like tagging relevant course codes or topics may be available. |
| 5    | Submit Thread: After entering all necessary information, the user submits the thread for posting.                                                                |
| 6    | Confirmation: The system displays a confirmation message indicating that the thread has been successfully created.                                               |
| 7    | View Thread: The new thread is now visible in the forum for other users to view and respond to.                                                                  |

**Deleting a Thread**

**Sequence Diagram**

![SequenceDiagramU12.2.png](SequenceDiagramU12.2.png)

**Actor**: User

**System Components**: User Interface, Forum Management, Database

**Sequence Steps**:

| Step | Description                                                                                                                                                                              |
|------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | Confirm that the user is logged in (could be verified continuously through session management).                                                                                          |
| 2    | The user locates the thread they wish to delete. This might involve navigating through their profile to find threads they've started or directly accessing the thread through the forum. |
| 3    | The user selects the "Delete" option on the thread. This may be an icon or a link, typically located near the thread title or at the end of the first post.                              |
| 4    | The system prompts the user to confirm the deletion to prevent accidental removals. The user must confirm their intent to delete the thread.                                             |
| 5    | Upon confirmation, the system deletes the thread.                                                                                                                                        |
| 6    | The user receives a message confirming that the thread has been successfully deleted.                                                                                                    |
| 7    | The thread is removed from the forum display, and the user is redirected back to the forum homepage or their profile page.                                                               |

#### Use Case "Create, Edit, Reply, and Delete Post" (U13) ####

**Class Diagram**

**Creating a Post**

**Sequence Diagram**

![SequenceDiagramU13.1.png](SequenceDiagramU13.1.png)

**Actor**: User

**System Components**: User Interface, Post Management, Database

**Sequence Steps**

| Step | Description                                                                                                                                                                                |
|------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User logs into the system and navigates to a specific thread in the community forum, where the User Interface displays the thread with existing posts and an option to add a new post.     |
| 2    | User selects the option to create a new post, and the User Interface presents a form for entering the post's content.                                                                      |
| 3    | User enters details for the new post and submits the form, while the User Interface captures the input data and sends it to the PostManagement component.                                  |
| 4    | PostManagement validates the post details for inappropriate content or format errors and sends a create request to the Database.                                                           |
| 5    | Database stores the new post, assigns it an identifier, and links it to the thread, then confirms the creation back to PostManagement.                                                     |
| 6    | PostManagement receives the confirmation including a success message and details about the new post (e.g., post ID, timestamp) and notifies the User Interface of the successful creation. |
| 7    | User Interface displays the newly created post within the thread and confirms to the User, making the post live in the thread for others to view and respond to.                           |

**Editing a Post**

![SequenceDiagramU13.2.png](SequenceDiagramU13.2.png)

**Actor**: User

**System Components**: User Interface, Post Management, Database

Sequence Steps:

| Step | Description                                                                                                                                                               |
|------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User selects the edit option on their own post, and the User Interface provides an editable form pre-filled with the existing post content.                               |
| 2    | User modifies the content and submits the updated information, after which the User Interface sends the updated content to PostManagement.                                |
| 3    | PostManagement validates the updated details for format and appropriateness, and sends an update request to the Database.                                                 |
| 4    | Database updates the post details, modifies the post record, and confirms the update back to PostManagement.                                                              |
| 5    | PostManagement receives the update confirmation and sends a message indicating successful update to the User Interface.                                                   |
| 6    | User Interface updates the post display and notifies the User of the successful edit, allowing the User to see the updated content in place of the old one in the thread. |

#### Replying to a Post ####

![SequenceDiagramU13.3.png](SequenceDiagramU13.3.png)

| Step | Description                                                                                                                                               |
|------|-----------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User selects the reply option on a post, and the User Interface provides a form for entering the reply content.                                           |
| 2    | User writes their reply and submits it, after which the User Interface captures the reply and forwards it to PostManagement.                              |
| 3    | PostManagement processes the reply, ensuring it is linked to the correct post, and sends it to the Database.                                              |
| 4    | Database stores the reply and links it under the original post, confirming back to PostManagement.                                                        |
| 5    | PostManagement confirms the successful addition of the reply and sends a success message to the User Interface.                                           |
| 6    | User Interface displays the new reply under the original post and confirms to the User, updating the thread to show the reply inline with the discussion. |

#### Deleting a Post ####

![SequenceDiagramU13.4.png](SequenceDiagramU13.4.png)

| Step | Description                                                                                                                                                                         |
|------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1    | User selects the delete option on their post, and the User Interface asks the User to confirm the deletion to prevent accidental removals.                                          |
| 2    | Upon confirmation, User Interface sends the delete request to PostManagement, including the post ID and user verification.                                                          |
| 3    | PostManagement verifies the User's authority to delete the post, checking if the User is the owner of the post or has moderator rights, and sends a delete command to the Database. |
| 4    | Database deletes the post and returns a confirmation of deletion to PostManagement.                                                                                                 |
| 5    | PostManagement receives the deletion confirmation and notifies the User Interface.                                                                                                  |
| 6    | User Interface updates to reflect the deletion of the post and informs the User, refreshing the forum display to show that the post is no longer available.                         |
