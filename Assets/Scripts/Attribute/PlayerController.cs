using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //声明两个类，直接写成变量也是可以的。

    public class Ability
    {
        public string name;
        public int value;
       
        public Ability(string _name, int _value)
        {
            name = _name;
            value = _value;
        }
    }
    public class SubjectScore
    {
        public string name;
        public int value;

        public SubjectScore(string _name, int _value)
        {
            name = _name;
            value = _value;
        }
    }

    // 声明各种能力的变量
    public Ability liliang = new Ability("力量", 0);//力量
    public Ability tounao = new Ability("头脑", 0);//头脑
    public Ability meili = new Ability("魅力", 0);//魅力

    //声明各种学科的变量(两个类可以合在一块写，看之后开发有没有需求)
    public SubjectScore jianshu = new SubjectScore("剑术", 0);//剑术
    public SubjectScore xinyang = new SubjectScore("信仰", 0);//信仰
    public SubjectScore liyi = new SubjectScore("礼仪", 0);//礼仪

 
    
    private int _xingdongli = 100;//行动力
    //封装,可写可不写、看设计需求。
    public GameObject meiyouxingdongli;
    public int xindongli
    {
        get { return _xingdongli; }
        set
        {
            // 确保行动力不小于0
            _xingdongli = Mathf.Max(value, 0);
            // 设置一个最大行动力100
            _xingdongli = Mathf.Min(_xingdongli, 100);

            // 如果要执行其他逻辑（例如在行动值、或者心情、金币变化时播放动画），可以在这里添加代码
            
            // 如果行动力、心情小于等于0，执行无体力事件
            if (_xingdongli <= 0)
            {
                meiyouxingdongli.GetComponent<Animator>().enabled =true;
            }
        }
    }


    public int jinbi = 0;//金币
    public int xinqing = 100;//心情

    // UI Text 组件引用
    
    public Text xingdongliText;//行动力
    public Text jinbiText;//金币
    public Text xinqingText;//心情

    //主要属性
    public Text liliangText;//力量
    public Text tounaoText;//头脑
    public Text meiliText;//魅力

    //课程
    public Text jiangshuText;//剑术
    public Text xinyangText;//信仰
    public Text liyiText;//礼仪

    // 更新 UI 的方法
    void UpdateUI()
    {
        //基础属性
        liliangText.text = "力量: " + liliang.value.ToString();
        tounaoText.text = "头脑: " + tounao.value.ToString();
        meiliText.text = "魅力: " + meili.value.ToString();

        //学科
        jiangshuText.text = jianshu.value.ToString();
        xinyangText.text = xinyang.value.ToString();
        liyiText.text =  liyi.value.ToString();

        //行动力、金币、心情
        xingdongliText.text = "行动力" + _xingdongli.ToString();
        jinbiText.text ="金币" + jinbi.ToString();
        xinqingText.text ="心情" + xinqing.ToString();

    }

    public void ModifyAbility(string abilityName, int modifier)//修改能力、修改课程分数复制粘贴稍加修改即可。
    {
        switch (abilityName)
        {
            case "力量"://加一个判定防止数据溢出或者为负数
                liliang.value += modifier;
                if (liliang.value < 0)
                    liliang.value = 0;
                break;
            case "头脑":
                tounao.value += modifier;
                break;
            case "魅力":
                meili.value += modifier;
                break;
                
                //可以将行动力、课程等数据放在此处、也可另写一个方法

            default:
                Debug.LogWarning("没有该能力： " + abilityName);
                break;
        }
    }

    void Start()
    {
        // 初始化时更新 UI
        UpdateUI();
    }
    void Update()
    {
        UpdateUI();
    }
}

