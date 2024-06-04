# System Design Diagrams

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

**Sequence Diagram**

![SequenceDiagramU1.png](SequenceDiagramU1.png)

**Actor**: User

**System Components**: User Interface, AuthenticationService, Database

**Sequence Steps**:

| Step | Description                                                                                                  |
|------|--------------------------------------------------------------------------------------------------------------|
| 1    | User initiates the registration process by accessing the registration form on the User Interface.            |
| 2    | User fills out the registration form with necessary details (username, password, email, etc.).               |
| 3    | User Interface sends the filled-out registration form data to the AuthenticationService.                     |
| 4    | AuthenticationService receives the registration data and performs initial validations:                       |
|      | - Validates the format of the email.                                                                         |
|      | - Checks if the password meets the security criteria.                                                        |
|      | - Ensures the username is not already taken (involves a quick check with the Database).                      |
| 5    | If any validation fails, AuthenticationService sends an error message back to the User Interface, which then |
|      | displays it to the User.                                                                                     |
| 6    | If all validations pass, AuthenticationService hashes the password and prepares the data for database entry. |
| 7    | AuthenticationService sends the validated and processed data to the Database to create a new user record.    |
| 8    | Database attempts to create a new record:                                                                    |
|      | - Checks for uniqueness constraints again (to prevent race conditions).                                      |
|      | - If successful, confirms the creation of the user account.                                                  |
|      | - If it fails (e.g., due to a username now being taken), it sends a failure message back to the              |
|      | AuthenticationService.                                                                                       |
| 9    | AuthenticationService receives the response from the Database:                                               |
|      | - If the account creation is successful, it sends a success notification to the User Interface.              |
|      | - If the account creation fails, it sends the appropriate error message to the User Interface.               |
| 10   | User Interface receives the final response and informs the User:                                             |
|      | - Displays a success message and possibly directs the user to a flush page or a confirmation email is sent.  |
|      | - Displays an error message if the registration failed, asking the user to try different credentials or      |
|      | contact support.                                                                                             |

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

**Sequence Diagram**

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

**Activity Diagram**

### Use Case "View and Edit Account Information" (U3)

**Sequence Diagram**

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

**Activity Diagram**

![ActivtyDiagramU3.1.png](ActivtyDiagramU3.1.png)

### Use Case "Reset Account Password" (U4)

**Sequence Diagram**

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

**Activity Diagram**

![ActivityDiagramU4.jpg](ActivityDiagramU4.jpg)

1. Open the forgot password page.
2. The user can enter email address or username to connect the account.
3. The system will confirm whether the account exists.
4. If the account not exists, the system will return to the beginning.
5. If the account exists, the system will send a password reset link to user’s email address. Password reset link will be valid for one
   hour.
6. If user enter it in time, the they can reset the password.
7. If not the user will not able to reset the password, and go back to the forgot password page.
8. After reset the password the system will show the confirm password reset message.

### Use Case "Delete Account" (U5)

**Sequence Diagram**

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

**Activity Diagram**

### Use Case "View Academic Calendar" (U6)

**Sequence Diagram**

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

**Activity Diagram**

![ActivityDiagramU6.png](ActivityDiagramU6.png)

1. User requests to view academic calendar
2. System gets academic calendar data
3. System displays academic calendar

### Use Case "View and Bookmark Course Pathways" (U7)

**Sequence Diagram**

![SequenceDiagramU7.png](SequenceDiagramU7.png)

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

**Activity Diagram**

![ActivityDiagramU7.png](ActivityDiagramU7.png)

1. User views recommended courses
2. User selects course to bookmark
3. System saves course to bookmark list
4. User accesses bookmark section
5. System displays bookmarked courses
6. If user removes course from bookmark, system returns to the viewing recommended courses page
7. If user adds courses to bookmark, system updates bookmark list

### Use Case "Filter Courses" (U8)

**Sequence Diagram**

![SequenceDiagramU8.png](SequenceDiagramU8.png)

**Actor**: User

**System Components**: User Interface, CourseRecommendation, Database

Sequence Steps:

1. User accesses the course browsing or recommendation section of the application.
2. User Interface displays various filter options (e.g., department, level, availability).
3. User selects desired filter criteria and submits the filter request.
4. User Interface captures the filter choices and sends them to the CourseRecommendation component.
5. CourseRecommendation processes the request, formulating a query based on the selected criteria.
6. CourseRecommendation sends the query to the Database to retrieve relevant courses.
7. Database executes the query and retrieves courses that match the filter criteria.
8. Database sends the filtered course results back to the CourseRecommendation component.
9. CourseRecommendation processes the results, perhaps ordering or further refining them based on additional logic (like prioritizing by
   popularity or prerequisites).
10. CourseRecommendation sends the processed course list back to the User Interface.
11. User Interface updates the display to show the filtered courses to the User.

**Activity Diagram**

![ActivityDiagramU8.png](ActivityDiagramU8.png)

### Use Case "Obtain Course Recommendation from Query" (U9)

**Sequence Diagram**

![SequenceDiagramU9.png](SequenceDiagramU9.png)

**Actor**: User

**System Components**: User Interface, Query, OpenAIAPI, CourseRecommendation, Database

Sequence Steps:

1. User logs into the system and navigates to the course recommendation feature.
2. User inputs a natural language query describing their course interests or requirements in the search field provided on the User
   Interface.
3. User Interface captures the query and sends it to the Query component.
4. Query component parses the query to extract essential keywords and search parameters, then sends this refined data to the OpenAIAPI.
5. OpenAIAPI analyzes the refined query to further understand the context and intent, extracting key topics and terms relevant to courses.
6. OpenAIAPI sends the analysis results back to the Query component.
7. Query component forwards these results to the CourseRecommendation system.
8. CourseRecommendation uses the received keywords and terms to formulate a database search query.
9. CourseRecommendation sends the search query to the Database to find matching courses.
10. Database retrieves courses that fit the criteria and sends them back to the CourseRecommendation system.
11. CourseRecommendation processes the list, possibly ranking the courses based on relevance to the query, popularity, and other criteria.
12. CourseRecommendation sends the final list of recommended courses to the User Interface.
13. User Interface displays the recommended courses to the User, providing detailed information such as course descriptions, prerequisites,
    and possible pathways.

**Activity Diagram**

![ActivityDiagramU9.png](ActivityDiagramU9.png)

### Use Case "Submit Course Feedback" (U10)

**Sequence Diagram**

![SequenceDiagramU10.png](SequenceDiagramU10.png)

**Actor**: User

**System Components**: User Interface, Feedback, Database

**Sequence Steps**:

1. User completes a course and decides to provide feedback.
2. User navigates to the feedback section of the course in the User Interface.
3. User Interface provides a form for submitting feedback, which includes rating and comment fields.
4. User fills out the form, providing a numerical rating and optional textual comments.
5. User Interface captures the feedback and sends it to the Feedback component.
6. Feedback component validates the input to ensure it meets any specified criteria (e.g., rating within valid range, comments do not
   contain prohibited content).
7. If validation fails, Feedback component sends an error message back to the User Interface, which then displays it to the User.
8. If validation passes, Feedback component sends the feedback data to the Database.
9. Database stores the feedback, linking it with the user's ID and the course ID.
10. Database confirms the successful storage of feedback to the Feedback component.
11. Feedback component notifies the User Interface of the successful feedback submission.
12. User Interface displays a confirmation message to the User thanking them for their feedback.

**Activity Diagrams**

![ActivityDiagramU10.png](ActivityDiagramU10.png)

1. User completes a course
2. User enters rating from a scale of 1 to 5
3. Users have the option to leave written reviews
4. User submits course feedback
5. System filters inappropriate language/spam
6. If feedback is inappropriate, the system goes back to the leave written review page
7. If feedback is appropriate, feedback will be stores by the system
8. System aggregates ratings
9. System displays ratings and reviews

### Use Case "Access and Analyze User Data" (U11)

**Sequence Diagram**

![SequenceDiagramU11.png](SequenceDiagramU11.png)

**Actor**: Admin

**System Components**: User Interface, SystemAnalytics, Database

**Sequence Steps**:

1. Admin logs into the system and navigates to the dashboard for user data analysis.
2. User Interface presents options for selecting specific data sets (e.g., user engagement metrics, feedback, course completion rates) and
   criteria for analysis (e.g., time period, user demographics).
3. Admin selects the desired data sets and criteria, and submits the query.
4. User Interface sends the request to the SystemAnalytics component.
5. SystemAnalytics formulates the query based on the selected parameters and sends it to the Database.
6. Database executes the query and retrieves the relevant user data.
7. Database sends the raw data back to the SystemAnalytics.
8. SystemAnalytics processes the raw data, performing necessary calculations and transformations to produce actionable insights (e.g.,
   statistical analysis, trend detection, pattern recognition).
9. SystemAnalytics sends the analyzed data back to the User Interface.
10. User Interface displays the analyzed results in an accessible format (e.g., graphs, charts, tables) to the Admin.
11. Admin reviews the results, gaining insights into user behavior and system performance which can be used to make informed decisions about
    system improvements, policy changes, or targeted interventions.

**Activity Diagram**

![ActivityDiagramU11.jpg](ActivityDiagramU11.jpg)

1. University official open the access user data page.
2. The user select which data they want to access (User data or Course data).
3. Selecting user data, the user can view user information and user data analyzed by the system.
4. Selecting course data, the user can view course information and course data analyzed by the system.
5. Users end this access.
6. The user can choose to access other data or end visit the access user data page.
7. If user want to access other data, the system will return to select data stage.
8. If user want to end visit the activity end.

### Use Case "Create and Delete Thread" (U12)

**Creating a Thread**

**Sequence Diagram**

![SequenceDiagramU12.1.png](SequenceDiagramU12.1.png)

**Actor**: User

**System Components**: User Interface, Forum Management, Database

**Sequence Steps**:

1. User Authentication: The user logs into the system.
2. Access Community Forum: The user navigates to the community forums section of the interface.
3. Initiate Thread Creation: The user clicks on the "Create New Thread" button or link.
4. Enter Thread Details: The user enters the title and description of the thread. Additional options like tagging relevant course codes or
   topics may be available.
5. Submit Thread: After entering all necessary information, the user submits the thread for posting.
6. Confirmation: The system displays a confirmation message indicating that the thread has been successfully created.
7. View Thread: The new thread is now visible in the forum for other users to view and respond to.

**Deleting a Thread**

**Sequence Diagram**

![SequenceDiagramU12.2.png](SequenceDiagramU12.2.png)

**Actor**: User

**System Components**: User Interface, Forum Management, Database

**Sequence Steps**:

1. User Authentication: Confirm that the user is logged in (could be verified continuously through session management).
2. Navigate to Thread: The user locates the thread they wish to delete. This might involve navigating through their profile to find threads
   they've started or directly accessing the thread through the forum.
3. Select Delete Option: The user selects the "Delete" option on the thread. This may be an icon or a link, typically located near the
   thread title or at the end of the first post.
4. Confirm Deletion: The system prompts the user to confirm the deletion to prevent accidental removals. The user must confirm their intent
   to delete the thread.
5. Deletion Process: Upon confirmation, the system deletes the thread.
6. Confirmation of Deletion: The user receives a message confirming that the thread has been successfully deleted.
7. Update Forum Display: The thread is removed from the forum display, and the user is redirected back to the forum homepage or their
   profile page.

#### Use Case "Create, Edit, Reply, and Delete Post" (U13) ####

**Creating a Post**

**Sequence Diagram**

![SequenceDiagramU13.1.png](SequenceDiagramU13.1.png)

**Actor**: User

**System Components**: User Interface, Post Management, Database

**Sequence Steps**

1. User logs into the system and navigates to a specific thread in the community forum.
    - User Interface displays the thread with existing posts and an option to add a new post.

2. User selects the option to create a new post.
    - User Interface presents a form for entering the post's content.

3. User enters details for the new post and submits the form.
    - User Interface captures the input data and sends it to the PostManagement component.

4. PostManagement validates the post details and sends a create request to the Database.
    - Checks for any inappropriate content or format errors.

5. Database stores the new post and confirms the creation back to PostManagement.
    - The Database records the post, assigns it an identifier, and links it to the thread.

6. PostManagement receives the confirmation and notifies the User Interface of the successful creation.
    - Includes a success message and details about the new post (e.g., post ID, timestamp).

7. User Interface displays the newly created post within the thread and confirms to the User.
    - User can see their post live in the thread, available for others to view and respond to.

**Editing a Post**

![SequenceDiagramU13.2.png](SequenceDiagramU13.2.png)

**Actor**: User

**System Components**: User Interface, Post Management, Database

Sequence Steps:

1. User selects the edit option on their own post.
    - User Interface provides an editable form pre-filled with the existing post content.

2. User modifies the content and submits the updated information.
    - User Interface sends the updated content to the PostManagement.

3. PostManagement validates the updated details and sends an update request to the Database.
    - Verifies the edited content for format and appropriateness.

4. Database updates the post details and confirms the update back to PostManagement.
    - The Database modifies the post record and confirms the update.

5. PostManagement receives the update confirmation and informs the User Interface.
    - Sends a message indicating successful update.

6. User Interface updates the post display and notifies the User of the successful edit.
    - User sees the updated content in place of the old one in the thread.

#### Replying to a Post ####

![SequenceDiagramU13.3.png](SequenceDiagramU13.3.png)

1. User selects the reply option on a post.
    - User Interface provides a form for entering the reply content.

2. User writes their reply and submits it.
    - User Interface captures the reply and forwards it to PostManagement.

3. PostManagement processes the reply, attaching it to the original post, and sends it to the Database.
    - Ensures the reply is linked to the correct post.

4. Database stores the reply and links it under the original post, confirming back to PostManagement.
    - The Database records the reply as a child of the original post.

5. PostManagement confirms the successful addition of the reply to the User Interface.
    - A success message is sent to the User Interface.

6. User Interface displays the new reply under the original post and confirms to the User.
    - The thread is updated to show the reply inline with the discussion.

#### Deleting a Post ####

![SequenceDiagramU13.4.png](SequenceDiagramU13.4.png)

1. User selects the delete option on their post.
    - User Interface asks the User to confirm the deletion to prevent accidental removals.

2. Upon confirmation, User Interface sends the delete request to PostManagement.
    - The request includes the post ID and user verification.

3. PostManagement verifies the User's authority to delete the post and sends a delete command to the Database.
    - Checks if the User is the owner of the post or has moderator rights.

4. Database deletes the post and returns a confirmation of deletion to PostManagement.
    - The Database removes the post from its records.

5. PostManagement receives the deletion confirmation and notifies the User Interface.
    - Confirmation ensures the process was completed correctly.

6. User SuperInterface updates to reflect the deletion of the post and informs the User.
    - The forum display is refreshed to show that the post is no longer available.