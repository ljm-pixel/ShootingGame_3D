using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//数值：
//玩家  功Atk10   血 10   治疗量 1   功速Speed 1 (最大为10)   子弹数量（共用） 50
//受到伤害的频率 0.5   最大0.1 每层减0.025

//武器 
//霰弹枪 子弹数 3 颗(最大8颗)  伤害 = Atk*0.05   功速 1.5 - Speed*0.1 (最小是 0.5)
//步枪  伤害 = Atk*0.1  功速 = 1 - Speed*0.07 (最小是 0.3)
//刀 伤害 Atk*0.5

//怪物   生成频率 3到5秒  
//大的 伤害 3 血量 7 移速 1
//中的 伤害 2 血量 5 移速 1.5
//小的 伤害 1 血量 2 移速 2
//🥚   伤害 1 血量 3 移速 1.5
//每层加1血 加0.5攻 

//时间：每层加10秒

//音效数据

public class GameData : MonoBehaviour
{
    private static GameData instance = new GameData();
    public static GameData Instance => instance;

    public GameObject Player;
    public Player player;

    //怪物血量
    private float monsterHealth = 1f;
    //怪物伤害
    private float monsterAttack = 1f;
    //怪物移速
    private float monsterSpeed = 1f;

    public float MonsterHealth
    {
        get { return monsterHealth; }
        set { monsterHealth = value; }
    }
    public float MonsterAttack
    {
        get { return monsterAttack; }
        set { monsterAttack = value; }
    }
    public float MonsterSpeed
    {
        get { return monsterSpeed; }
        set { monsterSpeed = value; }
    }

    void Awake()
    {
        instance = this;
        player = Player.GetComponent<Player>();
    }
}
