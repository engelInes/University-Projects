package Model;

public class Fish implements InterfaceAnimal{
    private int animalAge;

    public Fish(int age) {
        animalAge = age;
    }

    @Override
    public int getAge() {
        return animalAge;
    }

    @Override
    public String toString() {
        return "Fish of age: " + animalAge;
    }
}
