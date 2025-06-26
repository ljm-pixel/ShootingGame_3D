using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    protected override void OnEnable()
    {
        base.OnEnable();
        //speed = 15f + GameData.Instance.player.AttackSpeed;
        damage = GameData.Instance.player.Attack * 0.15f;
    }
}
