package Model.expression;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Model.Utils.ISymTable;
import Model.Value.IValue;

public class VariableExpression implements IExpression{

    private final String id;

    public VariableExpression(String s){
        id=s;
    }
    @Override
    public IValue eval(ISymTable<String, IValue> tbl) throws ADTException {
        return tbl.lookup(id);
    }

    @Override
    public IExpression deepCopy() {
        return new VariableExpression(id);
    }

    @Override
    public String toString() {
        return "(" + id + ")";
    }
}
