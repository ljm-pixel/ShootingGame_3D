using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egglet : Monster
{
    protected override void Initialize()
    {
        speed = GameData.Instance.monsterData.dataDic[1].speed;
        damage = GameData.Instance.monsterData.dataDic[1].attack;
        maxHealth = GameData.Instance.monsterData.dataDic[1].health;
    }
}
