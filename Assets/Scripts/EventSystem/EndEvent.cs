using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndEvent : Event
{
    public Button btn_1;
    public Button btn_2;
    void Start()
    {
        buttons.Add(btn_1);
        btn_1.onClick.AddListener(() =>
        {
        
        });
        buttons.Add(btn_2);
    }

    void option1()
    {

    }
}


