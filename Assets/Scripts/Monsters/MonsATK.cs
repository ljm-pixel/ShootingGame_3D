using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsATK : MonoBehaviour
{
    private float damage;

    public float Damage
    {
        get => damage;
        set
        {
            damage = value;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.Instance.player.TakeDamage(Damage);
            other.gameObject.GetComponent<Player>().SetbeInjuredIntervalTime();
            this.gameObject.SetActive(false);
        }
    }
}
