package Model.expression;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Model.Utils.ISymTable;
import Model.Value.IValue;

public interface IExpression {
    //each expression class has an overridden method eval which takes as arguments
    //a reference to the SymTable
    //returns an object IValue
    IValue eval(ISymTable<String,IValue> tbl) throws ExpressionEvaluationException, ADTException;
    IExpression deepCopy();

}
