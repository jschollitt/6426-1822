using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace Week6
{
    class SFML_HelloWorld
    {
        Font font;
        Text text;
        Clock clock;
        float delta, angle, angleSpeed;
        RenderWindow window;

        public SFML_HelloWorld()
        {
            VideoMode mode = new VideoMode(700, 700);
            window = new RenderWindow(mode, "SFML.NET");

            window.Closed += Window_Closed;
            window.KeyPressed += Window_KeyPressed;
            window.KeyReleased += Window_KeyReleased;

            font = new Font("C:/Windows/Fonts/arial.ttf");
            text = new Text("Hello World!", font);
            text.CharacterSize = 100;
            float textWidth = text.GetLocalBounds().Width;
            float textHeight = text.GetLocalBounds().Height;
            float xOffset = text.GetLocalBounds().Left;
            float yOffset = text.GetLocalBounds().Top;
            text.Origin = new Vector2f(textWidth / 2f + xOffset, textHeight / 2f + yOffset);
            text.Position = new Vector2f(window.Size.X / 2f, window.Size.Y / 2f);

            clock = new Clock();
            delta = 0f;
            angle = 0f;
            angleSpeed = 90f;
        }

        public void Run()
        {
            while (this.window.IsOpen)
            {
                Update();
                Draw();
            }
        }

        public void Update()
        {
            delta = clock.Restart().AsSeconds();
            angle += angleSpeed * delta;
            window.DispatchEvents();
            window.Clear();
            text.Rotation = angle;
        }

        public void Draw()
        {
            window.Draw(text);
            window.Display();
        }

        public void Window_Closed(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Close();
        }

        public void Window_KeyPressed(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Code == Keyboard.Key.Escape)
            {
                window.Close();
            }
            if (e.Code == Keyboard.Key.Space)
            {
                this.text.FillColor = Color.Red;
            }
        }

        public void Window_KeyReleased(object sender, KeyEventArgs e)
        {
            Window window = (Window)sender;
            if (e.Code == Keyboard.Key.Space)
            {
                this.text.FillColor = Color.White;
            }
        }
    }
}
