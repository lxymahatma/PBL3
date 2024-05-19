<show-structure for="chapter" depth="3"/>

# Requirements Specification Document

## Preface

### Version History

| Version | Date      | Description |
|---------|-----------|-------------|
| 1.0     | 2024-5-20 | Initial     |

This document outlines the expected readership and provides a version history of the requirements specification for the Course
Recommendation System. It summarizes the rationale behind each version.

### Document Conventions

* The keywords **"SHALL", "SHALL NOT", "SHOULD", "SHOULD NOT"**, in this document are to be interpreted as described
  in [RFC 2119](https://datatracker.ietf.org/doc/html/rfc2119).
* Functional requirements will be prefixed with **"FR"**. Non-functional requirements will be prefixed with **"NFR"**. Use case will be
  prefixed with **"UC"**.

### Audience

* Developers: For understanding the detailed technical requirements.
* Project Managers: To align project trajectory defined in the specifications.
* Stakeholders: To verify the system meets their expectations and needs.

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

* **UC1**: Submit course feedback
* **UC2**: View academic calendar
* **UC3**: View course pathways
* **UC4**: Filter courses
* **UC5**: View personal information
* **UC6**: Obtain course recommendations from query
* **UC7**: Register and log into the system
* **UC8**: University officials access and analyze course data

![UseCase_Diagram0.png](UseCase_Diagram0.png)

## User Requirements

### Functional Requirements {id="functional-requirements_1"}

#### User Authentication and Security

* **FR9**: The system **shall** provide a secure registration process for new users.
* **FR10**: Users **shall** register using their email, password, and basic profile information.
* **FR11**: The system **shall** support secure login with email and password
* **FR12**: The system **shall** provide a password recovery mechanism for users to reset forgotten passwords via email.

### Non-Functional Requirements {id="non-functional-requirements_1"}

#### User Interface Clarity

* **NFR9:** The system should present a clear and uncluttered user interface, ensuring that all textual and graphical elements are easily
  understandable by users without prior training.

#### Consistent Navigation

* **NFR10:** he system should offer consistent navigation menus and icons throughout the application to prevent user confusion and to
  facilitate easy learning of the interface.

#### Interactive Performance

* **NFR11:** The system should ensure that all user interactions, such as button clicks and form submissions, receive immediate feedback,
  with actions being acknowledged or completed within 1 second under typical usage conditions.

#### Secure User Data Input

* **NFR12:** The system should ensure that all user input is validated and sanitized to prevent common vulnerabilities such as SQL
  injection, cross-site scripting (XSS), and other forms of input-based attacks.

#### Privacy of User Data

* **NFR13:** The system should clearly inform users about how their data is used and obtain their consent where necessary, complying with
  privacy regulations.

#### User Feedback Mechanism

* **NFR14:** The system should maintain stable user sessions with automatic recovery of the session state after brief disconnections or
  interruptions.

## System Architecture

### Overview

The system will follow a client-server architecture with the following main components:

* Client Application: A frontend interface where students can interact with the system.
* Server Application: Backend services that process data and serve the course recommendations.
* Database: To store course information, user data, and interaction logs.

### Detailed Design

* Client Application: Built using Avalonia UI and C#, providing cross-platform support.
* Server Application: Utilizes OpenAI's ChatGPT for NLP tasks
* Database: A database system to store structured data securely.

## System Requirements

### Functional Requirements

#### Course Recommendation

* **FR1**: The system **should** allow students to input queries in natural language to get course recommendations.
* **FR2**: Based on the input, the system **should** use NLP to analyze and fetch relevant course information from the university’s course
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

### Non-Functioanl Requirements

#### Performance

* **NFR1**: The system **should** ensure quick responses to user queries, aiming for a latency of less than 2 seconds for results.

#### Usability

* **NFR2**: The system **should** be intuitive, allowing users with minimal training to perform basic operations.

#### Reliability

* **NFR3**: The system **should** be operational 99% of the time, with minimal downtime for maintenance.

#### Scalability

* **NFR4**: The system **should** handle increasing amounts of data and concurrent users as the student population grows.

#### Security

* **NFR5**: The system **should** implement standard security measures including data encryption and user authentication.

#### Maintainability

* **NFR6**: The system should be designed for easy maintenance and future upgrades without significant downtime.

#### Fault Tolerance

* **NFR7**: The system should handle at least 100 users concurrently without significant degradation in performance.
* **NFR8**: The system should be capable of recovering from common errors without total system failure and with minimal downtime.

## Data Flow and User Scenarios

### Data Flow

1. The user enters a course query in natural language.
2. The query is processed by the NLP module to extract relevant terms.
3. The system matches these terms with the course database.
4. Filtered results based on user preferences are presented in the interface.
5. Users can further explore courses through visual pathways and integrated scheduling.

![DataFlowDiagram.png](DataFlowDiagram.png)

### User Scenario Example

* A second-year student is looking for a programming-related course without scheduling conflicts. They use the system to input: “I need a
  programming course with no clashes in my schedule.”
* The system recommends suitable courses, showing their prerequisites and where they fit into the student's academic calendar.

  ![UserScenarioDiagram.png](UserScenarioDiagram.png)
* A university official logs in to the system and reviews course feedback and ratings to identify areas for improvement in the programming
  curriculum.

## Verification and Validation

* **Test 1**: Ensure that the course recommendation matches the user query in terms of relevance and accuracy.
* **Test 2**: Verify that the user interface is user-friendly and meets the usability requirements.
* **Test 3**: Validate that user data is handled securely and in compliance with privacy standards.
* **Test 4**: Confirm that the user registration and login processes are secure and function as expected.
* **Test 5**: Ensure that university officials can access the data dashboard and that the displayed information is accurate and up-to-date.

## Appendices

* **Appendix A**: API Documentation for third-party services used.
* **Appendix B**: User manual for system interaction.

