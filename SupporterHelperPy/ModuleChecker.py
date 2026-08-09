import importlib.util
import subprocess
import sys

class ModuleChecker(object):
    modules = ["sqlite3"]

    def registerModule(self, module: str):
        moduleExists = False
        for moduleInList in self.modules:
            if(moduleInList == module):
                moduleExists = True

        if(not moduleExists):
            self.modules.append(module)

    def checkIfModulesInstalled(self):
        for module_name in self.modules:
            module_spec = importlib.util.find_spec(module_name)

            if module_spec is None:
                subprocess.check_call([sys.executable, "-m", "pip", "install", module_name])
