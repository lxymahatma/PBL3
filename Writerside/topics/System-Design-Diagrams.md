# System Design Diagrams

## Class Diagram

![ClassDiagram.png](ClassDiagram.png)

1. User
    - Attributes: Username, Password, Email
    - Methods: Login(), Logout(), Register(), DeleteUser()

2. UserProfile
    - Attributes: FirstName, LastName, UserPreferences, AcademicLevel
    - Methods: UpdateProfile(), ViewProfile()

3. Course
    - Attributes: CourseID, CourseName, Description, Credits, Prerequisites
    - Methods: GetCourseDetails(), UpdateCourseInfo()

4. CourseRecommendation
    - Attributes: RecommendationList
    - Methods: GenerateRecommendations(Query), FilterResults(Criteria)

5. Query
    - Attributes: QueryString, SearchParameters
    - Methods: ParseQuery(), ExecuteSearch()

6. OpenAIAPI
    - Attributes: Models, Configuration
    - Methods: AnalyzeText(Input), ExtractKeywords()

7. Feedback
    - Attributes: FeedbackID, Rating, Comments, Username, CourseID
    - Methods: SubmitFeedback(), EditFeedback()

8. Forum
    - Attributes: ForumID, Title, Description
    - Methods: CreateThread(), DeleteThread(), PostReply()

9. ForumThread
    - Attributes: ThreadID, Title, CreatorID, CreationDate
    - Methods: EditThread(), ViewThread()

10. ForumPost
    - Attributes: PostID, ThreadID, Content, PostTime
    - Methods: EditPost(), DeleteParent()

11. CourseBookmark
    - Attributes: Username, CourseID, BookmarkDate
    - Methods: AddBookmark(), RemoveBookmark()

12. Admin
    - Attributes: AdminID, AdminLevel
    - Methods: ViewUserData(), ModifyCourseInfo()

13. SystemAnalytics
    - Attributes: DataLogs, AccessRecords
    - Methods: GenerateReport(), AnalyzeTrends()

14. AuthenticationService
    - Attributes: SecurityProtocol, SessionDetails
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

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

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

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

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

#### Use Case "View and Edit Account Information" (U3) ####

![SequenceDiagramU3.png](SequenceDiagramU3.png)

**Actor**: User

**System Components**: User Interface, UserProfile, Database

**Sequence Steps:**

**Viewing Account Information**

1. User logs into the system and navigates to the account information page.
2. User Interface sends a request to UserProfile to retrieve the user's information.
3. UserProfile sends a query to the Database to fetch the user's details.
4. Database retrieves the information and returns it to UserProfile.
5. UserProfile receives the data and sends it to the User Interface.
6. User Interface displays the user's account information (e.g., username, email, name, academic level).

**Editing Account Information**

1. User selects the option to edit their account information on the same page.
2. User Interface allows the user to edit fields such as email, name, and academic level.
3. User makes changes and submits the updated information.
4. User Interface sends the updated details to UserProfile.
5. UserProfile validates the new information and sends an update request to the Database:
    - Checks for the format of the email.
    - Validates that the name does not contain invalid characters.
    - Ensures that the academic level is within the allowed range.
6. Database updates the user's information and confirms the update back to UserProfile.
7. UserProfile receives the confirmation and notifies the User Interface of the successful update.
8. User Interface informs the User that their information has been successfully updated.

#### Use Case "Reset Account Password" (U4) ####

![SequenceDiagramU4.png](SequenceDiagramU4.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

1. User navigates to the login page and clicks on the "Forgot Password" link.
2. User Interface prompts the User to enter their email address.
3. User enters their email and submits the request.
4. User Interface sends the email address to AuthenticationService.
5. AuthenticationService validates the email format:
    - If invalid, it sends an error message back to the User Interface, which then displays it to the User.
6. If the email format is valid, AuthenticationService checks with the Database to confirm the existence of the account associated with the
   email.
7. Database returns a response:
    - If no account is associated, it sends a "no account found" response to AuthenticationService.
    - If found, it sends a "user verified" response.
8. AuthenticationService:
    - If the user is verified, it generates a password reset link with a unique, time-limited token.
    - Sends the reset link to the User's email.
9. User receives the email and clicks on the password reset link, which redirects them to a password reset page.
10. User Interface displays the password reset form where the User can enter a new password.
11. User enters a new password and submits the form.
12. User Interface sends the new password to AuthenticationService.
13. AuthenticationService validates the new password against security criteria:
    - If the password does not meet the criteria, sends an error message back to the User Interface.
    - If it meets the criteria, hashes the password and sends it to the Database for updating.
14. Database updates the password and confirms the update to AuthenticationService.
15. AuthenticationService notifies the User Interface of the successful password reset.
16. User Interface informs the User that their password has been successfully reset and redirects them to the login page.

#### Use Case "Delete Account" (U5) ####

![SequenceDiagramU5.png](SequenceDiagramU5.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

Sequence Steps:

1. User logs into the system and navigates to the account settings or profile page.
2. User selects the option to delete their account.
3. User Interface prompts the User to confirm their decision:
    - This may include entering their password again for verification and clicking a "Confirm Deletion" button.
4. User enters their password and confirms the deletion.
5. User Interface sends the password and deletion request to AuthenticationService.
6. AuthenticationService verifies the password with the Database:
    - If the password is incorrect, it sends an "invalid password" response to the User Interface, which informs the User.
    - If the password is correct, it proceeds with the deletion process.
7. AuthenticationService sends a command to the Database to delete the user's account.
8. Database performs the deletion:
    - Removes all records associated with the user's account (personal information, settings, data, etc.).
    - Confirms the deletion to AuthenticationService.
9. AuthenticationService receives confirmation of the deletion.
10. AuthenticationService informs the User Interface that the account has been successfully deleted.
11. User Interface notifies the User that their account has been deleted and logs them out of the system.

#### Use Case "View Academic Calendar" (U6) ####

![SequenceDiagram6.png](SequenceDiagram6.png)

**Actor**: User

**System Components**: User Interface, System, Database

**Sequence Steps**:

1. User logs into the system and navigates to the section where the academic calendar is available.
2. User Interface sends a request to the System to retrieve the academic calendar.
3. System sends a query to the Database to fetch the academic calendar data.
4. Database retrieves the calendar details and sends them back to the System.
5. System processes the calendar data, organizing it into a user-friendly format.
6. System sends the formatted academic calendar to the User Interface.
7. User Interface displays the academic calendar to the User, allowing them to view important academic dates, such as semester start and end
   dates, exam periods, holidays, and registration deadlines.

#### Use Case "View and Bookmark Course Pathways" (U7) ####

**Actor**: User

**System Components**: User Interface, Course, CourseBookmark, Database

**Sequence Steps**:

Viewing Course Pathways

1. User logs into the system and navigates to the section where course pathways are available.
2. User Interface sends a request to the Course component to retrieve the available courses and their pathways.
3. Course component queries the Database to fetch the course details and pathways.
4. Database returns the requested course data to the Course component.
5. Course component formats the course data and sends it back to the User Interface.
6. User Interface displays the course pathways to the User, allowing them to explore various courses and their prerequisites, credits, and
   descriptions.

Bookmarking Courses

1. User selects specific courses they are interested in and chooses to bookmark them for future reference.
2. User Interface captures the user's selection and sends the course IDs to the CourseBookmark component.
3. CourseBookmark component processes the request and sends it to the Database to save the bookmarks under the user’s profile.
4. Database stores the bookmark details and confirms the successful bookmarking back to the CourseBookmark component.
5. CourseBookmark component confirms the successful bookmarking to the User Interface.
6. User Interface notifies the User that the courses have been successfully bookmarked.

#### Use Case "Filter Courses" (U8) ####

#### Use Case "Obtain Course Recommendation from Query" (U9) ####

#### Use Case "Submit Course Feedback" (U10) ####

#### Use Case "Access and Analyze User Data" (U11) ####