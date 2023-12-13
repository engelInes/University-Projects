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
import java.io.FileNotFoundException;
import java.io.FileReader;

public class OpenReadFile implements IStmt{
    private final IExpression expression;
    public OpenReadFile(IExpression exp){
        expression=exp;
    }
    @Override
    public PrgState execute(PrgState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException {
        IValue value=expression.eval(state.getSymTable());
        if(value.getType().equals(new StringType())){
            StringValue fileName=(StringValue) value;
            ISymTable<String, BufferedReader> fileTable=state.getFileTable();
            if(!fileTable.isDefined(fileName.getValue())){
                //checking if it is already in the table
                BufferedReader br;
                try{
                    br=new BufferedReader(new FileReader(fileName.getValue()));
                }catch (FileNotFoundException e){
                    throw new StatementExecutionException("file could not be opened");
                }
                fileTable.put(fileName.getValue(),br);
                state.setFileTable(fileTable);
            }else{
                throw new StatementExecutionException("file is already opened");
            }
        }else{
            throw new StatementExecutionException("expression does not evaluate to StringType");
        }
        return state;
    }

    @Override
    public IStmt deepCopy() {
        return new OpenReadFile(expression.deepCopy());
    }

    @Override
    public String toString() {
        return "OpenReadFile{" +
                "expression=" + expression +
                '}';
    }
}
