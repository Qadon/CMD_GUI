using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AsciiMenu1
{
    internal class Window
    {
        public Display disp;
        public int x;
        public int y;
        public int width;
        public int height;
        public string name;
        public Border border;

        public List<string> contents = [];

        /// <summary>
        /// A class for making a window on a display.
        /// </summary>
        /// <param name="Name">The name of the window (used primarily for debugging)</param>
        /// <param name="X">The left-most point of the window</param>
        /// <param name="Y">The top of the window</param>
        /// <param name="Width">The width of the window</param>
        /// <param name="Height">The height of the window</param>
        public Window(string Name, int X, int Y, int Width, int Height)
        {
            contents = [];
            name = Name;
            x = X;
            y = Y;
            width = Width;
            height = Height;
            border = new Border();
            for(int i = 0; i <= Height; i++)
            {
                contents.Add(" ");
            }

        }
        public Window(string Name, int X, int Y, int Width, int Height, string input, bool clearBorder = false)
        {
            border = (clearBorder) ? new Border(" ", " ", " ") : new Border();
            contents = [];
            name = Name;
            x = X;
            y = Y;
            width = Width;
            height = Height;
            border = new Border();
            int countX = 0;
            int countY = 0;
            contents.Add("");
            foreach (char c in input)
            {
                if (countY >= Height) { break; }
                if (countX >= Width) { 
                    countY++; contents.Add("");
                    countX = 0;
                }
                if (c == '\n') {
                    countY++;
                    countX = 0;
                    contents.Add("");
                    continue;
                }
                contents[countY] += c;
                countX++;
            }
            if (contents.Count < height)
            {
                for (int i = contents.Count-1; i <= Height; i++)
                {
                    contents.Add(" ");
                }
            }
        }

        public Window(string Name, int X, int Y, int Width, int Height, List<string> Contents, bool clearBorder = false)
        {
            border = (clearBorder) ? new Border(" ", " ", " ") : new Border();
            contents = [""];
            this.x = X;
            this.y = Y;
            this.width = Width;
            this.height = Height;
            this.name = Name;
            string newString = "";
            int countX = 0;
            int countY = 0;
            foreach (string s in Contents)
            {
                newString += s;
            }
            foreach (char c in newString)
            {
                if (countY >= Height) { break; }
                if (countX >= Width)
                {
                    countY++; contents.Add("");
                    countX = 0;
                }
                if (c == '\n')
                {
                    countY++;
                    countX = 0;
                    contents.Add("");
                    continue;
                }
                contents[countY] += c;
                countX++;
            }
            if (contents.Count < height)
            {
                for (int i = contents.Count - 1; i <= Height; i++)
                {
                    contents.Add(" ");
                }
            }
        }

        public void Update(List<string> Contents){
            this.contents = [""];
            string newString = "";
            int countX = 0;
            int countY = 0;
            foreach (string s in Contents)
            {
                newString += s;
            }
            foreach (char c in newString)
            {
                if (countY >= height) { break; }
                if (countX >= width)
                {
                    countY++; contents.Add("");
                    countX = 0;
                }
                if (c == '\n')
                {
                    countY++;
                    countX = 0;
                    contents.Add("");
                    continue;
                }
                contents[countY] += c;
                countX++;
            }
            if (contents.Count < height)
            {
                for (int i = contents.Count - 1; i <= height; i++)
                {
                    contents.Add(" ");
                }
            }
            this.disp.showDisplay();
        }
        
    }
}
