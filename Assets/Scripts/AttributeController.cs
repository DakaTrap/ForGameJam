using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribute
{
    public string name;//��������
    #region ����ֵ
    public int value//����ֵ
    {
        get { return _value; }
        set { _value = Mathf.Clamp(value, 0, valMax); }
    }
    public int valMax;//�������ֵ
    private int _value;
    #endregion
    public int baseIncreasePerTurn;//ÿ�غ�������
    public float increaseSpeed = 1f;//�������ʣ������ٶȣ�
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

    public Attribute Population = new("�˿�",0,int.MaxValue,1);
    public Attribute Resource = new("��Դ",0,int.MaxValue,1);
    public Attribute Chaos = new("����",0,100,1);

    public Attribute Biology = new("����ѧ",0,100,1);
    public Attribute Physics = new("����ѧ", 0, 100, 1);
    public Attribute Sociology = new("���ѧ", 0, 100, 1);

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
