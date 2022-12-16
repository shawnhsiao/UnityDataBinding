using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class PropertySearchWindow : ScriptableObject, ISearchWindowProvider
{
    public class SearchInfo
    {
        public PropertyInfo PropertyInfo;
        public Component Component;
    }
    public Action<PropertyInfo, Component> OnSelected;
    private UnityEngine.Object target;
    private List<Type> AllowTypes;

    public PropertySearchWindow(UnityEngine.Object target, List<Type> allowTypes, Action<PropertyInfo, Component> onSelected)
    {
        OnSelected = onSelected;
        this.target = target;
        this.AllowTypes = allowTypes;
    }

    public List<SearchTreeEntry> CreateSearchTree(SearchWindowContext context)
    {
        var tree = new List<SearchTreeEntry>()
        {
            new SearchTreeGroupEntry(new GUIContent("Search property"),0)
        };

        var childs = target.GetComponentsInChildren<Transform>();
        foreach (var child in childs)
        {
            tree.Add(new SearchTreeGroupEntry(new GUIContent(child.name), 1));
            var components = child.GetComponents(typeof(Component));
            foreach (var component in components)
            {
                tree.Add(new SearchTreeGroupEntry(new GUIContent(component.GetType().Name), 2));
                var properties = component.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    if (AllowTypes.Contains(prop.PropertyType))
                    {
                        tree.Add(new SearchTreeEntry(new GUIContent(prop.Name)) { level = 3, userData = new SearchInfo() { PropertyInfo = prop, Component = component } });
                    }
                }
            }
        }

        return tree;
    }

    public bool OnSelectEntry(SearchTreeEntry SearchTreeEntry, SearchWindowContext context)
    {
        var select = (SearchTreeEntry.userData as SearchInfo);
        OnSelected?.Invoke(select.PropertyInfo, select.Component);

        return true;
    }
}



