select * from EmpSalary

--; with cte as(
-- select salary, 
-- DENSE_RANK() over(order by salary desc) as rank
-- from EmpSalary
-- )
-- select distinct salary from cte where rank = 3
 
  
 ;with cte as (
 select salary, DENSE_RANK() over (order by salary desc) as rank
 from EmpSalary
 )
 select distinct salary from cte where rank = 5


 
 with cte as(
 select salary, deparment , emp
