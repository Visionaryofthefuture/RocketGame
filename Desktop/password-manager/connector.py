import mysql.connector
from os import getenv
from dotenv import load_dotenv
load_dotenv()

class Database_Connector :
    def __init__(self):
        self.mydb = mysql.connector.connect(
                host = "localhost",
                user = getenv("USERNAME"),
                password = getenv("PASSWORD"),
                database = "MY_PASSWORDS"
        )
        self.mycursor = self.mydb.cursor()
    def make_tables(self) -> bool:
        self.mycursor.execute("SHOW TABLES")
        res = [ x[0] for x in self.mycursor.fetchall()]
        print(res)
        if "USERS" in res and "PSWD" in res: 
            return True
        else:
            self.mycursor.execute(""" CREATE TABLE USERS ( 
            id INT AUTO_INCREMENT PRIMARY KEY,
            Name VARCHAR(200) NOT NULL UNIQUE
            )
        """)
            self.mycursor.execute("""
            CREATE TABLE PSWD(
                id INT AUTO_INCREMENT NOT NULL PRIMARY KEY ,
                Name VARCHAR(200) NOT NULL UNIQUE,
                Password VARCHAR(300) NOT NULL,
                UserId INT ,
                FOREIGN KEY(UserId) REFERENCES USERS(id)
                            )
                            """)
        return False

    def create_user(self, name : str , hashed_pass  : bytes):
    
        self.make_tables()        
        self.mycursor.execute(f"""
            INSERT INTO USERS VALUES ( {name} , {hashed_pass})
                              """)