from pkg_resources import non_empty_lines
from TicketHandler import TicketHandler
from ToolboxCli import ToolboxCli
from SqliteHandler import SqliteHandler
from Models.Settings import Settings
from SettingsHandler import SettingsHandler
from pathlib import Path
from Models.Ticket import Ticket
import pandas as pd

class Cli:
    tbc = ToolboxCli()
    #pathToSettings = Path(__file__).resolve().parent / "Settings.json"
    pathToSettings: str
    settings: SettingsHandler
    sqliteHandler: SqliteHandler
    ticketHanlder: TicketHandler

    def __init__(self, pathToSettingsParam: str):
        self.pathToSettings = pathToSettingsParam
        self.settings = SettingsHandler(str(self.pathToSettings))
        self.sqliteHandler = SqliteHandler(self.settings.getSettings())
        self.ticketHandler = TicketHandler(self.settings)

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

        print("Goodbye :-)")

    def bugMenu(self):
        bugMenuChoosen = ""
        bugMenuArray = [
            "View",
            "Edit",
            "New"
        ]

        while bugMenuChoosen != "q":
            self.tbc.cliTitle("Bug Menü")
            bugMenuChoosen = self.tbc.menuSimple(bugMenuArray,
                                                 "Choose Bug Menü > ",
                                                 True)
            if bugMenuChoosen == "v":
                self.bugView()
            if bugMenuChoosen == "e":
                self.bugEdit()
            if bugMenuChoosen == "n":
                self.bugNew()

    # ToDo - implementation
    def bugView(self):
        None

    # ToDo - implementation
    def bugEdit(self):
        None

    # ToDo - implementation
    def bugNew(self):
        None

    def ticketMenu(self):
        ticketMenuChoosen = ""
        ticketMenuList = ["List", "Edit", "Create"]

        while ticketMenuChoosen != "q":
            self.tbc.cliTitle("Ticket Menü")
            ticketMenuChoosen = self.tbc.menuSimple(ticketMenuList,
                                                   "Choose TickMenu > ",
                                                   True)

            # ToDo - functions
            if ticketMenuChoosen == "l":
                print("List Tickets")
                self.ticketView()
            elif ticketMenuChoosen == "e":
                print("Edit Tickets")
                self.ticketEdit()
            elif ticketMenuChoosen == "c":
                print("Create Tickets")
                self.ticketCreate()
        print("Ticket Menu")

    def ticketView(self):
        self.tbc.cliTitle("View Tickets")
        ticketList = [Ticket]
        ticketList = self.ticketHandler.getTicketList()
        df = pd.DataFrame([vars(t) for t in ticketList])
        print(df)


    def ticketEdit(self):
        None
        """
            ToDo: Load tickets
            create Menu according to ticket
            choose ticket
            load data
            edit data
            write it to db
            reload tickets
        """


    def ticketCreate(self):
        self.tbc.cliTitle("Create Ticket")
        ticketNew: Ticket

        ticketNew.number = self.tbc.getInput(None,"Ticket-Number: ")
        ticketNew.title = self.tbc.getInput(None, "Ticket-Titel: ")
        ticketNew.comment = self.tbc.getInput(None, "Kommentar: ")
        ticketNew.link = self.tbc.getInput(None, "Link: ")
        ticketNew.state = self.ticketState()

        self.ticketHandler.addTicket(ticketNew)

    def ticketState(self) -> str:
        outputState: str

        ticketState = [
            "New",
            "InProgress",
            "Done"
        ]

        choosenState = self.tbc.menuSimple(ticketState, "Ticket-State: ", False)

        if(choosenState == "n"):
            outputState = ticketState[0]
        elif(choosenState == "i"):
            outputState = ticketState[1]
        elif(choosenState == "d"):
            outputState = ticketState[2]

        return outputState

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
