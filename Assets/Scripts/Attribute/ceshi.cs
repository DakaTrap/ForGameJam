using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ceshi : MonoBehaviour//在外部填写要改变的数值
{
    public PlayerController playerControlled;
    public string[] shuxing;//属性
    public int[] shuzhi;//数值


   public void tianjia()
    {
            playerControlled.ModifyAbility(shuxing[0], shuzhi[0]);
        playerControlled.ModifyAbility(shuxing[1], shuzhi[1]);
        playerControlled.ModifyAbility(shuxing[2], shuzhi[2]);
    }

    public void jianshao()
    {
        playerControlled.xindongli -= 20;

    }
    public void TJ()
    {
        playerControlled.xindongli += 20;

    }
}


