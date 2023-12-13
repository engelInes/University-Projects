package Model.Utils;

import Exceptions.ADTException;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

//dictionary with key var val value
public class SymTable<K,V> implements ISymTable<K,V>{
    private final HashMap<K,V> dict;
    public SymTable(){
        dict=new HashMap<>();
    }
    @Override
    public boolean isDefined(K key) {
        return dict.containsKey(key);
    }

    @Override
    public void put(K key, V value) {
        dict.put(key,value);
    }

    @Override
    public V lookup(K key) throws ADTException {
        if(!isDefined(key)){
            throw new ADTException(key+" is not defined");
        }
        return dict.get(key);
    }

    @Override
    public void update(K newKey, V newValue) throws ADTException {
        if(!isDefined(newKey)){
            throw new ADTException(newKey+ " is not defined");
        }
        dict.put(newKey, newValue);
    }

    @Override
    public void remove(K key) throws ADTException {
        if(!isDefined(key)){
            throw new ADTException(key+"is not defined");
        }
        dict.remove(key);
    }

    @Override
    public Set<K> keySet() {
        return dict.keySet();
    }

    @Override
    public Collection<V> values() {
        return dict.values();
    }

    @Override
    public String toString() {
        return "SymTable{" +
                "dict=" + dict +
                '}';
    }
}
