using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using Unity.VisualScripting;

[Serializable]
public class BooleanModelProperty : ModelProperty
{
    public bool Value;

    public override List<Type> AllowTypes => new List<Type>() { typeof(bool) };

    public bool GetUpdateValue()
    {
        return Value;
    }

    public bool GetBindValue()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return false;
        return (bool)BindComponent.GetType().GetProperty(BindPropertyName).GetValue(BindComponent);
    }

    public override void OnValueChanged()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return;
        if (supervisor.IsValid())
            BindComponent.GetType().GetProperty(BindPropertyName).SetValue(BindComponent, GetUpdateValue());
    }

    public override bool Equals(object obj)
    {
        if (obj is bool)
            return obj == (object)this.Value;
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Value);
    }

    public static implicit operator BooleanModelProperty(bool v) => v;
}

[Serializable]
public class StringModelProperty : ModelProperty
{
    public string Value;

    public override List<Type> AllowTypes => new List<Type>() { typeof(string), typeof(Text) };

    public string GetUpdateValue()
    {
        return Value;
    }

    public string GetBindValue()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return String.Empty;
        return (string)BindComponent.GetType().GetProperty(BindPropertyName).GetValue(BindComponent);
    }

    public override void OnValueChanged()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return;
        if (supervisor.IsValid())
            BindComponent.GetType().GetProperty(BindPropertyName).SetValue(BindComponent, GetUpdateValue());
    }

    public static implicit operator StringModelProperty(string v) => v;
}

[Serializable]
public class IntegerModelProperty : ModelProperty
{
    public int Value;

    public override List<Type> AllowTypes => new List<Type>() { typeof(int), typeof(Int16), typeof(Int32), };

    public int GetUpdateValue()
    {
        return Value;
    }

    public int GetBindValue()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return int.MinValue;
        return (int)BindComponent.GetType().GetProperty(BindPropertyName).GetValue(BindComponent);
    }

    public override void OnValueChanged()
    {
        if (supervisor.IsValid())
            BindComponent.GetType().GetProperty(BindPropertyName).SetValue(BindComponent, GetUpdateValue());
    }

    public static implicit operator IntegerModelProperty(int v) => v;
}


[Serializable]
public class FloatModelProperty : ModelProperty
{
    public float Value;

    public override List<Type> AllowTypes => new List<Type>() { typeof(float), typeof(double) };

    public float GetUpdateValue()
    {
        return Value;
    }

    public float GetBindValue()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return float.MinValue;
        return (float)BindComponent.GetType().GetProperty(BindPropertyName).GetValue(BindComponent);
    }

    public override void OnValueChanged()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return;
        if (supervisor.IsValid())
            BindComponent.GetType().GetProperty(BindPropertyName).SetValue(BindComponent, GetUpdateValue());
    }

    public static implicit operator FloatModelProperty(float v) => v;
}

[Serializable]
public class SpriteModelProperty : ModelProperty
{
    public Sprite Value;

    public override List<Type> AllowTypes => new List<Type>() { typeof(Sprite) };

    public Sprite GetUpdateValue()
    {
        return Value;
    }

    public Sprite GetBindValue()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return null;
        return (Sprite)BindComponent.GetType().GetProperty(BindPropertyName).GetValue(BindComponent);
    }

    public override void OnValueChanged()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return;
        if (supervisor.IsValid())
            BindComponent.GetType().GetProperty(BindPropertyName).SetValue(BindComponent, GetUpdateValue());
    }

    public static implicit operator SpriteModelProperty(Sprite v) => v;
}


[Serializable]
public class StateModelProperty : ModelProperty
{
    public enum State
    {
        Idle,
        Show,
        Hide,
        Dead
    }
    public State Value;

    public override List<Type> AllowTypes => new List<Type>() { typeof(Color), typeof(Color32) };

    public Color GetUpdateValue()
    {
        var col = Color.black;
        switch (Value)
        {
            case State.Idle:
                col = Color.white;
                break;
            case State.Show:
                col = Color.blue;
                break;
            case State.Hide:
                col = Color.black;
                break;
            case State.Dead:
                col = Color.red;
                break;
            default:
                break;
        }
        return col;
    }

    public Color GetBindValue()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return Color.white;
        return (Color)BindComponent.GetType().GetProperty(BindPropertyName).GetValue(BindComponent);
    }

    public override void OnValueChanged()
    {
        if (BindComponent == null || BindPropertyName == String.Empty) return;
        if (supervisor.IsValid())
            BindComponent.GetType().GetProperty(BindPropertyName).SetValue(BindComponent, GetUpdateValue());
    }

    public static implicit operator StateModelProperty(State v) => v;
}