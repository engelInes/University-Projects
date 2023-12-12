from Domain.domain import Sentence

class UI:
    @staticmethod
    def print_menu():
        print("Choose your option: ")
        print("1. Add a sentence")
        print("2. Play Hangman")
        print("3. Exit the game")

    @staticmethod #we have to use staticmethod, otherwise it command will be interpreted as self
    def valid_commands(command):
        available_commands=["1","2","3"]
        return command in available_commands

    def add_sentence(self):
        prop=Sentence()
        ok=False
        while ok==False:
            new_sentence=input("Enter a sentence with minimum 1 word with at least 3 letters:")
            new_sentence.strip()
            cnt=0
            #checking whether the input is correct
            for i in new_sentence:
                if i==" ":
                    cnt=cnt+1
            if cnt<1:
                print("Not enough words")
            else:
                ok_letters=True
                cnt=0
                for i in new_sentence:
                    if i!=" ":
                        cnt=cnt+1
                    else:
                        if cnt<3:
                            print("One of the words doesn't have at least 3 letters")
                            ok_letters=False
                            break
                        else:
                            cnt=0
                if cnt<3:
                    print("One of the words doesn't have at least 3 letters")
                    ok_letters=False
                if ok_letters==True:
                    prop.set_sentence(new_sentence)
                    if prop.write_to_file("C:\Users\Ines\PycharmProjects\pythonProject19\Hangman.txt")==True:
                        ok=True
                    else:
                        print("Sentence already exists")

    def play_game(self):
        prop=Sentence()
        prop.read_from_file("C:\Users\Ines\PycharmProjects\pythonProject19\Hangman.txt")
        letters=[] #a list only with the letters from the sentence
        letters.append(prop.sentence[0])
        for i in range(len(prop.sentence)):
            if prop.sentence[i]==" ":
                letters.append(prop.sentence[i-1])
                letters.append(prop.sentence[i+1])
        letters.append(prop.sentence[-1])
        letters.append(" ")

        new_string=""
        cnt=0
        #creating the empty list with _
        for i in range(len(prop.sentence)):
            if prop.sentence[i] not in letters:
                new_string=new_string+"_"
                cnt=cnt+1
            else:
                new_string=new_string+prop.sentence[i]
        initial_hng="hangman"
        k=0
        final_hng=""
        used_characters=[]
        while cnt>0 and final_hng!=initial_hng:
            print(new_string+"-"+final_hng)
            character=input("Choose a letter: ")
            if character in used_characters:
                print("Letter has already been used")
            if character not in prop.sentence:
                k=k+1
                final_hng=initial_hng[0:k]
            else:
                string2=""
                for i in range(len(prop.sentence)):
                    if prop.sentence==character:
                        string2=string2+character
                        cnt=cnt-1
                    else:
                        string2=string2+new_string[i]
                new_string=string2
            used_characters.append(character)
        if final_hng==initial_hng:
            print(new_string+"-"+final_hng)
            print("Game over! You lost")

        if cnt==0:
            print(new_string+"-"+final_hng)
            print("Game over! You won")

    def menu(self):
        options={"1":self.add_sentence(),"2":self.play_game()}
        while True:
            UI.print_menu()
            option=input("Choose an option: ")
            while not UI.valid_commands(option):
                option=input("Enter a valid command")
            if option=="3":
                break
            options[option]()

if __name__=="__main__":
    ui=UI()
    ui.menu()



