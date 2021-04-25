
using System;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace sfml_menu
{
    /// <summary>
    /// Class for creating and drawing a game menu (like an escape menu).
    /// </summary>
    public class GameMenu
    {
        /// Background rectangle
        RectangleShape recMenuBackground;

        /// Lists for holding all the text and buttons added to the menu
        List<MenuButton> buttons;
        List<MenuText> texts;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameMenu()
        {
            recMenuBackground = new RectangleShape();
            buttons = new List<MenuButton>();
            texts = new List<MenuText>();
        }

        /// <summary>
        /// Constructor that sets position and size of menu
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        public GameMenu(Vector2f position, Vector2f size) : this()
        {
            recMenuBackground.Size = size;
            recMenuBackground.Origin = size / 2;
            recMenuBackground.Position = position;
        }

        /// <summary>
        /// Constructor that takes position and size as floats and
        /// passes them as vectors to the other constructor
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public GameMenu(float x, float y, float width, float height)
            : this(new Vector2f(x, y), new Vector2f(width, height))
        {
        }

        /// <summary>
        /// Return the center coordinates of the menu
        /// </summary>
        /// <returns></returns>
        public Vector2f getCentre()
        {
            return recMenuBackground.Position;
        }

        /// <summary>
        /// Set the style attributes of the menu background
        /// </summary>
        /// <param name="fillColour"></param>
        /// <param name="outlineColour"></param>
        /// <param name="outlineWidth"></param>
        public void setMenuStyle(Color fillColour, Color outlineColour, float outlineWidth)
        {
            recMenuBackground.FillColor = fillColour;
            recMenuBackground.OutlineColor = outlineColour;
            recMenuBackground.OutlineThickness = outlineWidth;
        }

        /// <summary>
        /// Check if the mouse click overlaps with any buttons
        /// and invoke the event if it does
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void DispatchEvents(int X, int Y)
        {
            foreach(MenuButton btn in buttons)
            {
                if (btn.checkOverlap(X, Y))
                {
                    btn.OnClick(X, Y);
                }
            }
        }

        /// <summary>
        /// Add button to the list
        /// </summary>
        /// <param name="button"></param>
        public void AddButton(MenuButton button)
        {
            buttons.Add(button);
        }

        /// <summary>
        /// Create a menu button and add it to the list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public void AddButton(float x, float y, float width, float height, string text, Font font)
        {
            AddButton(new MenuButton(x, y, width, height, text, font));
        }

        /// <summary>
        /// Add a menu text label to the list
        /// </summary>
        /// <param name="text"></param>
        public void AddText(MenuText text)
        {
            texts.Add(text);
        }

        /// <summary>
        /// Create a menu text label and add it to the list
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="charsize"></param>
        public void AddText(float x, float y, string text, Font font, uint charsize)
        {
            AddText(new MenuText(x, y, text, font, charsize));
        }

        /// <summary>
        /// Draw all of the elements of the menu
        /// </summary>
        /// <param name="target"></param>
        /// <param name="state"></param>
        public void Draw(RenderTarget target, RenderStates state)
        {
            /// draw the background first
            target.Draw(this.recMenuBackground, state);
            
            /// draw the buttons over the background
            foreach (MenuButton btn in buttons)
            {
                btn.Draw(target, state);
            }

            /// draw the text labels
            foreach (MenuText text in texts)
            {
                text.Draw(target, state);
            }
        }
    }

    /// <summary>
    /// Menu Text label class. Provides a way to setup text
    /// to be used in a game menu
    /// </summary>
    public class MenuText
    {
        Text text;

        /// <summary>
        /// Constructor that creates a menu text label based on the
        /// passed parameter values
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="charsize"></param>
        public MenuText(float x, float y, string text, Font font, uint charsize)
        {
            this.text = new Text(text, font, charsize);
            this.text.Position = new Vector2f(x, y);
            centerText();
        }

        /// <summary>
        /// Set the design attributes of the menu text label
        /// </summary>
        /// <param name="fillColour"></param>
        /// <param name="outlineColour"></param>
        /// <param name="outlineWidth"></param>
        public void setTextStyle(Color fillColour, Color outlineColour, float outlineWidth)
        {
            text.FillColor = fillColour;
            text.OutlineColor = outlineColour;
            text.OutlineThickness = outlineWidth;
        }

        /// <summary>
        /// Move the origin of the text object to the centre of the text
        /// </summary>
        private void centerText()
        {
            var bounds = text.GetLocalBounds();
            text.Origin = new Vector2f(bounds.Width / 2, bounds.Height / 2);
        }

        /// <summary>
        /// Check if a point overlaps with the bounds of the text
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool checkOverlap(Vector2f point)
        {
            return MathLib2D.isPointInRect(text.GetGlobalBounds(), point);
        }

        /// <summary>
        /// Draw the text to the target
        /// </summary>
        /// <param name="target"></param>
        /// <param name="state"></param>
        public void Draw(RenderTarget target, RenderStates state)
        {
            target.Draw(text, state);
        }
    }

    /// <summary>
    /// Menu Button class. Provides a way to setup a button
    /// to be used in a game menu and provide click functionality
    /// </summary>
    public class MenuButton
    {
        RectangleShape recButtonBackground;
        Text txtButtonText;

        /// Event handler for the button click. Allows a function to
        /// be called when a condition passes
        public event EventHandler<MouseButtonEventArgs> Click;

        /// <summary>
        /// Constructor
        /// </summary>
        public MenuButton()
        {
            recButtonBackground = new RectangleShape();
            txtButtonText = new Text();
        }

        /// <summary>
        /// Constructor that sets up the position and size of the button,
        /// and the text that is written on the button
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public MenuButton(Vector2f position, Vector2f size, string text, Font font) : this()
        {
            recButtonBackground.Origin = size / 2;
            recButtonBackground.Size = size;
            recButtonBackground.Position = position;

            txtButtonText.DisplayedString = text;
            txtButtonText.Font = font;
            txtButtonText.Position = position;
        }

        /// <summary>
        /// Contructor that sets up the position and size of the button as
        /// floats instead of vectors
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="text"></param>
        /// <param name="font"></param>
        public MenuButton(float x, float y, float width, float height, string text, Font font) 
            : this(new Vector2f(x, y), new Vector2f(width, height), text, font)
        {
        }

        /// <summary>
        /// method to invoke the click functionality of the button.
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void OnClick(int X, int Y)
        {
            MouseButtonEventArgs e = new MouseButtonEventArgs(new MouseButtonEvent());
            e.X = X;
            e.Y = Y;
            this.Click.Invoke(this, e);
        }

        /// <summary>
        /// Set the design attributes of the button
        /// </summary>
        /// <param name="fillColour"></param>
        /// <param name="outlineColour"></param>
        /// <param name="outlineWidth"></param>
        public void setButtonStyle(Color fillColour, Color outlineColour, float outlineWidth)
        {
            recButtonBackground.FillColor = fillColour;
            recButtonBackground.OutlineColor = outlineColour;
            recButtonBackground.OutlineThickness = outlineWidth;
        }

        /// <summary>
        /// Set the design attributes of the text on the button
        /// </summary>
        /// <param name="colour"></param>
        /// <param name="outlineColour"></param>
        /// <param name="outlineWidth"></param>
        /// <param name="fontSize"></param>
        public void setTextStyle(Color colour, Color outlineColour, float outlineWidth, uint fontSize)
        {
            txtButtonText.FillColor = colour;
            txtButtonText.CharacterSize = fontSize;
            txtButtonText.OutlineColor = outlineColour;
            txtButtonText.OutlineThickness = outlineWidth;
            centreText();
        }

        /// <summary>
        /// Set the origin of the button text to the middle of the text
        /// </summary>
        private void centreText()
        {
            var bounds = txtButtonText.GetLocalBounds();
            txtButtonText.Origin = new Vector2f(bounds.Width / 2, bounds.Height / 2);
        }

        /// <summary>
        /// Check if a point overlaps with the button
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool checkOverlap(Vector2f point)
        {
            return MathLib2D.isPointInRect(recButtonBackground.GetGlobalBounds(), point);
        }

        /// <summary>
        /// Make a vector from given floats and check for overlaps
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool checkOverlap(float x, float y)
        {
            return checkOverlap(new Vector2f(x, y));
        }

        /// <summary>
        /// Draw the button to the target, and draw the text over the top
        /// </summary>
        /// <param name="target"></param>
        /// <param name="state"></param>
        public void Draw(RenderTarget target, RenderStates state)
        {
            target.Draw(recButtonBackground, state);
            target.Draw(txtButtonText, state);
        }
    }
}
