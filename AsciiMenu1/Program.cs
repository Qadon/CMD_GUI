using AsciiMenu1;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

/// <summary>
/// The main program class which houses the Main function.
/// </summary>

 class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;

        Random rand = new Random();
        int errorCount;
        int dispTimer = 0;
        const int dispTimeOut = 100;
        int optionsIndex = 0;
        Display newDisp = new Display();
        List<Option> options = new List<Option>
            {
                new Option("Add Error", () =>  newDisp.errors.Add("New Error\n")),
                new Option("New Window",() => newDisp.wAdd(new Window("CreatedWindow",90,30,30,10,"A newly created window!"))),
                new Option("Exit", () => Environment.Exit(0)),
            };
        newDisp.wAdd(new Window("Clock", 2, 2, 80, 20, "This is a display"));
        newDisp.wAdd(new Window("Not Clock", 50, 15, 30, 20, WriteOptions(options, options[optionsIndex])));
        newDisp.showDisplay();
        errorCount = 0;
        

        ConsoleKeyInfo keyInfo;

        while (true)
        {
           if (errorCount != newDisp.errors.Count)
            {
                newDisp.windows[0].Update(newDisp.getErrors(newDisp.windows[0].height));
                errorCount = newDisp.errors.Count;
            }

        if (rand.Next(100) == 40)
            {
                newDisp.errors.Add("Random Error\n");
            }

                keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    if (optionsIndex < options.Count-1)
                    {
                        optionsIndex++;
                        newDisp.windows[1].Update(WriteOptions(options, options[optionsIndex]));
                    }
                }
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                if (optionsIndex > 0)
                {
                    optionsIndex--;
                    newDisp.windows[1].Update(WriteOptions(options, options[optionsIndex]));
                }
            }
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                options[optionsIndex].selected.Invoke();
            }
            System.Threading.Thread.Sleep(dispTimeOut); 


            
            

        }
    }
    static List <string> WriteOptions(List <Option> Options, Option selectedOption)
    {
        List<string> sList = [];
        string s;
        foreach(Option option in Options)
        {
            s = "";
             if (option == selectedOption)
            {
                s += ">";
            }
            s += option.name;
            s += "\n";
            sList.Add(s);
        }
        return sList;
    }
}