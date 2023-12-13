package Model.Value;

import Model.Type.BoolType;
import Model.Type.IType;

import java.util.Objects;

public class BoolValue implements IValue{

    private final boolean val;
    public BoolValue(boolean v){
        val=v;
    }
    public boolean getVal(){
        return val;
    }

    @Override
    public IType getType() {
        return new BoolType();
    }

//    @Override
//    public IValue deepCopy() {
//        return new BoolValue(val);
//    }

    @Override
    public String toString() {
        return "BoolValue{" +
                "val=" + val +
                '}';
    }

//    @Override
//    public boolean equals(Object o) {
//        if (this == o) return true;
//        if (o == null || getClass() != o.getClass()) return false;
//        BoolValue boolValue = (BoolValue) o;
//        return val == boolValue.val;
//    }
//
//    @Override
//    public int hashCode() {
//        return Objects.hash(val);
//    }
}
