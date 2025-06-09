from cryptography.fernet import Fernet
class Encrypter:
    def __init__(self):
        self.key = Fernet.generate_key()
        self.fernet = Fernet(self.key)
    
    def encrypt_password(self , pswd1: str) -> bytes:
        return self.fernet.encrypt(pswd1.encode())

    def decrypt_password(self, enc_pswd: bytes) -> str:
        return self.fernet.decrypt(enc_pswd).decode()
