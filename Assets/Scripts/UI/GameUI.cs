using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : BasePanel<GameUI>
{
    public Text buffHint;
    public GameObject monsterSpawner;
    public Transform PlayerPos;
    public Transform currentHealth;
    public Transform maxHealth;
    public Transform minHealth;
    public Text currentHealthText;
    public Text attackText;
    public Text attackSpeedText;
    public Text bulletNumText;

    private bool isSpawner = false;
    public override void Init()
    {
        // maxHealth = currentHealth;
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
        // 确保比例在 [0,1] 范围内
        healthRatio = Mathf.Clamp01(healthRatio);
        float targetX = Mathf.Lerp(minHealth.position.x, maxHealth.position.x, healthRatio);

        Vector3 newPos = new Vector3(targetX, currentHealth.position.y, currentHealth.position.z);
        currentHealth.position = newPos;
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
