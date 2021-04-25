using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace sfml_menu
{
    class Program
    {
        /// <summary>
        /// Program starting point.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Press ESC key to close window");
            MyWindow window = new MyWindow();
            window.Run();
            Console.WriteLine("All done");
        }
    }

    /// <summary>
    /// Game engine class. Creates a game window, runs the game loop
    /// and handle user inputs.
    /// </summary>
    class MyWindow
    {
        RenderWindow window;

        Clock clock;
        Time delta;
        float angle;
        float speed;

        Font font;
        Text text, helptext;

        GameMenu menu;
        bool showMainMenu = false;

        /// <summary>
        /// Constructor to setup the game window
        /// </summary>
        public MyWindow()
        {
            VideoMode mode = new VideoMode(1280, 720);
            window = new RenderWindow(mode, "SFML.NET Menu Example", Styles.Titlebar);

            window.Closed += this.Window_close;
            window.KeyPressed += this.Key_press;
            window.MouseButtonPressed += this.Mouse_press;

            clock = new Clock();
            delta = Time.Zero;
            angle = 0f;
            speed = 200f;

            font = new Font(@"C:\\Windows\Fonts\Arial.ttf");
            text = new Text("Hello World!", font, 100);
            helptext = new Text("Press Escape to open and close Game Menu", font, 20);

            var textBounds = text.GetLocalBounds();
            float xOffset = textBounds.Width / 2f + textBounds.Left;
            float yOffset = textBounds.Height / 2f + textBounds.Top;

            text.Origin = new Vector2f(xOffset, yOffset);
            text.Position = (Vector2f)window.Size / 2;

            setupMenu();
        }

        ////////////// Game Window Critical Methods ///////////////
        public void Run()
        {
            /// Game loop
            while (window.IsOpen)
            {
                this.Update();
                this.Draw();
            }
        }

        /// <summary>
        /// Method for updating the valid elements of the game
        /// </summary>
        public void Update()
        {
            window.DispatchEvents();
            delta = clock.Restart();

            /// Check if the menu is being displayed. If not, update the game.
            if (showMainMenu)
            {

            }
            else
            {
                angle += speed * delta.AsSeconds();
                text.Rotation = angle;
            }
        }

        /// <summary>
        /// Method for drawing the game elements to the game window
        /// </summary>
        public void Draw()
        {
            /// clear the window
            window.Clear();

            /// draw game scene
            window.Draw(text);

            /// draw menu
            if (showMainMenu)
            {
                menu.Draw(window, RenderStates.Default);
            }

            /// draw help text
            window.Draw(helptext);

            /// display the window to the screen
            window.Display();
        }


        ////////////// Game Window Event Methods ///////////////
        
        /// <summary>
        /// Event for handling keyboard button presses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Key_press(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;

            switch (e.Code)
            {
                case Keyboard.Key.Escape:
                    this.showMainMenu = !showMainMenu;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Event for handling mouse button presses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Mouse_press(object sender, MouseButtonEventArgs e)
        {
            switch (e.Button)
            {
                case Mouse.Button.Left:
                    if (showMainMenu)
                    {
                        menu.DispatchEvents(e.X, e.Y);
                    }
                    break;
                case Mouse.Button.Right:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Event for closing the game window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_close(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        /// <summary>
        /// Create a menu, and add a title and 3 buttons to it
        /// </summary>
        public void setupMenu()
        {
            Font font = new Font(@"C:\\Windows\Fonts\Arial.ttf");
            this.menu = new GameMenu(window.Size.X / 2, window.Size.Y / 2, 300, 400);
            this.menu.setMenuStyle(new Color(255, 255, 255, 150), Color.Red, 2);

            float menuCenterX = this.menu.getCentre().X;
            float menuCenterY = this.menu.getCentre().Y;

            MenuText title = new MenuText(menuCenterX, menuCenterY - 160, "Main Menu", font, 30);
            title.setTextStyle(Color.White, Color.Black, 1);
            this.menu.AddText(title);

            MenuButton btn1 = new MenuButton(menuCenterX, menuCenterY - 75, 200, 75, "White Text", font);
            btn1.setButtonStyle(Color.White, Color.Black, 2);
            btn1.setTextStyle(Color.Black, Color.Black, 0, 20);
            btn1.Click += Menu_WhiteText_Click;
            this.menu.AddButton(btn1);

            MenuButton btn2 = new MenuButton(menuCenterX, menuCenterY + 25, 200, 75, "Red Text", font);
            btn2.setButtonStyle(Color.White, Color.Black, 2);
            btn2.setTextStyle(Color.Black, Color.Black, 0, 20);
            btn2.Click += Menu_RedText_Click;
            this.menu.AddButton(btn2);

            MenuButton btn3 = new MenuButton(menuCenterX, menuCenterY + 125, 200, 75, "Exit", font);
            btn3.setButtonStyle(Color.White, Color.Black, 2);
            btn3.setTextStyle(Color.Black, Color.Black, 0, 20);
            btn3.Click += Menu_Exit_Click;
            this.menu.AddButton(btn3);
        }

        /// <summary>
        /// Method for button event to call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_WhiteText_Click(object sender, MouseButtonEventArgs e)
        {
            this.text.FillColor = Color.White;
        }

        /// <summary>
        /// Method for button event to call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_RedText_Click(object sender, MouseButtonEventArgs e)
        {
            this.text.FillColor = Color.Red;
        }

        /// <summary>
        /// Method for button event to call
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Menu_Exit_Click(object sender, MouseButtonEventArgs e)
        {
            window.Close();
        }
    }
}
