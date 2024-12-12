
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

insert into Puzzles
  values (1, 'pack://application:,,,/Picture/GamePlay/Animal/Beaver.jpg'),
		 (2, 'pack://application:,,,/Picture/GamePlay/Animal/Cat.jpg'),
		 (3, 'pack://application:,,,/Picture/GamePlay/Animal/Dog.png'),
		 (4, 'pack://application:,,,/Picture/GamePlay/Animal/Duck.jpg'),
		 (5, 'pack://application:,,,/Picture/GamePlay/Animal/Fox.jpg'),
		 (6, 'pack://application:,,,/Picture/GamePlay/Animal/Rabbit.jpg'),
		 (7, 'pack://application:,,,/Picture/GamePlay/Animal/RedPanda.jpg'),
		 (8, 'pack://application:,,,/Picture/GamePlay/Animal/Tiger.jpg'),
		 (9, 'pack://application:,,,/Picture/GamePlay/Animal/Wolf.jpg'),
		 (10, 'pack://application:,,,/Picture/GamePlay/Meme/ChillGuy.jpg'),
		 (11, 'pack://application:,,,/Picture/GamePlay/Meme/JerryLove.jpg'),
		 (12, 'pack://application:,,,/Picture/GamePlay/Meme/Kid.jpg'),
		 (13, 'pack://application:,,,/Picture/GamePlay/Meme/MrBean.jpg'),
		 (14, 'pack://application:,,,/Picture/GamePlay/Meme/Pepe.jpg'),
		 (15, 'pack://application:,,,/Picture/GamePlay/Meme/ReallyNigger.jpg'),
		 (16, 'pack://application:,,,/Picture/GamePlay/Meme/Sigma.jpg'),
		 (17, 'pack://application:,,,/Picture/GamePlay/Meme/Stonks.jpg'),
		 (18, 'pack://application:,,,/Picture/GamePlay/Meme/ThreeDragon.jpg'),
		 (19, 'pack://application:,,,/Picture/GamePlay/Anime/Broly.jpg'),
		 (20, 'pack://application:,,,/Picture/GamePlay/Anime/Doflamigo.jpg'),
		 (21, 'pack://application:,,,/Picture/GamePlay/Anime/DragonBall.jpg'),
		 (22, 'pack://application:,,,/Picture/GamePlay/Anime/Kakashi.jpg'),
		 (23, 'pack://application:,,,/Picture/GamePlay/Anime/Naruto.jpg"'),
		 (24, 'pack://application:,,,/Picture/GamePlay/Anime/Obito.jpg'),
		 (25, 'pack://application:,,,/Picture/GamePlay/Anime/OnePiece.jpg'),
		 (26, 'pack://application:,,,/Picture/GamePlay/Anime/Vegeta.png'),
		 (27, 'pack://application:,,,/Picture/GamePlay/Anime/Zoro.jpg')


