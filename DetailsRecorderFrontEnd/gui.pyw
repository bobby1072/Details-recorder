from LogCLass import *
import tkinter as tk
import urllib3
urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
def gui() -> tk.Tk:
    window = tk.Tk()
    window.geometry("")
    window.title("People logger")
    tk.Label(
        window,
        text="Name:"
    ).grid(row=0, sticky="w")
    NameEnt = tk.Entry(window)
    NameEnt.grid(row=0, column=1, sticky="w")
    tk.Label(
        window,
        text="Date of birth:"
    ).grid(row=1, sticky="w")
    DOBEnt = tk.Entry(window)
    DOBEnt.grid(row=1, column=1, sticky="w")
    def clear():
        NameEnt.delete(0, tk.END)
        DOBEnt.delete(0, tk.END)
    def LogButton():
        name = NameEnt.get()
        dob = DOBEnt.get()
        record = PersonLog(name,dob)
        record.submit()
        clear()
    def ShowAllButton():
        allRecords = ShowAll()
        i = 1
        for items in allRecords.allRecs:
            displayName = f"Name: {items['name']}"
            displayAge = f"Date of birth: {items['dob']}"
            tk.Label(window, text = displayName).grid(row = 3 +i)
            i =i + i
            tk.Label(window, text=displayAge).grid(row=3+ i)
            i = i + i
    tk.Button(text = "Display All", command=ShowAllButton).grid(row = 2, column = 0, sticky = "w")
    tk.Button(window, text = "Log Record", command = LogButton).grid(row = 2, column = 1, sticky="w")
    return window
if __name__ == "__main__":
    master = gui()
    master.mainloop()
