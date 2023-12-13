package Controller;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;
import Model.Statement.IStmt;
import Model.Utils.IExeStack;
import Repository.IRepo;

public class Controller {
    private final IRepo repo;
    public Controller(IRepo newRepo){
        repo=newRepo;
    }
    public PrgState oneStep(PrgState state) throws StatementExecutionException, ADTException, ExpressionEvaluationException {
        IExeStack<IStmt> stack=state.getStck();
        if(stack.isEmpty()){
            throw new StatementExecutionException("program state stack is empty");
        }
        IStmt crtStmt=stack.pop();
        //state.setStck(stack);
        return crtStmt.execute(state);
    }

    public void allSteps() throws ExpressionEvaluationException,ADTException,StatementExecutionException{
        PrgState prg=repo.getCurrentProgramState();
        //System.out.println(prg);
        while(!prg.getStck().isEmpty())
        {
            oneStep(prg);
        }
        //System.out.println(prg);
    }
    public void addProgram(PrgState newPrg){
        repo.add(newPrg);
    }
    public PrgState getCurrentProgram(){
        return repo.getCurrentProgramState();
    }
    public boolean isEmpty(){
        return repo.getCurrentProgramState().getStck().isEmpty();
    }
}
