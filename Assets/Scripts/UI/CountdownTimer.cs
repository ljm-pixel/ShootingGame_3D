using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : BasePanel<CountdownTimer>
{
    public Text countdownText;  // 拖入倒计时 Text 组件
    private float totalTime = 20f; // 总倒计时时间（秒）
    public bool autoStart = false; // 是否自动开始倒计时
    public Text levelText;
    public GameObject ExplosionProp;
    private int levelNum = 0;

    private float currentTime;
    private bool isCounting = false;

    public override void Init()
    {
        if (autoStart) 
            StartCountdown();
    }

    // 外部调用启动倒计时
    public void StartCountdown()
    {
        currentTime = totalTime;
        isCounting = true;
    }

    void Update()
    {
        if (!isCounting) return;

        currentTime -= Time.deltaTime;
        UpdateDisplay(currentTime);

        if (currentTime <= 0)
        {
            currentTime = 0;
            isCounting = false;
            OnCountdownEnd();
        }

        if (currentTime <= 10f)
        {
            countdownText.color = Color.red;
            countdownText.fontStyle = FontStyle.Bold;
        }
        else
        {
            countdownText.color = Color.white;
            countdownText.fontStyle = FontStyle.Normal;
        }
    }

    void UpdateDisplay(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        //int milliseconds = Mathf.FloorToInt((time * 1000) % 1000);

        // 格式示例1: "01:23"
        countdownText.text = $"{minutes:00}:{seconds:00}";

        // 格式示例2: "01:23.456"
        // countdownText.text = $"{minutes:00}:{seconds:00}.{milliseconds:000}";
    }

    void OnCountdownEnd()
    {
        Debug.Log("倒计时结束！");
        // 触发自定义事件（如游戏结束、播放音效等）
        LevelUI.Instance.ShowMe();
        GameUI.Instance.StopGame();

        ExplodeProp explodeProp = new ExplodeProp();
        explodeProp.TriggerEffect();
        //GameObject monster = ObjectPool.Instance.GetObject(ExplosionProp);
        //monster.transform.position = GameUI.Instance.GetPlayerPos().position;
    }

    public void PauseCountdown()
    {
        isCounting = false;
    }

    public void ResumeCountdown()
    {
        isCounting = true;
    }

    //  增加时间
    public void AddTime(float extraSeconds)
    {
        currentTime = Mathf.Min(currentTime + extraSeconds, totalTime);
    }
    // 设置时间
    public void SetTime(float newTime)
    {
        currentTime = Mathf.Clamp(newTime, 0, totalTime);
        UpdateDisplay(currentTime);
    }

    //  设置总时间
    public void SetTotalTime(float totalTime)
    {
        this.totalTime = totalTime;
    }
    public float GetTotalTime()
    {
        return totalTime;
    }

    public void TheNextLevel()
    {
        totalTime += 10;
        levelText.text = "第 " + ++levelNum + " 层";
        //if(GameData.Instance.player.BeInjuredIntervalTime > 0.1f)
        //    GameData.Instance.player.BeInjuredIntervalTime -= 0.025f;//  每层减0.025
        GameData.Instance.MonsterAttack += 0.5f;
        GameData.Instance.MonsterHealth += 0.3f;
        //if(GameData.Instance.MonsterSpeed < 2f)
        //    GameData.Instance.MonsterSpeed += 0.1f;
    }
}
