package model.stmt;

import exceptions.DictionaryException;
import exceptions.DivisionByZero;
import exceptions.ExpressionEvaluationException;
import exceptions.StatementExecutionException;
import model.expressions.IExpression;
import model.programState.ProgramState;
import model.types.StringType;
import model.utils.MyIDictionary;
import model.values.IValue;
import model.values.StringValue;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;

public class CloseReadFileStmt implements IStmt{
    private final IExpression exp;

    public CloseReadFileStmt(IExpression e)
    {
        this.exp=e;
    }

    @Override
    public ProgramState execute(ProgramState state) throws ExpressionEvaluationException, DivisionByZero, StatementExecutionException, IOException, DictionaryException {
        IValue val = exp.eval(state.getSymbolTable());

        if(!val.getType().equals(new StringType()))
            throw new StatementExecutionException("File name should be of type string");
        StringValue fileName = (StringValue) val;
        MyIDictionary<String, BufferedReader> fileTable = state.getFileTable();

        if(!fileTable.isDefined(fileName.getValue()))
            throw new StatementExecutionException("File should be opened first");

        BufferedReader bufR = fileTable.lookup(fileName.getValue());
        bufR.close();

        fileTable.remove(fileName.getValue());
        state.setFileTable(fileTable);
        return state;
    }

    public IStmt deepcopy()
    {
        return new CloseReadFileStmt(exp.deepcopy());
    }

    @Override
    public String toString() {
        return "CloseReadFileStmt{" +
                "exp=" + exp +
                '}';
    }
}
