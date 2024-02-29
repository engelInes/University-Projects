package view;

import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;

public class TextMenu {
    private Map<String, Command> commands;

    public TextMenu()
    {
        this.commands = new HashMap<>();
    }

    public void addCommand(Command c)
    {
        commands.put(c.getKey(), c);
    }

    private void printMenu()
    {
        for(Command com: commands.values())
        {
            String line = String .format("%s : %s", com.getKey(), com.getDescription());
            System.out.println(line);
        }
    }

    public void show()
    {
        Scanner scanner = new Scanner(System.in);
        while (true)
        {
            this.printMenu();

            System.out.println("input option: ");
            String key = scanner.nextLine();
            Command com = commands.get(key);

            if(com == null)
            {
                System.out.println("Invalid option");
                continue;
            }

            com.execute();
        }
    }
}
