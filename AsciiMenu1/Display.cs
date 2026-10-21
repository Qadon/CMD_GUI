using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiMenu1
{
    /// <summary>
    /// <description>Creates an object with a fixed width and height for displaying multiple windows onto.</description>
    /// 
    /// </summary>
    internal class Display
    {
        public int width = 500;
        public int height = 500;
        public List<string> errors = [];

        public List<Window> windows = [];

        /// <summary>
        /// Basic Class constructor function.
        /// </summary>
        public Display()
        {
        }
        public void wAdd(Window w)
        {
            windows.Add(w);
            w.disp = this;
            errors.Add($"Created Window: \"{w.name}\"\n");
        }
        /// <summary>
        /// Print the actual display in the terminal.
        /// </summary>
        public void showDisplay()
        {
            foreach (Window w in windows)            
            {
                Console.SetCursorPosition(0, 0);
                try
                {

                    if (w.x > 0 && w.x < width)
                    {
                        if (w.y > 0 && w.y < height)
                        {
                            Console.SetCursorPosition(w.x - 1, w.y);
                            Console.Write(w.border.corners);
                            for (int i = 0; i < w.width; i++)
                            {
                                if (i + w.x > width) { break; }
                                Console.Write(w.border.tops);
                            }
                            Console.Write(w.border.corners);
                            for (int i = 0; i <= w.height; i++)
                            {
                                Console.SetCursorPosition(w.x - 1, w.y + i + 1);
                                Console.Write(w.border.sides);
                                Console.Write(w.contents[i]);
                                (int left, int top) = Console.GetCursorPosition();
                                while ((left < w.x + w.width - 1) && (left < width))
                                {
                                    (left, top) = Console.GetCursorPosition();
                                    Console.Write(" ");
                                }
                                Console.Write(w.border.sides);

                            }
                            Console.SetCursorPosition(w.x-1, w.y + w.height+1);
                            Console.Write(w.border.corners);
                            for (int i = 0; i < w.width; i++) { if (i + w.x > width) { break; } Console.Write(w.border.tops); }
                            Console.Write(w.border.corners);
                            
                        }
                        else
                        {
                            errors.Add($"Window \"{w.name}\" y is out of bounds\n");
                        }
                    }
                    else
                    {
                        errors.Add($"Window '{w.name}' x is out of bounds");
                    }
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    errors.Add($"Error: \"{w.name}\" extends out of range.\n");
                }
            }
        }
        public List <string> getErrors(int size) {
            List<string> retErrors = errors;
            if(size < retErrors.Count)
            {
                retErrors = retErrors[(retErrors.Count-size)..];
            }
            return (retErrors);


        }
    }
}
