using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//A struct used to link a field to it's parent MonoBehaviour
public struct LinkedField
{
    public MonoBehaviour monoBehaviour;
    public FieldInfo field;

    public LinkedField(MonoBehaviour monoBehaviour, FieldInfo field)
    {
        this.monoBehaviour = monoBehaviour;
        this.field = field;
    }
}

//Defines the custom attribute that we use to detect whether to draw a variable.
[AttributeUsage(AttributeTargets.Field)]
public class DrawVectorAttribute : PropertyAttribute
{

    public readonly Color DrawColor;
    public DrawVectorAttribute(float r = 1, float g = 0, float b = 0, bool update = true)
    {
        DrawColor = new Color(r, g, b, 1);
    }

}

[ExecuteInEditMode]
public class VectorTracer : MonoBehaviour
{
    List<LinkedField> drawVectors = new List<LinkedField>();

    private void Awake()
    {
        MonoBehaviour[] monoBehaviours = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            FindVectors(monoBehaviour);
        }
    }

    void OnDrawGizmos()
    {
        UpdateAndDrawVectors();
    }

    //Something to do with C# reflection. I used a lot of tutorials so i have zero clue.
    public void FindVectors(MonoBehaviour monoBehaviour)
    {
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
        FieldInfo[] fields = monoBehaviour.GetType().GetFields(flags);
        foreach (FieldInfo field in fields)
        {
            DrawVectorAttribute drawVectorAttribute = field.GetCustomAttribute<DrawVectorAttribute>();
            if (drawVectorAttribute != null)
            {
                LinkedField linkedField = new LinkedField(monoBehaviour, field);
                drawVectors.Add(linkedField);
            }
        }
    }

    //Iterates through an array of linkedfields and draws the vectors.
    public void UpdateAndDrawVectors()
    {
        foreach (LinkedField linkedField in drawVectors)
        {
            Vector3 pos = linkedField.monoBehaviour.transform.position;
            Vector3 val = (Vector3)linkedField.field.GetValue(linkedField.monoBehaviour);
            Color col = linkedField.field.GetCustomAttribute<DrawVectorAttribute>().DrawColor;
            Debug.DrawRay(pos, val, col);
        }
    }
}



