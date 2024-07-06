using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Attack : Ability {
    // Start is called before the first frame update
    public override void Active(BattleCharacter Starter, BattleCharacter Target)
    {
        int dmg = Starter.atk - (Target.def / 2);
        dmg = Mathf.Clamp(dmg, 1, Starter.atk);

        if (Target.armor > 0)
        {
            Target.currHP -= Mathf.Clamp(dmg - Target.armor, 0, dmg);
            Target.armor = Mathf.Clamp(Target.armor - dmg, 0, Target.armor);
            
        }
        else
        {
            Target.currHP -= dmg;
        }
        Starter.currEP -= cost;
    }
}

