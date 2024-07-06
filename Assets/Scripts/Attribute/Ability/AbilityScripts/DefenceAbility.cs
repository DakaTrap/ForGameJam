using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Defence : Ability
{
    public override void Active(BattleCharacter Starter, BattleCharacter Target)
    {
        Target.armor += Target.def/2;
        Starter.currEP -= cost;
    }
}
