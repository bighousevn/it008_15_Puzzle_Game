
CREATE DATABASE PuzzleGameDB;
USE PuzzleGameDB;

-- Bảng Users
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY, 
    username VARCHAR(50) NOT NULL UNIQUE,
	usermoney int not null,
	maxlevel int not null,
    password_hash VARCHAR(255) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at DATETIME DEFAULT GETDATE()
)
CREATE TABLE UserImages (
    image_id INT IDENTITY(1,1) PRIMARY KEY,
    user_id INT NOT NULL,
    image_byte image NOT NULL,  -- Đường dẫn tới ảnh
    FOREIGN KEY (user_id) REFERENCES Users(user_id)  -- Liên kết với bảng Users
)

CREATE TABLE UserImageRecords (
    record_id INT IDENTITY(1,1) PRIMARY KEY,
    user_image_id INT NOT NULL,
    level_id INT NOT NULL,
    move INT NOT NULL,
    time_taken INT NOT NULL,
    FOREIGN KEY (user_image_id) REFERENCES UserImages(image_id),
    FOREIGN KEY (level_id) REFERENCES Levels(level_id)
);

-- Bảng Levels
CREATE TABLE Levels (
    level_id INT PRIMARY KEY,
    level_name VARCHAR(50) NOT NULL,
    grid_size INT
)

-- Bảng Puzzles
CREATE TABLE Puzzles (
    puzzle_id INT PRIMARY KEY,
    image_path VARCHAR(255) NOT NULL,
	level_id  int not null,
	foreign key (level_id) references Levels(level_id)
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
(4, 'Option', null);


insert into Puzzles
  values (1, 'pack://application:,,,/Picture/GamePlay/Animal/Beaver.jpg', 1),
		 (2, 'pack://application:,,,/Picture/GamePlay/Animal/Cat.jpg', 1),
		 (3, 'pack://application:,,,/Picture/GamePlay/Animal/Dog.png', 1),
		 (4, 'pack://application:,,,/Picture/GamePlay/Animal/Duck.jpg', 1),
		 (5, 'pack://application:,,,/Picture/GamePlay/Animal/Fox.jpg', 1),
		 (6, 'pack://application:,,,/Picture/GamePlay/Animal/Rabbit.jpg', 1),
		 (7, 'pack://application:,,,/Picture/GamePlay/Animal/RedPanda.jpg', 1),
		 (8, 'pack://application:,,,/Picture/GamePlay/Animal/Tiger.jpg', 1),
		 (9, 'pack://application:,,,/Picture/GamePlay/Animal/Wolf.jpg', 1),
		 (10, 'pack://application:,,,/Picture/GamePlay/Meme/ChillGuy.jpg', 2),
		 (11, 'pack://application:,,,/Picture/GamePlay/Meme/JerryLove.jpg', 2),
		 (12, 'pack://application:,,,/Picture/GamePlay/Meme/Kid.jpg', 2),
		 (13, 'pack://application:,,,/Picture/GamePlay/Meme/MrBean.jpg', 2),
		 (14, 'pack://application:,,,/Picture/GamePlay/Meme/Pepe.jpg', 2),
		 (15, 'pack://application:,,,/Picture/GamePlay/Meme/ReallyNigger.jpg', 2),
		 (16, 'pack://application:,,,/Picture/GamePlay/Meme/Sigma.jpg', 2),
		 (17, 'pack://application:,,,/Picture/GamePlay/Meme/Stonks.jpg', 2),
		 (18, 'pack://application:,,,/Picture/GamePlay/Meme/ThreeDragon.jpg', 2),
		 (19, 'pack://application:,,,/Picture/GamePlay/Anime/Broly.jpg', 3),
		 (20, 'pack://application:,,,/Picture/GamePlay/Anime/Doflamigo.jpg', 3),
		 (21, 'pack://application:,,,/Picture/GamePlay/Anime/DragonBall.jpg', 3),
		 (22, 'pack://application:,,,/Picture/GamePlay/Anime/Kakashi.jpg', 3),
		 (23, 'pack://application:,,,/Picture/GamePlay/Anime/Naruto.jpg"', 3),
		 (24, 'pack://application:,,,/Picture/GamePlay/Anime/Obito.jpg', 3),
		 (25, 'pack://application:,,,/Picture/GamePlay/Anime/OnePiece.jpg', 3),
		 (26, 'pack://application:,,,/Picture/GamePlay/Anime/Vegeta.png', 3),
		 (27, 'pack://application:,,,/Picture/GamePlay/Anime/Zoro.jpg', 3)
