import importlib.util
import subprocess
import sys
import sqlite3

class SqliteHandler:
    def __init__(self, settings):
        self.dbname = ""
        self.settings = settings

    def checkIfInstalled(self):
        module_name = "sqlite3"
        module_spec =  importlib.util.find_spec(module_name)

        if module_spec is None:
            subprocess.check_call([sys.executable, "-m", "pip", "install", module_name])
        importlib.import_module(module_name)

    def checkIfTablesExists(self):
        print("Test")