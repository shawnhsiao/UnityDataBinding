using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

[CustomPropertyDrawer(typeof(BooleanModelProperty))]
public class BooleanModelEditor : PropertyDrawer
{
    private bool foldout;
    private SerializedProperty boolProp;
    private SerializedProperty bindPropName;
    private SerializedProperty bindComponent;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var initPos = position;
        initPos.height = EditorGUIUtility.singleLineHeight;
        initPos.width = EditorGUIUtility.currentViewWidth;

        var pos1 = position;
        pos1.y = EditorGUIUtility.singleLineHeight * 1.5f;
        pos1.width = EditorGUIUtility.currentViewWidth * 0.7f;
        pos1.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.BeginProperty(initPos, label, property);
        this.foldout = EditorGUI.BeginFoldoutHeaderGroup(initPos, this.foldout, property.name);
        if (foldout)
        {
            boolProp = property.FindPropertyRelative("Value");
            bindComponent = property.FindPropertyRelative("BindComponent");
            bindPropName = property.FindPropertyRelative("BindPropertyName");

            var target = property.serializedObject.targetObject;
            var modelProp = fieldInfo.GetValue(target) as BooleanModelProperty;
            var pos2 = new Rect(pos1);
            pos2.y += EditorGUIUtility.singleLineHeight * 1.25f;
            var pos3 = new Rect(pos2);
            pos3.x = 20;
            pos3.y += EditorGUIUtility.singleLineHeight;
            var pos4 = new Rect(pos3);
            pos4.x = 20;
            pos4.y += EditorGUIUtility.singleLineHeight;
            var pos5 = new Rect(pos2);
            pos5.x += 280;
            pos5.width = 50;
            var pos6 = new Rect(pos4);
            pos6.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(pos2, boolProp);
            EditorGUI.PropertyField(pos3, bindComponent);
            EditorGUI.PropertyField(pos4, bindPropName);
            if (GUI.Button(pos5, "Bind"))
            {
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                    new PropertySearchWindow(target, modelProp.AllowTypes, (prop, com) =>
                    {
                        modelProp.BindPropertyName = prop.Name;
                        modelProp.BindComponent = com;

                    }));
            }

            if (modelProp.BindPropertyName != string.Empty)
                EditorGUI.Toggle(pos6, bindPropName.stringValue, modelProp.GetBindValue());
        }

        EditorGUI.EndFoldoutHeaderGroup();
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = foldout ? 90 : 0;
        return base.GetPropertyHeight(property, label) + height;
    }
}


[CustomPropertyDrawer(typeof(StringModelProperty))]
public class StringModelPropertyEditor : PropertyDrawer
{
    private bool foldout;
    private SerializedProperty prop;
    private SerializedProperty bindPropName;
    private SerializedProperty bindComponent;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var initPos = position;
        initPos.height = EditorGUIUtility.singleLineHeight;
        initPos.width = EditorGUIUtility.currentViewWidth;

        var pos1 = position;
        pos1.width = EditorGUIUtility.currentViewWidth;
        pos1.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.BeginProperty(initPos, label, property);
        this.foldout = EditorGUI.BeginFoldoutHeaderGroup(initPos, this.foldout, property.name);
        if (foldout)
        {
            this.prop = property.FindPropertyRelative("Value");
            bindComponent = property.FindPropertyRelative("BindComponent");
            bindPropName = property.FindPropertyRelative("BindPropertyName");

            var target = property.serializedObject.targetObject;
            var modelProp = fieldInfo.GetValue(target) as StringModelProperty;
            var pos2 = new Rect(pos1);
            pos2.y += EditorGUIUtility.singleLineHeight;
            pos2.width = EditorGUIUtility.currentViewWidth * 0.7f;
            var pos3 = new Rect(pos2);
            pos3.x = 20;
            pos3.y += EditorGUIUtility.singleLineHeight;
            var pos4 = new Rect(pos3);
            pos4.x = 20;
            pos4.y += EditorGUIUtility.singleLineHeight;
            var pos5 = new Rect(pos2);
            pos5.x += 280;
            pos5.width = 50;
            var pos6 = new Rect(pos4);
            pos6.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(pos2, prop);
            EditorGUI.PropertyField(pos3, bindComponent);
            EditorGUI.PropertyField(pos4, bindPropName);
            if (GUI.Button(pos5, "Bind"))
            {
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                    new PropertySearchWindow(target, modelProp.AllowTypes, (prop, com) =>
                    {
                        modelProp.BindPropertyName = prop.Name;
                        modelProp.BindComponent = com;

                    }));
            }

            if (modelProp.BindPropertyName != string.Empty)
                EditorGUI.TextField(pos6, bindPropName.stringValue, modelProp.GetBindValue());
        }

        EditorGUI.EndFoldoutHeaderGroup();
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = foldout ? 90 : 0;
        return base.GetPropertyHeight(property, label) + height;
    }
}

[CustomPropertyDrawer(typeof(IntegerModelProperty))]
public class IntegerModelPropertyEditor : PropertyDrawer
{
    private bool foldout;
    private SerializedProperty prop;
    private SerializedProperty bindPropName;
    private SerializedProperty bindComponent;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var initPos = position;
        initPos.height = EditorGUIUtility.singleLineHeight;
        initPos.width = EditorGUIUtility.currentViewWidth;

        var pos1 = position;
        pos1.width = EditorGUIUtility.currentViewWidth;
        pos1.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.BeginProperty(initPos, label, property);
        this.foldout = EditorGUI.BeginFoldoutHeaderGroup(initPos, this.foldout, property.name);
        if (foldout)
        {
            this.prop = property.FindPropertyRelative("Value");
            bindComponent = property.FindPropertyRelative("BindComponent");
            bindPropName = property.FindPropertyRelative("BindPropertyName");

            var target = property.serializedObject.targetObject;
            var modelProp = fieldInfo.GetValue(target) as IntegerModelProperty;
            var pos2 = new Rect(pos1);
            pos2.y += EditorGUIUtility.singleLineHeight;
            pos2.width = EditorGUIUtility.currentViewWidth * 0.7f;
            var pos3 = new Rect(pos2);
            pos3.x = 20;
            pos3.y += EditorGUIUtility.singleLineHeight;
            var pos4 = new Rect(pos3);
            pos4.x = 20;
            pos4.y += EditorGUIUtility.singleLineHeight;
            var pos5 = new Rect(pos2);
            pos5.x += 280;
            pos5.width = 50;
            var pos6 = new Rect(pos4);
            pos6.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(pos2, prop);
            EditorGUI.PropertyField(pos3, bindComponent);
            EditorGUI.PropertyField(pos4, bindPropName);
            if (GUI.Button(pos5, "Bind"))
            {
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                    new PropertySearchWindow(target, modelProp.AllowTypes, (prop, com) =>
                    {
                        modelProp.BindPropertyName = prop.Name;
                        modelProp.BindComponent = com;

                    }));
            }

            if (modelProp.BindPropertyName != string.Empty)
                EditorGUI.IntField(pos6, bindPropName.stringValue, modelProp.GetBindValue());
        }

        EditorGUI.EndFoldoutHeaderGroup();
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = foldout ? 90 : 0;
        return base.GetPropertyHeight(property, label) + height;
    }
}


[CustomPropertyDrawer(typeof(FloatModelProperty))]
public class FloatModelPropertyEditor : PropertyDrawer
{
    private bool foldout;
    private SerializedProperty prop;
    private SerializedProperty bindPropName;
    private SerializedProperty bindComponent;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var initPos = position;
        initPos.height = EditorGUIUtility.singleLineHeight;
        initPos.width = EditorGUIUtility.currentViewWidth;

        var pos1 = position;
        pos1.width = EditorGUIUtility.currentViewWidth;
        pos1.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.BeginProperty(initPos, label, property);
        this.foldout = EditorGUI.BeginFoldoutHeaderGroup(initPos, this.foldout, property.name);
        if (foldout)
        {
            this.prop = property.FindPropertyRelative("Value");
            bindComponent = property.FindPropertyRelative("BindComponent");
            bindPropName = property.FindPropertyRelative("BindPropertyName");

            var target = property.serializedObject.targetObject;
            var modelProp = fieldInfo.GetValue(target) as FloatModelProperty;
            var pos2 = new Rect(pos1);
            pos2.y += EditorGUIUtility.singleLineHeight;
            pos2.width = EditorGUIUtility.currentViewWidth * 0.7f;
            var pos3 = new Rect(pos2);
            pos3.x = 20;
            pos3.y += EditorGUIUtility.singleLineHeight;
            var pos4 = new Rect(pos3);
            pos4.x = 20;
            pos4.y += EditorGUIUtility.singleLineHeight;
            var pos5 = new Rect(pos2);
            pos5.x += 280;
            pos5.width = 50;
            var pos6 = new Rect(pos4);
            pos6.y += EditorGUIUtility.singleLineHeight;

            EditorGUI.PropertyField(pos2, prop);
            EditorGUI.PropertyField(pos3, bindComponent);
            EditorGUI.PropertyField(pos4, bindPropName);
            if (GUI.Button(pos5, "Bind"))
            {
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                    new PropertySearchWindow(target, modelProp.AllowTypes, (prop, com) =>
                    {
                        modelProp.BindPropertyName = prop.Name;
                        modelProp.BindComponent = com;

                    }));
            }

            if (modelProp.BindPropertyName != string.Empty)
                EditorGUI.FloatField(pos6, bindPropName.stringValue, modelProp.GetBindValue());
        }

        EditorGUI.EndFoldoutHeaderGroup();
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = foldout ? 90 : 0;
        return base.GetPropertyHeight(property, label) + height;
    }
}

[CustomPropertyDrawer(typeof(SpriteModelProperty))]
public class SpriteModelPropertyEditor : PropertyDrawer
{
    private bool foldout;
    private SerializedProperty prop;
    private SerializedProperty bindPropName;
    private SerializedProperty bindComponent;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var initPos = position;
        initPos.height = EditorGUIUtility.singleLineHeight;
        initPos.width = EditorGUIUtility.currentViewWidth;

        var pos1 = position;
        pos1.width = EditorGUIUtility.currentViewWidth;
        pos1.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.BeginProperty(initPos, label, property);
        this.foldout = EditorGUI.BeginFoldoutHeaderGroup(initPos, this.foldout, property.name);
        if (foldout)
        {
            this.prop = property.FindPropertyRelative("Value");
            bindComponent = property.FindPropertyRelative("BindComponent");
            bindPropName = property.FindPropertyRelative("BindPropertyName");

            var target = property.serializedObject.targetObject;
            var modelProp = fieldInfo.GetValue(target) as SpriteModelProperty;
            var pos2 = new Rect(pos1);
            pos2.y += EditorGUIUtility.singleLineHeight;
            pos2.width = EditorGUIUtility.currentViewWidth * 0.7f;
            var pos3 = new Rect(pos2);
            pos3.x = 20;
            pos3.y += EditorGUIUtility.singleLineHeight;
            var pos4 = new Rect(pos3);
            pos4.x = 20;
            pos4.y += EditorGUIUtility.singleLineHeight;
            var pos5 = new Rect(pos2);
            pos5.x += 280;
            pos5.width = 50;
            var pos6 = new Rect(pos4);
            pos6.y += EditorGUIUtility.singleLineHeight;
            pos6.width = 100;
            pos6.height = 100;


            EditorGUI.PropertyField(pos2, prop);
            EditorGUI.PropertyField(pos3, bindComponent);
            EditorGUI.PropertyField(pos4, bindPropName);
            if (GUI.Button(pos5, "Bind"))
            {
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                    new PropertySearchWindow(target, modelProp.AllowTypes, (prop, com) =>
                    {
                        modelProp.BindPropertyName = prop.Name;
                        modelProp.BindComponent = com;

                    }));
            }

            if (modelProp.BindPropertyName != string.Empty && modelProp.BindPropertyName != null
                && modelProp.GetBindValue() != null)
                EditorGUI.DrawPreviewTexture(pos6, modelProp.GetBindValue().texture);
        }

        EditorGUI.EndFoldoutHeaderGroup();
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = foldout ? 150 : 0;
        return base.GetPropertyHeight(property, label) + height;
    }
}

[CustomPropertyDrawer(typeof(StateModelProperty))]
public class StateModelPropertyEditor : PropertyDrawer
{
    private bool foldout;
    private SerializedProperty prop;
    private SerializedProperty bindPropName;
    private SerializedProperty bindComponent;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        var initPos = position;
        initPos.height = EditorGUIUtility.singleLineHeight;
        initPos.width = EditorGUIUtility.currentViewWidth;

        var pos1 = position;
        pos1.width = EditorGUIUtility.currentViewWidth;
        pos1.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.BeginProperty(initPos, label, property);
        this.foldout = EditorGUI.BeginFoldoutHeaderGroup(initPos, this.foldout, property.name);
        if (foldout)
        {
            this.prop = property.FindPropertyRelative("Value");
            bindComponent = property.FindPropertyRelative("BindComponent");
            bindPropName = property.FindPropertyRelative("BindPropertyName");

            var target = property.serializedObject.targetObject;
            var modelProp = fieldInfo.GetValue(target) as StateModelProperty;
            var pos2 = new Rect(pos1);
            pos2.y += EditorGUIUtility.singleLineHeight;
            pos2.width = EditorGUIUtility.currentViewWidth * 0.7f;
            var pos3 = new Rect(pos2);
            pos3.x = 20;
            pos3.y += EditorGUIUtility.singleLineHeight;
            var pos4 = new Rect(pos3);
            pos4.x = 20;
            pos4.y += EditorGUIUtility.singleLineHeight;
            var pos5 = new Rect(pos2);
            pos5.x += 280;
            pos5.width = 50;
            var pos6 = new Rect(pos4);
            pos6.y += EditorGUIUtility.singleLineHeight;
            pos6.width = 100;
            pos6.height = 100;


            EditorGUI.PropertyField(pos2, prop);
            EditorGUI.PropertyField(pos3, bindComponent);
            EditorGUI.PropertyField(pos4, bindPropName);
            if (GUI.Button(pos5, "Bind"))
            {
                SearchWindow.Open(new SearchWindowContext(GUIUtility.GUIToScreenPoint(Event.current.mousePosition)),
                    new PropertySearchWindow(target, modelProp.AllowTypes, (prop, com) =>
                    {
                        modelProp.BindPropertyName = prop.Name;
                        modelProp.BindComponent = com;

                    }));
            }

            if (modelProp.BindPropertyName != string.Empty && modelProp.BindPropertyName != null)
                EditorGUI.ColorField(pos6, modelProp.GetBindValue());
        }

        EditorGUI.EndFoldoutHeaderGroup();
        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        var height = foldout ? 150 : 0;
        return base.GetPropertyHeight(property, label) + height;
    }
}

