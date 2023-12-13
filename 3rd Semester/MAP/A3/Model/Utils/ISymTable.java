package Model.Utils;

import Exceptions.ADTException;
import Model.Value.IValue;

import java.util.Collection;
import java.util.List;
import java.util.Set;

public interface ISymTable<K, V> {
    boolean isDefined(K key);
    void put(K key, V value);
    V lookup(K key) throws ADTException;
    void update(K newKey, V newValue) throws ADTException;
    void remove(K key) throws ADTException;
    Set<K> keySet();
    Collection<V> values();

}
