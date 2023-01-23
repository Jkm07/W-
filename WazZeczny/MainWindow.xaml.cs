using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using WazZeczny.GameLogic;
using WazZeczny.Interface;
using WazZeczny.States;

namespace WazZeczny
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<GridImage, ImageSource> gridValToImage = new()
        {
            {GridImage.Empty, Images.Empty},
            {GridImage.Snake, Images.Body},
            {GridImage.Food, Images.Food},
            {GridImage.SnakeHead, Images.Head},
        };

        private int rows = 15, cols = 30;
        private readonly Image[,] gridImages;
        private GameState gameState;
        private bool gameRunning;
        private State state;
        private GameStateBuilder builder;

        private async Task RunGame()
        {
            gameState = builder.Build();
            Draw();
            await ShowCountDown();
            Overlay.Visibility = Visibility.Hidden;
            state = new GameRunning(gameState, builder);
            await GameLoop();
            await ShowGameOver();
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(!gameRunning && e.Key == Key.Space)
            {
                gameRunning = true;
                await RunGame();
                gameRunning = false;
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            state = state.Handle(e);
        }

        private async Task GameLoop()
        {
            while(!gameState.GameOver())
            {
                gameState.SaveAllSnake();
                gameState.RunAllAI();
                await Task.Delay(100);
                gameState.Move();
                Draw();
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
            builder = new GameStateBuilder();
            state = new Start(null, builder);
            new GUIProxy(this);
        }

        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;
            GameGrid.Width = GameGrid.Height * (cols / (double)rows);

            for(int r = 0; r < rows; r++)
            {
                for(int c = 0; c < cols; c++)
                {
                    var image = new Image
                    {
                        Source = Images.Empty,
                        RenderTransformOrigin = new Point(0.5, 0.5)
                    };
                    images[r, c] = image;
                    GameGrid.Children.Add(image);
                }
            }

            return images;
        }

        public void Draw()
        {
            DrawGrid();
            ScoreText.Text = $"PUNKTY: {gameState.snakes[0].Score}";
        }

        private void DrawGrid()
        {
            int r = 0;
            int c = 0;
            foreach(var i in gameState.Board)
            {
                gridImages[r, c].Source = gridValToImage[i.Type];
                gridImages[r, c].RenderTransform = new RotateTransform(i.Rotation);
                if(++c == cols)
                {
                    c = 0;
                    ++r;
                }
            }
        }

        private async Task ShowCountDown()
        {
            for (int i = 3; i >= 1; i--)
            {
                OverlatText.Text = i.ToString();
                await Task.Delay(500);
            }
        }

        private async Task ShowGameOver()
        {
            //await DrawDeadSnake();
            await Task.Delay(1000);
            Overlay.Visibility = Visibility.Visible;
            OverlatText.Text = "NACIŚNIJ PRZYCISK";
        }

        public void ChangeTextOfSnake1(string text)
        {
            Snake1Opt.Text = text;
        }

        public void ChangeTextOfSnake2(string text)
        {
            Snake2Opt.Text = text;
        }

        public void ChangeTextOfSnake3(string text)
        {
            Snake3Opt.Text = text;
        }

        public void SetActiveSnake1()
        {
            Snake1Opt.Foreground = new SolidColorBrush(Colors.Red);
        }

        public void SetActiveSnake2()
        {
            Snake2Opt.Foreground = new SolidColorBrush(Colors.Red);
        }

        public void SetActiveSnake3()
        {
            Snake3Opt.Foreground = new SolidColorBrush(Colors.Red);
        }

        public void SetUnactiveSnake1()
        {
            Snake1Opt.Foreground = new SolidColorBrush(Colors.White);
        }

        public void SetUnactiveSnake2()
        {
            Snake2Opt.Foreground = new SolidColorBrush(Colors.White);
        }

        public void SetUnactiveSnake3()
        {
            Snake3Opt.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
