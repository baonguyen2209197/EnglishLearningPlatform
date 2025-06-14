-- SQL script for PostgreSQL: Create tables for EnglishLearningPlatform

CREATE TABLE "Courses" (
    "Id" UUID PRIMARY KEY,
    "Title" VARCHAR(100) NOT NULL,
    "Type" VARCHAR(50) NOT NULL
);

CREATE TABLE "Lessons" (
    "Id" UUID PRIMARY KEY,
    "Title" VARCHAR(100) NOT NULL,
    "Content" TEXT NOT NULL,
    "CourseId" UUID NOT NULL REFERENCES "Courses"("Id") ON DELETE CASCADE
);

CREATE TABLE "Users" (
    "Id" UUID PRIMARY KEY,
    "Email" VARCHAR(100) NOT NULL UNIQUE,
    "Name" VARCHAR(100) NOT NULL,
    "Role" VARCHAR(20) NOT NULL,
    "PasswordHash" VARCHAR(256) NOT NULL
);

CREATE TABLE "UserProgress" (
    "Id" UUID PRIMARY KEY,
    "UserId" UUID NOT NULL REFERENCES "Users"("Id") ON DELETE CASCADE,
    "LessonId" UUID NOT NULL REFERENCES "Lessons"("Id") ON DELETE CASCADE,
    "Score" INT NOT NULL,
    "StudyTime" INTERVAL NOT NULL,
    "CompletedAt" TIMESTAMP NOT NULL
);

-- Table for Tests/Assessments
CREATE TABLE "Tests" (
    "Id" UUID PRIMARY KEY,
    "Title" VARCHAR(100) NOT NULL,
    "Type" VARCHAR(50) NOT NULL,
    "CourseId" UUID REFERENCES "Courses"("Id") ON DELETE CASCADE
);

CREATE TABLE "TestQuestions" (
    "Id" UUID PRIMARY KEY,
    "TestId" UUID NOT NULL REFERENCES "Tests"("Id") ON DELETE CASCADE,
    "QuestionText" TEXT NOT NULL,
    "CorrectAnswer" VARCHAR(100) NOT NULL
);

CREATE TABLE "TestResults" (
    "Id" UUID PRIMARY KEY,
    "TestId" UUID NOT NULL REFERENCES "Tests"("Id") ON DELETE CASCADE,
    "UserId" UUID NOT NULL REFERENCES "Users"("Id") ON DELETE CASCADE,
    "Score" INT NOT NULL,
    "SubmittedAt" TIMESTAMP NOT NULL
);
