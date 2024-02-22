-- First create the database
CREATE DATABASE ItineraryPlanner

-- Then create tables and fields
CREATE TABLE Trip (
TripId INT PRIMARY KEY IDENTITY(1, 1), 
Destination NVARCHAR(50), 
[Description] NVARCHAR(MAX),
StartDate DATETIME, 
EndDate DATETIME
)

CREATE TABLE TripTask (
TripTaskId INT PRIMARY KEY IDENTITY(1, 1), 
TripId INT REFERENCES Trip(TripId), --FK
TaskName NVARCHAR(50), 
TaskDescription NVARCHAR(MAX),
TaskDueDate DATETIME
)