using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : ScriptableObject {

    public new string name;//����
    public int cooldownTime;//��ȴʱ��
    public int cost;//��������
    public BattleCharacter Target;

    public virtual void Active(BattleCharacter Starter, BattleCharacter Target) { }

}
