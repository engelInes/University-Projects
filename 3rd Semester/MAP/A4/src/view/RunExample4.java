package view;

import controller.Controller;
import exceptions.*;

import java.io.IOException;

public class RunExample4 extends Command{
    private Controller ctrl;
    public RunExample4(String key, String description, Controller ctrl)
    {
        super(key,description);
        this.ctrl=ctrl;
    }

    public void execute()
    {
        try{
            ctrl.executeAllSteps();
        }catch(DictionaryException | ExpressionEvaluationException | StatementExecutionException | StackException | DivisionByZero |
               IOException e)
        {
            System.out.println(e.getMessage());
        }
    }
}
