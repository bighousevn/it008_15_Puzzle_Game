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
using System.Windows.Media.Imaging;

namespace _15_Puzzle_Game
{
    /// <summary>
    /// Interaction logic for PlayPage.xaml
    /// </summary>
    public partial class PlayPage : Page
    {
        public List<Image> imageList = new List<Image>();
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
            // Gọi sự kiện OnMoveTextChanged nếu nó có người đăng ký
            OnMoveTextChanged?.Invoke(this, newText);
        }


        public PlayPage(string n, string path, BitmapImage bitmap1)
        {
            InitializeComponent();
            Initial(n,path, bitmap1);
        }

        //Thêm hình ảnh vào
        private void Initial(string n, string path, BitmapImage bitmap1)
        {
            if (imageList != null)
            {
                foreach (Image pic in imageList.ToList())
                {
                    // Kiểm tra nếu item này là phần tử con của Canvas
                    if (PuzzleCanvas.Children.Contains(pic)) // PuzzleGrid là tên Canvas của bạn
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
                bitmap = bitmap1;
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


        //Tạo các image nhỏ 3x3,4x4,5x5
        private void CreateImageList()
        {
            for (int i = 0; i < n2*n2; i++)
            {
                Image temp = new Image();
                temp.Width = 390/n2;
                temp.Height = 390/n2;
                temp.Tag = i.ToString();

                temp.MouseLeftButtonDown += OnPicClick;
                locations.Add(i.ToString());
                imageList.Add(temp);
            }
        }



        private void CropImage(BitmapImage main_bitmap, int height, int width)
        {
            int x = 0, y = 0;
           

            for (int blocks = 0; blocks < n2*n2; blocks++)
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
            float scaleX = (float) 390 / bitmap.PixelWidth;
            float scaleY = (float) 390 / bitmap.PixelHeight;

            BitmapImage tempBitmap = ResizeAndDisplayImage(bitmap, scaleX, scaleY);
           
            CropImage(tempBitmap, ((int)tempBitmap.Width)/n2, ((int)tempBitmap.Height)/n2);
            for (int i = 1; i < imageList.Count; i++)
            {
                imageList[i].Source = images[i];
            }
            PlaceImageList();
        }


        public BitmapImage ResizeAndDisplayImage(BitmapImage main_bitmap, double scaleX, double scaleY)
        {
            // Calculate the new width and height based on the scaling factors
            int newWidth = (int)(main_bitmap.PixelWidth * scaleX);
            int newHeight = (int)(main_bitmap.PixelHeight * scaleY);

            // Create a WriteableBitmap with the new size
            WriteableBitmap writeableBitmap = new WriteableBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32, null);


            // Create a DrawingVisual to use for drawing the image
            DrawingVisual drawingVisual = new DrawingVisual();
            using (DrawingContext drawingContext = drawingVisual.RenderOpen())
            {
                // Draw the image into the DrawingContext with the new dimensions
                drawingContext.DrawImage(main_bitmap, new Rect(0, 0, newWidth, newHeight));
            }

            // Create a RenderTargetBitmap to render the DrawingVisual into the WriteableBitmap
            RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(newWidth, newHeight, 96, 96, PixelFormats.Pbgra32);
            renderTargetBitmap.Render(drawingVisual);

            // Now copy the rendered result into the WriteableBitmap
            writeableBitmap = new WriteableBitmap(renderTargetBitmap);

            // Create a MemoryStream to save the resized image
            MemoryStream memoryStream = new MemoryStream();
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(writeableBitmap));
            encoder.Save(memoryStream);

            // Reset MemoryStream to the beginning
            memoryStream.Position = 0;

            // Create a new BitmapImage from the MemoryStream
            BitmapImage resizedImage = new BitmapImage();
            resizedImage.BeginInit();
            resizedImage.StreamSource = memoryStream;
            resizedImage.CacheOption = BitmapCacheOption.OnLoad;
            resizedImage.EndInit();

            // Return the resized BitmapImage
            return resizedImage;
        }



        static bool CountInversions(List<Image> puzzle)
        {
            int inversions = 0;
            int length = puzzle.Count;

            // Tính số đảo
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (int.Parse(puzzle[i].Tag.ToString()) > int.Parse(puzzle[j].Tag.ToString()) && puzzle[i].Tag.ToString() != "0" && puzzle[j].Tag.ToString() != "0")
                    {
                        inversions++;
                    }
                }
            }
            return inversions % 2 == 0;
        }


        public void PlaceImageList()
        {
            //Shuffle lại danh sách hình ảnh

            //var shuffleimages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            //while (!CountInversions(shuffleimages))
            //    shuffleimages = imageList.OrderBy(a => Guid.NewGuid()).ToList();
            //imageList = shuffleimages;
            steps = 0;
            ChangeMoveText(steps.ToString());

            double x = 0; // Khởi tạo vị trí x
            double y = 0; // Khởi tạo vị trí y
            double width = imageList[0].Width; // Chiều rộng của mỗi hình ảnh
            double height = imageList[0].Height; // Chiều cao của mỗi hình ảnh

            PuzzleCanvas.Children.Clear();
            win_position = "";
            
            for (int i = 0; i < imageList.Count; i++)
            {
                var img = imageList[i];

                // Điều chỉnh vị trí hình ảnh
                if (i % n2 == 0 && i!=0)  // Khi tới hình ảnh thứ 4 và thứ 7, di chuyển xuống hàng mới
                {
                    y = y + height + paddingBetween;  // Di chuyển xuống hàng mới
                    x = 0; // Đặt lại x về vị trí đầu dòng mới
                }

                // Đặt vị trí hình ảnh trong Canvas hoặc Grid
                Canvas.SetLeft(img, x);
                Canvas.SetTop(img, y);

                // Thêm Image vào Grid (hoặc Canvas)
                PuzzleCanvas.Children.Add(img);

                // Cập nhật vị trí để hình ảnh tiếp theo được thêm vào cạnh bên
                x = x + width + paddingBetween;  // Di chuyển sang bên phải

                // Nếu bạn muốn lưu vị trí hình ảnh, có thể lưu vào danh sách
                win_position += (i);  // Lưu vị trí hiện tại (nếu cần)

            }

            locations.Clear();

            foreach (var child in imageList)
            {
                if (child is Image image)
                {
                    // Kiểm tra thuộc tính Tag (hoặc các thuộc tính khác tùy theo yêu cầu)
                    locations.Add(image.Tag?.ToString());
                }
            }
        }

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

        public void CheckGame()
        {
            current_position = "";
            // Kết hợp các vị trí hiện tại thành chuỗi
            current_position = string.Join("", locations);

            // Hiển thị kết quả trong các Label

            // Kiểm tra nếu vị trí hiện tại khớp với vị trí chiến thắng
            Console.WriteLine(win_position);
            Console.WriteLine(current_position);
            if (win_position == current_position)
            {
                var mainViewModel = (MainViewModel)DataContext;
                mainViewModel.StopTimer();


                if(CurrentUser.Instance.CurrentLevelName != "Option")
                {
                    var user = DataProvider.Instance.DB.Users.FirstOrDefault(p => p.username == CurrentUser.Instance.CurrentUserName);
                    var level = DataProvider.Instance.DB.Levels.FirstOrDefault(p => p.level_name == CurrentUser.Instance.CurrentLevelName);
                    var puzzle = DataProvider.Instance.DB.Puzzles.FirstOrDefault(p => p.image_path == CurrentUser.Instance.CurrentImagePath);
                    int newMove = steps;
                    int newTimeTaken = mainViewModel.getTime();
                    if (DataProvider.Instance.DB.LeaderBoards.Count() > 0)
                    {
                        var existingLeaderBoard = DataProvider.Instance.DB.LeaderBoards
                        .FirstOrDefault(p => p.user_id == user.user_id
                                          && p.puzzle_id == puzzle.puzzle_id
                                          && p.level_id == level.level_id);



                        if (existingLeaderBoard != null)
                        {
                            // Cập nhật nếu move hoặc time_taken mới nhỏ hơn
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
                            // Thêm mới nếu không tồn tại
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

                mainViewModel.Move = steps;
                //AudioControl.Instance.VictoryEffect_Play();
              

                var parentFrame = FindParentFrame(this);
                if (parentFrame != null)
                {
                    Console.WriteLine("Parent Frame found.");
                }
                else
                {
                    Console.WriteLine("No Parent Frame found.");
                }

                var gamePlayPage = FindGamePlayPage(this);
                Console.WriteLine(gamePlayPage);
                Console.WriteLine(parentFrame);

                Congratulation congratulationWindow = new Congratulation();
                congratulationWindow.DataContext = gamePlayPage;
                congratulationWindow.ShowDialog();
                mainViewModel._elapsedTime = 1;
                mainViewModel.StartTimer();

                PlaceImageList();
            }
        }

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


        private void OnPicClick(object sender, MouseButtonEventArgs e)
        {
            Image clickedImage = (Image)sender;
            Image emptyBox = imageList.FirstOrDefault(x => x.Tag.ToString() == "0");

            // Lấy tọa độ của các mảnh ghép
            Point clickedImagePosition = new Point(Canvas.GetLeft(clickedImage), Canvas.GetTop(clickedImage));
            Point emptyBoxPosition = new Point(Canvas.GetLeft(emptyBox), Canvas.GetTop(emptyBox));

            

            var n = Math.Sqrt(imageList.Count());
            // Kiểm tra xem mảnh ghép có thể hoán đổi với ô trống không
            if (CanSwap(clickedImage, emptyBox, n))
            {
                // Hoán đổi vị trí giữa mảnh ghép và ô trống
                Canvas.SetLeft(clickedImage, emptyBoxPosition.X);
                Canvas.SetTop(clickedImage, emptyBoxPosition.Y);

                Canvas.SetLeft(emptyBox, clickedImagePosition.X);
                Canvas.SetTop(emptyBox, clickedImagePosition.Y);

                // Cập nhật lại danh sách các vị trí của mảnh ghép
                UpdateLocations(clickedImage, emptyBox);

                AudioControl.Instance.WoodEffect_Play();
            }

            // Kiểm tra xem trò chơi đã hoàn thành chưa
            CheckGame();
        } 

        public void ShuffleClick(object sender, RoutedEventArgs e)
        {
            PlaceImageList();
        }

        public void SubscribeToGamePlayPageEvents(GamePlayPage gamePlayPage)
        {
            gamePlayPage.KeyPressed += Grid_KeyDown;
        }
        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            Image emptyBox = imageList.FirstOrDefault(x => x.Tag.ToString() == "0");
            Image targetImage = null;
            Point emptyBoxPosition = new Point(Canvas.GetLeft(emptyBox), Canvas.GetTop(emptyBox));

            double n = Math.Sqrt(imageList.Count); // Số lượng ô theo một chiều
            double tileWidth= emptyBox.Width + paddingBetween;
            switch (e.Key)
            {
                case Key.Left:
                    // Tìm hình ở bên trái ô trống
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        // Kiểm tra xem hình ảnh có ở bên phải ô trống hay không
                        return (Canvas.GetLeft(emptyBox) - xPosition ) == tileWidth &&
                                 (yPosition - Canvas.GetTop(emptyBox)) == 0;
                    });
                    break;
                case Key.Right:
                    // Tìm hình ở bên phải ô trống
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        // Kiểm tra xem hình ảnh có ở bên phải ô trống hay không
                        return (xPosition - Canvas.GetLeft(emptyBox) ) == tileWidth &&
                                 (yPosition - Canvas.GetTop(emptyBox)) == 0;
                    });
                    break;
                case Key.Up:
                    // Tìm hình ở bên trên ô trống
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        // Kiểm tra xem hình ảnh có ở bên phải ô trống hay không
                        return (xPosition - Canvas.GetLeft(emptyBox)) == 0 &&
                                 (Canvas.GetTop(emptyBox) - yPosition ) == tileWidth;
                    });
                    break;
                case Key.Down:
                    // Tìm hình ở dưới ô trống
                    targetImage = imageList.FirstOrDefault(x =>
                    {
                        double xPosition = Canvas.GetLeft(x);
                        double yPosition = Canvas.GetTop(x);

                        // Kiểm tra xem hình ảnh có ở bên phải ô trống hay không
                        return (xPosition - Canvas.GetLeft(emptyBox)) == 0 &&
                                (yPosition - Canvas.GetTop(emptyBox) ) == tileWidth;
                    });
                    break;
            }

            if (targetImage != null)
            {
                Point targetImagePosition = new Point(Canvas.GetLeft(targetImage), Canvas.GetTop(targetImage));


                if (CanSwap(targetImage, emptyBox, n))
                {
                    // Hoán đổi vị trí giữa mảnh ghép và ô trống
                    Canvas.SetLeft(targetImage, emptyBoxPosition.X);
                    Canvas.SetTop(targetImage, emptyBoxPosition.Y);

                    Canvas.SetLeft(emptyBox, targetImagePosition.X);
                    Canvas.SetTop(emptyBox, targetImagePosition.Y);

                    // Cập nhật lại danh sách các vị trí của mảnh ghép
                    UpdateLocations(targetImage, emptyBox);

                    AudioControl.Instance.WoodEffect_Play();
                }

                // Kiểm tra xem trò chơi đã hoàn thành chưa
                CheckGame();
            }

        }
    }
}

