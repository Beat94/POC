from Models.Settings import Settings
import json
import os

class SettingsHandler(object):
    settings = Settings
    def __init__(self, fileLink: str):
        data = ""
        try:
            with open(fileLink, "r", encoding="utf-8-sig") as file:
                data = json.load(file)
                self.settings = Settings(
                    devopsLink=data.get("devopsLink", ""),
                    dbLink=data.get("dbLink", "")
                )

        # https://stackoverflow.com/questions/287871/how-do-i-print-colored-text-to-the-terminal
        except Exception as exept:
            print(f"\033[93m No config file detected link: {fileLink} \033[0m")
            print(f"Fehlermeldung: {exept}")
            self.settings = Settings(devopsLink="", dbLink="")

    def settingsTest(self):
        print(self.settings.devopsLink)
        print(self.settings.dbLink)

    def getSettings(self) -> Settings:
        return self.settings