# System Design Diagrams

## Class Diagram

![ClassDiagram.png](ClassDiagram.png)

1. User
    - Attributes: userID, username, password, email
    - Methods: Login(), Logout(), Register(), DeleteUser()

2. UserProfile
    - Attributes: firstName, lastName, userPreferences, academicLevel
    - Methods: UpdateProfile(), ViewProfile()

3. Course
    - Attributes: courseID, courseName, description, credits, prerequisites
    - Methods: GetCourseDetails(), UpdateCourseInfo()

4. CourseRecommendation
    - Attributes: recommendationList
    - Methods: GenerateRecommendations(query), FilterResults(criteria)

5. Query
    - Attributes: queryString, searchParameters
    - Methods: ParseQuery(), ExecuteSearch()

6. OpenAIAPI
    - Attributes: models, configuration
    - Methods: AnalyzeText(input), ExtractKeywords()

7. Feedback
    - Attributes: feedbackID, rating, comments, userID, course_urdID
    - Methods: SubmitFeedback(), EditFeedback()

8. Forum
    - Attributes: forumID, title, description
    - Methods: CreateThread(), DeleteThread(), PostReply()

9. ForumThread
    - Attributes: threadID, title, creatorID, creationDate
    - Methods: EditThread(), ViewThread()

10. ForumPost
    - Attributes: postID, threadID, content, postTime
    - Methods: EditPost(), DeletePost()

11. CourseBookmark
    - Attributes: userID, courseID, bookmarkDate
    - Methods: AddBookmark(), RemoveBookmark()

12. Admin
    - Attributes: adminID, adminLevel
    - Methods: ViewUserData(), ModifyCourseInfo()

13. SystemAnalytics
    - Attributes: dataLogs, accessRecords
    - Methods: GenerateReport(), AnalyzeTrends()

14. AuthenticationService
    - Attributes: securityProtocol, sessionDetails
    - Methods: AuthenticateUser(), ResetPassword()

### Use cases

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

## Sequence Diagram

#### Use Case "Register Account" (U1) ####

![SequenceDiagramU1.png](SequenceDiagramU1.png)

1. Actor: User
2. System Components: User Interface, AuthenticationService, Database
   Sequence Steps:
1. User initiates the registration process by accessing the registration form on the User Interface.
2. User fills out the registration form with necessary details (username, password, email, etc.).
3. User Interface sends the filled-out registration form data to the AuthenticationService.
4. AuthenticationService receives the registration data and performs initial validations:
    - Validates the format of the email.
    - Checks if the password meets the security criteria.
    - Ensures the username is not already taken (involves a quick check with the Database).
5. If any validation fails, AuthenticationService sends an error message back to the User Interface, which then displays it to the User.
6. If all validations pass, AuthenticationService hashes the password and prepares the data for database entry.
7. AuthenticationService sends the validated and processed data to the Database to create a new user record.
8. Database attempts to create a new record:
    - Checks for uniqueness constraints again (to prevent race conditions).
    - If successful, confirms the creation of the user account.
    - If it fails (e.g., due to a username now being taken), it sends a failure message back to the AuthenticationService.
9. AuthenticationService receives the response from the Database:
    - If the account creation is successful, it sends a success notification to the User Interface.
    - If the account creation fails, it sends the appropriate error message to the User Interface.
10. User Interface receives the final response and informs the User:
    - Displays a success message and possibly directs the user to a login page or a confirmation email is sent.
    - Displays an error message if the registration failed, asking the user to try different credentials or contact support.

#### Use Case "Log In" (U2) ####

![SequenceDiagramU2.png](SequenceDiagramU2.png)

1. Actor: User
2. System Components: User Interface, AuthenticationService, Database

Sequence Steps:

1. User accesses the login form on the User Interface.
2. User enters their username and password into the form.
3. User Interface sends the login credentials to the AuthenticationService.
4. AuthenticationService receives the credentials and performs initial checks:
    - Validates the format of the username and password.
    - If the format is incorrect, it sends an error message back to the User Interface.
5. If the formats are correct, AuthenticationService hashes the password and sends the username and hashed password to the Database for
   verification.
6. Database checks the hashed password against the stored hash for the given username:
    - If the username does not exist, it returns a "user not found" response.
    - If the password does not match, it returns a "wrong password" response.
    - If both match, it returns a "login successful" response along with user data if necessary.
7. AuthenticationService receives the response from the Database:
    - If the login is successful, it may generate a session token or other security credentials and sends a success message along with any
      user data to the User Interface.
    - If the login fails, it sends the appropriate error message (e.g., "wrong username or password") to the User Interface.
8. User Interface receives the final response and informs the User:
    - Displays a welcome message and transitions the user to the dashboard or homepage if login is successful.
    - Displays an error message if the login failed, offering the user the option to try again or reset their password.


