import Ui as interface
from Cli import Cli
from ModuleChecker import ModuleChecker
from ToolboxCli import ToolboxCli
from Models.Ticket import Ticket
from Models.Bug import Bug
from BugHandler import BugHandler

def main():
    moduleChecker = ModuleChecker()
    toolboxCli = ToolboxCli()

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
    commandLine = Cli()

    if(choosen.lower() == "u"):
        #moduleChecker.checkIfModulesInstalled()
        interface.start()
    elif(choosen.lower() == "c"):
        #moduleChecker.checkIfModulesInstalled()
        commandLine.start()
    elif(choosen.lower() == "w"):
        print("Start webinterface")

if __name__ == "__main__":
    main()