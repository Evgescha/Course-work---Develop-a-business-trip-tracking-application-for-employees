DROP DATABASE IF EXISTS `businessTripCounter`;
CREATE DATABASE IF NOT EXISTS `businessTripCounter`;
USE `businessTripCounter`;

DROP TABLE IF EXISTS `ExpenseType`;
CREATE TABLE `ExpenseType` (
  `name` VARCHAR(255) NOT NULL, 
  PRIMARY KEY (`name`)
) ENGINE=innodb DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `Position`;
CREATE TABLE `Position` (
  `id` INTEGER NOT NULL AUTO_INCREMENT, 
  `name` VARCHAR(255), 
  `salary` FLOAT NULL, 
  PRIMARY KEY (`id`)
) ENGINE=innodb DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `Employee`;
CREATE TABLE `Employee` (
  `id` INTEGER NOT NULL AUTO_INCREMENT, 
  `fio` VARCHAR(255), 
  `position` INTEGER, 
  PRIMARY KEY (`id`),
  FOREIGN KEY (`position`) REFERENCES `Position`(`id`)
) ENGINE=innodb DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `BusinessTrip`;
CREATE TABLE `BusinessTrip` (
  `id` INTEGER NOT NULL AUTO_INCREMENT, 
  `employee` INTEGER, 
  `StartDate` VARCHAR(255), 
  `dayCount` INTEGER, 
  `predPaiment` FLOAT NULL, 
  PRIMARY KEY (`id`),
  FOREIGN KEY (`employee`) REFERENCES `Employee`(`id`)
) ENGINE=innodb DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `Expense`;
CREATE TABLE `Expense` (
  `id` INTEGER NOT NULL AUTO_INCREMENT, 
  `businessTrip` INTEGER, 
  `type` VARCHAR(255), 
  `count` FLOAT NULL, 
  PRIMARY KEY (`id`),
  FOREIGN KEY (`businessTrip`) REFERENCES `BusinessTrip`(`id`),
  FOREIGN KEY (`type`) REFERENCES `ExpenseType`(`name`)
) ENGINE=innodb DEFAULT CHARSET=utf8;