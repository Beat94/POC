import tkinter as tk
from tkinter import *
from tkinter import ttk
import UiFunc as uf

def start():
    # 1. Hauptfenster erstellen
    root = tk.Tk()
    root.geometry("300x200")
    root.title("SupportHelper")

    menu = Menu(root)
    root.config(menu=menu)

    filemenu = tk.Menu(menu)
    menu.add_cascade(label="File", menu=filemenu)
    filemenu.add_command(label="Neu")

    editmenu = tk.Menu(menu)
    menu.add_cascade(label="Edit", menu=editmenu)
    editmenu.add_command(label="Settings", command=uf.printfn())

    # 2. Notebook (Registerkarten-Manager) erstellen
    notebook = ttk.Notebook(root)
    notebook.pack(fill='both', expand=True)
    
    # 3. Frames (Inhalte für die Tabs) erstellen
    tab1 = ttk.Frame(notebook)
    tab2 = ttk.Frame(notebook)

    # 4. Tabs zum Notebook hinzufügen
    notebook.add(tab1, text='Startseite')
    notebook.add(tab2, text='Einstellungen')
    
    # 5. Elemente zu Tab 1 hinzufügen
    label1 = ttk.Label(tab1, text="Das ist Tab 1!")
    label1.pack(padx=10, pady=10)
    
    # 6. Elemente zu Tab 2 hinzufügen
    label2 = ttk.Label(tab2, text="Das ist Tab 2!")
    label2.pack(padx=10, pady=10)
    
    # App starten
    root.mainloop()