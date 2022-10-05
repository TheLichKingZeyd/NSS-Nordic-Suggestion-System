create DATABASE if not EXISTS NSS;

use NSS;

CREATE TABLE if NOT EXISTS employee
( EmplyeeNumber: int not null,
  FirstName: varchar(50) not null,
  LastName: varchar(50) not null,
  Password: varchar(50) not null,
  AccountPrivilege: tinyint not null,
  AccountState: boolean not null,
  SgstnCount: smallint,
  ProfilePicture: varbinary,

  Primary key (EmplyeeNumber)
  );