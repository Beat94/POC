import Ui as interface
from ModuleChecker import ModuleChecker
from ToolboxCli import ToolboxCli
from Models.Ticket import Ticket
from Models.Bug import Bug
from BugHandler import BugHandler
from pathlib import Path

def main():
    moduleChecker = ModuleChecker()
    toolboxCli = ToolboxCli()

    pathToSettings = Path(__file__).resolve().parent / "Settings.json"

    toolboxCli.cliTitle("Start Menü")
    print("Choose interface:")
    choosen = toolboxCli.menuSimple(["UI","CLI","Webinterface"], "Menu > ", True)

    """
    isCorrect = False
    choosen = None
    while(isCorrect == False):
        choosen = input("UI (u) or CLI (c): ")
    
        if(choosen.lower() == "u" or choosen.lower() == "c"):
            isCorrect = True
    """

    if(choosen.lower() == "u"):
        #moduleChecker.checkIfModulesInstalled()
        #interface.start()
        print("userinterface to fix")
    elif(choosen.lower() == "c"):
        # add module pandas to check
        moduleChecker.registerModule("pandas")
        moduleChecker.checkIfModulesInstalled()

        from Cli import Cli

        commandLine = Cli(pathToSettings)
        commandLine.start()
    elif(choosen.lower() == "w"):
        # ToDo: complete Webinterface-thingy
        # Nicegui
        moduleChecker.registerModule("nicegui")
        moduleChecker.checkIfModulesInstalled()

        from nicegui import ui

        # start here
        print("Start webinterface")

if __name__ == "__main__":
    main()