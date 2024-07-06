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
    public Prop health = new Prop("����",100);
    public Prop energy = new Prop("����",100);

    public Prop strength = new Prop("����", 0);//����
    public Prop wisdom = new Prop("ͷ��", 0);//ͷ��
    public Prop charm = new Prop("����", 0);//����

    public Prop swordsmanship = new Prop("����", 0);//����
    public Prop belief = new Prop("����", 0);//����
    public Prop protocol = new Prop("����", 0);//����



    private int _actionPoint = 100;//�ж���
    //��װ,��д�ɲ�д�����������

    public int actionPoint
    {
        get { return _actionPoint; }
        set
        {
            // ȷ���ж�����С��0
            _actionPoint = Mathf.Max(value, 0);
            // ����һ������ж���100
            _actionPoint = Mathf.Min(_actionPoint, 100);

            // ���Ҫִ�������߼����������ж�ֵ���������顢��ұ仯ʱ���Ŷ�������������������Ӵ���
        }
    }


    public int coin = 0;//���
    public int mood = 100;//����
    public void ModifyAbility(string abilityName, int modifier)//�޸��������޸Ŀγ̷�������ճ���Լ��޸ļ��ɡ�
    {
        switch (abilityName)
        {
            case "����"://��һ���ж���ֹ�����������Ϊ����
                strength.value += modifier;
                if (strength.value < 0)
                    strength.value = 0;
                break;
            case "ͷ��":
                wisdom.value += modifier;
                break;
            case "����":
                charm.value += modifier;
                break;

            //���Խ��ж������γ̵����ݷ��ڴ˴���Ҳ����дһ������

            default:
                Debug.LogWarning("û�и������� " + abilityName);
                break;
        }
    }

}
