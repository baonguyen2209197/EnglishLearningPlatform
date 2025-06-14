# Data Structure Overview: EnglishLearningPlatform

## Main Tables

### Courses
- **Id** (UUID, PK): Unique identifier
- **Title** (string): Course name
- **Type** (string): Course type (Grammar, Vocabulary, ...)

### Lessons
- **Id** (UUID, PK): Unique identifier
- **Title** (string): Lesson name
- **Content** (text): Lesson content
- **CourseId** (UUID, FK): Reference to Courses

### Users
- **Id** (UUID, PK): Unique identifier
- **Email** (string): User email (unique)
- **Name** (string): User name
- **Role** (string): User role (Admin/User)
- **PasswordHash** (string): Hashed password

### UserProgress
- **Id** (UUID, PK): Unique identifier
- **UserId** (UUID, FK): Reference to Users
- **LessonId** (UUID, FK): Reference to Lessons
- **Score** (int): Score for lesson
- **StudyTime** (interval): Time spent
- **CompletedAt** (timestamp): Completion time

### Tests
- **Id** (UUID, PK): Unique identifier
- **Title** (string): Test name
- **Type** (string): Test type (Grammar, Vocabulary, ...)
- **CourseId** (UUID, FK): Reference to Courses

### TestQuestions
- **Id** (UUID, PK): Unique identifier
- **TestId** (UUID, FK): Reference to Tests
- **QuestionText** (text): Question content
- **CorrectAnswer** (string): Correct answer

### TestResults
- **Id** (UUID, PK): Unique identifier
- **TestId** (UUID, FK): Reference to Tests
- **UserId** (UUID, FK): Reference to Users
- **Score** (int): Test score
- **SubmittedAt** (timestamp): Submission time

## Relationships
- One Course has many Lessons, many Tests
- One Lesson belongs to one Course
- One User has many UserProgress, many TestResults
- One Test has many TestQuestions, many TestResults

## Notes
- All foreign keys use `ON DELETE CASCADE` for data integrity
- Extendable for OAuth, logs, or other modules as needed
