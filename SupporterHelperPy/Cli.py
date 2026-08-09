from ToolboxCli import ToolboxCli

class Cli(object):
    def __init__(self):
        unused = ""
        self.tbc = ToolboxCli()

    def start(self):
        """
        self.testMenuFunction()
        self.testInputTitle()
        """

    def testMenuFunction(self):
        array = []
        choosen2 = ""

        while (choosen2.lower() != "q"):
            print("CLI Test")
            print("q is quit:")
            choosen2 = ""
            choosen2 = input("> ")
            array.append(choosen2)
        self.tbc.menuSimple(array)

    def testInputTitle(self):
        title = self.tbc.getInput("set Title:", "Title")
        self.tbc.cliTitle(title)
