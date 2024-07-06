using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
   public class Prop
    {
        public string name;
        public int value;
        public Prop(string _name,int _value)
        {
            name = _name;
            value = _value;
        }
    }
    public Prop health = new Prop("生命",100);
    public Prop energy = new Prop("能量",100);

    public Prop strength = new Prop("力量", 0);//力量
    public Prop wisdom = new Prop("头脑", 0);//头脑
    public Prop charm = new Prop("魅力", 0);//魅力

    public Prop swordsmanship = new Prop("剑术", 0);//剑术
    public Prop belief = new Prop("信仰", 0);//信仰
    public Prop protocol = new Prop("礼仪", 0);//礼仪



    private int _actionPoint = 100;//行动力
    //封装,可写可不写、看设计需求。

    public int actionPoint
    {
        get { return _actionPoint; }
        set
        {
            // 确保行动力不小于0
            _actionPoint = Mathf.Max(value, 0);
            // 设置一个最大行动力100
            _actionPoint = Mathf.Min(_actionPoint, 100);

            // 如果要执行其他逻辑（例如在行动值、或者心情、金币变化时播放动画），可以在这里添加代码
        }
    }


    public int coin = 0;//金币
    public int mood = 100;//心情
    public void ModifyAbility(string abilityName, int modifier)//修改能力、修改课程分数复制粘贴稍加修改即可。
    {
        switch (abilityName)
        {
            case "力量"://加一个判定防止数据溢出或者为负数
                strength.value += modifier;
                if (strength.value < 0)
                    strength.value = 0;
                break;
            case "头脑":
                wisdom.value += modifier;
                break;
            case "魅力":
                charm.value += modifier;
                break;

            //可以将行动力、课程等数据放在此处、也可另写一个方法

            default:
                Debug.LogWarning("没有该能力： " + abilityName);
                break;
        }
    }

}
