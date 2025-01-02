using _15_Puzzle_Game.Model;
using _15_Puzzle_Game.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace _15_Puzzle_Game
{
    public partial class PlayPage : Page
    {
        public List<Image> imageList = new List<Image>();
        public List<Image> imageList2 = new List<Image>();
        public List<CroppedBitmap> images = new List<CroppedBitmap>();
        public List<string> locations = new List<string>();
        public List<string> currentLocations = new List<string>();
        public BitmapImage bitmap;
        public double paddingBetween;
        public int n2;
        int steps;

        string win_position;
        string current_position;


        public event EventHandler<string> OnMoveTextChanged;


        // Phương thức để thay đổi nội dung TextBlockMove và gọi sự kiện
        public void ChangeMoveText(string newText)
        {
            OnMoveTextChanged?.Invoke(this, newText);
        }
      
        public PlayPage(string n, string path)
        {
            InitializeComponent();
            Initial(n, path);
        }

        //
        //Hàm khởi tạo
        private void Initial(string n, string path)
        {
            if (imageList != null)
            {
                foreach (Image pic in imageList.ToList())
                {
                    if (PuzzleCanvas.Children.Contains(pic))
                    {
                        PuzzleCanvas.Children.Remove(pic);
                    }
                }
                imageList.Clear();
                images.Clear();
                locations.Clear();
                currentLocations.Clear();
                win_position = "";
                steps = 0;
            }

            bitmap = new BitmapImage();
            if (CurrentUser.Instance.CurrentLevelName == "Option")
            {
                byte[] imageBytes = Convert.FromBase64String(path);
                using (MemoryStream stream = new MemoryStream(imageBytes))
                {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                    bitmap.Freeze();
                }
            }
            else
            {
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(path);
                bitmap.EndInit();
            }


            switch (int.Parse(n))
            {
                case 3:
                    paddingBetween = 8;
                    Myborder.Width = 411;
                    Myborder.Height = 411;
                    break;
                case 4:
                    paddingBetween = 5;
                    Myborder.Width = 408;
                    Myborder.Height = 408;
                    break;
                default:
                    paddingBetween = 3;
                    Myborder.Width = 405;
                    Myborder.Height = 405;
                    break;
            }

            n2 = int.Parse(n);
            CreateImageList();
            AddImages();
        }
        //

        //
        //Hàm tìm kiếm page trong navigation
        private GamePlayPage FindGamePlayPage(DependencyObject current)
        {
            while (current != null)
            {
                var gamePlayPage = current as GamePlayPage;
                if (gamePlayPage != null)
                    return gamePlayPage;

                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }
        private OptionalGamePlayPage FindOpntionalGamePlayPage(DependencyObject current)
        {
            while (current != null)
            {
                var gamePlayPage = current as OptionalGamePlayPage;
                if (gamePlayPage != null)
                    return gamePlayPage;

                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }

        private Frame FindParentFrame(DependencyObject obj)
        {
            while (obj != null)
            {
                obj = VisualTreeHelper.GetParent(obj);
                if (obj is Frame)
                {
                    return obj as Frame;
                }
            }
            return null;
        }
        //
        //Tạo các image nhỏ 3x3,4x4,5x5
        private void CreateImageList()
        {
            for (int i = 0; i < n2 * n2; i++)
            {
                Image temp = new Image();
                temp.Width = 390 / n2;
                temp.Height = 390 / n2;
                temp.Tag = i.ToString();

                temp.MouseLeftButtonDown += OnPicClick;
                locations.Add(i.ToString());
                imageList.Add(temp);
            }
        }

        private void CropImage(BitmapImage main_bitmap, int height, int width)
        {
            int x = 0, y = 0;


            for (int blocks = 0; blocks < n2 * n2; blocks++)
            {
                CroppedBitmap cropped_image = new CroppedBitmap(main_bitmap, new Int32Rect(x, y, height, width));
                images.Add(cropped_image);
                x += width;
                if (x == width * n2)
                {
                    x = 0;
                    y += height;
                }
            }
        }

        private void AddImages()
        {
            float scaleX = (float)390 / bitmap.PixelWidth;
            float scaleY = (float)390 / bitmap.PixelHeight;

            BitmapImage tempBitmap = ResizeAndDisplayImage(bitmap, scaleX, scaleY);

            CropImage(tempBitmap, ((int)tempBitmap.Width) / n2, ((int)tempBitmap.Height) / n2);
            for (int i = 1; i < imageList.Count; i++)
            {
                imageList[i].Source = images[i];

            }
            CopyImageList(imageList, imageList2);
            PlaceImageList();
        }

        public BitmapImage ResizeAndDisplayImage(BitmapImage main_bitmap, double scaleX, double scaleY)
        {
            int newWidth = (int)(main_bitmap.PixelWidth * scaleX);
            int newHeight = (int)(main_bitmap.PixelHeight * scaleY);

            WriteableBitmap writeableBitmap = new WriteableBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32, null);

            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                drawingContext.DrawImage(main_bitmap, new Rect(0, 0, newWidth, newHeight));
            }

            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingVisual);

            writeableBitmap = new WriteableBitmap(renderTargetBitmap);

            MemoryStream memoryStream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
            encoder.Save(memoryStream);

            memoryStream.Position = 0;

            BitmapImage resizedImage = new BitmapImage();
            resizedImage.BeginInit();
            resizedImage.StreamSource = memoryStream;
            resizedImage.CacheOption = BitmapCacheOption.OnLoad;
            resizedImage.EndInit();

            return resizedImage;
        }
        //

        //Hàm copy imageList để sử dụng cho mục đích khác
        private void CopyImageList(List<Image> sourceList, List<Image> destinationList)
        {
            destinationList.Clear();

            foreach (var image in sourceList)
            {
                Image newImage = new Image();

                newImage.Source = image.Source;
                newImage.Width = image.Width;
                newImage.Height = image.Height;
                newImage.Margin = image.Margin;
                newImage.Tag = image.Tag;
                newImage.HorizontalAlignment = image.HorizontalAlignment;
                newImage.VerticalAlignment = image.VerticalAlignment;
                newImage.MouseLeftButtonDown += OnPicClick;

                destinationList.Add(newImage);
            }
        }

        //Hàm kiểm tra puzzle có giải được hay không
        public bool CountInversions(List<Image> puzzle)
        {
            int inversions = 0;
            int length = puzzle.Count;
            int emptyBox = 1;

            // Tính số đảo
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (int.Parse(puzzle[i].Tag.ToString()) > int.Parse(puzzle[j].Tag.ToString()) 
                        && puzzle[i].Tag.ToString() != "0" && puzzle[j].Tag.ToString() != "0")
                    {
                        inversions++;
                    }
                }
            }
            for (int i = 0; i < length - 1; i++)
            {
                if (puzzle[i].Tag.ToString() == "0")
                {
                    emptyBox = i;
                    break;
                }

            }

            //nếu n chẳn thì tổng inversion và dòng của emptyBox phải lẻ
            if (n2 % 2 == 0)
            {           
                double result = Math.Floor((emptyBox * 1.0)/( n2 * 1.0));
                return (result + inversions) % 2 != 0;
            }
            //nếu n lẻ thì inversion phải chẳn
            return inversions % 2 == 0;
        }

        //Hàm đặt hình đã cắt vào Canvas
        public void PlaceImageList()
        {
            CopyImageList(imageList2, imageList);
            //var shuffleimages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            //while (!CountInversions(shuffleimages))
            //    shuffleimages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            //imageList = shuffleimages;

            steps = 0;
            ChangeMoveText(steps.ToString());

            double x = 0;
            double y = 0;
            double width = imageList[0].Width;
            double height = imageList[0].Height;

            PuzzleCanvas.Children.Clear();

            win_position = "";

            for (int i = 0; i < imageList.Count; i++)
            {
                var img = imageList[i];

                if (i % n2 == 0 && i != 0)
                {
                    y = y + height + paddingBetween;
                    x = 0;
                }

                Canvas.SetLeft(img, x);
                Canvas.SetTop(img, y);

                PuzzleCanvas.Children.Add(img);

                x = x + width + paddingBetween;

                win_position += (i);

            }

            locations.Clear();

            foreach (var child in imageList)
            {
                if (child is Image image)
                {
                    locations.Add(image.Tag?.ToString());
                }
            }
        }

        //Hàm cho phép swap ảnh
        private bool CanSwap(Image clickedImage, Image emptyBox, double n)
        {
            // Lấy tọa độ của mảnh ghép đã click và ô trống
            double clickedLeft = Canvas.GetLeft(clickedImage);
            double clickedTop = Canvas.GetTop(clickedImage);
            double emptyLeft = Canvas.GetLeft(emptyBox);
            double emptyTop = Canvas.GetTop(emptyBox);
            var check = 390 / n + paddingBetween;

            // Kiểm tra nếu mảnh ghép kề ô trống theo chiều ngang hoặc chiều dọc
            return (Math.Abs(clickedLeft - emptyLeft) == ((int)check) && clickedTop == emptyTop) || // Kề nhau theo chiều ngang
                   (Math.Abs(clickedTop - emptyTop) == ((int)check) && clickedLeft == emptyLeft);   // Kề nhau theo chiều dọc
        }

        //Hàm cập nhập lại ví trí của ảnh
        private void UpdateLocations(Image clickedImage, Image emptyBox)
        {
            // Cập nhật vị trí của clickedImage và emptyBox trong danh sách locations

            var clickedLocation = clickedImage.Tag.ToString();
            var emptyLocation = emptyBox.Tag.ToString();


            int clickedIndex = locations.IndexOf(clickedLocation);
            int emptyIndex = locations.IndexOf(emptyLocation);

            string temp = locations[clickedIndex];
            locations[clickedIndex] = locations[emptyIndex];
            locations[emptyIndex] = temp;
            steps++;
            ChangeMoveText(steps.ToString());
        }
        //

        //Hàm kiểm tra thắng game
        public void CheckGame()
        {
            current_position = "";
            current_position = string.Join("", locations);

            // Kiểm tra nếu vị trí hiện tại khớp với vị trí chiến thắng
            Console.WriteLine(win_position);
            Console.WriteLine(current_position);
            if (win_position == current_position)
            {
                var mainViewModel = (MainViewModel)DataContext;
                mainViewModel.StopTimer();
                int newMove = steps;
                int newTimeTaken = mainViewModel.getTime();

                if (CurrentUser.Instance.CurrentLevelName != "Option")
                {
                    var user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);
                    var level = DataProvider.Instance.DB.Levels.FirstOrDefault(p => p.level_name == CurrentUser.Instance.CurrentLevelName);
                    var puzzle = DataProvider.Instance.DB.Puzzles.FirstOrDefault(p => p.image_path == CurrentUser.Instance.CurrentImagePath);

                    if (DataProvider.Instance.DB.LeaderBoards.Count() > 0)
                    {
                        var existingLeaderBoard = DataProvider.Instance.DB.LeaderBoards
                        .FirstOrDefault(p => p.user_id == user.user_id
                                          && p.puzzle_id == puzzle.puzzle_id
                                          && p.level_id == level.level_id);



                        if (existingLeaderBoard != null)
                        {
                            if (newTimeTaken < existingLeaderBoard.time_taken ||
                               (newTimeTaken == existingLeaderBoard.time_taken && newMove < existingLeaderBoard.move))
                            {
                                existingLeaderBoard.move = newMove;
                                existingLeaderBoard.time_taken = newTimeTaken;
                                DataProvider.Instance.DB.SaveChanges();
                            }
                        }
                        else
                        {
                            var newLeaderBoard = new LeaderBoards
                            {
                                leaderboards_id = DataProvider.Instance.DB.LeaderBoards.Max(p => p.leaderboards_id) + 1,
                                user_id = user.user_id,
                                puzzle_id = puzzle.puzzle_id,
                                level_id = level.level_id,
                                move = newMove,
                                time_taken = newTimeTaken
                            };
                            DataProvider.Instance.DB.LeaderBoards.Add(newLeaderBoard);
                            DataProvider.Instance.DB.SaveChanges();
                        }
                    }
                    else
                    {
                        var newLeaderBoard = new LeaderBoards
                        {
                            leaderboards_id = 1,
                            user_id = user.user_id,
                            puzzle_id = puzzle.puzzle_id,
                            level_id = level.level_id,
                            move = newMove,
                            time_taken = newTimeTaken
                        };
                        DataProvider.Instance.DB.LeaderBoards.Add(newLeaderBoard);
                        DataProvider.Instance.DB.SaveChanges();
                    }
                    mainViewModel.LoadStageList();
                    if (level.level_id == 1)
                        CurrentUser.Instance.CurrentUserMoney += 50;
                    else if (level.level_id == 2)
                        CurrentUser.Instance.CurrentUserMoney += 100;
                    else
                        CurrentUser.Instance.CurrentUserMoney += 150;

                    user.usermoney = CurrentUser.Instance.CurrentUserMoney;
                    mainViewModel.usermoney = user.usermoney.ToString();
                    DataProvider.Instance.DB.SaveChanges();
                }
                else
                {
                    if (DataProvider.Instance.DB.UserImageRecords.Count() > 0)
                    {
                        var existingImageRecord = DataProvider.Instance.DB.UserImageRecords
                        .FirstOrDefault(p => p.user_image_id == CurrentUser.Instance.UserImageID && p.level_id == CurrentUser.Instance.LevelID);



                        if (existingImageRecord != null)
                        {
                            if (newTimeTaken < existingImageRecord.time_taken ||
                               (newTimeTaken == existingImageRecord.time_taken && newMove < existingImageRecord.move))
                            {
                                existingImageRecord.move = newMove;
                                existingImageRecord.time_taken = newTimeTaken;
                                DataProvider.Instance.DB.SaveChanges();
                                mainViewModel.BestMove = newMove;
                                mainViewModel.BestTime = TimeSpan.FromSeconds(newTimeTaken).ToString(@"mm\:ss");
                            }
                            mainViewModel.BestMove = existingImageRecord.move;
                            mainViewModel.BestTime = TimeSpan.FromSeconds(existingImageRecord.time_taken).ToString(@"mm\:ss");
                        }
                        else
                        {
                            // Thêm mới nếu không tồn tại
                            var newUserImageRecord = new UserImageRecords
                            {
                                record_id = DataProvider.Instance.DB.UserImageRecords.Max(p => p.record_id) + 1,
                                user_image_id = CurrentUser.Instance.UserImageID,
                                level_id = CurrentUser.Instance.LevelID,
                                move = newMove,
                                time_taken = newTimeTaken
                            };
                            DataProvider.Instance.DB.UserImageRecords.Add(newUserImageRecord);
                            DataProvider.Instance.DB.SaveChanges();
                            mainViewModel.BestMove = newMove;
                            mainViewModel.BestTime = TimeSpan.FromSeconds(newTimeTaken).ToString(@"mm\:ss");
                        }
                    }
                    else
                    {
                        var newUserImageRecord = new UserImageRecords
                        {
                            record_id = 1,
                            user_image_id = CurrentUser.Instance.UserImageID,
                            level_id = CurrentUser.Instance.LevelID,
                            move = newMove,
                            time_taken = newTimeTaken
                        };
                        DataProvider.Instance.DB.UserImageRecords.Add(newUserImageRecord);
                        DataProvider.Instance.DB.SaveChanges();
                        mainViewModel.BestMove = newMove;
                        mainViewModel.BestTime = TimeSpan.FromSeconds(newTimeTaken).ToString(@"mm\:ss");
                    }
                }

                //Thêm dữ liệu vào cơ sở dữ liệu

                mainViewModel.Move = steps;

                var parentFrame = FindParentFrame(this);

                if (CurrentUser.Instance.CurrentLevelName == "Option")
                {
                    var gamePlayPage = FindOpntionalGamePlayPage(this);
                    OptionalCongratulation optionalCongratulationWindow = new OptionalCongratulation(gamePlayPage);
                    AudioControl.Instance.VictoryEffect_Play();
                    optionalCongratulationWindow.ShowDialog();
                }
                else
                {
                    var gamePlayPage = FindGamePlayPage(this);
                    Congratulation congratulationWindow = new Congratulation(gamePlayPage);
                    AudioControl.Instance.VictoryEffect_Play();
                    congratulationWindow.ShowDialog();
                }

                mainViewModel._elapsedTime = 1;
                mainViewModel.StartTimer();

                PlaceImageList();
            }
        }
        
        //Hàm tạo Animation
        private void CreateSwapAnimations(Image clickedImage, Image emptyBox, Point clickedImagePosition, Point emptyBoxPosition, Storyboard storyboard)
        {
            DoubleAnimation animateLeft1 = new DoubleAnimation
            {
                From = clickedImagePosition.X,
                To = emptyBoxPosition.X,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new QuadraticEase()
            };

            DoubleAnimation animateTop1 = new DoubleAnimation
            {
                From = clickedImagePosition.Y,
                To = emptyBoxPosition.Y,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new QuadraticEase()
            };

            DoubleAnimation animateLeft2 = new DoubleAnimation
            {
                From = emptyBoxPosition.X,
                To = clickedImagePosition.X,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new QuadraticEase()
            };

            DoubleAnimation animateTop2 = new DoubleAnimation
            {
                From = emptyBoxPosition.Y,
                To = clickedImagePosition.Y,
                Duration = TimeSpan.FromSeconds(0.1),
                EasingFunction = new QuadraticEase()
            };
            Storyboard.SetTarget(animateLeft1, clickedImage);
            Storyboard.SetTargetProperty(animateLeft1, new PropertyPath(Canvas.LeftProperty));

            Storyboard.SetTarget(animateTop1, clickedImage);
            Storyboard.SetTargetProperty(animateTop1, new PropertyPath(Canvas.TopProperty));

            Storyboard.SetTarget(animateLeft2, emptyBox);
            Storyboard.SetTargetProperty(animateLeft2, new PropertyPath(Canvas.LeftProperty));

            Storyboard.SetTarget(animateTop2, emptyBox);
            Storyboard.SetTargetProperty(animateTop2, new PropertyPath(Canvas.TopProperty));

            storyboard.Children.Add(animateLeft1);
            storyboard.Children.Add(animateTop1);
        }

        //Hàm thực hiện click chuột
        private void OnPicClick(object sender, MouseButtonEventArgs e)
        {
            Image clickedImage = (Image)sender;
            Image emptyBox = imageList.FirstOrDefault(x => x.Tag.ToString() == "0");

            Point clickedImagePosition = new Point(Canvas.GetLeft(clickedImage), Canvas.GetTop(clickedImage));
            Point emptyBoxPosition = new Point(Canvas.GetLeft(emptyBox), Canvas.GetTop(emptyBox));

            var n = Math.Sqrt(imageList.Count());

            Storyboard storyboard = new Storyboard();

            if (CanSwap(clickedImage, emptyBox, n))
            {
                Canvas.SetLeft(emptyBox, clickedImagePosition.X);
                Canvas.SetTop(emptyBox, clickedImagePosition.Y);
                CreateSwapAnimations(clickedImage, emptyBox, clickedImagePosition, emptyBoxPosition, storyboard);

                storyboard.Completed += (s, args) =>
                {
                    UpdateLocations(clickedImage, emptyBox);
                    AudioControl.Instance.WoodEffect_Play();
                    CheckGame();

                };
                storyboard.Begin();
                storyboard.Children.Clear();
            }

        }

        //Hàm thực hiện nhấn phím
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            Image emptyBox = imageList.FirstOrDefault(x => x.Tag.ToString() == "0");
            Image targetImage = null;
            Point emptyBoxPosition = new Point(Canvas.GetLeft(emptyBox), Canvas.GetTop(emptyBox));

            double n = Math.Sqrt(imageList.Count);
            double tileWidth = emptyBox.Width + paddingBetween;

            switch (e.Key)
            {
                case Key.Left:
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        return (Canvas.GetLeft(emptyBox) - xPosition) == tileWidth &&
                                 (yPosition - Canvas.GetTop(emptyBox)) == 0;
                    });
                    break;
                case Key.Right:
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        return (xPosition - Canvas.GetLeft(emptyBox)) == tileWidth &&
                                 (yPosition - Canvas.GetTop(emptyBox)) == 0;
                    });
                    break;
                case Key.Up:
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        return (xPosition - Canvas.GetLeft(emptyBox)) == 0 &&
                                 (Canvas.GetTop(emptyBox) - yPosition) == tileWidth;
                    });
                    break;
                case Key.Down:
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        return (xPosition - Canvas.GetLeft(emptyBox)) == 0 &&
                                (yPosition - Canvas.GetTop(emptyBox)) == tileWidth;
                    });
                    break;
            }

            if (targetImage != null)
            {
                Point targetImagePosition = new Point(Canvas.GetLeft(targetImage), Canvas.GetTop(targetImage));

                if (CanSwap(targetImage, emptyBox, n))
                {
                    Storyboard storyboard = new Storyboard();
                    Canvas.SetLeft(emptyBox, targetImagePosition.X);
                    Canvas.SetTop(emptyBox, targetImagePosition.Y);
                    CreateSwapAnimations(targetImage, emptyBox, targetImagePosition, emptyBoxPosition, storyboard);

                    storyboard.Completed += (s, args) =>
                    {
                        UpdateLocations(targetImage, emptyBox);
                        AudioControl.Instance.WoodEffect_Play();
                        CheckGame();
                        storyboard.Children.Clear();

                    };

                    storyboard.Begin();

                }
            }

        }
        //

        //
        //Thực hiện đăng ký event keyDown trên GamePlayPage và OptionalGamePLayPage
        public void SubscribeToGamePlayPageEvents(GamePlayPage gamePlayPage)
        {
            gamePlayPage.KeyPressed += Grid_KeyDown;
        }
        public void SubscribeToOptionalGamePlayPageEvents(OptionalGamePlayPage gamePlayPage)
        {
            gamePlayPage.KeyPressed += Grid_KeyDown;
        }
        //

        //Hàm shuffle
        public void ShuffleClick(object sender, RoutedEventArgs e)
        {
            PlaceImageList();
        }

    }
}

