# System Architecture Documentation

## Application Design

### Languages

* C#
* XAML

### Frameworks / Libraries

* [Avalonia](https://github.com/AvaloniaUI/Avalonia) - Develop Desktop, Embedded, Mobile and WebAssembly apps with C# and XAML
* [MessageBox.Avalonia](https://github.com/AvaloniaCommunity/MessageBox.Avalonia) - MessageBox for AvaloniaUI
* [Autofac](https://github.com/autofac/Autofac) - .NET IoC container
* [OpenAI Dotnet](https://github.com/openai/openai-dotnet) - Official .NET library for the OpenAI API
* [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet) - .NET MVVM library with helpers
* [HotAvalonia](https://github.com/Kir-Antipov/HotAvalonia) - .NET library crafted to seamlessly integrate hot reload functionality into
  Avalonia applications
* [Serilog](https://github.com/serilog/serilog) - Simple .NET logging with fully-structured events
* [NRedisStack](https://github.com/redis/NRedisStack) - Redis Stack .Net client

### Build System

* [MSBuild](https://github.com/dotnet/msbuild) - Build platform for .NET and Visual Studio

### Testing

* [Xunit](https://github.com/xunit/xunit) - Free, open source, community-focused unit testing tool for .NET
* [Moq](https://github.com/devlooped/moq) - Mocking framework for .NET

### Development Tools

* [Rider](https://www.jetbrains.com/rider) - IDE
* [Visual Studio](https://visualstudio.microsoft.com) - IDE

## Context Diagram

![ContextDiagram](ContextDiagram.png)

| **Component**                    | **Description**                                                                                                                          |
|----------------------------------|------------------------------------------------------------------------------------------------------------------------------------------|
| **Course Recommendation System** | Central system that processes user queries, generates course recommendations, and manages user and course data.                          |
| **Student**                      | Users of the system who seek recommendations for courses and manage their course selections.                                             |
| **Admin**                        | Administrators who use the system to access aggregated data on user interactions and course selections for analysis and decision-making. |
| **System Database**              | The storage system for user data, thread data, course information, and other related data required by the course recommendation system.  |
| **OpenAI API**                   | External API used to process user queries and generate course recommendations using natural language processing and machine learning.    |

## Component Diagram

![ComponentDiagram.png](ComponentDiagram.png)

| Component             | Description                                                                                                                                            |
|-----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------|
| **User Interface**    | Provides a user-friendly interface for students to interact with the course recommendation system.                                                     |
| **Academic Calendar** | Provides the User Interface component access to the academic calendar.                                                                                 |
| **Feedback System**   | Allows students to post threads and view other users' threads.                                                                                         |
| **OpenAI API**        | Analyzes user queries, extracts relevant information, and processes course descriptions to provide course recommendations.                             |
| **User Database**     | Stores and manages user account information, including login credentials and profile information.                                                      |
| **Course Database**   | Stores and manages the university's course catalog data, including course descriptions, credits, prerequisites, instructor information, and schedules. |
| **Forum Database**    | Stores and manages the threads and posts of the community forums.                                                                                      |

## Deployment Diagram

![DeploymentDiagram.png](DeploymentDiagram.png)

| Node                          | Description                                                                                     | Components Deployed                                                                 | Connected To                            |
|-------------------------------|-------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------|-----------------------------------------|
| **Client Devices (Desktops)** | Machines used by students and administrators to run the desktop application.                    | - CourseRecommendationApp.exe (Windows) <br/> - CourseRecommendationApp.dmg (macOS) | Application Server                      |
| **Application Server**        | Server running the main application logic and processing requests from the desktop application. | - NLPProcessing.jar <br/> - RecommendationEngine.jar                                | Database Server <br/> External Services |
| **Database Server**           | Server for managing the databases.                                                              | - UserDatabase.db <br/> - CourseDatabase.db <br/> - ForumDatabase.db                | Application Server                      |
| **External Services**         | External APIs and services integrated with the application.                                     | - OpenAIService <br/> - EmailService                                                | Application Server                      |

## System Architecture Diagram

![SystemArchitectureDiagram.png](SystemArchitectureDiagram.png)

| Component                    | Description                                                             | Connected To                           | Role/Function                                         |
|------------------------------|-------------------------------------------------------------------------|----------------------------------------|-------------------------------------------------------|
| **System Users**             | Individuals interacting with the system (Admins and Users).             | Admin, User                            | Primary actors who use the system.                    |
| **Admin**                    | University Officials                                                    | Admin's Visual Interface               | Uses the system to view analytics.                    |
| **User**                     | General user of the system.                                             | User's Visual Interface                | Uses the system to get course recommendations.        |
| **Admin's Visual Interface** | User interface for the admin.                                           | Admin Logic                            | Allows admins to view the analytics.                  |
| **User's Visual Interface**  | User interface for general users.                                       | Application Logic                      | Allows users to interact with the system.             |
| **Admin Logic**              | Backend logic specific to admin functionalities.                        | NPL Module (OpenAI)                    | Processes admin-specific operations and data.         |
| **Application Logic**        | Backend logic for handling user interactions and data processing.       | Course Database                        | Processes user queries and manages user interactions. |
| **NPL Module (OpenAI)**      | Natural Language Processing module using OpenAI API.                    | Recommendation Engine                  | Interprets user inputs and generates recommendations. |
| **Course Database**          | Database containing course information.                                 | NPL Module (OpenAI), Application Logic | Stores and retrieves course data.                     |
| **Recommendation Engine**    | Component that generates course recommendations based on processed data | NPL Module (OpenAI)                    | Produces personalized course recommendations.         |

