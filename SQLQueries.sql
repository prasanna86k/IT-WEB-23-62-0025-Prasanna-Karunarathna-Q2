--Query 01 .
SELECT * FROM student

--Query 02
SELECT StudentId,StudentName,StudentCity from student Where dbo.student.StudentCity='Kandy'

--Query 03
Update dbo.student
SET StudentCity = 'Galle'
WHERE StudentId ='4'

--Query 04
SELECT *, (SELECT course.CourseName from course WHERE course.CourseID = student.CourseID) AS "Course Name" FROM dbo.student