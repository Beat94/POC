using System.Text.Json;

public class CliHelper
{
   private MenuPoints menuPoints = new();
   private BusinessCaseMaster businessCaseMaster;
   private string path;
   
   public void Start()
   {
      Console.WriteLine("SupportHelper started - Welcome");
      string mainMenuChoosen = string.Empty;
      while (!mainMenuChoosen.Equals("x", StringComparison.InvariantCultureIgnoreCase))
      {
         mainMenuChoosen = Toolset.Menu("Main Menu", "Main", menuPoints.mainMenuPoints);
            
         if (mainMenuChoosen.Equals("n", StringComparison.InvariantCultureIgnoreCase))
         {
            MainMenuNew();
            MenuSecond();
         }
         else if (mainMenuChoosen.Equals("l", StringComparison.InvariantCultureIgnoreCase))
         {
            MainMenuLoad();
            MenuSecond();
         }
         else if (mainMenuChoosen.Equals("s", StringComparison.InvariantCultureIgnoreCase))
         {
            MainMenuSave();
            MenuSecond();
         }
      }
   }

   private void MainMenuNew()
   {
      businessCaseMaster = new();
   }

   private void MainMenuLoad()
   {
      bool isCorrect = false;
      string userInput = String.Empty;
      string input = String.Empty;
      
      while (!userInput.Equals("x", StringComparison.InvariantCultureIgnoreCase)
             || !isCorrect)
      {
         Console.Write("Enter loading path (or quit x): ");
         
         try
         {
            userInput = Console.ReadLine();
            input = File.ReadAllText(userInput);
         }
         catch (Exception e)
         {
            Console.WriteLine("File not found. Please try again - exception:");
            Console.WriteLine(e);
         }

         try
         {
            businessCaseMaster = JsonSerializer.Deserialize<BusinessCaseMaster>(input);
            isCorrect = true;
         }
         catch (Exception e)
         {
            Console.WriteLine("Wrong json-format. Please try another one - exception:");
            Console.WriteLine(e);
         }
      }
   }

   private void MainMenuSave()
   {

      if (businessCaseMaster == null)
      {
         businessCaseMaster = new();
      }
      
      string output = JsonSerializer.Serialize(businessCaseMaster);
      bool isEntryTrue = false;
      string path = string.Empty;
      
      while (!isEntryTrue 
             && !path.Equals(("q", StringComparison.InvariantCultureIgnoreCase)))
      {
         try
         {
            Console.Write("Enter saving path (q for quit saving action): ");
            path = Console.ReadLine();
            File.WriteAllText(path, output);
            isEntryTrue = true;
         }
         catch (Exception e)
         {
            Console.WriteLine("Wrong Entry - try again. Exception:");
            Console.WriteLine(e);
         }
      }
      
   }

   private void MenuSecond()
   {
      string menuChoosen = string.Empty;
      while (!menuChoosen.Equals("b", StringComparison.InvariantCultureIgnoreCase))
      {
         menuChoosen = Toolset.Menu("Menu", "Menu", menuPoints.steeringMenuPoints);

         if (menuChoosen.Equals("e", StringComparison.InvariantCultureIgnoreCase))
         {
            // variable businessCaseMaster
            
            // BusinessCase -> Topic -> Solution
            
            /*
             * Logic each leevel:
             * if there is no value go to creation-mode.
             * else let user choose with edit menu
             *    if edit is choosen - use CreatMenu
             *    if new is choosen - then the user can instantly type the name of the level and save it
             */
            
            throw new NotImplementedException();
         }
         else if (menuChoosen.Equals("s", StringComparison.InvariantCultureIgnoreCase))
         {
            GoThroughDatamodel();
         }
      }
   }

   private void GoThroughDatamodel()
   {
      string result = string.Empty;
      string resultBusinessCase = string.Empty;
      
      BusinessCase businessCase;
      Topic topic;
      
      while (!result.Equals(("b", StringComparison.InvariantCultureIgnoreCase)))
      {
         result = Toolset.Menu("Search Solution", "Search", businessCaseMaster.CreateMenu());
         businessCase = businessCaseMaster.businessCaseList[Int32.Parse(result)];

         while (resultBusinessCase.Equals("b", StringComparison.InvariantCultureIgnoreCase))
         {
            resultBusinessCase = Toolset.Menu("Search Solution", "Search", businessCase.CreateMenu());
            topic = businessCase.topics[Int32.Parse(resultBusinessCase)];
            SolutionMaster(topic);
         }
      }
   }

   private void SolutionMaster(Topic topic)
   {
      string result = string.Empty;
      int pointer = 0;
      int maxPointer = topic.solutions.Count;
      
      while (
         result.Equals("y", StringComparison.InvariantCultureIgnoreCase) 
         && result.Equals("b", StringComparison.InvariantCultureIgnoreCase)
         && maxPointer >= pointer)
      {
         Console.WriteLine($"Solution {pointer}: {topic.solutions[pointer]}");
         Console.Write("Did it helped? (y/n or b for back): ");
         result = Console.ReadLine();

         if (result.Equals("n", StringComparison.InvariantCultureIgnoreCase))
         {
            ++pointer;
         }
      }
   }

   /// <summary>
   /// Checks if path is set or not - if it is not set then it will get the information from the user
   /// </summary>
   /// <param name="cliCommand">String which will be shown on userquestion</param>
   /// <returns>set path in class or path from userentry</returns>
   private string GetPath(string cliCommand)
   {
      if(string.IsNullOrEmpty(path))
      {
         Console.Write($"{cliCommand}: ");
         path = Console.ReadLine();
      }
      
      return path;
   }
}