class ToolboxCli(object):
    def menuSimple(self, menuPoints):
        isCorrect = False
        print(self.menuLine(["cmd", "Menu Point"]))

        while(isCorrect == False):
            for point in menuPoints:
                print(self.menuLine([point[0], point]))
            isCorrect = True

    def menuLine(self, cellInLine: [str]) -> str:
        line = ""
        for cell in cellInLine:
            line += cell + "\t"
        return line

    def cliTitle(self, title: str):
        i = 0
        line = ""
        while(len(title) + 2 > i):
            line += "-"
            i = i + 1
        print(line)
        print(" " + title)
        print(line)

    def getInput(self, question, inputCommand):
        if(question != None):
            print(question)

        if(inputCommand == None):
            inputCommand2 = " "

        else:
            inputCommand2 = inputCommand + " "

        return input(inputCommand2)