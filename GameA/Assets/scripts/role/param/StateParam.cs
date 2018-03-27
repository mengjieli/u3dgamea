public abstract class StateParam  {

    public string name
    {
        get { return GetName(); }
    }

    abstract protected string GetName();
}
