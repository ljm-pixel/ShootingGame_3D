using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Monster
{
protected override void Initialize()
    {
        speed = GameData.Instance.monsterData.dataDic[4].speed;
        damage = GameData.Instance.monsterData.dataDic[4].attack;
        maxHealth = GameData.Instance.monsterData.dataDic[4].health;
    }
}
