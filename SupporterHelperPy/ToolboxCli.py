class ToolboxCli(object):
    def menuSimple(self,
                   menuPoints: [str],
                   inLineMessage: str,
                   hasQuitOption: bool) -> str:
        isCorrect = False
        menuCommandArray = []
        menuArray = []
        output = None
        userInput = None

        for menuPoint in menuPoints:
            menuArray.append(menuPoint)

        if(hasQuitOption):
            menuArray.append("Quit")

        print(self.menuLine(["cmd", "Menu Point"]))

        for point in menuArray:
            menuCommandArray.append(point[0].lower())

        while(isCorrect == False):
            for point in menuArray:
                print(self.menuLine([point[0].lower(), point]))

            userInput = input(inLineMessage).lower()

            for command in menuCommandArray:
                if(command == userInput):
                    isCorrect = True

        output = userInput

        return output

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