package Repository;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Model.ProgramState.PrgState;

import java.io.IOException;
import java.util.List;

public interface IRepo {
    PrgState getCurrentProgramState();
    void add(PrgState prgState);

    void logPrgStateExec() throws IOException, ADTException;
    List<PrgState> getProgramList();
    void setProgramStates(List<PrgState> programStates);
    void emptyLogFile() throws IOException;
}
