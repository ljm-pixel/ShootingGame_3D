using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Monster
{
    protected override void Initialize()
    {
        maxHealth = GameData.Instance.MonsterHealth * 7f;
        damage = GameData.Instance.MonsterAttack * 3f;
        speed = GameData.Instance.MonsterSpeed;
    }
}
