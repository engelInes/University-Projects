package Model.Value;

import Model.Type.IType;
import Model.Type.IntType;

import java.util.Objects;

public class IntValue implements IValue{

    int val;
    public IntValue(int v){
        val=v;
    }
    public int getVal(){
        return val;
    }

    @Override
    public IType getType() {
        return new IntType();
    }

    @Override
    public String toString() {
        return "IntValue{" +
                "val=" + val +
                '}';
    }

//    @Override
//    public IValue deepCopy() {
//        return new IntValue(val);
//    }

//    @Override
//    public boolean equals(Object o) {
//        if (this == o) return true;
//        if (o == null || getClass() != o.getClass()) return false;
//        IntValue intValue = (IntValue) o;
//        return val == intValue.val;
//    }
//
//    @Override
//    public int hashCode() {
//        return Objects.hash(val);
//    }
}
