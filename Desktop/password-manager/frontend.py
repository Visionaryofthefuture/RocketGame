from tkinter import *
from hashing import Encrypter  
from connector import Database_Connector
enc = Encrypter()
root = Tk()
Database_conn = Database_Connector()


root.title("Password Manager")
w = Label(root, text="My Password Manager")
w.pack()
is_create_mode = True

container2 = Frame(master=root)
container2.pack()

Label(master=container2, text='First Name').grid(row=0)
Label(master=container2, text='Last Name').grid(row=1)

e1 = Entry(master=container2)
e2 = Entry(master=container2)
e1.grid(row=0, column=1)
e2.grid(row=1, column=1)

# Function to toggle between Create User and Sign In
def toggle_mode():
    global is_create_mode
    if is_create_mode:
        make_user.config(text="Sign In", command=sign_in)
    else:
        make_user.config(text="Create User", command=create_user)
    is_create_mode = not is_create_mode

def create_user():
    try:
        print("Creating user:", e1.get(), e2.get())
        if( len(e1.get()) == 0 or len(e2.get()) == 0 ):
            raise ValueError("Empty Fields")
        hashed_pass  = enc.encrypt_password(e2.get())

    except {ValueError, OSError, RuntimeError} as e:
        print(E)


        return    
    
    toggle_mode()

def sign_in():
    print("Signing in:", e1.get(), e2.get())
    toggle_mode()

make_user = Button(root, text="Create User", width=25, command=create_user)
close = Button(root, text="Close Application", width=25, command=root.destroy)

make_user.pack()
close.pack()

root.mainloop()
