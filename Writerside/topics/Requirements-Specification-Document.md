<show-structure for="chapter" depth="3"/>

# Requirements Specification Document

## Preface

This document outlines the expected readership and provides a version history of the requirements specification for the Course
Recommendation System. It summarizes the rationale behind each version.

### Version History

| Version | Date      | Description |
|---------|-----------|-------------|
| 1.0     | 2024-5-20 | Initial     |

### Document Conventions

* The keywords **"SHALL", "SHALL NOT", "SHOULD", "SHOULD NOT"**, in this document are to be interpreted as described
  in [RFC 2119](https://datatracker.ietf.org/doc/html/rfc2119).
* Functional requirements will be prefixed with **"FR"**. Non-functional requirements will be prefixed with **"NFR"**. Use case will be
  prefixed with **"U"**. Data Flow will be prefixed with **"DF"**.

### Audience

* **Developers:** For understanding the detailed technical requirements.
* **Project Managers:** To align project trajectory defined in the specifications.
* **Stakeholders:** To verify the system meets their expectations and needs.

## Glossary

See [General Glossary](Glossary.md#general-glossary "General Glossary for the whole project document")
and [Project Proposal Glossary](Glossary.md#project-proposal "Specific Glossary for Requirement Specification Document") for more detail.

## Introduction

### System Overview

* The course recommendation system utilizes NLP to recommend university courses based on student queries.
* This system will integrate with existing university databases and scheduling tools
  to offer a seamless course selection process, supporting students in meeting their academic goals.
* It provides an interactive digital course booklet and supports filter-based search options for course selection.
* The system includes a secure user login and registration functionality to enhance data security and personalization.
* Universities can access aggregated and anonymized data to improve course offerings based on student interactions with the system.

### Goals and Objectives

* To provide accurate course recommendations to students based on their academic needs and preferences.
* To provide a user-friendly interface with easy navigation and detailed course descriptions.
* To ensure secure access for students and university staff with authentication and data protection.
* To enable universities to access system data to identify trends and improve course offerings.

### Use cases

![UseCase_Diagram0.png](UseCase_Diagram0.png)

* **U1**: Submit course feedback
* **U2**: View academic calendar
* **U3**: View course pathways
* **U4**: Filter courses
* **U5**: View personal information
* **U6**: Obtain course recommendations from query
* **U7**: Register and log into the system
* **U8**: University officials access and analyze course data
* **U9**: Register an account on the system
* **U10**: Reset and recover account password
* **U11**: Delete account from the system

## User Requirements

### Functional Requirements {id="functional-requirements_1"}

#### FR-1 - User Authentication and Security

* **FR-1.1:** The system **should** provide intuitive controls to initiate the signup process.
* **FR-1.2:** The system **shall** provide a secure registration process for
  new users.
* **FR-1.3:** The system **shall** support secure login with email and password
* **FR-1.4:** The system **shall** provide a password recovery mechanism for users to reset forgotten passwords via email.
* **FR-1.5:** Users **shall** register using their email, password, and basic profile information.
* **FR-1.6:** The system **should** collect citizens consent to our terms of use.

#### FR-2 - Reset Password

* **FR-2.1:** The system **should** provide a “Forgot Password” link on the login page for users who have forgotten their passwords.
* **FR-2.2:** When users click on the “Forgot Password” link, they **should** be directed to a password recovery page.
* **FR-2.3:** Users **should** be prompted to enter their email address or username associated with their account.
* **FR-2.4:** After entering their required user information, the system **should** send a password reset link to the user’s registered
  email address.
* **FR-2.5:** The password reset link sent to the user’s email **should** be unique and valid for one hour.
* **FR-2.6:** Clicking on the password reset link **should** redirect the user to a page where they can create a new password.
* **FR-2.7:** After successfully resetting their password, users **should** receive a confirmation message.
* **FR-2.8:** Users **should** be redirected to the login page.

#### FR-3 - Delete Account

* **FR-3.1:** User **should** be logged in for their account to be deleted.
* **FR-3.2:** User **should** be prompted to enter their password.
* **FR-3.3:** User **should** be prompted with confirmation where user can either delete and cancel the account deletion.
* **FR-3.4:** Account **should** be removed from the system once deletion process is done within 2 minutes.

#### FR-4 - Community Forums

* **FR-4.1:** The system **should** provide a community forum or discussion board where users can discuss courses, share study tips, and
  collaborate.
* **FR-4.2:** The system **should** allow users to create new discussion threads within the forum.
* **FR-4.3:** The system **should** allow useres to enter a title and description for the new thread.
* **FR-4.4:** The system **should** have options to format the text and add links or images.
* **FR-4.5:** The system **should** allow users to be able to tag their thread with relevant course codes or topics for easy navigation.
* **FR-4.6:** The system **should** enable users to reply to existing discussion threads.
* **FR-4.7:** Users **should** be able to post replies to any thread.
* **FR-4.8:** The system **should** allow replies to include text, links, and images.
* **FR-4.9:** The system **should** allow users to edit their own posts and threads.
* **FR-4.10:** There **should** be a 30 minutes time limit after posting within which edits can be made.
* **FR-4.11:** Edited posts **should** display an "edited" label with the edit timestamp.
* **FR-4.12:** The system **should** implement moderation tools to manage the content and enforce forum rules.
* **FR-4.13:** Moderators **should** be able to delete or edit any post or thread.
* **FR-4.14:** Moderators **should** be able to ban users who violate forum rules.
* **FR-4.15:** The system **should** support reporting posts to moderators for review.
* **FR-4.16:** The system **should** allow users to rate posts and mark answers as helpful.
* **FR-4.17:** Users **should** be able to upvote or downvote posts.
* **FR-4.18:** The total score of each post **should** be visible next to it.

### Non-Functional Requirements {id="non-functional-requirements_1"}

#### NFR-1 - User Interface Clarity

* **NFR-1.1:** The system **should** present a clear and uncluttered user interface, ensuring that all textual and graphical elements are
  easily understandable by users without prior training.
* **NFR-1.2:** The system **should** use a consistent layout and design scheme across all pages and views.
* **NFR-1.3:** All screens **should** follow the same color scheme and typography.
* **NFR-1.4:** Interactive elements (like buttons, text fields, dropdown menus) **should** have a consistent look and feel.
* **NFR-1.5:** Spacing, alignment, and positioning of elements **should** be uniform across similar types of interfaces.
* **NFR-1.6:** The system **should** provide adequate feedback to user actions within a reasonable timeframe.
* **NFR-1.7:** Visual cues (like highlighting, animations, or progress indicators) **should** be used to show that an action is being
  processed.
* **NFR-1.8:** Success, warning, or error messages **should** be clearly displayed following user actions to indicate the result.
* **NFR-1.9:** The system **should** aim for response times that keep the user experience fluid and responsive under 1 second for immediate
  actions and under 10 seconds for complex operations.

#### NFR-2 - Consistent Navigation

<<<<<<< HEAD
* **NFR-2.1:** The system **should** offer consistent navigation menus and icons throughout the application to prevent user confusion and to
=======
* **NFR10:** the system **should** offer consistent navigation menus and icons throughout the application to prevent user confusion and to
>>>>>>> origin/main
  facilitate easy learning of the interface.
* **NFR-2.2:** The system **should** use a standardized layout for primary navigation menus.
* **NFR-2.3:** The primary navigation menu **should** be positioned in a common area (such as the top bar, sidebar, or bottom bar) across
  all
  pages.
* **NFR-2.4:** The layout **should** support scalability, accommodating additional items without disrupting the overall design.
* **NFR-2.5:** The system **should** offer clear visual cues to indicate the user’s current location within the application.
* **NFR-2.6:** The current section or page **should** be highlighted or distinguished in the navigation menu.
* **NFR-2.7:** Tabs, buttons, or links representing the current area **should** be styled differently from inactive elements.
* **NFR-2.8:** In hierarchical or nested navigation, parent sections **should** also be visually indicated when a child is selected.

* **NFR-2.9:** The system **should** avoid deep navigation hierarchies, ensuring that users can reach any part of the application within a
  few
  clicks.
* **NFR-2.10:** Users **should** be able to reach important features and information within three clicks from the homepage or main menu.

#### NFR-3 - Interactive Performance

* **NFR-3.1:** The system **should** ensure that all user interactions, such as button clicks and form submissions, receive immediate
  feedback,
  with actions being acknowledged or completed within 1 second under typical usage conditions.
* **NFR-3.2:** The system **should** use visual indicators such as progress bars, spinners, or animation to inform users about ongoing
  processes
  that take longer than 1 second.
* **NFR-3.3:** These indicators **should** remain on screen until the action is completed or an error message is displayed.
* **NFR-3.4:** The indicators **should** be placed prominently so that they are easily noticeable by users.
* **NFR-3.5:** The system **should** ensure that the interface remains responsive and usable even when background tasks or calculations are
  being performed.
* **NFR-3.6:** The UI **should** not freeze or become unresponsive during any operation.
* **NFR-3.7:** Any input from the user during background processing **should** be handled correctly without data loss or corruption.
* **NFR-3.8:** The system **should** optimize screen refresh and rendering times to ensure smooth updates and transitions.
* **NFR-3.9:** Any visual changes in the UI **should** appear seamless and without noticeable lag or jerkiness.
* **NFR-3.10:** The system **should** provide immediate error notifications for issues related to user actions to minimize user confusion
  and
  frustration.
* **NFR-3.11:** These messages **should** be descriptive enough to inform the user of the nature of the problem and suggest potential
  solutions.
* **NFR-3.12:** The design and placement of error messages **should** ensure that they are highly visible without disrupting the user's
  workflow.
* **NFR-3.13:** The system **should** minimize the latency experienced by users during typical interaction patterns to enhance the overall
  responsiveness.
* **NFR-3.14:** The system **should** aim for a latency of less than 100 milliseconds for simple interactions under typical conditions.
* **NFR-3.15:** Complex operations that require more processing time **should** still be optimized to complete as quickly as possible, with
  intermediate feedback provided.
* **NFR-3.16:** The system **should** handle sudden spikes in usage or load without complete failure.
* **NFR-3.17:** Under high load, the system may degrade non-critical features while keeping essential functions responsive.
* **NFR-3.18:** Users **should** be notified appropriately if the performance is impacted significantly, with clear messages indicating any
  temporary limitations.

#### NFR-4 - Secure User Data Input

* **NFR-4.1:** The system **should** ensure that all user input is validated and sanitized to prevent common vulnerabilities such as SQL
  injection, cross-site scripting (XSS), and other forms of input-based attacks.
* **NFR-4.2:** The system should implement server-side validation of all user input to prevent injection and other input-based
  vulnerabilities.
* **NFR-4.3:** Validation logic should cover all types of input, including strings, numbers, dates, and file uploads.
* **NFR-4.4:** Server-side validation should check for length, range, format, and type constraints.
* **NFR-4.5:** Any input failing validation should result in a clear, non-technical error message being returned to the user.
* **NFR-4.6:** The system should use prepared statements and parameterized queries to interact with databases to prevent SQL injection
  attacks
* **NFR-4.7:** All database queries should use parameterized queries or prepared statements to prevent mixing code with data.
* **NFR-4.8:** The system should implement input length restrictions to prevent buffer overflow and denial-of-service (DoS) attacks.
* **NFR-4.9:** Maximum acceptable lengths for different types of input should be clearly defined and enforced.
* **NFR-4.10:** The system should promptly reject inputs that exceed the set length limits with an appropriate error message.
* **NFR-4.11:** File uploads should be checked for both file size and type to prevent large or potentially dangerous files from being
  processed.

#### NFR-5 - Privacy of User Data

* **NFR-5.1:** The system **should** clearly inform users about how their data is used and obtain their consent where necessary, complying
  with privacy regulations.
* **NFR-5.2:** The system should allow users to access, review, and update their personal data at any time.
* **NFR-5.3:** Users should have a straightforward way to view their personal data within the system.
* **NFR-5.4:** The system should offer functionality for users to correct or update their personal information whenever necessary.
* **NFR-5.5:** The system should implement the necessary measures to ensure that user data is anonymized where possible.
* **NFR-5.6:** Critical data that can identify a user directly (like names, social security numbers) should be anonymized in storage and
  processing.
* **NFR-5.7:** The system should encrypt user data both in transit and at rest to protect it from unauthorized access.
* **NFR-5.8:** The system should support the right to be forgotten, allowing users to delete their accounts and personal information
  permanently.
* **NFR-5.9:** Users should be able to request the deletion of their account and associated data through a clear and accessible mechanism.
* **NFR-5.10:** The system should ensure that the deletion process is comprehensive and irreversible, removing all personal data without
  undue delay.
* **NFR-5.11:** After deletion, the system should not retain any personal data unless required by law or for legitimate business purposes.
* **NFR-5.12:** The system should only collect personal data that is necessary for the specified purposes of processing.
* **NFR-5.13:** Unnecessary collection of data, such as collecting data for possible future use without a clear purpose, should be avoided.

#### NFR-6 - User Feedback Mechanism

* **NFR-6.1:** The system **should** maintain stable user sessions with automatic recovery of the session state after brief disconnections
  or interruptions.
* **NFR-6.2:** The system should include a simple and intuitive interface for users to submit feedback, bug reports, and feature
  suggestions.
* **NFR-6.3:** Feedback forms should allow users to describe their experience, categorize the type of feedback, and, if necessary, attach
  screenshots or other relevant files.
* **NFR-6.4:** There should be a clear process for reviewing user feedback and categorizing it into issues, enhancements, and feature
  requests.
* **NFR-6.5:** The development team should regularly prioritize and implement changes based on this feedback, following an agile and
  user-centered design approach.
* **NFR-6.6:** The system should allow users to rate their experience and provide structured feedback through surveys or rating systems.
* **NFR-6.7:** The system should periodically prompt users to complete surveys or rate their experience, without causing disruption or
  annoyance.
* **NFR-6.8:** Surveys should be concise, relevant, and designed to capture clear, actionable insights.
* **NFR-6.9:** The system should track key metrics such as usage frequency, error rates, completion times, and user pathways.
* **NFR-6.10:** Privacy and consent considerations must be respected in the collection and use of interaction data, ensuring data is
  anonymized where necessary.

## System Architecture

### Overview

#### The system will follow a client-server architecture with the following main components:

* **Client Application:** A frontend interface where students can interact with the system.
* **Server Application:** Backend services that process data and serve the course recommendations.
* **Database:** To store course information, user data, and interaction logs.

### Detailed Design

* **Client Application:** Built using Avalonia UI and C#, providing cross-platform support.
* **Server Application:** Utilizes OpenAI's ChatGPT for NLP tasks
* **Database:** A database system to store structured data securely.

## System Requirements

### Functional Requirements

#### FR-5 - Course Recommendation

* **FR-5.1:** The system ****should**** allow students to input queries in natural language to get course recommendations.
* **FR-5.2:** Based on the input, the system ****should**** use NLP to analyze and fetch relevant course information from the university’s
  course
  catalog.

#### User Interface

* **FR3**: The system **shall** offer an easy-to-use interface with options to filter courses based on criteria like difficulty and
  department.
* **FR4**: The system **shall** provide visual course pathways showing prerequisites and recommended sequences.

#### Data Utilization and Privacy

* **FR5**: The system **shall** ensure robust data protection mechanisms to prevent misuse of personal data.

#### Additional Features

* **FR7**: The system **shall** integrate with the academic calendar for scheduling.
* **FR8**: The system **shall** include a feedback system for students to rate courses after completion.

### Non-Functional Requirements

#### Performance

* **NFR1**: The system ****should**** ensure quick responses to user queries, aiming for a latency of less than 2 seconds for results.

#### Usability

* **NFR2**: The system ****should**** be intuitive, allowing users with minimal training to perform basic operations.

#### Reliability

* **NFR3**: The system ****should**** be operational 99% of the time, with minimal downtime for maintenance.

#### Scalability

* **NFR4**: The system ****should**** handle increasing amounts of data and concurrent users as the student population grows.

#### Security

* **NFR5**: The system ****should**** implement standard security measures including data encryption and user authentication.

#### Maintainability

* **NFR6**: The system **should** be designed for easy maintenance and future upgrades without significant downtime.

#### Fault Tolerance

* **NFR7**: The system **should** handle at least 100 users concurrently without significant degradation in performance.
* **NFR8**: The system **should** be capable of recovering from common errors without total system failure and with minimal downtime.

## Data Flow and User Scenarios

### Data Flow

* **DF1:** The user enters a course query in natural language.
* **DF2:** The query is processed by the NLP module to extract relevant terms.
* **DF3:** The system matches these terms with the course database.
* **DF4:** Filtered results based on user preferences are presented in the interface.
* **DF5:** Users can further explore courses through visual pathways and integrated scheduling.

![DataFlowDiagram.png](DataFlowDiagram.png)

## Verification and Validation

* **Test 1:** Ensure that the course recommendation matches the user query in terms of relevance and accuracy.
* **Test 2:** Verify that the user interface is user-friendly and meets the usability requirements.
* **Test 3:** Validate that user data is handled securely and in compliance with privacy standards.
* **Test 4:** Confirm that the user registration and login processes are secure and function as expected.
* **Test 5:** Ensure that university officials can access the data dashboard and that the displayed information is accurate and up-to-date.

## Appendices

* **Appendix A:** API Documentation for third-party services used.
* **Appendix B:** User manual for system interaction.

