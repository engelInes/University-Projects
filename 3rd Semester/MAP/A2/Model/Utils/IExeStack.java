package Model.Utils;

import java.util.List;

public interface IExeStack<T> {
    T pop();
    void push(T v);
    boolean isEmpty();
    List<T> getReverse();
}
