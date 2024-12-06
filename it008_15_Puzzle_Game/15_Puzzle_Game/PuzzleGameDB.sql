
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

-- Insert dữ liệu vào bảng Levels (3 bộ: Dễ, Trung Bình, Khó)
INSERT INTO Levels (level_id, level_name, grid_size)
VALUES
(1, 'Dễ', 3),
(2, 'Trung Bình', 4),
(3, 'Khó', 5);

-- Insert dữ liệu vào bảng Puzzles (4 bộ với image_path)
INSERT INTO Puzzles (puzzle_id, image_path)
VALUES
(1, 'Picture/1039168.png'),
(2, 'Picture/1092839.jpg'),
(3, 'Picture/BackGroundLogin.jpg'),
(4, 'Picture/sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg');

-- Insert dữ liệu vào bảng Users (2 user: toan và admin)
-- Bạn có thể thêm password_hash và email sau khi tạo bảng

-- Insert dữ liệu vào bảng LeaderBoards (giả sử người dùng 'toan' và 'admin' tham gia vào các level và puzzle)
INSERT INTO LeaderBoards (leaderboards_id, user_id, puzzle_id, level_id, move, time_taken)
VALUES
(1, 1, 1, 1, 10, 300), -- Người dùng 'toan' chơi puzzle 1, level 'Dễ'
(2, 1, 2, 2, 20, 600), -- Người dùng 'toan' chơi puzzle 2, level 'Trung Bình'
(3, 2, 3, 3, 30, 900), -- Người dùng 'admin' chơi puzzle 3, level 'Khó'
(4, 2, 4, 1, 15, 450); -- Người dùng 'admin' chơi puzzle 4, level 'Dễ'




