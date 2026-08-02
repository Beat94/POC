class Bug(object):
    def __init__(self, number, title, state):
        self.number = number
        self.title = title
        self.state = state

    def __repr__(self):
        return f"Bug(id={self.id}, title='{self.title}', status='{self.status}')"