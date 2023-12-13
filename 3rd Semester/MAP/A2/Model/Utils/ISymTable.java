package Model.Utils;

import Exceptions.ADTException;
import Exceptions.MyException;
import Model.Value.IValue;

public interface ISymTable<K, V> {
    boolean isDefined(K key);
    void put(K key, V value);
    V lookup(K key) throws ADTException;
    void update(K newKey, V newValue) throws ADTException;

}
