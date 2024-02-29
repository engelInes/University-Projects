package repo;

import exceptions.HeapException;
import model.programState.ProgramState;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.List;

public interface IRepository {
    void addProgram(ProgramState newProgram);

//    ProgramState getCurrentProgram();

    void logPrgStateExec(ProgramState programState) throws IOException, HeapException;
    List<ProgramState> getPrgList();
    void  setPrgList(List<ProgramState> newPrgList);
}
