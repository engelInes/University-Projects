package Model.expression;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Model.Type.IntType;
import Model.Utils.ISymTable;
import Model.Value.BoolValue;
import Model.Value.IValue;
import Model.Value.IntValue;

import java.util.Objects;

public class RelationalExpression implements IExpression{
    private final String op;
    private final IExpression expression1;
    private final IExpression expression2;
    public RelationalExpression(String operator, IExpression ex1, IExpression exp2)
    {
        op=operator;
        expression1=ex1;
        expression2=exp2;
    }
    @Override
    public IValue eval(ISymTable<String, IValue> tbl) throws ExpressionEvaluationException, ADTException {
        IValue val1;
        IValue val2;
        val1=expression1.eval(tbl);
        if(val1.getType().equals(new IntType())){
            val2=expression2.eval(tbl);
            if(val2.getType().equals(new IntType())){
                IntValue v1=(IntValue) val1;
                IntValue v2=(IntValue) val2;
                int value1;
                int value2;
                value1=v1.getVal();
                value2=v2.getVal();
                if(Objects.equals(op,"<")){
                    return new BoolValue(value1<value2);
                }
                else if(Objects.equals(op, "<=")){
                    return new BoolValue(value1<=value2);
                }
                else if(Objects.equals(op, "=")){
                    return new BoolValue(value1==value2);
                }
                else if(Objects.equals(op, ">")){
                    return new BoolValue(value1>value2);
                }
                else if(Objects.equals(op, ">=")){
                    return new BoolValue(value1>=value2);
                }
                else if(Objects.equals(op,"!=")){
                    return new BoolValue(value1!=value2);
                }
            }
            else{
                throw new ExpressionEvaluationException("Second operand is not an integer");
            }

        }
        else {
            throw new ExpressionEvaluationException("First operand is not an integer");
        }
        return null;
    }

    @Override
    public IExpression deepCopy() {
        return new RelationalExpression(op,expression1.deepCopy(),expression2.deepCopy());
    }

    @Override
    public String toString() {
        return "RelationalExpression{" +
                "op='" + op + '\'' +
                ", expression1=" + expression1 +
                ", expression2=" + expression2 +
                '}';
    }
}
