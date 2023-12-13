package Model.expression;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Exceptions.MyException;
import Model.Type.BoolType;
import Model.Utils.ISymTable;
import Model.Value.BoolValue;
import Model.Value.IValue;

import java.util.Objects;

public class LogicalExpression implements IExpression{
    private final IExpression exp1;
    private final IExpression exp2;
    private final int op;

    public LogicalExpression(IExpression e1, IExpression e2, int o){
        exp1=e1;
        exp2=e2;
        op=o;
    }

    @Override
    public IValue eval(ISymTable<String, IValue> tbl) throws ExpressionEvaluationException, ADTException {
        IValue v1;
        IValue v2;
        v1=exp1.eval(tbl);
        if(v1.getType().equals(new BoolType())){
            v2 = exp2.eval(tbl);
            if(v2.getType().equals(new BoolType())) {
                BoolValue b1 = (BoolValue) v1;
                BoolValue b2 = (BoolValue) v2;
                boolean bool1;
                boolean bool2;
                bool1 = b1.getVal();
                bool2 = b2.getVal();
                //if (Objects.equals(op, 1)) {
                if (op==1) {
                    return new BoolValue(bool1 && bool2);
                //} else if (Objects.equals(op, 2)) {
                } else if (op==2) {
                    return new BoolValue(bool1 || bool2);
                }
            }
            else{
                throw new ExpressionEvaluationException("first operand is not a boolean");
            }
        }
        else{
            throw new ExpressionEvaluationException("First operand is not a boolean");
        }
        return null;
    }

    @Override
    public IExpression deepCopy() {
        return new LogicalExpression(exp1.deepCopy(), exp2.deepCopy(), op);
    }

    @Override
    public String toString() {
//        return "LogicalExpression{" +
//                "exp1=" + exp1 +
//                ", exp2=" + exp2 +
//                ", op=" + op +
//                '}';
        return switch (op) {
            case 1 -> "(" + exp1 + " && " + exp2 + ")";
            case 2 -> "(" + exp1 + " || " + exp2 + ")";

            default -> "";
        };
    }
}
