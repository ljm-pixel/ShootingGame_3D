using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BasePanel<GameUI>
{
    public Text buffHint;
    public GameObject monsterSpawner;
    public Transform PlayerPos;
    public RectTransform currentHealth;
    public RectTransform maxHealth;
    public RectTransform minHealth;
    public Text currentHealthText;
    public Text attackText;
    public Text attackSpeedText;
    public Text bulletNumText;

    private bool isSpawner = false;
    public override void Init()
    {
        HideMe();
    }

    private void OnEnable()
    {
        CloseMouse();

        if (!isSpawner)
        {
            isSpawner = true;
            return; 
        }
        CountdownTimer.Instance.TheNextLevel();
        MonsterSpawner spawner = monsterSpawner.GetComponent<MonsterSpawner>();
        spawner.StartSpawner();
    }
    public void StartGame()
    {
        ShowMe();
        //CountdownTimer.Instance.TheNextLevel();
        CountdownTimer.Instance.StartCountdown();
        //MonsterSpawner spawner = monsterSpawner.GetComponent<MonsterSpawner>();
        //spawner.StartSpawner();
    }

    public void StopGame()
    {
        MonsterSpawner spawner = monsterSpawner.GetComponent<MonsterSpawner>();
        spawner.StopSpawner();
        HideMe();
    }

    public void SetBuffHint(string hint)
    {
        if(buffHint != null)
        {
            buffHint.text = hint;
            Invoke("ClearBuffHint", 2f);
        }
    }
    public void ClearBuffHint()
    {
        buffHint.text = "";
    }

    public Transform GetPlayerPos()
    {
        return PlayerPos;
    }

    public void SetHealthText(float healthRatio)
    {
        //print("血量"+healthRatio);
        float x = (maxHealth.position.x - minHealth.position.x) * healthRatio - 47f;
        //print(x);
        //print(maxHealth.position.x);
        //print(minHealth.position.x);
        currentHealth.position = new Vector3(x, currentHealth.position.y, currentHealth.position.z);
    }
    public void SetCurrentHealthText(float currentHealth)
    {
        currentHealthText.text = currentHealth.ToString();
    }
    public void SetAttackText(float attack)
    {
        attackText.text = attack.ToString();
    }
    public void SetAttackSpeedText(float attackSpeed)
    {
        attackSpeedText.text = attackSpeed.ToString();
    }
    public void SetBulletNumText(int bulletNum)
    {
        bulletNumText.text = bulletNum.ToString();
    }
}
