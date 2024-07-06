using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    public string name;//属性名称
    #region 属性值
    public int value//属性值
    {
        get { return _value; }
        set { _value = Mathf.Clamp(value, 0, valMax); }
    }
    public int valMax;//属性最大值
    private int _value;
    #endregion
    public int baseIncreasePerTurn;//每回合增长量
    public float increaseSpeed = 1f;//增长倍率（增长速度）
    public Attribute(string name, int value, int valMax, int increasePerTurn)
    {
        this.name = name;
        this.value = value;
        this.valMax = valMax;
        this.baseIncreasePerTurn = increasePerTurn;
    }
}
public enum AgeType
{
    Original,Feudalism,Renaissance,Modern,Future
}
public class AttributeController : MonoSingleton<AttributeController> {

    public AgeType age;

    public Dictionary<string,Attribute> Attributes = new Dictionary<string,Attribute>();

    public Attribute Population = new("人口",0,int.MaxValue,1);
    public Attribute Resource = new("资源",0,int.MaxValue,1);
    public Attribute Chaos = new("混乱",0,100,1);

    public Attribute Biology = new("生物学",0,100,1);
    public Attribute Physics = new("物理学", 0, 100, 1);
    public Attribute Sociology = new("社会学", 0, 100, 1);

    public void UpdateAttribute()
        {
        Population.value = (int)(Population.baseIncreasePerTurn * Population.increaseSpeed);
        Resource.value = (int)(Resource.baseIncreasePerTurn * Resource.increaseSpeed);
        Chaos.value = (int)(Chaos.baseIncreasePerTurn * Chaos.increaseSpeed);

        float productivity = (float)Resource.value / (float)Population.value - (float)(Chaos.value/Chaos.valMax);

        Biology.value = (int)(Biology.baseIncreasePerTurn * Biology.increaseSpeed * productivity);
        Physics.value = (int)(Physics.baseIncreasePerTurn * Physics.increaseSpeed * productivity);
        Sociology.value = (int)(Sociology.baseIncreasePerTurn * Sociology.increaseSpeed * productivity);
    }

    // Start is called before the first frame update
    void Start()
    {
        Attributes.Add(Population.name, Population);
        Attributes.Add(Resource.name, Resource);
        Attributes.Add(Chaos.name, Chaos);
        Attributes.Add(Biology.name, Biology);
        Attributes.Add(Physics.name, Physics);
        Attributes.Add(Sociology.name, Sociology);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
