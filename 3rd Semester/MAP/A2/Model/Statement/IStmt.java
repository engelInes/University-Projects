package Model.Statement;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;

public interface IStmt {
    PrgState execute(PrgState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException;

}
