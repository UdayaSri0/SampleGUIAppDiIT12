-- Create database
CREATE DATABASE SampleGUIAppDiIT12;
GO

-- Use the created database
USE SampleGUIAppDiIT12;
GO

-- Create Users table
CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL,
    Password NVARCHAR(50) NOT NULL,
    Role NVARCHAR(10) NOT NULL  -- Role can be 'User' or 'Admin'
);
GO

-- Insert sample admin and user account
INSERT INTO Users (Username, Password, Role) VALUES ('admin', 'Admin@123', 'Admin');
INSERT INTO Users (Username, Password, Role) VALUES ('user', 'User@123', 'User');
GO
