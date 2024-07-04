using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BattleCharacter : Character { 
    public int maxHP;//���Ѫ��
    public int currHP;//��ǰѪ��
    public int maxEP;//�������
    public int currEP;//��ǰ����
    public int armor;//����ֵ
    public int atk;//������
    public int def = 0;//������
    public int speed;//�ٶ�
    public bool isPlayer;

    [HideInInspector]
    public AbilityHolder abilityHolder;

    public void Start()
    {
        abilityHolder = GetComponent<AbilityHolder>();
        if (isPlayer == true)
        {
            EventCenter.AddListener<Ability, BattleCharacter>(EventType.PlayerActive, Active);
        }
        else
        {
            EventCenter.AddListener<Ability, BattleCharacter>(EventType.EnemyActive, Active);
        }
    }
    public void InitialData()
    {
        currHP = maxHP = health;
        currEP = maxEP = energy;
    }

    public void Active(Ability ability, BattleCharacter go)
    {
        if (ability.cost > currEP)
        {
            return;
        }      
            ability.Active(this, go);
    }
    public Ability FindAbility(string name)
    {
        foreach(Ability ability in abilityHolder.abilities)
        {
            if(ability.name == name) {  return ability; }
        }
        return null;
    }
}
