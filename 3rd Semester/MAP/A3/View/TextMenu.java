package View;

import Exceptions.ADTException;
import Model.Utils.ISymTable;
import Model.Utils.SymTable;

import java.util.Scanner;

public class TextMenu {
    private ISymTable<String, Command> commands;
    public TextMenu(){
        commands=new SymTable<>();
    }
    public void addCommand(Command newCommand){
        commands.put(newCommand.getKey(),newCommand);
    }
    private void printMenu(){
        for(Command currentCommand:commands.values()){
            String line=String.format("%4s:%s",currentCommand.getKey(),currentCommand.getDescription());
            System.out.println(line);
        }
    }
    public void show(){
        Scanner scanner=new Scanner(System.in);
        while(true){
            printMenu();
            System.out.println("Enter your option: ");
            String key=scanner.nextLine();
            try{
                Command curCommand=commands.lookup(key);
                curCommand.execute();
            }catch (ADTException e){
                System.out.println("Invalid option");
            }
        }
    }
}
