package Model.Utils;

import java.util.*;

public class ExeStack<T> implements IExeStack<T> {

    private final Stack<T> stack;

    public ExeStack(){
        stack=new Stack<>();
    }
    @Override
    public T pop() {
        return stack.pop();
    }

    @Override
    public void push(T v) {
        stack.push(v);
    }

    @Override
    public boolean isEmpty() {
        return stack.isEmpty();
    }

    @Override
    public List<T> getReverse() {
        List<T> auxList;
        //auxList = Arrays.asList((T[]) stack.toArray());
        auxList = new ArrayList<>(stack);
        Collections.reverse(auxList);
        return auxList;
    }

    @Override
    public String toString() {
//        return "ExeStack{" +
//                "stack=" + stack +
//                '}';
        return "stack: " + getReverse();
    }
}
