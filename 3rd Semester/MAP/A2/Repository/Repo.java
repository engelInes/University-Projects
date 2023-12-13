package Repository;

import Model.ProgramState.PrgState;

import java.util.ArrayList;
import java.util.List;

public class Repo implements IRepo{

    private final List<PrgState> prgStateList;
    public Repo(){
        prgStateList=new ArrayList<>();
    }
    @Override
    public PrgState getCurrentProgramState() {
        return prgStateList.get(prgStateList.size()-1);
    }

    @Override
    public void add(PrgState prgState) {
        prgStateList.add(prgState);
    }

}
