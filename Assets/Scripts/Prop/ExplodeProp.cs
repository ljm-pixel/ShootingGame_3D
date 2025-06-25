using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeProp : Prop
{
    //public GameObject monsterSpawner;

    public override void TriggerEffect()
    {
        //for (int i = 0; i < monsterSpawner.transform.childCount; i++)
        //{
        //    monsterSpawner.transform.GetChild(i).gameObject.SetActive(false);
        //}
        // 方法1：通过标签查找所有怪物
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameUI.Instance.SetBuffHint(BuffHint());
        foreach (GameObject monster in monsters)
        {
            if (monster != null) 
                monster.GetComponent<Monster>().Die();
        }

    }

    public override string BuffHint()
    {
        return "清除场上所有怪物";
    }
    //protected override void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Monster"))
    //    {
    //        Monster monster = other.GetComponent<Monster>();
    //        if (monster != null)
    //            monster.TakeDamage(1000);
    //    }
    //}
}