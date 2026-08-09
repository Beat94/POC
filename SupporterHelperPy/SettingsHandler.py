class SettingsHandler(object):
    def __init___(self, fileLink):
        data = ""
        try:
            with open(fileLink, "r") as file:
                data = json.load(file)

        # https://stackoverflow.com/questions/287871/how-do-i-print-colored-text-to-the-terminal
        except:
            print(f"\033[93m No config file detected link: {link} \033[0m")

            return

        self.devopsLink = data["DevopsLink"]