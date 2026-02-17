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
            caracterFixed = string.Empty;
            countNow = menuPoint.character.Length;
            
            if (countNow < maxCount)
            {
                for (int i = 0; i <= maxCount - countNow; i++)
                {
                    caracterFixed += " ";
                }
            }
            
            caracterFixed += menuPoint.character;
            consoleMenu += $"{caracterFixed}\t{menuPoint.menuDesc}\n";
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
    
    public static string Menu(
        string menuTitle, 
        string lineString, 
        List<string> menuPoints, 
        bool? isEditMode = false)
    => Menu(menuTitle, lineString, CreateMenuOfSingleList(menuPoints,false));

    // Hier wird ein Menü erstellt, das direkt eine fertige Liste von Tupel an Menu-Funktionalität übergibt
    /// <summary>
    /// Creates a menu which passes a finished menu to menu-functionality
    /// </summary>
    /// <param name="menuTitle">Title of menu</param>
    /// <param name="lineString">String which is added before readline</param>
    /// <param name="menuPoints">List of menu points</param>
    /// <returns>a string according menu for further actions</returns>
    public static string MenuCreation(string menuTitle, string lineString, List<string> menuPoints, bool deleteToo)
    {
        List<(string, string)> menuPointList = CreateMenuOfSingleList(menuPoints,deleteToo );
        
        menuPointList.Insert(menuPointList.Count - 1, ("n", "new Item"));
        
        return Menu(menuTitle, lineString, menuPointList);
    }

    private static List<(string, string)> CreateMenuOfSingleList(List<string> singleList, bool deleteToo)
    {
        List<(string, string)> outputList = new();
        int count = 0;
        
        foreach (string item in singleList)
        {
            outputList.Add((String.Concat(count.ToString()),item));
            ++count;
        }

        if (deleteToo)
        {
            outputList.Add(("d", "Delete"));
        }

        outputList.Add(("b", "Back"));
        
        return outputList;
    }

    public static string getInfosFromUser(string userMessage)
    {
        Console.Write(userMessage);
        return Console.ReadLine();
    }
    
}