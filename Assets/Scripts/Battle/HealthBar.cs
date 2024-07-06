using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public BattleSystem battleSystem;

    public BattleCharacter player;
    public Image hpImage_player;
    public Image loadImage_player;
    public Text player_text;
    public int maxHP_player;
    public int currHP_player;

    private Coroutine updateCoroutine_player;

    public BattleCharacter enemy;
    public Image hpImage_enemy;
    public Image loadImage_enemy;
    public Text enemy_text;
    public int maxHP_enemy;
    public int currHP_enemy;

    public float BuffTime = 0.5f;

    private Coroutine updateCoroutine_enemy;
    private void Start()
    {     
        EventCenter.AddListener(EventType.PlayerTurn,SetHealth);
        EventCenter.AddListener(EventType.EnemyTurn, SetHealth);
        hpImage_player.fillAmount = 1;
        loadImage_player.fillAmount = 1;
        hpImage_enemy.fillAmount = 1;
        loadImage_enemy.fillAmount = 1;
    }

    void SetHealth()
    {
        player = battleSystem.player;
        enemy = battleSystem.enemy;
        InitialHealth(player,maxHP_player,currHP_player,hpImage_player,player_text);
        InitialHealth(enemy,maxHP_enemy,currHP_enemy,hpImage_enemy,enemy_text);

        updateCoroutine_player = StartCoroutine(UpdateHP(player,hpImage_player,loadImage_player,player_text));
        updateCoroutine_enemy = StartCoroutine(UpdateHP(enemy,hpImage_enemy,loadImage_enemy,enemy_text));
    }

    void InitialHealth(BattleCharacter character,int maxhp,int currhp,Image hpImage,Text text)
    {        
        maxhp = character.maxHP;
        currhp = Mathf.Clamp(character.currHP, 0, maxhp);
        hpImage.fillAmount = (float)currhp / (float)maxhp;
        text.text = currhp + "/" +maxhp;
    }

    private IEnumerator UpdateHP(BattleCharacter character,Image hpImage,Image loadImage,Text text)
    {     
        float loadlenth = loadImage.fillAmount - hpImage.fillAmount;
        float elapsedTime = 0f;

        while(elapsedTime < BuffTime && loadlenth != 0)
        {
            elapsedTime += Time.deltaTime;
            loadImage.fillAmount = Mathf.Lerp(hpImage.fillAmount + loadlenth, hpImage.fillAmount, elapsedTime / BuffTime);
            yield return null;
        }
        loadImage.fillAmount = hpImage.fillAmount;

        text.text = character.currHP + "/" + character.maxHP;
    }

}
