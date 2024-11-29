
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

-- Thêm dữ liệu vào bảng Users
INSERT INTO Users (username, password_hash, email)
VALUES ('admin', 'admin', 'admin@example.com');

-- Thêm dữ liệu vào bảng Levels (có thể có các cấp độ khác nhau, ở đây sẽ tạo 1 cấp độ mặc định)
INSERT INTO Levels (level_id, level_name, grid_size)
VALUES (1, 'Beginner', 3), 
       (2, 'Intermediate', 4), 
       (3, 'Advanced', 5);

-- Thêm dữ liệu vào bảng Puzzles với 4 image path cụ thể
INSERT INTO Puzzles (puzzle_id, image_path, level_id)
VALUES (1, 'Picture/1039168.png', 1),
       (2, 'Picture/1092839.jpg', 2),
       (3, 'Picture/BackGround.jpg', 3),
       (4, 'Picture/sunset-river-nature-scenery-4k-wallpaper-uhdpaper.com-693@0@j.jpg', 1);

-- Thêm dữ liệu vào bảng LeaderBoards cho người dùng admin
INSERT INTO LeaderBoards (user_id, puzzle_id, level_id, move, time_taken)
VALUES (1, 1, 1, 10, 120),
       (1, 2, 2, 15, 150),
       (1, 3, 3, 20, 180),
       (1, 4, 1, 12, 130);
