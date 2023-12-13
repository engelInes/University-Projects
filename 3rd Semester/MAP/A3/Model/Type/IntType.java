package Model.Type;

import Model.Value.IValue;
import Model.Value.IntValue;

public class IntType implements IType{
    @Override
    public boolean equals(Object differentType) {
        return differentType instanceof IntType;
    }

    @Override
    public IValue defaultValue() {
        return new IntValue(0);
    }

    @Override
    public IType deepCopy() {
        return new IntType();
    }

    public String toString(){
        return "int";
    }
}
