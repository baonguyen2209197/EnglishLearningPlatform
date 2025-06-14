# EnglishLearningPlatform API Documentation

## Authentication
- JWT Bearer authentication for all endpoints (except registration/login)
- OAuth2 for Google/Facebook login (scaffold, cần cấu hình thêm)

## Mục lục Endpoint
- [Auth](#auth)
  - [POST /api/v1/auth/login](#post-apiviauthlogin)
  - [POST /api/v1/auth/register](#post-apiviauthregister)
  - [GET /signin-google](#get-signin-google)
  - [GET /signin-facebook](#get-signin-facebook)
- [Courses](#courses)
  - [GET /api/v1/courses](#get-apivicourses)
  - [POST /api/v1/courses](#post-apivicourses-admin)
- [Lessons](#lessons)
  - [GET /api/v1/lessons](#get-apivilessons)
  - [POST /api/v1/lessons](#post-apivilessons-admin)
- [Users (Admin)](#users-admin)
  - [GET /api/v1/users](#get-apiv1users)
  - [GET /api/v1/users/{id}](#get-apiv1usersid)
  - [PUT /api/v1/users/{id}](#put-apiv1usersid)
  - [DELETE /api/v1/users/{id}](#delete-apiv1usersid)
- [Progress](#progress)
  - [GET /api/v1/progress](#get-apiv1progress)
  - [POST /api/v1/progress](#post-apiv1progress)
- [Points & Rankings](#points--rankings)
  - [GET /api/v1/points](#get-apiv1points)
- [Suggestions](#suggestions)
  - [GET /api/v1/suggestions](#get-apiv1suggestions)
- [History](#history)
  - [GET /api/v1/history](#get-apiv1history)
- [Tests](#tests)
  - [GET /api/v1/tests](#get-apiv1tests)
  - [POST /api/v1/tests/submit](#post-apiv1testssubmit)

---

## Auth
### POST /api/v1/auth/login
- Đăng nhập, trả về JWT token
- Request:
```json
{
  "email": "user@example.com",
  "password": "string"
}
```
- Response:
```json
{
  "token": "<jwt-token>"
}
```

### POST /api/v1/auth/register
- Đăng ký tài khoản mới
- Request:
```json
{
  "email": "user@example.com",
  "name": "User Name",
  "password": "string"
}
```
- Response:
```json
{
  "token": "<jwt-token>"
}
```

### GET /signin-google
- Đăng nhập Google (OAuth2, scaffold)

### GET /signin-facebook
- Đăng nhập Facebook (OAuth2, scaffold)

---

## Courses
### GET /api/v1/courses
- Lấy danh sách khoá học
- Response:
```json
[
  { "id": "...", "title": "Basic Grammar", "type": "Grammar" },
  { "id": "...", "title": "Everyday Vocabulary", "type": "Vocabulary" }
]
```

### POST /api/v1/courses (Admin)
- Tạo khoá học mới
- Request:
```json
{
  "title": "New Course",
  "type": "Grammar"
}
```
- Response: CourseDto

---

## Lessons
### GET /api/v1/lessons
- Lấy danh sách bài học
- Response:
```json
[
  { "id": "...", "title": "Nouns", "content": "Lesson on nouns", "courseId": "..." }
]
```

### POST /api/v1/lessons (Admin)
- Tạo bài học mới
- Request:
```json
{
  "title": "Lesson Title",
  "content": "Lesson Content",
  "courseId": "..."
}
```
- Response: Lesson

---

## Users (Admin)
### GET /api/v1/users
- Lấy danh sách user
- Response:
```json
[
  { "id": "...", "email": "user@example.com", "name": "User Name", "role": "User" }
]
```

### GET /api/v1/users/{id}
- Lấy thông tin user

### PUT /api/v1/users/{id}
- Cập nhật user
- Request:
```json
{
  "name": "New Name",
  "role": "Admin"
}
```

### DELETE /api/v1/users/{id}
- Xoá user

---

## Progress
### GET /api/v1/progress
- Lấy tiến độ học tập của user hiện tại
- Response:
```json
[
  { "lessonId": "...", "score": 10, "studyTime": "00:30:00", "completedAt": "2025-06-15T10:00:00Z" }
]
```

### POST /api/v1/progress
- Ghi nhận tiến độ học tập
- Request:
```json
{
  "lessonId": "...",
  "score": 10,
  "studyTime": "00:30:00"
}
```

---

## Points & Rankings
### GET /api/v1/points
- Lấy tổng điểm và xếp hạng của user
- Response:
```json
{
  "totalScore": 100,
  "userRank": 2
}
```

---

## Suggestions
### GET /api/v1/suggestions
- Gợi ý bài học tiếp theo
- Response:
```json
{
  "id": "...",
  "title": "Nouns",
  "courseId": "..."
}
```

---

## History
### GET /api/v1/history
- Lịch sử học tập của user
- Response:
```json
[
  { "lessonId": "...", "score": 10, "studyTime": "00:30:00", "completedAt": "2025-06-15T10:00:00Z" }
]
```

---

## Tests
### GET /api/v1/tests
- Lấy danh sách bài kiểm tra
- Response:
```json
[
  { "id": 1, "name": "Vocabulary Test", "type": "Vocabulary" },
  { "id": 2, "name": "Grammar Test", "type": "Grammar" }
]
```

### POST /api/v1/tests/submit
- Nộp bài kiểm tra
- Request:
```json
{
  "testId": 1,
  "answers": { "q1": "a", "q2": "b" }
}
```
- Response:
```json
{
  "score": 10,
  "message": "Chấm điểm mẫu (scaffold)"
}
```

---

## Error Codes
- 400: Validation error
- 401: Unauthorized
- 403: Forbidden
- 404: Not found
- 500: Internal server error

## Seed Data
- Tài khoản admin mặc định: `admin@elp.com` / `admin123`
- Một số khoá học, bài học mẫu đã được seed sẵn

## See also
- `openapi.json` for full OpenAPI spec
- `postman_collection.json` for Postman collection
