using System;
using System.Collections.Generic;
using System.Text;
using SFML.System;
using SFML.Graphics;

namespace sfml_menu
{
    /// <summary>
    /// Static helper class to provide commonly used functionality in one place
    /// </summary>
    public static class MathLib2D
    {
        /// <summary>
        /// Check if a point (CheckX, CheckY) is inside the bounds of a rectangle(x, y, width, height)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="checkX"></param>
        /// <param name="checkY"></param>
        /// <returns></returns>
        public static bool isPointInRect(float x, float y, float width, float height, float checkX, float checkY)
        {
            return (checkX >= x && checkX <= x + width && checkY >= y && checkY <= y + height);
        }

        /// <summary>
        /// Check if a point is inside the bounds of a rectangle, using vector inputs
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="size"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool isPointInRect(Vector2f pos, Vector2f size, Vector2f point)
        {
            return isPointInRect(pos.X, pos.Y, size.X, size.Y, point.X, point.Y);
        }

        /// <summary>
        /// Check if a point is inside the bounds of a rectangle, using FloatRect input
        /// </summary>
        /// <param name="bounds"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static bool isPointInRect(FloatRect bounds, Vector2f point)
        {
            return isPointInRect(bounds.Left, bounds.Top, bounds.Width, bounds.Height, point.X, point.Y);
        }
    }
}
