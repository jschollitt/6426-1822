using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;
using SFML.Window;

namespace Week11
{
    public enum tileState
    {
        empty,
        flooded,
        wall
    }

    public class Tile
    {
        public RectangleShape shape;
        private tileState state;

        public Tile(float x, float y, float width, float height, tileState state)
        {
            shape = new RectangleShape(new Vector2f(width, height));
            shape.Position = new Vector2f(x, y);
            shape.OutlineThickness = 1;
            shape.OutlineColor = Color.White;
            SetState(state);
        }
        public void SetState(tileState state)
        {
            this.state = state;
            switch (this.state)
            {
                case tileState.empty:
                    shape.FillColor = Color.Black;
                    break;
                case tileState.flooded:
                    shape.FillColor = Color.Red;
                    break;
                case tileState.wall:
                    shape.FillColor = Color.White;
                    break;
            }
        }

        public tileState GetState() { return state; }

        public void Draw(RenderWindow window)
        {
            window.Draw(this.shape);
            //if (this.shape.FillColor != Color.Black)
            //    Console.WriteLine(this.shape.FillColor);
        }
    }
    class FloodFill
    {
        RenderWindow window;
        Clock clock;
        double updateTime = 0.1;
        Time delta;

        Tile[,] tiles;
        float tileW, tileH;

        Queue<int> queue;
        bool isFlood = false;

        public FloodFill()
        {
            VideoMode mode = new VideoMode(700, 700);
            window = new RenderWindow(mode, "SFML.NET Flood Fill example", Styles.Titlebar);

            window.Closed += this.Window_close;
            window.KeyPressed += this.Key_press;
            window.MouseButtonPressed += this.Mouse_press;

            clock = new Clock();
            delta = Time.Zero;

            int tilesPerSide = 10;
            tiles = new Tile[tilesPerSide, tilesPerSide];
            tileW = mode.Width / tilesPerSide;
            tileH = mode.Height / tilesPerSide;

            for (int y = 0; y < tiles.GetLength(0); y++)
            {
                for (int x = 0; x < tiles.GetLength(1); x++)
                {
                    tiles[x, y] = new Tile(x * tileW, y * tileH, tileW, tileH, tileState.empty);
                }
            }

            queue = new Queue<int>();
        }

        ////////////// Game Window Critical Methods ///////////////
        public void Run()
        {
            while (window.IsOpen)
            {
                this.Update();
                this.Display();
            }
        }

        public void Update()
        {
            window.DispatchEvents();

            //delta += clock.Restart();
            if (clock.ElapsedTime.AsSeconds() > updateTime)
            {
                clock.Restart();
                if (isFlood)
                    FloodNext(1);
            }
        }

        public void Display()
        {
            /// clear the window
            window.Clear();

            /// draw the help text
            foreach (Tile tile in tiles) tile.Draw(window);

            /// display the window to the screen
            window.Display();
        }


        ////////////// Game Window Event Methods ///////////////
        public void Key_press(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;

            switch (e.Code)
            {
                case Keyboard.Key.Escape:
                    window.Close();
                    break;
                case Keyboard.Key.Space:
                    isFlood = !isFlood;
                    Console.WriteLine(isFlood);
                    break;
                default:
                    break;
            }
        }

        public void Mouse_press(object sender, MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left:
                    Flood(
                        Convert.ToInt32(e.X / tileW) - 1,
                        Convert.ToInt32(e.Y / tileH) - 1);
                    break;
                case Mouse.Button.Right:
                    Wall(e.X, e.Y);
                    break;
                default:
                    break;
            }
        }

        public void Window_close(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        public void Flood(int x, int y)
        {
            tiles[x, y].SetState(tileState.flooded);
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    //Console.WriteLine($"i:{i},    j:{j}");
                    if (i >= 0 && i < tiles.GetLength(1) && j >= 0 && j < tiles.GetLength(0))
                    {
                        //Console.WriteLine("valid");
                        if (tiles[i, j].GetState() == tileState.empty)
                        {
                            //Console.WriteLine("empty");
                            int index = i * tiles.GetLength(1) + j;
                            //Console.WriteLine("not in queue");
                            if (queue.Contains(index) == false)
                            {
                                queue.Enqueue(index);
                                
                            }
                        }
                    }
                }
            }
            Console.WriteLine(queue.Count);
        }

        public void FloodNext(int count)
        {
            for (int i = 0; i < count; i++)
            {
                if (queue.Count == 0)
                    return;
                int num = queue.Dequeue();
                int x = num / tiles.GetLength(1);
                int y = num % tiles.GetLength(1);
                Console.WriteLine($"flood:{x}, {y}");
                Flood(x, y);
            }
        }

        public void Wall(float x, float y)
        {
            tiles[
                Convert.ToInt32(x / tileW),
                Convert.ToInt32(y / tileH)
                ].SetState(tileState.wall);
        }

    }
}
