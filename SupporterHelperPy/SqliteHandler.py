import sqlite3
from Models.Settings import Settings
from Models.Ticket import Ticket

class SqliteHandler:
    createTblTickets = """
        CREATE TABLE IF NOT EXISTS tbl_Tickets (
            id_Tickets INTEGER PRIMARY KEY AUTOINCREMENT,
            Ticket_Number TEXT,
            Ticket_Title TEXT,
            Ticket_Comment TEXT,
            Ticket_Link TEXT,
            Ticket_State TEXT
        )
    """

    def __init__(self, settings: Settings):
        self.settings = settings
        self.dbLink = settings.dbLink

        with sqlite3.connect(self.dbLink) as dbConnection:
            dbConnection.execute(self.createTblTickets)
            dbConnection.commit()

    def _get_connection(self) -> sqlite3.Connection:
        """Hilfsmethode: Stellt sicher, dass Spaltennamen als Keys nutzbar sind."""
        connection = sqlite3.connect(self.dbLink)
        connection.row_factory = sqlite3.Row
        return connection

    def writeTicket(self, ticket: Ticket) -> int:
        ticket_data = (
            ticket.number,
            ticket.title,
            ticket.comment,
            ticket.link,
            ticket.state
        )

        with self._get_connection() as dbConnection:
            cursor = dbConnection.cursor()
            cursor.execute(
                """
                    INSERT INTO tbl_Tickets (Ticket_Number, Ticket_Title, Ticket_Comment, Ticket_Link, Ticket_State) 
                    VALUES (?, ?, ?, ?, ?)
                """,
                ticket_data,
            )
            dbConnection.commit()

            return cursor.lastrowid

    def getSpecificTicket(self, id: int):
        with self._get_connection() as dbConnection:
            cursor = dbConnection.cursor()
            cursor.execute(
                "SELECT * FROM tbl_Tickets WHERE id_Tickets = ?",
                (id,)
            )
            queryResult = cursor.fetchone()

        if not queryResult:
            return None

        return Ticket(
            number=queryResult["Ticket_Number"].strip() if queryResult["Ticket_Number"] else "",
            title=queryResult["Ticket_Title"].strip() if queryResult["Ticket_Title"] else "",
            comment=queryResult["Ticket_Comment"].strip() if queryResult["Ticket_Comment"] else "",
            link=queryResult["Ticket_Link"].strip() if queryResult["Ticket_Link"] else "",
            state=queryResult["Ticket_State"].strip() if queryResult["Ticket_State"] else ""
        )

    def editTicket(self, ticket: Ticket, id: int) -> bool:
        functionTuple = (
            ticket.number,
            ticket.title,
            ticket.comment,
            ticket.link,
            ticket.state,
            id
        )

        with self._get_connection() as dbConnection:
            cursor = dbConnection.execute(
                """
                    UPDATE tbl_Tickets
                    SET Ticket_Number = ?,
                        Ticket_Title = ?,
                        Ticket_Comment = ?,
                        Ticket_Link = ?,
                        Ticket_State = ?
                    WHERE id_Tickets = ?
                """,
                functionTuple
            )
            dbConnection.commit()
            return cursor.rowcount > 0

    def deleteTicket(self, id: int) -> bool:
        with self._get_connection() as dbConnection:
            cursor = dbConnection.execute(
                "DELETE FROM tbl_Tickets WHERE id_Tickets = ?",
                (id,)
            )
            dbConnection.commit()
            return cursor.rowcount > 0

    def getTicketList(self) -> [Ticket]:
        output = []
        with self._get_connection() as dbConnection:
            result = dbConnection.execute("SELECT * FROM tbl_Tickets").fetchall()

        for line in result:
            output.append(
                Ticket(
                    number=line["Ticket_Number"].strip() if line["Ticket_Number"] else "",
                    title=line["Ticket_Title"].strip() if line["Ticket_Title"] else "",
                    comment=line["Ticket_Comment"].strip() if line["Ticket_Comment"] else "",
                    link=line["Ticket_Link"].strip() if line["Ticket_Link"] else "",
                    state=line["Ticket_State"].strip() if line["Ticket_State"] else ""
                )
            )

        return output