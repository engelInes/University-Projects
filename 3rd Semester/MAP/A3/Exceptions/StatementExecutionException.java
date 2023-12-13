package Exceptions;

public class StatementExecutionException extends Exception{
    public StatementExecutionException(){
        super();
    }
    public StatementExecutionException(String s){
        super(s);
    }
}
