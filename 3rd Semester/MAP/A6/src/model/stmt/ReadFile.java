package model.stmt;

import exceptions.ADTException;
import exceptions.DivisionByZero;
import exceptions.ExpressionEvaluationException;
import exceptions.StatementExecutionException;
import model.expressions.IExpression;
import model.programState.ProgramState;
import model.types.IntType;
import model.types.StringType;
import model.types.Type;
import model.utils.MyIDictionary;
import model.values.IntValue;
import model.values.StringValue;
import model.values.Value;

import java.io.BufferedReader;
import java.io.IOException;

public class ReadFile implements IStatement{
    private final IExpression expression;
    private final String varName;

    public ReadFile(IExpression expression, String varName) {
        this.expression = expression;
        this.varName = varName;
    }
    @Override
    public ProgramState execute(ProgramState state) throws StatementExecutionException, ExpressionEvaluationException, ADTException, DivisionByZero {
        MyIDictionary<String, Value> symTable = state.getSymTable();
        MyIDictionary<String, BufferedReader> fileTable = state.getFileTable();

        if (symTable.isDefined(varName)) {
            Value value = symTable.lookUp(varName);
            if (value.getType().equals(new IntType())) {
                Value fileNameValue = expression.eval(symTable, state.getHeap());
                if (fileNameValue.getType().equals(new StringType())) {
                    StringValue castValue = (StringValue)fileNameValue;
                    if (fileTable.isDefined(castValue.getValue())) {
                        BufferedReader br = fileTable.lookUp(castValue.getValue());
                        try {
                            String line = br.readLine();
                            if (line == null)
                                line = "0";
                            symTable.put(varName, new IntValue(Integer.parseInt(line)));
                        } catch (IOException e) {
                            throw new StatementExecutionException(String.format("Could not read from file %s", castValue));
                        }
                    } else {
                        throw new StatementExecutionException(String.format("The file table does not contain %s", castValue));
                    }
                } else {
                    throw new StatementExecutionException(String.format("%s does not evaluate to StringType", value));
                }
            } else {
                throw new StatementExecutionException(String.format("%s is not of type IntType", value));
            }
        } else {
            throw new StatementExecutionException(String.format("%s is not present in the symTable.", varName));
        }
        return null;
    }

    @Override
    public MyIDictionary<String, Type> typeCheck(MyIDictionary<String, Type> typeEnv) throws StatementExecutionException, ExpressionEvaluationException, ADTException {
        if (expression.typeCheck(typeEnv).equals(new StringType()))
            if (typeEnv.lookUp(varName).equals(new IntType()))
                return typeEnv;
            else
                throw new StatementExecutionException("ReadFile requires an int as its variable parameter.");
        else
            throw new StatementExecutionException("ReadFile requires a string as es expression parameter.");
    }

    @Override
    public IStatement deepCopy() {
        return new ReadFile(expression.deepCopy(), varName);
    }

    @Override
    public String toString() {
        return String.format("ReadFile(%s, %s)", expression.toString(), varName);
    }
}