using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BattleCharacter : Character { 
    public int maxHP;//最大血量
    public int currHP;//当前血量
    public int maxEP;//最大体力
    public int currEP;//当前体力
    public int armor;//护甲值
    public int atk;//攻击力
    public int def = 0;//防御力
    public int speed;//速度
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
        currHP = maxHP = health.value;
        currEP = maxEP = energy.value;
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
