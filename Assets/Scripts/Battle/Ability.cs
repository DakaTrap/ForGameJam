using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject {

    public new string name;//名字
    public int cooldownTime;//冷却时间
    public int cost;//体力消耗
    public BattleCharacter Target;

    public virtual void Active(BattleCharacter Starter, BattleCharacter Target) { }

}
