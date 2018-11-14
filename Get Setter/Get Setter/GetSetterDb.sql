BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS `Routines` (
	`RoutineID`	INTEGER UNIQUE,
	`Goal`	TEXT,
	`TrainingDays`	INTEGER,
	PRIMARY KEY(`RoutineID`)
);
CREATE TABLE IF NOT EXISTS `Logged Sets` (
	`LogID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`SheduleID`	INTEGER,
	`Data`	REAL,
	`WeightLifted`	INTEGER,
	`Set Number`	INTEGER,
	`Repititions`	INTEGER
);
CREATE TABLE IF NOT EXISTS `Exercises` (
	`ExerciseID`	INTEGER NOT NULL,
	`ExerciseName`	TEXT UNIQUE,
	`MuscleGroup`	TEXT,
	`MuscleName`	TEXT,
	PRIMARY KEY(`ExerciseID`)
);
INSERT INTO `Exercises` VALUES (1,'Barbell Bench','Chest','Compound');
INSERT INTO `Exercises` VALUES (2,'DeadLift','Back','Compound');
INSERT INTO `Exercises` VALUES (3,'Squat','Legs','Compound');
INSERT INTO `Exercises` VALUES (4,'Barbell Row','Back','Compound');
INSERT INTO `Exercises` VALUES (5,'Chin Up','Back','Compound');
INSERT INTO `Exercises` VALUES (6,'Shoulder Press','Shoulder','Compound');
CREATE TABLE IF NOT EXISTS `Day Shedule` (
	`SheduleID`	INTEGER NOT NULL,
	`RoutineID`	INTEGER NOT NULL,
	`ExerciseID`	INTEGER NOT NULL,
	`RoutineExerciseNumber`	INTEGER,
	`RoutineDayNumber`	INTEGER,
	PRIMARY KEY(`SheduleID`),
	FOREIGN KEY(`RoutineID`) REFERENCES `Routines`(`RoutineID`) ON UPDATE SET NULL ON DELETE SET NULL
);
COMMIT;
