package Model.Statement;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;
import Model.Type.StringType;
import Model.Utils.ISymTable;
import Model.Value.IValue;
import Model.Value.StringValue;
import Model.expression.IExpression;

import java.io.BufferedReader;
import java.io.IOException;

public class CloseReadFile implements IStmt{
    private final IExpression expression;
    public CloseReadFile(IExpression exp){
        expression=exp;
    }
    @Override
    public PrgState execute(PrgState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException {
        IValue value=expression.eval(state.getSymTable());
        if(!value.getType().equals(new StringType())){
            throw new StatementExecutionException("the value does not evaluate to StringValue");
        }
        StringValue fileName=(StringValue) value;
        ISymTable<String, BufferedReader> fileTable=state.getFileTable();
        if(!fileTable.isDefined(fileName.getValue()))
            throw new StatementExecutionException("is not present in the FileTable");
        BufferedReader br=fileTable.lookup(fileName.getValue());
        try{
            br.close();
        }catch (IOException e){
            throw new StatementExecutionException("unexpected error in closing");
        }
        fileTable.remove(fileName.getValue());
        state.setFileTable(fileTable);
        return null;
    }

    @Override
    public IStmt deepCopy() {
        return new CloseReadFile(expression.deepCopy());
    }

    @Override
    public String toString() {
        return "CloseReadFile{" +
                "expression=" + expression +
                '}';
    }
}
