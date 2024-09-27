using System;

namespace dotnet_playground;

public class Shape
{
    public string InfoString;
    public Shape(string info) => InfoString = info;

    static void ValueTypeContainingRefType()
    {
        // Create the first Rectangle.
        Console.WriteLine("-> Creating r1");
        var r1 = new Rectangle("First Rect", 10, 10, 50, 50);
        // Now assign a new Rectangle to r1.
        Console.WriteLine("-> Assigning r2 to r1");
        Rectangle r2 = r1;
        // Change some values of r2.
        Console.WriteLine("-> Changing values of r2");
        r2.RectInfo.InfoString = "This is new info!";
        r2.RectBottom = 4444;
        // Print values of both rectangles.
        r1.Display();
        r2.Display();

        // Assignment copies the reference types, but the value types get copied.
    }

    struct Rectangle
    {
        // The Rectangle structure contains a reference type member.
        public readonly Shape RectInfo;
        public readonly int RectTop;
        public readonly int RectLeft;
        public int RectBottom;
        public readonly int RectRight;

        public Rectangle(string info, int top, int left, int bottom, int right)
        {
            RectInfo = new Shape(info);
            RectTop = top;
            RectBottom = bottom;
            RectLeft = left;
            RectRight = right;
        }

        public void Display() =>
            Console.WriteLine("String = {0}, Top = {1}, Bottom = {2}, " +
                              "Left = {3}, Right = {4}",
                RectInfo.InfoString, RectTop, RectBottom, RectLeft, RectRight);
    }
}
