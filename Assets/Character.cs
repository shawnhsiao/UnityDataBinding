using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField]
    private ModelComponent modelComponent;

    [SerializeField]
    private AbilityComponent abilityModelComponent;

    [SerializeField]
    private bool autoRun;

    private void Start()
    {
        modelComponent.IsShow.Value = true;
    }

    private void Update()
    {
        if (autoRun)
        {
            modelComponent.HP.Value += 1;
            if (modelComponent.HP.Value > 100)
                modelComponent.HP.Value = 0;
        }
    }

    public void ChangeWeapon(Sprite weapon)
    {
        modelComponent.Weapon.Value = weapon;
    }

    public void Damage(float damage)
    {
        modelComponent.HP.Value -= abilityModelComponent.CalDamage(damage);
    }
}
