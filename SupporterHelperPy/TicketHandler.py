from Models.Ticket import Ticket
from Models.Settings import Settings
from SqliteHandler import SqliteHandler

class TicketHandler (object):
    ticketList = []
    settings: Settings
    sqliteHandler: SqliteHandler

    def __init__ (self, settings: Settings):
        self.settings = settings
        self.sqliteHandler = SqliteHandler(self.settings.getSettings())

    def addTicket (self, ticket: Ticket):
        if(isinstance(ticket, Ticket)):
            self.ticketList.append(ticket)
            self.sqliteHandler.writeTicket(ticket)
        else:
            ticketObject = Ticket(ticket[0], ticket[1], ticket[2])
            self.ticketList.append(ticketObject)
            self.sqliteHandler.writeTicket(ticketObject)

        self.refreshTickets()

    def editTicket (self, ticket: Ticket, ticketId: int):
        print("edit Tickets")
        self.refreshTickets()
        self.sqliteHandler.editTicket(ticket, ticketId)
        self.refreshTickets()


    def refreshTickets(self):
        self.ticketList = self.sqliteHandler.getTicketList()

    def getTicketList (self) -> [Ticket]:
        output = []
        self.refreshTickets()
        for ticketObject in self.ticketList:
            output.append((ticketObject.number, ticketObject.link, ticketObject.state))
        return output