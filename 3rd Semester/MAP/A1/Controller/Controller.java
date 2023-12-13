package Controller;
import Exceptions.MyException;
import Model.Fish;
import Model.InterfaceAnimal;
import Model.Turtle;
import Repository.InterfaceRepo;

import java.util.ArrayList;
import java.util.List;

public class Controller {
    InterfaceRepo repository;

    public Controller(InterfaceRepo repo) {
        repository = repo;
    }

    public void init() throws MyException {
        Fish f1=new Fish(12);
        Turtle t1=new Turtle(1);
        Fish f2=new Fish(0);
        Turtle t2=new Turtle(120);
        repository.addObject(f1);
        repository.addObject(t1);
        repository.addObject(f2);
        repository.addObject(t2);
    }

    public void addAnimal(InterfaceAnimal animal) throws MyException {
        repository.addObject(animal);
    }

    public void removeAnimal(int position) throws MyException {
        repository.removeObject(position);
    }
    public List<InterfaceAnimal> filter(int minAge){
        List<InterfaceAnimal> filteredAnimals=new ArrayList<>();
        for(int i=0; i<repository.getSize(); i++){
            if(repository.getAllObjects()[i].getAge()>minAge){
                filteredAnimals.add(repository.getAllObjects()[i]);
            }
        }
        return filteredAnimals;
    }

    public List<InterfaceAnimal> getAll(){
        List<InterfaceAnimal> animals=new ArrayList<>();
        for(int i=0; i < repository.getSize(); i++){
            animals.add(repository.getAllObjects()[i]);
        }
        return animals;
    }
}
