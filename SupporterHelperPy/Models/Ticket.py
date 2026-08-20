from dataclasses import dataclass

@dataclass
class Ticket:
    number: str
    link: str
    state: str