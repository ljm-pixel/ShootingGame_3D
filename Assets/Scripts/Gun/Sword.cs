using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Sword : MonoBehaviour
{
    private float damage = 10;
    public GameObject hitEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster"))
        {
            damage = GameData.Instance.player.Attack;
            // 获取怪物碰撞体上离剑最近的近似点
            Vector3 closestPoint = other.ClosestPoint(transform.position);
            Debug.Log($"触发接触点: {closestPoint}");
            SoundManager.Instance.Play3DSound(3, closestPoint);
            // 触发伤害逻辑
            Monster monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                monster.TakeDamage(damage);
                GameObject gameObject = ObjectPool.Instance.GetObject(hitEffectPrefab);
                gameObject.transform.position = closestPoint;
                //Instantiate(hitEffectPrefab, closestPoint, Quaternion.identity);
            }
        }
    }
}
