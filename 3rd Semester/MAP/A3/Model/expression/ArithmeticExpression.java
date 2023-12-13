package Model.expression;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Model.Type.IntType;
import Model.Utils.ISymTable;
import Model.Value.IValue;
import Model.Value.IntValue;

public class ArithmeticExpression implements IExpression{
    private final IExpression exp1;
    private final IExpression exp2;
    private final int op; //1+, 2-, 3*, 4/

    public ArithmeticExpression(IExpression e1, IExpression e2, int o){
        exp1=e1;
        exp2=e2;
        op=o;
    }

    @Override
    public IValue eval(ISymTable<String, IValue> tbl) throws ExpressionEvaluationException, ADTException {
        IValue v1;
        IValue v2;
        v1 = exp1.eval(tbl);
        if (v1.getType().equals(new IntType())) {
            v2 = exp2.eval(tbl);
            if (v2.getType().equals(new IntType())) {
                IntValue i1 = (IntValue) v1;
                IntValue i2 = (IntValue) v2;
                int n1;
                int n2;
                n1 = i1.getVal();
                n2 = i2.getVal();
                if (op == 1) {
                    return new IntValue(n1 + n2);
                }
                if (op == 2) {
                    return new IntValue(n1 - n2);
                }
                if (op == 3) {
                    return new IntValue(n1 * n2);
                }
                if (op == 4) {
                    if (n2 == 0) {
                        throw new ExpressionEvaluationException("division by zero");
                    } else return new IntValue(n1 / n2);
                }
            } else {
                throw new ExpressionEvaluationException("second op is not an integer");
            }
        } else {
            throw new ExpressionEvaluationException("first operand is not an integer");
        }
        return null;
    }

    @Override
    public IExpression deepCopy() {
        return new ArithmeticExpression(exp1.deepCopy(), exp2.deepCopy(), op);
    }

    @Override
    public String toString() {
        return switch (op) {
            case '1' -> "(" + exp1.toString() + "+" + exp2.toString() + ")";
            case '2' -> "(" + exp1.toString() + "-" + exp2.toString() + ")";
            case '3' -> "(" + exp1.toString() + "*" + exp2.toString() + ")";
            case '4' -> "(" + exp1.toString() + "/" + exp2.toString() + ")";
            default -> "";
        };
    }
}
