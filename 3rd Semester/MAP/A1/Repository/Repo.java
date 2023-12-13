package Repository;
import Exceptions.MyException;
import Model.InterfaceAnimal;
public class Repo implements InterfaceRepo{
    InterfaceAnimal[] animals;

    int size;

    @Override
    public int getSize() {
        return size;
    }

    public Repo(int capacity) throws MyException {
        if (capacity <= 0)
            throw new MyException("The capacity of the repository cannot be 0 or less");
        animals = new InterfaceAnimal[capacity];
        size=0;
    }

    @Override
    public void addObject(InterfaceAnimal animal) throws MyException {
        if (size == animals.length)
            throw new MyException("You have exceeded the size of the repository");
        animals[size++] = animal;
    }

    @Override
    public void removeObject(int position) throws MyException {
        if (position >= size || position < 0)
            throw new MyException("Invalid position.");
        for (int i = position; i+1 < size; ++i)
            animals[i] = animals[i+1];
        --size;
    }

    @Override
    public InterfaceAnimal[] getAllObjects() {
        return animals;
    }
}
