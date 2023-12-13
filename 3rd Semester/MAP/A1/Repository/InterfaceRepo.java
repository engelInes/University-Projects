package Repository;
import Model.InterfaceAnimal;
import Exceptions.*;
public interface InterfaceRepo {
    void addObject(InterfaceAnimal animal) throws MyException;
    void removeObject(int position) throws MyException;
    InterfaceAnimal[] getAllObjects();
    int getSize();
}
