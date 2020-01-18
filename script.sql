SELECT * FROM Accounts
SELECT * FROM Phones

CREATE TABLE Accounts(
   ID INT PRIMARY KEY,
   SURNAME TEXT NOT NULL,
   NAME TEXT NOT NULL,
   MIDDLENAME TEXT NOT NULL,
   GENDER INT NOT NULL,
   BIRTHDAY DATETIME NOT NULL,
   COUNTRY TEXT NOT NULL,
   REGION TEXT NOT NULL,
   CITY TEXT NOT NULL,
   ADDRESS TEXT NOT NULL,
   EMAIL TEXT NOT NULL,
   ASFOUND TEXT NOT NULL
)

INSERT INTO Accounts VALUES (1, 'Мерчанский', 'Руслан', 'Юрьевич', 0, '1998-02-22', 'Украина', 'Харьковская', 'Харьков', 'Тест', 'rusya998@gmail.com', 'Интернет'),
(2, 'Курочкин', 'Иван', 'Викторович', 0, '1992-05-18', 'Украина', 'Харьковская', 'Харьков', 'Тест', 'kurochka@gmail.com', 'На улице'),
(3, 'Торчков', 'Георгий', 'Михайлович', 0, '1994-03-08', 'Украина', 'Харьковская', 'Харьков', 'Тест', 'torchkov@gmail.com', 'От друга'),
(4, 'Светова', 'Светлана', 'Ростиславовна', 1, '1991-07-03', 'Украина', 'Харьковская', 'Харьков', 'Тест', 'svetova@gmail.com', 'От подруги');


CREATE TABLE Phones(
   ID INT PRIMARY KEY,
   PHONE TEXT NOT NULL,
   ACCOUNTS_ID INT NOT NULL,
   FOREIGN KEY (ACCOUNT_ID) REFERENCES Accounts(ID)
)

INSERT INTO Phones VALUES (1, 0676812312, 1);