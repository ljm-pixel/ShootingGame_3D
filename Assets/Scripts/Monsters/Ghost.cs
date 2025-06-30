using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    protected override void Initialize()
    {
        speed = GameData.Instance.monsterData.dataDic[2].speed;
        damage = GameData.Instance.monsterData.dataDic[2].attack;
        maxHealth = GameData.Instance.monsterData.dataDic[2].health;
    }
}
