package Exceptions;

public class MyException extends Throwable {

    private String msg;
    public MyException(String s) {
        msg=s;
    }
}
