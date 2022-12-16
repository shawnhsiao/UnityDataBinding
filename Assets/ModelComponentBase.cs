using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.Build;
using UnityEngine;
using UniRx;
using Unity.VisualScripting;
using System.Linq;

public interface IModelPropertyValidator
{
    bool IsValid();
}

public class DockPropertyValidator : IModelPropertyValidator
{
    private Func<bool> DockMethod;

    public DockPropertyValidator(Func<bool> dockMethod)
    {
        DockMethod = dockMethod;
    }

    public bool IsValid()
    {
        return DockMethod.Invoke();
    }
}

public class DummyPropertyValidator : IModelPropertyValidator
{
    public bool IsValid()
    {
        return true;
    }
}

public abstract class ModelProperty
{
    public Component BindComponent;
    public string BindPropertyName;

    protected IModelPropertyValidator supervisor = new DummyPropertyValidator();

    public abstract List<Type> AllowTypes { get; }

    public abstract void OnValueChanged();

    public void SetValidator(IModelPropertyValidator vadiator) { this.supervisor = vadiator; }
}

public class ModelComponentBase : MonoBehaviour
{
    private void Awake()
    {
        var runtimeProps = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

        var modelProps = runtimeProps.Where(e => e.FieldType.BaseType == typeof(ModelProperty));
        foreach (var prop in modelProps)
        {
            var propVal = prop.GetValue(this) as ModelProperty;
            var property = propVal.GetType().GetField("Value").GetValue(propVal);
            propVal.ObserveEveryValueChanged(e => propVal.GetType().GetField("Value").GetValue(propVal)).AsObservable().Subscribe(_ =>
             {
                 propVal.OnValueChanged();
             }).AddTo(this);
        }
    }

}