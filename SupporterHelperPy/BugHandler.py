from Models.Bug import Bug
from Models.Settings import Settings

class BugHandler (object):
    def __init__(self, settings):
        self.bugList = []
        self.settings = settings

    def addBug(self, bug):
        if(isinstance(bug, Bug)):
            self.bugList.append(bug)
        else:
            bugObject = Bug(bug[0], bug[1], bug[2])
            self.bugList.append(bugObject)

    def getBugList(self):
        output = []
        for bugObject in self.bugList:
            output.append((bugObject.number, bugObject.title, bugObject.state))
        return output

    def getRawBugList(self):
        return self.bugList

    def updateBugsInList(self):
        if(isinstance(self.settings, Settings) and self.settings.devopsLink is not None):
            for bug in self.bugList:
                """
                call link and workitem of azure devops and update state of bug
                """
