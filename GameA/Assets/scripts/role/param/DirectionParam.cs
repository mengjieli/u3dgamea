public class DirectionParam : StateParam {

    public const string NAME = "direction";

    public const string RIGHT = "right";
    public const string LEFT = "left";

    public string direction;

    public DirectionParam(string direction)
    {
        this.direction = direction;
    }

    protected override string GetName()
    {
        return NAME;
    }

    public int flipx
    {
        get { return direction == RIGHT ? 1 : (direction == LEFT ? -1 : 0); }
    }
}
