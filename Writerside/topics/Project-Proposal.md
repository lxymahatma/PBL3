<show-structure for="chapter" depth="2"/>

# Project Proposal

## Overview of the chosen problem area within smart cities

Selecting courses is a critical task for university students, impacting their academic journey and future career paths.
Currently, students often rely on course booklets provided by universities to make these decisions.
However, these booklets are typically extensive, complex, and static documents that can be challenging to navigate.
Students may find it difficult to understand course descriptions, prerequisites, and how certain courses align with their academic goals and
interests.
This often leads to confusion and errors in course selection, potentially affecting students' educational outcomes.

## Team’s vision and Objective

Our proposed solution is to develop an application that utilizes Natural Language Processing (NLP) to recommend courses to students based on
their specific queries.
This application aims to streamline the course selection process by providing personalized course recommendations.
These recommendations will consider various factors such as the student's past courses, prerequisites of potential future courses, and
individual interests.
Our goal is to mitigate the problems associated with the current manual and often tedious process, enabling students to make more informed
and accurate decisions regarding their course choices.

## Methodology

Our application will be created using C# and Avalonia <tooltip term="UI">UI</tooltip> framework, because Avalonia provides the
cross-platform compatibility.
The main purpose of the application is to provide course recommendations to users.
To achieve this goal, we plan to utilize NLP technology to interact with users.
The production of the project will be carried out in a few stages.
We have finished defining the scope and goals of the system, as well as identifying the user types and functional requirements.
The next step is to gather all the course materials that will be utilized within the system and extract important information from the
course syllabus to create a course database.

To extract keywords from user inputs, we will use the `OpenAI API Dotnet` nuget package to use <tooltip term="API">API</tooltip> by ChatGPT.
Next, we will decide what method to use to filter recommended courses based on user needs.
In the subsequent step, we will work on implementing the system to the application interface.
Once that's done, we'll test the system and review to make necessary adjustments to the application.
Moving on, we'll evaluate the results of our tests using common indicators to determine the accuracy.
We can also conduct usability testing with real users and collect feedback on their satisfaction.

## Features

![Diagram](diagram.png){border-effect="line" preview-src="diagram_preview.png"}

### Natural Language Processing:

This feature integrates OpenAI's ChatGPT technology to interpret and process user queries that are written in natural language.
It is designed to be intuitive, enabling users to engage in an interaction where they can ask questions regarding their academic needs in
their own words.
The system dynamically understands and processes queries, providing responses.
It is capable of a range of inputs from simple queries about course details to complex queries involving course sequencing and
prerequisites.

### Course Recommendation System:

The system can analyze the content of user’s queries and cross-reference them with the database of courses offered in ISSE.
It considers various factors such as the user’s course prerequisites, past courses, and credit requirements.

### DigitalCourse Booklet:

The paper-based course booklet is accessible via the application.
The digital booklet will be updated to reflect changes and new course additions to ensure users always have access to the most current
information.

### Filter-Based Search Options:

For users who prefer a more traditional search approach, this feature provides a filtering system that allows users to sort and view courses
based on specific criteria such as course level, department or semester.
This functionality enables users to quickly narrow down course options and customize their search process according to their unique
preferences and academic needs.

## Limitations

Our proposed course recommendation application implementing <tooltip term="NLP">NLP</tooltip> aims to provide personalized course
suggestions to users, focusing specifically on ISSE courses. However, there are several limitations to it.

1. <tooltip term="NLP">NLP</tooltip> may struggle with ambiguous user queries and understanding user intent.
   For instance, challenges may arise in handling context, nuance, and specific knowledge, impacting the relevance of course suggestions.
2. Difficulties with synonyms and new terms may also result in inaccurate recommendations.
3. Since the system's effectiveness heavily relies on the <tooltip term="API">API</tooltip>, we don't have direct access to the model, so
   there is a potential that it might lead to biased or incomplete recommendations.
4. There is difficulty assessing the effectiveness of course recommendations due to various factors influencing user satisfaction and
   learning outcomes.
5. Deployment may initially be limited to Windows, macOS, and Linux, with potential adaptation for Android platforms with further
   development.

Despite these challenges, our project aims to address these limitations through algorithmic approaches and user-centered design principles.

## Glossary

See [General Glossary](Glossary.md#general-glossary "General Glossary for the whole project document")
and [Project Proposal Glossary](Glossary.md#project-proposal "Specific Glossary for Project Proposal Document") for more detail.

## References

* [Avalonia](https://avaloniaui.net/)
* [OpenAI API Dotnet](https://github.com/OkGoDoIt/OpenAI-API-dotnet)
* [openai-cookbook](https://github.com/openai/openai-cookbook/blob/main/examples/Question_answering_using_embeddings.ipynb)