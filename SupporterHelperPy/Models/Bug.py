from dataclasses import dataclass

@dataclass
class Bug:
    number: str
    title: str
    state: str

    def __repr__(cls):
        return f"Bug(id={cls.id}, title='{cls.title}', status='{cls.status}')"