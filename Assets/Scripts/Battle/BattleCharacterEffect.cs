using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class BattleCharacterEffect : MonoBehaviour
{ 
    public GameObject shieldPrefab;
    public GameObject Shield;
    public bool isPlayer;
    public void Start()
    {
        if(isPlayer)
            EventCenter.AddListener<BattleCharacter>(EventType.PlayerEffectUpdate, UpdateShieldEffect);
        else{
            EventCenter.AddListener<BattleCharacter>(EventType.EnemyEffectUpdate, UpdateShieldEffect);
        }
    }

    void UpdateShieldEffect(BattleCharacter character) {
       
            if (character.armor > 0 && Shield == null)
            {
                Shield = Instantiate(shieldPrefab, character.transform);
            }
            else if (character.armor <= 0 && Shield != null)
            {
                DestroyImmediate(Shield);
            }    
    }

}
