# ProjectProposal

## Overview of the chosen problem area within smart cities
* The development of our advanced course search website 【(Easy Choose of Your Course)】, reflects a profound shift in priorities. 
Originally conceived to enhance existing information, the project now addresses the pressing issue of navigating complex and user-unfriendly course brochures.
* The primary challenge lies in the inefficiency and frustration experienced by students when attempting to select courses from these booklets. 
The lack of intuitiveness makes the process laborious, requiring students to painstakingly sift through pages to identify suitable options. This inefficiency not only consumes valuable time but also increases the likelihood of overlooking relevant courses.
* Therefore, it is imperative to simplify this process by leveraging technology to provide personalized course recommendations tailored to the individual preferences, interests, and abilities of students. 
By doing so, we aim to alleviate the difficulties associated with course selection and enhance the overall academic experience for students.

## Team’s vision and Objective
To alleviate the issue of <problem>, we aim to develop a course recommendation system utilizing natural language processing (NLP) aimed at undergraduate students. 
Users can input natural language to then be recommended courses based on their preference, credit acquisition status, or future prospects. 
By users utilizing other features as well, we aim to save time for students searching through the entire list of courses to find their desired courses.

## Methodology
Our main web page functionality will be to provide course recommendations to users. 
To achieve this goal, we plan to utilize NLP technology to interact with users. 
The production of the project will be carried out in seven stages. 
We have finished defining the scope and goals of the system, as well as identifying the user types and functional requirements. 
The next step is to gather all the course materials that will be utilized within the system and extract important information from the course syllabus to create a course database. 
To extract keywords, we will be using NLP, and we may also consider utilizing AI as an assistant. 
Third, by using NLP tools like spaCy, NLTK, or pre-trained models from Hugging Face’s Transformers library to process and interpret user input information. 
Fourth, we will decide what method to use to filter recommended courses based on user needs. 
We consider using the entered keywords and course difficulty (user ratings, content, grades) to recommend. 
At the same time, the model would be trained based on the course materials. If the user wants to index the course materials, we consider using methods such as TF-IDF or word embedding to build each course description. 
In the fifth step, we will work on implementing the system and designing the web interface. Once that's done, we'll test the system and gather feedback so we can make any necessary adjustments to the model. 
Moving on to the sixth step, we'll evaluate the results of our tests using common indicators to determine the accuracy of our model. 
We can also conduct usability testing with real users and collect feedback on their satisfaction. 
Finally, in the seventh step, we'll deploy the system and perform regular maintenance. 
We'll consider user feedback and new technologies or methods in NLP and machine learning to make any necessary improvements.

## Features
1. **Natural Language Processing**

This feature integrates OpenAI's ChatGPT technology to interpret and process user queries that are written in natural language. It is designed to be intuitive, enabling users to engage in an interaction where they can ask questions regarding their academic needs in their own words. The system dynamically understands and processes queries, providing responses. It is capable of a range of inputs from simple queries about course details to complex queries involving course sequencing and prerequisites.

1. **Course Recommendation System:**

The system can analyze the content of user’s queries and cross-reference them with the database of courses offered in ISSE. It considers various factors such as the user’s course prerequisites, past courses, and credit requirements.

1. **DigitalCourse Booklet:**

The paper-based course booklet is accessible via the application. ****The digital booklet will be updated to reflect changes and new course additions to ensure users always have access to the most current information.

1. **Filter-Based Search Options:**

For users who prefer a more traditional search approach, this feature provides a filtering system that allows users to sort and view courses based on specific criteria such as course level, department or semester. This functionality enables users to quickly narrow down course options and customize their search process according to their unique preferences and academic needs.

## Limitations
Our proposed course recommendation application implementing Natural Language Processing (NLP) aims to provide personalized course suggestions to users, focusing specifically on ISSE courses. However, there are several limitations to it. 
Firstly, NLP may struggle with ambiguous user queries and understanding user intent. For instance, challenges may arise in handling context, nuance, and specific knowledge, impacting the relevance of course suggestions. Moreover, difficulties with synonyms and new terms may also result in inaccurate recommendations. 
Furthermore, since the system's effectiveness heavily relies on the quality and diversity of training data, there is a potential that it might lead to biased or incomplete recommendations. 
In addition, there is difficulty assessing the effectiveness of course recommendations due to various factors influencing user satisfaction and learning outcomes. 
Finally, deployment may initially be limited to Windows, macOS, and Linux, with potential adaptation for Android platforms with further development. 
Despite these challenges, our project aims to address these limitations through algorithmic approaches and user-centered design principles.
