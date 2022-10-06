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

