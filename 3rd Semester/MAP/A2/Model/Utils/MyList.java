package Model.Utils;

import java.util.ArrayList;
import java.util.List;

public class MyList<E> implements MyIList<E> {

    private final List<E> items;

    public MyList(){
        items=new ArrayList<>();
    }
    @Override
    public void add(E elem) {
        items.add(elem);
    }

    @Override
    public String toString() {
        return "MyList{" +
                "items=" + items +
                '}';
    }
}
