 --select e.id, e.empname, m.id, m.EmpName from emp e
 --join emp m
 --on m.id = e.MangerId

 select e.id, e.empname from emp e join
 emp m on
 e.MangerId = m.id

 select * from emp


 select * from Students
 select * from Accounts
 select * from FeePayments


 CREATE TABLE Accounts (
    AccountId INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL,
    TotalFee DECIMAL(10, 2) NOT NULL,        -- Total fee assigned to student
    TotalPaid DECIMAL(10, 2) NOT NULL,       -- Cumulative amount paid
    Balance AS (TotalFee - TotalPaid) PERSISTED,  -- Auto-calculated
    LastPaymentDate DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE(),
    RowVersion ROWVERSION,

    CONSTRAINT FK_Accounts_Students FOREIGN KEY (StudentId)
        REFERENCES Students(StudentId)
        ON DELETE CASCADE
);


select * from Accounts