
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
    image_path VARCHAR(255) NOT NULL,
    level_id INT NOT NULL,
    FOREIGN KEY (level_id) REFERENCES Levels(level_id) ON DELETE CASCADE
)

-- Bảng LeaderBoards
CREATE TABLE LeaderBoards (
    user_id INT NOT NULL,
    puzzle_id INT NOT NULL,
    level_id INT NOT NULL,
    move INT NOT NULL,
    time_taken INT NOT NULL,
    PRIMARY KEY (user_id, puzzle_id, level_id),
    FOREIGN KEY (user_id) REFERENCES Users(user_id),
    FOREIGN KEY (puzzle_id) REFERENCES Puzzles(puzzle_id),
    FOREIGN KEY (level_id) REFERENCES Levels(level_id)
)