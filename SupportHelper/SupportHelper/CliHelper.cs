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
      while (!menuChoosen.Equals("b", StringComparison.OrdinalIgnoreCase))
      {
         menuChoosen = Toolset.Menu("Main Administration", "Menu", menuPoints.steeringMenuPoints);

         if (menuChoosen.Equals("e", StringComparison.OrdinalIgnoreCase))
         {
            // Sicherstellen, dass der Master existiert
            if (businessCaseMaster == null) businessCaseMaster = new();
            
            // Starte die rekursive Verwaltung
            ManageCaseLevel(businessCaseMaster, "Main Administration View");
         }
         else if (menuChoosen.Equals("s", StringComparison.OrdinalIgnoreCase))
         {
            if (businessCaseMaster != null && businessCaseMaster.businessCaseList.Count > 0)
            {
               GoThroughDatamodel();
            }
            else
            {
               Console.WriteLine("No data available to search. Please create or load data first.");
            }
         }
      }
   }
   
   private void ManageCaseLevel(ICase current, string title)
   {
      string choice = string.Empty;
      while (!choice.Equals("b", StringComparison.OrdinalIgnoreCase))
      {
         // Wenn die Liste leer ist, zwingen wir den User fast in den Creation-Mode ("n")
         var currentMenu = current.CreateMenu();
         choice = Toolset.MenuCreation(title, "Action (n:New, d:Delete, b:Back, Index:Open)", currentMenu, true);

         switch (choice.ToLower())
         {
            case "b": 
               return;

            case "n":
               HandleCreation(current);
               break;

            case "d":
               HandleDeletion(current);
               break;

            default:
               if (int.TryParse(choice, out int pointer))
               {
                  object next = current.getObject(pointer);

                  if (next is ICase subCase)
                  {
                     // REKURSION: Wir gehen eine Ebene tiefer
                     ManageCaseLevel(subCase, subCase.GetName());
                  }
                  else
                  {
                     // SACKGASSE: Es ist ein String (Solution)
                     Console.WriteLine($"\n--- SOLUTION DETAIL ---\n{next}\n-----------------------");
                     Console.WriteLine("Press any key to return...");
                     Console.ReadKey();
                  }
               }
               break;
         }
      }
   }
   
   private void HandleCreation(ICase current)
   {
      // Die Fabrik-Methode aus dem Interface nutzen!
      object newItem = current.CreateNewChild();

      if (newItem is ICase complex)
      {
         string name = Toolset.getInfosFromUser("Name for new entry: ");
         complex.SetName(name);
         current.AddPoint(complex);
      }
      else
      {
         // Es ist eine Solution (String)
         string content = Toolset.getInfosFromUser("Enter Solution text: ");
         current.AddPoint(content);
      }
      Console.WriteLine("Saved successfully.");
   }

   private void HandleDeletion(ICase current)
   {
      var menu = current.CreateMenu();
      if (menu.Count == 0) return;

      string delIdx = Toolset.MenuCreation("Delete Mode", "Index to delete:", menu, false);
      if (int.TryParse(delIdx, out int ptr) && ptr >= 0 && ptr < menu.Count)
      {
         string confirm = Toolset.Menu($"Really delete '{menu[ptr]} '?", "Confirm", menuPoints.menuYesNo);
         if (confirm.Equals("y", StringComparison.OrdinalIgnoreCase))
         {
            current.DelAtPoint(ptr);
         }
      }
   }

   private void GoThroughDatamodel()
   {
      string result = string.Empty;
    
      while (!result.Equals("b", StringComparison.OrdinalIgnoreCase))
      {
         var menu = businessCaseMaster.CreateMenu();
         if (menu.Count == 0) {
            Console.WriteLine("Keine BusinessCases vorhanden.");
            return;
         }

         result = Toolset.Menu("Search Solution", "Choose BusinessCase", menu);
         if (result.Equals("b", StringComparison.OrdinalIgnoreCase)) break;

         if (int.TryParse(result, out int bcIndex) && bcIndex < businessCaseMaster.businessCaseList.Count)
         {
            var bCase = businessCaseMaster.businessCaseList[bcIndex];
            SearchTopic(bCase);
         }
      }
   }

   private void SearchTopic(BusinessCase bCase)
   {
      string result = string.Empty;
      while (!result.Equals("b", StringComparison.OrdinalIgnoreCase))
      {
         var menu = bCase.CreateMenu();
         result = Toolset.Menu("Search Topic", "Choose Topic", menu);
         if (result.Equals("b", StringComparison.OrdinalIgnoreCase)) break;

         if (int.TryParse(result, out int tIndex) && tIndex < bCase.topics.Count)
         {
            SolutionMaster(bCase.topics[tIndex]);
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