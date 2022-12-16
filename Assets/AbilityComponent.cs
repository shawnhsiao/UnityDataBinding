public class AbilityComponent : ModelComponentBase
{
    public FloatModelProperty ATK;
    public FloatModelProperty DEF;
    public FloatModelProperty INT;

    public float CalDamage(float damage)
    {
        return damage - DEF.Value;
    }
}


