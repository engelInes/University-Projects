package View;

public abstract class Command {
    private final String key;
    private final String description;
    public Command(String k, String d){
        key=k;
        description=d;
    }
    public abstract void execute();
    public String getKey(){
        return key;
    }
    public String getDescription(){
        return description;
    }
}
