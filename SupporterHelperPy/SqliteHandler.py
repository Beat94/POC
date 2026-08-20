import importlib.util
import subprocess
import sys
import sqlite3
from Models.Settings import Settings

class SqliteHandler:
    createTblTickets = ("create table if not exists tbl_Tickets "
                             "(id Integer primary key id_Tickets, "
                             "text Ticket_Number, "
                             "text Ticket_Title, "
                             "text Ticket_Comment,"
                             "text Ticket_Link)")
    dbname = None
    dbLink = None
    settings = Settings

    def __init__(self, settings: Settings):
        self.settings = settings
        self.dbLink = settings.dbLink


    def checkIfInstalled(self):
        module_name = "sqlite3"
        module_spec =  importlib.util.find_spec(module_name)

        if module_spec is None:
            subprocess.check_call([sys.executable, "-m", "pip", "install", module_name])
        importlib.import_module(module_name)



    def checkIfTablesExists(self):
        with sqlite3.connect(self.settings) as f:
            print("ToDel")