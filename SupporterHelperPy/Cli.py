from ToolboxCli import ToolboxCli
from SqliteHandler import SqliteHandler
from Models.Settings import Settings
from SettingsHandler import SettingsHandler
from pathlib import Path

class Cli:
    tbc = ToolboxCli()
    pathToSettings = Path(__file__).resolve().parent / "Settings.json"
    settings = SettingsHandler(str(pathToSettings))
    sqliteHandler = SqliteHandler(settings.getSettings())

    def start(self):
        """
        self.testMenuFunction()
        self.testInputTitle()
        """
        self.mainMenu()

    def mainMenu(self):
        self.tbc.cliTitle("Main Menu")
        mainMenuPoints = [
            'Bug-Menu',
            'Ticket-Menu'
        ]

        mainMenuChoosen = ""

        while mainMenuChoosen != 'q':

            mainMenuChoosen = self.tbc.menuSimple(mainMenuPoints,
                            "Choose Menu > ",
                            True)
            if(mainMenuChoosen == 'b'):
                self.bugMenu()
            elif(mainMenuChoosen == 't'):
                self.ticketMenu()

    def bugMenu(self):
        print("Bug Menü")

    def ticketMenu(self):
        print("Ticket Menu")

    def testMenuFunction(self):
        array = []
        choosen2 = ""

        while (choosen2.lower() != "q"):
            print("CLI Test")
            print("q is quit:")
            choosen2 = ""
            choosen2 = input("> ")
            if not choosen2.lower() == "q":
                array.append(choosen2)
        self.tbc.menuSimple(array,"", True)

    def testInputTitle(self):
        title = self.tbc.getInput("set Title:", "Title")
        self.tbc.cliTitle(title)
