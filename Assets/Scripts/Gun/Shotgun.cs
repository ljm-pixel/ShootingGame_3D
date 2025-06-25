using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    private int bulletNum;
    public float bulletAngle = 7.5f;

    protected override void Fire()
    {
        interval = 1.5f - (GameData.Instance.player.AttackSpeed * 0.1f);
        //animator.SetTrigger("Shoot");
        bulletNum = GameData.Instance.player.ShotgunBulletNum;
        int median = bulletNum / 2;
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            bullet.transform.position = bulletPos.position;

            if (bulletNum % 2 == 1)
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median), Vector3.up) * bulletPos.forward);
            }
            else
            {
                bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(bulletAngle * (i - median) + bulletAngle / 2, Vector3.up) * bulletPos.forward);
            }
        }

        PlaySound();

        GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        shell.transform.position = shellPos.position;
        shell.transform.rotation = shellPos.rotation;
    }

    public override string HintText()
    {
        return "消耗 8 点生命值，获得该武器";
    }
}
