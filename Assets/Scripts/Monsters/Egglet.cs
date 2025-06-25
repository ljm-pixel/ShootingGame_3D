using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egglet : Monster
{
    protected override void Initialize()
    {
        maxHealth = GameData.Instance.MonsterHealth * 3f;
        damage = GameData.Instance.MonsterAttack;
        speed = GameData.Instance.MonsterSpeed * 1.5f;
    }
}
