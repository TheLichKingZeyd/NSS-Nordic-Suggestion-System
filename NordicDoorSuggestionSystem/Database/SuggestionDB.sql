CREATE DATABASE IF NOT EXISTS SuggestionDB;

use SuggestionDB;

CREATE TABLE IF NOT EXISTS Employee
( EmployeeNumber: int not null,
  FirstName: varchar(50) not null,
  LastName: varchar(50) not null,
  Password: varchar(50) not null,
  AccountPrivilege: tinyint not null,
  AccountState: boolean not null,
  SgstnCount: smallint,
  ProfilePicture: varbinary,

  Primary key (EmployeeNumber)
  );

CREATE TABLE IF NOT EXISTS Department(
DepartmentID: INT NOT NULL,
DepartmentName: VARCHAR(50),
DepartmentLeader: INT NOT NUll,
PRIMARY KEY (DeprtmentID),
FOREIGN KEY (DepartmentLeader) REFERENCES Employee(EmployeeNumber)
);

CREATE TABLE IF NOT EXISTS Team (
TeamID: INT NOT NULL,
TeamName: VARCHAR(50),
TeamLeader: INT NOT NULL,
/*TeamSgstnCount: INT DEFAULT 0,*/
PRIMARY (TeamID),
FOREIGN KEY (TeamLeader) REFERENCES Employee(EmployeeNumber),
);

  CREATE TABLE IF NOT EXISTS Suggestion (

  SgstnID: INT NOT NULL,
  EmployeeNumber: INT NOT NULL,
  TeamID: INT DEFAULT 0,
  ResponsibleEmployee: INT NOT NULL,
  SubmissionTime: DATETIME NOT NULL,
  ETA: DATETIME NOT NULL,
  Title: TINYTEXT,
  ProbDescr: TEXT,
  Solution: TEXT,
  Goal: TEXT,
  HasMediaAttachments: BIT NOT NULL,
  Progress: TINYINT DEFAULT 0,
  HasReasoning: BIT NOT NULL,

  PRIMARY KEY (SgstnID),
  FOREIGN KEY (EmployeeNumber) REFERENCES Employee(EmployeeNumber),
  FOREIGN KEY (TeamID) REFERENCES Team(TeamID),
  FOREIGN KEY (ResponsibleEmployee) REFERENCES Employee(EmployeeNumber),
  );

  CREATE TABLE IF NOT EXISTS SgstnReason (
    ReasonForDenial: TINYTEXT NOT NULL,
    SgstnID: INT NOT NULL,
    PRIMARY (ReasonForDenial,SgstnID),
    FOREIGN KEY (SgstnID) REFERENCES Suggestion(SgstnID),
  );

