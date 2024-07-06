using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
public class AttributeAlter : MonoBehaviour
{
    public AttributeController Controller;

    public List<string> names;//需要改变的属性名称
    public List<int> change_vals;//改变值

    private void Start()
    {
        Controller = GetComponent<AttributeController>();
    }
    public void attributeAlter()
    {
        for(int i = 0; i < names.Count; i++)
        {
            if (Controller.Attributes.ContainsKey(names[i]))
            {
                Controller.Attributes[names[i]].value += change_vals[i];
            }
            else
            {
                Debug.LogError("属性中没有" + names[i]);
            }
        }
    }
}
