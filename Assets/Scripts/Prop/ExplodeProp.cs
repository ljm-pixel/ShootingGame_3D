using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeProp : Prop
{
    public override void TriggerEffect()
    {
        // 通过标签查找所有怪物
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        GameUI.Instance.SetBuffHint(BuffHint());
        foreach (GameObject monster in monsters)
        {
            if (monster != null)
                ObjectPool.Instance.PushObject(monster);
        }
    }

    public override string BuffHint()
    {
        Init();
        return "清除场上所有怪物";
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[7].id;
    }
}