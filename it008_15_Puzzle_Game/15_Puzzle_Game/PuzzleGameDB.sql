
CREATE DATABASE PuzzleGameDB;
USE PuzzleGameDB;

-- Bảng Users
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY, 
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT GETDATE()
)

-- Bảng Levels
CREATE TABLE Levels (
    level_id INT PRIMARY KEY,
    level_name VARCHAR(50) NOT NULL,
    grid_size INT NOT NULL
)

-- Bảng Puzzles
CREATE TABLE Puzzles (
    puzzle_id INT PRIMARY KEY,
    image_path VARCHAR(255) NOT NULL
)

-- Bảng LeaderBoards
CREATE TABLE LeaderBoards (
	leaderboards_id int primary key,
    user_id INT NOT NULL,
    puzzle_id INT NOT NULL,
    level_id INT NOT NULL,
    move INT NOT NULL,
    time_taken INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (puzzle_id) REFERENCES Puzzles(puzzle_id),
    FOREIGN KEY (level_id) REFERENCES Levels(level_id)
)


INSERT INTO Levels (level_id, level_name, grid_size)
VALUES
(1, '3x3', 9),
(2, '4x4', 16),
(3, '5x5', 25),
(4, 'Option',9);


INSERT INTO Puzzles (puzzle_id, image_path)
VALUES
(1, 'Picture/1039168.png'),
(2, 'Picture/1092839.jpg'),
(3, 'Picture/BackGroundLogin.jpg'),
(4, 'Picture/sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg');

INSERT INTO Puzzles (puzzle_id, image_path)
VALUES
(1, 'pack://application:,,,/Picture/GamePlay/Cat.jpg')



