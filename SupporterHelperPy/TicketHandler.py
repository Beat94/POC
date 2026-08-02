from Models.Ticket import Ticket
from Models.Settings import Settings

class TicketHandler (object):
    def __init__ (self, settings):
        self.ticketList = []
        self.settings = settings

    def addTicket (self, ticket):
        if(isinstance(ticket, Ticket)):
            self.ticketList.append(ticket)
        else:
            ticketObject = Ticket(ticket[0], ticket[1], ticket[2])
            self.ticketList.append(ticketObject)

    def getTicketList (self):
        output = []
        for ticketObject in self.ticketList:
            output.append((ticketObject.number, ticketObject.link, ticketObject.state))
        return output