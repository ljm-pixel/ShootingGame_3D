using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public virtual void Init()
    {
    }
    public virtual string BuffHint()
    {
        return "";
    }

    public virtual void TriggerEffect()
    {
        if (GameData.Instance.bagItems.ContainsKey(GetID()))
        {
            GameData.Instance.bagItems[GetID()]++;
        }
        else
        {
            GameData.Instance.bagItems.Add(GetID(), 1);
        }
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TriggerEffect();
            if (GameData.Instance.bagItems.ContainsKey(GetID()))
            {
                GameData.Instance.bagItems[GetID()]++;
            }
            else
            {
                GameData.Instance.bagItems.Add(GetID(), 1);
            }
            ObjectPool.Instance.PushObject(gameObject);
        }
    }

    public virtual int GetID()
    {
        return -1; // 默认返回-1，子类应重写此方法返回具体ID
    }
}
