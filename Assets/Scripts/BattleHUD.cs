using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [HideInInspector]
    public BattleSystem battleSystem;
    [HideInInspector]
    public BattleCharacter player;
    [HideInInspector]
    public BattleCharacter enemy;
    public Button attkButton;
    public Button DefButton;
    public GameObject go_EndText;
    public GameObject go_BackToMain;
    void Start()
    {
        attkButton.interactable = false;
        DefButton.interactable = false;
        go_EndText.SetActive(false);
        go_BackToMain.SetActive(false);
        battleSystem = GameObject.Find("BattleSystem").GetComponent<BattleSystem>();
        EventCenter.AddListener(EventType.PlayerTurn, PlayerTurnHUD);
        EventCenter.AddListener(EventType.EnemyTurn, EnemyTurnHUD);
        EventCenter.AddListener<bool>(EventType.BattleEnd,EndHUD);
    }
    public void PlayerTurnHUD()
    {
       
        if (player == null || enemy == null)
        {
            player = battleSystem.player;
            enemy = battleSystem.enemy;
        }
        attkButton.interactable = true;
        attkButton.onClick.AddListener(() => {
            EventCenter.BroadCast(EventType.PlayerActive, player.FindAbility("Attack"),enemy);
            StartCoroutine(SetState(BattleState.EnemyTurn));
            StartCoroutine(battleSystem.EnemyTurn());
        }); 

        DefButton.interactable = true;
        DefButton.onClick.AddListener(() => {
            EventCenter.BroadCast(EventType.PlayerActive, player.FindAbility("Defence"),player);
            StartCoroutine(SetState(BattleState.EnemyTurn));
            StartCoroutine(battleSystem.EnemyTurn());
        });
    }
    public void EnemyTurnHUD()
    {
        attkButton.interactable = false;
        attkButton.onClick.RemoveAllListeners();
        DefButton.interactable = false;
        DefButton.onClick.RemoveAllListeners();
    }

    IEnumerator SetState(BattleState newState) 
    { 
        yield return new WaitForSeconds(2f); 
        battleSystem.state = newState;
    }

    public void EndHUD(bool isWin)
    {
        
        go_EndText.SetActive(true);
        go_BackToMain.SetActive(true);
        Text text = go_EndText.GetComponent<Text>();
        attkButton.interactable = false;
        attkButton.onClick.RemoveAllListeners();
        DefButton.interactable = false;
        DefButton.onClick.RemoveAllListeners();
        if (isWin == true)
        {
            text.text = "πßœ≤£¨ƒ„”Æ¿≤£°";
        }
        else
        {
            text.text = "∫‹“≈∫∂£¨‘ŸΩ”‘Ÿ¿˜£°";
        }
    }

}
