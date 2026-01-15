using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected float fireSpeed;
    protected float damage;


    public GameObject explosionPrefab;
    new Rigidbody rigidbody;
    // private float time = 5f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void OnEnable()
    {
        fireSpeed = GameData.Instance.weaponData.dataDic[1].fireSpeed;
        damage = GameData.Instance.player.Attack * GameData.Instance.weaponData.dataDic[1].damage;
    }


    public void SetSpeed(Vector3 direction)
    {
        rigidbody.velocity = direction * fireSpeed;
    }

    // void Update()
    // {
    //     if(time > 0)
    //         time -= Time.deltaTime;
    //     else
    //         ObjectPool.Instance.PushObject(gameObject);
    // }

    private void OnTriggerEnter(Collider other)
    {
        // Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        GameObject exp = ObjectPool.Instance.GetObject(explosionPrefab);// 爆炸
        exp.transform.position = transform.position;
        exp.transform.parent = other.transform;

        if (other.CompareTag("Monster"))
        {
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
                SoundManager.Instance.Play3DSound(2, monster.transform.position, 0.5f);
            }
        }
        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
