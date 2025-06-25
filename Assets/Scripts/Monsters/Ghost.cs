using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Monster
{
    protected override void Initialize()
    {
        maxHealth = GameData.Instance.MonsterHealth * 2f;
        damage = GameData.Instance.MonsterAttack;
        speed = GameData.Instance.MonsterSpeed * 2f;
    }
}
