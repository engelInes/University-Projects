package model.expressions;

import exceptions.ADTException;
import exceptions.DivisionByZero;
import exceptions.ExpressionEvaluationException;
import exceptions.HeapException;
import model.types.RefType;
import model.types.Type;
import model.utils.MyIDictionary;
import model.utils.MyIHeap;
import model.values.RefValue;
import model.values.Value;

public class ReadHeapExpression implements IExpression{
    private final IExpression expression;

    public ReadHeapExpression(IExpression expression) {
        this.expression = expression;
    }

    @Override
    public Type typeCheck(MyIDictionary<String, Type> typeEnv) throws ExpressionEvaluationException, ADTException {
        Type type = expression.typeCheck(typeEnv);
        if (type instanceof RefType) {
            RefType refType = (RefType) type;
            return refType.getInner();
        } else
            throw new ExpressionEvaluationException("The rH argument is not a RefType.");
    }

    @Override
    public Value eval(MyIDictionary<String, Value> symTable, MyIHeap heap) throws ExpressionEvaluationException, ADTException, DivisionByZero {
        Value value = expression.eval(symTable, heap);
        if (value instanceof RefValue) {
            RefValue refValue = (RefValue) value;
            if (heap.containsKey(refValue.getAddress()))
                return heap.get(refValue.getAddress());
            else
                throw new ExpressionEvaluationException("The address is not defined on the heap!");
        } else
            throw new ExpressionEvaluationException(String.format("%s not of RefType", value));
    }

    @Override
    public IExpression deepCopy() {
        return new ReadHeapExpression(expression.deepCopy());
    }

    @Override
    public String toString() {
        return String.format("ReadHeap(%s)", expression);
    }
}