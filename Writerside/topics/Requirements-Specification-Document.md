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

* The keywords “SHALL”, “SHALL NOT”, “SHOULD”, “SHOULD NOT”, in this document are to be interpreted as described in RFC 2119.

* Functional requirements will be prefixed with "FR". Non-functional requirements will be prefixed with "NFR".

## Glossary

See [Glossary](Glossary.md#requirement-specification-document "Glossary for Requirement Specification Document") for more detail.

## 1. Introduction

The Course Recommendation System is designed to enhance the educational experience by providing students with personalized course
recommendations using Natural Language Processing (NLP). This system will integrate with existing university databases and scheduling tools
to offer a seamless course selection process, supporting students in meeting their academic goals.

### 1.1 Use cases

1. Submit course feedback
2. View academic calendar
3. View course pathways
4. Filter courses
5. View personal information
6. Obtain course recommendations from query

![UseCaseDiagram.jpg](UseCaseDiagram.jpg)

## 2. General Description

### 2.1 System Overview

* The course recommendation system utilizes NLP to recommend university courses based on student queries.
* It provides an interactive digital course booklet and supports filter-based search options for course selection.
  2.2 Goals and Objectives
* To provide accurate course recommendations to students based on their academic needs and preferences.
* To provide a user-friendly interface with easy navigation and detailed course descriptions.

## 3. Specific Requirements

### 3.1 Functional Requirements

#### 3.1.1 Course Recommendation

* FR1: The system should allow students to input queries in natural language to get course recommendations.
* FR2: Based on the input, the system should use NLP to analyze and fetch relevant course information from the university’s course catalog.

#### 3.1.2 User Interface

* FR3: The system shall offer an easy-to-use interface with options to filter courses based on criteria like difficulty and department.
* FR4: The system shall provide visual course pathways showing prerequisites and recommended sequences.

#### 3.1.3 Data Utilization and Privacy

* FR5: The system shall ensure robust data protection mechanisms to prevent misuse of personal data.

#### 3.1.4 Additional Features

* FR7: The system shall integrate with the academic calendar for scheduling.
* FR8: The system shall include a feedback system for students to rate courses after completion.

### 3.2 Non-Functional Requirements

#### 3.2.1 Performance

* NFR1: The system should ensure quick responses to user queries, aiming for a latency of less than 2 seconds for results.

#### 3.2.2 Usability

* NFR2: The system should be intuitive, allowing users with minimal training to perform basic operations.

#### 3.2.3 Reliability

* NFR3: The system should be operational 99% of the time, with minimal downtime for maintenance.

#### 3.2.4 Scalability

* NFR4: The system should handle increasing amounts of data and concurrent users as the student population grows.

#### 3.2.5 Security

* NFR5: The system should implement standard security measures including data encryption and user authentication.

### Functional Requirements:

* The system must accept natural language input from users.
* It should provide accurate course recommendations.
* The interface must allow users to filter courses based on multiple criteria.

### Non-Functional Requirements:

* The system should be user-friendly, with minimal response time.
* It must ensure data security, particularly concerning students' personal information.

## 4. System Architecture

### 4.1 Overview

The system will follow a client-server architecture with the following main components:

* Client Application: A frontend interface where students can interact with the system.
* Server Application: Backend services that process data and serve the course recommendations.
* Database: To store course information, user data, and interaction logs.

### 4.2 Detailed Design

* Client Application: Built using Avalonia UI and C, providing cross-platform support.
* Server Application: Utilizes OpenAI's ChatGPT for NLP tasks
* Database: A database system to store structured data securely.

## 5. Data Flow and User Scenarios

### 5.1 Data Flow

1. The user enters a course query in natural language.
2. The query is processed by the NLP module to extract relevant terms.
3. The system matches these terms with the course database.
4. Filtered results based on user preferences are presented in the interface.
5. Users can further explore courses through visual pathways and integrated scheduling.

![DataFlowDiagram.png](DataFlowDiagram.png)

### 5.2 User Scenario Example

* A second-year student is looking for a programming-related course without scheduling conflicts. They use the system to input: “I need a
  programming course with no clashes in my schedule.”
* The system recommends suitable courses, showing their prerequisites and where they fit into the student's academic calendar.

![UserScenarioDiagram.png](UserScenarioDiagram.png)

## 6. Verification and Validation

* Test 1: Ensure that the course recommendation matches the user query in terms of relevance and accuracy.
* Test 2: Verify that the user interface is user-friendly and meets the usability requirements.
* Test 3: Validate that user data is handled securely and in compliance with privacy standards.

## 7. Appendices

* Appendix A: API Documentation for third-party services used.
* Appendix B: User manual for system interaction.

