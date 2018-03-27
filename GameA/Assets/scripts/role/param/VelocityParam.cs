public class VelocityParam : StateParam
{

    public const string NAME = "velocity";

    public const string RIGHT = "right";
    public const string LEFT = "left";

    public string direction;

    public float x;
    public float y;

    public VelocityParam(float x,float y = 0)
    {
        this.x = x;
        this.y = y;
    }

    protected override string GetName()
    {
        return NAME;
    }
}
