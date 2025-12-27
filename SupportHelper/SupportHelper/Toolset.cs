public class Toolset
{
    /// <summary>
    /// Lists menupoints according list and returns one char as string
    /// </summary>
    /// <param name="menuPoints"></param>
    /// <returns></returns>
    public static string Menu(
        string menuTitle, 
        string lineString, 
        List<(string command, string description)> menuPoints)
    {
        Console.WriteLine(menuTitle);
        int maxCount = menuPoints.Max(x => x.command.Length);
        int countNow = 0;
        string caracterFixed = string.Empty;
        string consoleMenu = string.Empty;
        string output = string.Empty;
        bool isCorrect = false;
        
        foreach ((string character, string menuDesc) menuPoint in menuPoints)
        {
            countNow = menuPoint.character.Length;
            
            if (countNow < maxCount)
            {
                for (int i = 0; i <= maxCount - countNow; i++)
                {
                    caracterFixed += " ";
                }
            }
            
            caracterFixed += menuPoint.character;
            consoleMenu += $"{caracterFixed}\t{menuPoint.menuDesc}";
        }

        while (!isCorrect)
        {
            Console.WriteLine(consoleMenu);
            Console.Write($"{lineString}> ");
            output = Console.ReadLine();
            
            // Here is to check, if the input is correct
            if (!string.IsNullOrEmpty(output))
            {
                isCorrect = true;
            }
        }
        
        return output;
    }

    public static string Menu(string menuTitle, string lineString, List<string> menuPoints)
    => Menu(menuTitle, lineString, CreateMenuOfSingleList(menuPoints));

    private static List<(string, string)> CreateMenuOfSingleList(List<string> singleList)
    {
        List<(string, string)> outputList = new();
        int count = 0;
        
        foreach (string item in singleList)
        {
            outputList.Add((String.Concat(count.ToString()),item));
            ++count;
        }

        outputList.Add(("b", "Back"));
        
        return outputList;
    }
}