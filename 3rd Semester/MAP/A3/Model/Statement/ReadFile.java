package Model.Statement;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.StatementExecutionException;
import Model.ProgramState.PrgState;
import Model.Type.IntType;
import Model.Type.StringType;
import Model.Utils.IExeStack;
import Model.Utils.ISymTable;
import Model.Value.IValue;
import Model.Value.IntValue;
import Model.Value.StringValue;
import Model.expression.IExpression;

import java.io.BufferedReader;
import java.io.IOException;

public class ReadFile implements IStmt {
    private final IExpression expression;
    private final String varName;
    public ReadFile(IExpression exp, String name){
        expression=exp;
        varName=name;
    }
    @Override
    public PrgState execute(PrgState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException {
        ISymTable<String, IValue> symTable=state.getSymTable();
        ISymTable<String, BufferedReader> fileTable=state.getFileTable();
        if(symTable.isDefined(varName)){
            IValue value=symTable.lookup(varName);
            if(value.getType().equals(new IntType())){
                value=expression.eval(symTable);
                if(value.getType().equals(new StringType())){
                    StringValue castValue=(StringValue) value;
                    if(fileTable.isDefined(castValue.getValue())){
                        BufferedReader br=fileTable.lookup(castValue.getValue());
                        try{
                            String line= br.readLine();
                            if(line==null)
                                line="0";
                            symTable.put(varName,new IntValue(Integer.parseInt(line)));
                        }catch (IOException e){
                            throw new StatementExecutionException("could not read from file");
                        }
                    }else{
                        throw new StatementExecutionException("the file table does not contain the value");
                    }
                }
                else{
                    throw new StatementExecutionException("does not evaluate to StringType");
                }
            }
            else {
                throw new StatementExecutionException("is not of type IntType");
            }
        }
        else {
            throw new StatementExecutionException("the value is not present in the symTable");
        }
        return state;
    }

    @Override
    public IStmt deepCopy() {
        return new ReadFile(expression.deepCopy(),varName);
    }

    @Override
    public String toString() {
        return "ReadFile{" +
                "expression=" + expression +
                ", varName='" + varName + '\'' +
                '}';
    }
}
