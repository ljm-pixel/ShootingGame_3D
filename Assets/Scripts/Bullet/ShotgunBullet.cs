using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : Bullet
{
    protected override void OnEnable()
    {
        fireSpeed = GameData.Instance.weaponData.dataDic[2].fireSpeed;
        damage = GameData.Instance.player.Attack * GameData.Instance.weaponData.dataDic[2].damage;
    }
}
