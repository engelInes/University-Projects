package Repository;

import Exceptions.ADTException;
import Exceptions.ExpressionEvaluationException;
import Model.ProgramState.PrgState;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.List;

public class Repo implements IRepo{

    private List<PrgState> prgStateList;
    private int currentPosition;
    private final String logFilePath;
    public Repo(PrgState prgState, String logFile)
    {
        logFilePath=logFile;
        prgStateList=new ArrayList<>();
        currentPosition=0;
        add(prgState);
    }

    public int getCurrentPosition() {
        return currentPosition;
    }

    public void setCurrentPosition(int currentPosition) {
        this.currentPosition = currentPosition;
    }
    public void setPrgStateList(List<PrgState> prgStates){
        prgStateList=prgStates;
    }

    @Override
    public PrgState getCurrentProgramState() {
        return prgStateList.get(currentPosition);
    }

    @Override
    public void add(PrgState prgState) {
        prgStateList.add(prgState);
    }

    @Override
    public void logPrgStateExec() throws IOException, ADTException {
        PrintWriter logFile;
        logFile=new PrintWriter(new BufferedWriter(new FileWriter(logFilePath,true)));
        logFile.println(this.prgStateList.get(0).programStateToString());
        logFile.close();
    }

    @Override
    public List<PrgState> getProgramList() {
        return prgStateList;
    }

    @Override
    public void setProgramStates(List<PrgState> programStates) {
        prgStateList=programStates;
    }

    @Override
    public void emptyLogFile() throws IOException {
        PrintWriter logFile;
        logFile=new PrintWriter(new BufferedWriter(new FileWriter(logFilePath,false)));
        logFile.close();
    }

}
