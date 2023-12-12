from random import randint

class Sentence:
    def read_from_file(self, file_name):
        with open(file_name, "r") as f:
            lines=f.readlines()
            random_sentence=randint(0, len(lines)-1)
            self.sentence=lines[random_sentence] #choosing a random sentence from the file
            self.sentence=self.sentence.strip("\n")
        f.close()

    def write_to_file(self, file_name):
        with open(file_name,"r") as f:
            lines=f.readlines()

        with open(file_name, "w") as f:
            ok=True
            for line in lines:
                if line.strip("\n")==self.sentence:
                    ok=False
                f.write(line)
            if ok==False:#if there are no more sentences to write in the file
                f.close()
                return False
            f.write(self.sentence)
            f.write("\n")
        f.close()
        return True

    def set_sentence(self, new_sentence):
        self.sentence=new_sentence

