using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
public class AttributeAlter : MonoBehaviour
{
    public AttributeController Controller;

    public List<string> names;//��Ҫ�ı����������
    public List<int> change_vals;//�ı�ֵ

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
                Debug.LogError("������û��" + names[i]);
            }
        }
    }
}
