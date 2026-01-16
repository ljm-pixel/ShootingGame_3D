using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phantom : Monster
{
    protected override void Initialize()
    {
        speed = GameData.Instance.monsterData.dataDic[3].speed;
        damage = GameData.Instance.monsterData.dataDic[3].attack;
        maxHealth = GameData.Instance.monsterData.dataDic[3].health;
    }
}
