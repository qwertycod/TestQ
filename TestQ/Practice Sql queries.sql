 SELECT * FROM [TestDB].[dbo].[Emp]

-- find duplicate records ( 4 methods)
--1
;with cte as(
select empname, MangerId, city , count(*) as groupnumber
from emp group by  empname, MangerId, city 
)
select empname, MangerId, city , groupnumber from cte
where groupnumber > 1
--2
select * from(
select * , row_number() over (partition by empname, mangerid, city order by id) as  cnt from emp
) as sub
where cnt > 1
--3
select e.empname, e.MangerId, e.city from emp e
join emp m
on m.empname = e.empname and e.MangerId = m.MangerId and e.City = m.City
where e.id > m.id

--4
select * FROM emp
WHERE id NOT IN (
    SELECT MIN(id)
    FROM emp
    GROUP BY empname, mangerid, city
);


-- Write an SQL query to delete duplicates from a table without using a temporary table.
 delete e1 from emp e1
 inner join emp e2 
 on e1.id > e2.id
 and e1.empname = e2.empname
 and e1.mangerid = e2.mangerid
 and (e1.dateofjoining= e2.dateofjoining OR (e1.dateofjoining IS NULL AND e2.dateofjoining IS NULL))
 and e1.city = e2.city
 

 with cte as(
 select *, row_number() over (Partition by empname, managerid order by id) as rn
 from emp
 )
 DELETE FROM CTE WHERE rn > 1;


 --  Write an SQL query to fetch only even rows from the table.
 SELECT * FROM emp
 where id % 2 = 0

  -- Using Row_number  
SELECT E.id, E.empname, E.city
FROM (
     select *, ROW_NUMBER() over (order by id) as rn from emp
) E
 where e.rn % 2 <> 1


 -- nth highest salary
 select top 1 * from (
 select top 3 * from EmpSalary order by salary desc)  t
 order by salary 

  ;with cte as (
 select salary, DENSE_RANK() over (order by salary desc) as rank
 from EmpSalary
 )
 select distinct salary from cte where rank = 5


 --  find the total sales amount for each region.
 select  regionid, sum(saleAmount) as sales
 from salesdata
 group by  regionid

 --Number of sales per region:
select regionid, count(*)  as totalSales
from SalesData
group by regionid

--  Average sale amount per region
select regionid, avg(SaleAmount)  as avgSales
from SalesData
group by regionid

--Regions with sales > 800
select regionid, sum(SaleAmount)  as total
from SalesData
group by regionid
having sum(SaleAmount) > 800


-- Highest-selling product per region
 select * from (
   SELECT regionId, productid, SUM(saleamount) AS total_quantity
      ,RANK() OVER (PARTITION BY regionid ORDER BY SUM(saleamount) DESC) AS rnk
	 FROM salesdata
    GROUP BY regionid, productid
	) as temp
	where rnk = 1
	 

--find third highest saleamount by region
select regionid, productid, saleamount from (
select *, dense_rank() over (partition by regionid order by saleamount) as rank from SalesData
) as temp
where rank = 3

 
 -- find emp who are manager
 --1
 SELECT DISTINCT e1.Id, e1.EmpName
FROM Emp e1
JOIN Emp e2 ON e1.Id = e2.MangerId;

--2
select * from emp
where id in (select distinct mangerid from emP)


--  Find Employees Who Are Not Managers

--1
select  * from emp
where id not in (select distinct mangerid from emp where MangerId is not null)
 
 --2
 SELECT distinct e.*
FROM emp e
LEFT JOIN emp m ON e.id =  m.MangerId  
WHERE m.MangerId IS NULL;

 ---- find emp name, manager name where emp salary > manager salary
select e.empname as empname,
m.EmpName as manager,
s.Salary as empsalary, 
s2.Salary as mansalary
from emp e
join emp m on m.Id = e.MangerId
join EmpSalary s on e.Id = s.EmpId
join EmpSalary s2 on m.Id = s2.EmpId
 and  s.Salary > s2.Salary

---  select first letter from emp name
select substring(empname,1,charindex(' ', empname)) from emp
 
 -- 
 select empname, LEN(empname) , len(replace(empname, 'a','')) 
 from emp
 update emp 
 set empname =
   ltrim(rtrim(empname))  

    --find students who have scored > 3 grade in more than 1 subject.

 select count(subject) as cn,  studentid  from studentgrades 
 where grade >= 3
 group by  studentid
 having count(subject) > 1
  

-- find emp that are not present in empSalary
select e.* from emp e
where not exists
(
select 1 from 
empsalary s where s.empid = e.id
)

--finding all employees, their managers, and their respective salaries.
SELECT 
  e.id,                     -- Employee ID
  e.empname,                -- Employee Name
  m.id AS managerId,        -- Manager ID
  m.empname AS ManagerName, -- Manager Name
  s.salary AS empsalary,    -- Employee's Salary
  sm.salary AS managerSalary -- Manager's Salary
FROM emp e
LEFT JOIN empsalary s 
  ON s.empid = e.id
LEFT JOIN emp m 
  ON e.mangerid = m.id
LEFT JOIN empsalary sm 
  ON sm.empid = m.id



--find the maximum salary of employees under each manager,
 select e.mangerid as ManagerId, e.empName as ManagerName, max(s.salary) as max
 from emp e
 join empsalary s
 on e.id = s.empid
 WHERE e.mangerid IS NOT NULL
 group by e.mangerid, e.empName


 -- List employees whose salary is more than their manager's salary.
 select e.empname, m.empname, s.salary as empSalary, sm.salary as ManagerSalary
from emp e
join emp m on e.mangerid = m.id
join empsalary s on e.id = s.empid
join empsalary sm on m.id = sm.empid
where s.salary > sm.salary


--Find managers who manage more than 2 employees.

select m.id, m.empname, count(*) as cnt 
from emp e
join emp m on m.id  = e.mangerid
group by m.id, m.empname
having count(*) > 2

--List employees whose manager is in the same city.
select e.empname, m.empname as manager, e.city from emp e
join emp m on e.mangerid = m.id
and e.city = m.city

-- List each Project's highest-paid employee.
--1
; with RankedSalary as (
select e.empname, s.salary, s.project,
ROW_NUMBER() over (partition by project order by salary desc) as rank
from emp e
join empsalary s 
on e.id = s.empid
)
select * from RankedSalary where rank = 1

--2
;with cte as(
select max(s.salary) as maxSalary, s.project as pro from empsalary s
group by s.project 
)  
select * from cte temp
join empsalary se on 
temp.maxSalary = se.salary and
temp.pro = se.project