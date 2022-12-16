using System;
using UnityEngine;


public class ModelComponent : ModelComponentBase, IModelPropertyValidator
{
    [SerializeField]
    public BooleanModelProperty IsShow;
    [SerializeField]
    public StringModelProperty Title;
    [SerializeField]
    public FloatModelProperty HP;
    [SerializeField]
    public SpriteModelProperty Weapon;
    [SerializeField]
    public StateModelProperty State;

    void Start()
    {
        Weapon.SetValidator(this);

        Title.SetValidator(new DockPropertyValidator(() =>
        {
            return !Title.Value.Contains(" ");
        }));

        HP.SetValidator(new DockPropertyValidator(() =>
        {
            return HP.Value > 0 || HP.Value < 100;
        }));
    }
    public bool IsValid()
    {
        return true;
    }
}


