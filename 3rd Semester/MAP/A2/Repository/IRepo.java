package Repository;

import Model.ProgramState.PrgState;

public interface IRepo {
    PrgState getCurrentProgramState();
    void add(PrgState prgState);
}
