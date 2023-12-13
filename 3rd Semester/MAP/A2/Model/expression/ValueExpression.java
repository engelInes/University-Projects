package Model.expression;

import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Model.Utils.ISymTable;
import Model.Value.IValue;

public class ValueExpression implements IExpression{
    private final IValue e;

    public ValueExpression(IValue exp){
        e=exp;
    }

    @Override
    public IValue eval(ISymTable<String, IValue> tbl) throws ExpressionEvaluationException {
        return e;
    }

    @Override
    public IExpression deepCopy() {
        return new ValueExpression(e);
    }

    @Override
    public String toString() {
        //return super.toString();
        return e.toString();
    }
}
