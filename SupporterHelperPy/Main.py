import Ui as interface
import Cli as commandLine
from Models.Ticket import Ticket
from Models.Bug import Bug
from BugHandler import BugHandler

"""
print("Hello World")
t1 = ti("123", "http://www.google.ch", "running")
print(t1.number + " " + t1.link + " " + t1.state)
t1.number = "187"
print(t1.number + " " + t1.link + " " + t1.state)

bugHandler = BugHandler(None)
print(bugHandler.bugList)

bög = Bug(123, "Bug Title", "Done")
bugHandler.addBug(bög)
bugList = bugHandler.getBugList()

print(bugList)
for object in bugList:
    print(object[1])
    print(object)

bugHandler.addBug("Bug")
print(bugHandler.getList())
bug1 = Bug(123, "bugtitle", "in Progess")
bugHandler.addBug(bug1)
print(bugHandler.getList())

#print(bugHandler.getRawBugList())
"""
isCorrect = False
choosen = None
while(isCorrect == False):
    choosen = input("UI (u) or CLI (c): ")

    if(choosen.lower() == "u" or choosen.lower() == "c"):
        isCorrect = True

if(choosen.lower() == "u"):
    interface.start()
else:
    commandLine.start()