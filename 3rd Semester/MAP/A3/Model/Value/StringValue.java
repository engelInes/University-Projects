package Model.Value;

import Model.Type.IType;
import Model.Type.StringType;

public class StringValue implements IValue{
    private final String value;
    public StringValue(String val){
        value=val;
    }
    @Override
    public IType getType() {
        return new StringType();
    }

    @Override
    public IValue deepCopy() {
        return new StringValue(value);
    }

    @Override
    public String toString() {
        return "StringValue{" +
                "value='" + value + '\'' +
                '}';
    }

    @Override
    public boolean equals(Object obj) {
        if(!(obj instanceof StringValue)){
            return false;
        }
        StringValue castValue=(StringValue) obj;
        return value.equals(castValue.value);
    }

    public String getValue() {
        return value;
    }
}
