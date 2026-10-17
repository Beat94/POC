from dataclasses import dataclass

@dataclass
class Ticket:
    number: str
    title: str
    comment: str
    link: str
    state: str