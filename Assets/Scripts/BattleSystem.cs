using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState
{
    Start,PlayerTurn,PlayerActive,EnemyTurn,EnemyActive,End
}

public class BattleSystem : MonoBehaviour
{

    public BattleState state;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerTransform;
    public Transform enemyTransform;
    [HideInInspector]
    public BattleCharacter player;
    [HideInInspector]
    public BattleCharacter enemy;

    void Start()
    {
        state = BattleState.Start;
        StartCoroutine(SetupBattle());      
    }
    #region �غ����API
    IEnumerator SetupBattle()
    {
        #region ���س��Ͻ�ɫ
        GameObject player_go = Instantiate(playerPrefab,playerTransform);
        player = player_go.GetComponent<BattleCharacter>();
        player.InitialData();
        GameObject enemy_go = Instantiate(enemyPrefab,enemyTransform);
        enemy = enemy_go.GetComponent<BattleCharacter>();
        enemy.InitialData();
        #endregion

        #region ��ʾս����ʼǰ���ı�
        yield return new WaitForSeconds(1f);
        EventCenter.BroadCast(EventType.BattleStart);
        #endregion

        #region ��һ���غϵ��ж�
        FirstTurnJudge(player,enemy);
        switch (state)
        {
            case BattleState.PlayerTurn:
                StartCoroutine(PlayerTurn());    
                break;
            case BattleState.EnemyTurn:
                StartCoroutine(EnemyTurn());
                break;
            default:
                Debug.Log("�غ�״̬����");
                break;

        }
        #endregion 

        yield return null;
    }

    public IEnumerator PlayerTurn()
    {
        EventCenter.BroadCast(EventType.PlayerTurn);
        if (player.currHP <= 0)
        {
            StartCoroutine(EndTurn());
            yield return null;
        }else{
            player.currEP = Mathf.Clamp(player.currEP + 1,0,player.maxEP);
            SceneUpdate();
            state = BattleState.PlayerActive;
        }
    }

    public IEnumerator EnemyTurn()
    {
        EventCenter.BroadCast(EventType.EnemyTurn);
        if (enemy.currHP <= 0)
        {
            StartCoroutine(EndTurn());
            yield return null;
        }else{
            SceneUpdate();
            StartCoroutine(EnemyActive());
        }
    }

    public IEnumerator EndTurn()
    {
        state = BattleState.End;
        bool isWin;
        if(enemy.currHP <= 0){
            isWin = true;
        }else{
            isWin = false;
        }
        SceneUpdate();
        EventCenter.BroadCast(EventType.BattleEnd,isWin);
        yield return null;
    }

    void SceneUpdate()
    {
        EventCenter.BroadCast(EventType.PlayerEffectUpdate, player);
        EventCenter.BroadCast(EventType.EnemyEffectUpdate, enemy);
    }

    private void FirstTurnJudge(BattleCharacter player, BattleCharacter enemy)
    {
        if (player.speed >= enemy.speed)
        {
            state = BattleState.PlayerTurn;
        }
        else
        {
            state = BattleState.EnemyTurn;
        }
    }

    #endregion

    #region ������ΪAPI
    IEnumerator EnemyActive()
    {
        //�����ǵ��˵�AI�߼��жϣ������Ľ�
        if (enemy.currHP <= 50)
        {
            StartCoroutine(EnemyDefence());
        }
        else
        {
            StartCoroutine(EnemyAttack());
        }
        yield return null;
    }

    IEnumerator EnemyAttack()
    {
        state = BattleState.EnemyActive;
        EventCenter.BroadCast(EventType.EnemyActive, enemy.FindAbility("Attack"), player);
        yield return new WaitForSeconds(1f);
        StartCoroutine(PlayerTurn());
    }

    IEnumerator EnemyDefence()
    {
        state = BattleState.EnemyActive;
        EventCenter.BroadCast(EventType.EnemyActive, enemy.FindAbility("Defence"),enemy);
        yield return new WaitForSeconds(1f);
        StartCoroutine(PlayerTurn());
    }

    #endregion

}
