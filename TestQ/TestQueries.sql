SELECT * FROM emp
 

 select substring(empname,1,charindex(' ', empname)) from emp
 
 select empname, LEN(empname), len(replace(empname, 'a','')) 
 from emp
 update emp 
 set empname =
   ltrim(rtrim(empname))  

   ALTER TABLE Students
ADD PhotoUrl NVARCHAR(500);


select * from  students 
select * from  studentbooks

select * from  FeePayments 
select * from  UserDetails

sp_help 'Students'

INSERT INTO UserDetails (StudentId, Username, PasswordHash, Email, Phone)
VALUES 
(6, 'john.doe', 'hashedpwd123', 'john.doe@example.com', '9876543210')
  