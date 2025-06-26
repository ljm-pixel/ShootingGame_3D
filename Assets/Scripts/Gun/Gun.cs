using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    protected float interval = 1f;//发射间隔
    //private int numBullet; 
    public GameObject bulletPrefab;
    public GameObject shellPrefab;
    public GameObject muzzleFlarePrefab;
    public Transform bulletPos;
    public Transform shellPos;
    protected float timer;
    //protected Animator animator;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        //判断GameUI是否为显示状态
        if(GameUI.Instance.gameObject.activeSelf)
            Shoot();
    }

    // 发射子弹
    protected virtual void Shoot()
    {
        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                timer = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            if (timer == 0)
            {
                timer = interval;
                if(GameData.Instance.player.NumBullet > 0)
                {
                    Fire();
                    GameData.Instance.player.NumBullet--;
                }
            }
        }
    }

    // 发射子弹
    protected virtual void Fire()
    {
        //animator.SetTrigger("Shoot");
        interval = (1f - (GameData.Instance.player.AttackSpeed * 0.07f)) * 0.5f;
        // GameObject bullet = Instantiate(bulletPrefab, muzzlePos.position, Quaternion.identity);
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab); // 子弹
        if (bullet != null)
        {
            bullet.transform.position = bulletPos.position; // 枪口位置
            bullet.transform.rotation = bulletPos.rotation; // 枪口位置
            float angel = Random.Range(-5f, 5f);
            bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * bulletPos.forward);
        }
        
        GameObject muzzleFlare = ObjectPool.Instance.GetObject(muzzleFlarePrefab);
        if (muzzleFlare != null)
        {
            muzzleFlare.transform.position = bulletPos.position; // 枪口位置
            muzzleFlare.transform.rotation = bulletPos.rotation; // 枪口位置
        }

        // Instantiate(shellPrefab, shellPos.position, shellPos.rotation);
        GameObject shell = ObjectPool.Instance.GetObject(shellPrefab); //  弹壳
        if (shell != null)
        {
            shell.transform.position = shellPos.position;
            shell.transform.rotation = shellPos.rotation;
        }

        PlaySound();
    }

    protected virtual void PlaySound()
    {
        SoundManager.Instance.Play3DSound(1, bulletPos.position, 0.2f);
    }

    public virtual string HintText()
    {
        return "消耗 5 点生命值，获得该武器";
    }
}
