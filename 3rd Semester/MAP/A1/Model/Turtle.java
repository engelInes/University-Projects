package Model;

public class Turtle implements InterfaceAnimal{
    private int animalAge;

    public Turtle(int age) {
        animalAge = age;
    }

    @Override
    public int getAge() {
        return animalAge;
    }

    @Override
    public String toString() {
        return "Turtle of age: " + animalAge;
    }

}
