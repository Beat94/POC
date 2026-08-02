import json
class Settings(object):
    def __init__(self, link):
        data = ""
        with open(link, "r") as file:
            data = json.load(file)

        self.devopsLink = data["DevopsLink"]