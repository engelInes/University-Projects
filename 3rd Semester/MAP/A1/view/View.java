package view;

import Controller.Controller;
import Exceptions.MyException;
import Model.Fish;
import Model.InterfaceAnimal;
import Model.Turtle;

import java.util.List;
import java.util.Scanner;
import java.util.InputMismatchException;

public class View {
    Controller controller;

    public View(Controller c) {
        controller = c;
    }

    public void printMenu() {
        System.out.println("1. Add a Fish");
        System.out.println("2. Add a Turtle");
        System.out.println("3. Delete an item");
        System.out.println("4. Show all items");
        System.out.println("5. Filter by age");
        System.out.println("0. Exit");
    }

    public void runMenu() throws MyException {
        controller.init();
        Scanner scanner = new Scanner(System.in);
        while (true) {
            printMenu();
            System.out.println("Choose an option: ");
            String option = scanner.nextLine();
            try {
                if (option.equals("1")) {
                    System.out.println("Enter the age: ");
                    int age = 0;
                    try {
                        age = scanner.nextInt();
                    } catch (InputMismatchException e) {
                        System.out.println("Invalid input. Please enter a valid age (an integer).");
                        scanner.nextLine();
                        continue;
                    }
                    controller.addAnimal(new Fish(age));
                } else if (option.equals("2")) {
                    System.out.println("Enter the age: ");
                    int age = 0;
                    try {
                        age = scanner.nextInt();
                    } catch (InputMismatchException e) {
                        System.out.println("Invalid input. Please enter a valid age (an integer).");
                        scanner.nextLine();
                        continue;
                    }
                    controller.addAnimal(new Turtle(age));
                } else if (option.equals("3")) {
                    System.out.println("Enter the position: ");
                    int pos = 0;
                    try {
                        pos = scanner.nextInt();
                    } catch (InputMismatchException e) {
                        System.out.println("Invalid input. Please enter a valid position (an integer).");
                        scanner.nextLine();
                        continue;
                    }
                    controller.removeAnimal(pos);
                }else if (option.equals("4")) {
                    System.out.println("All animals: ");
                    for (InterfaceAnimal animal : controller.getAll()) {
                        System.out.println(animal.toString());
                    }
                } else if (option.equals("5")) {
                    System.out.println("animals: ");
                    List<InterfaceAnimal> filteredAnimals = controller.filter(1);
                    for (InterfaceAnimal currentAnimal : filteredAnimals) {
                        System.out.println(currentAnimal.toString());
                    }

                } else if (option.equals("0")) {
                    System.out.println("Program exited");
                    break;
                }

            } catch (MyException e) {
                System.out.println(e.getMessage());
            }
        }
    }
}
