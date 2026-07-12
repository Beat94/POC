import importlib.util
import subprocess
import sys

def checkIfInstalled():
    module_name = "sqlite3"
    module_spec =  importlib.util.find_spec(module_name)

    if module_spec is None:
        subprocess.check_call([sys.executable, "-m", "pip", "install", module_name])
    importlib.import_module(module_name)