using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prop : MonoBehaviour
{
    public virtual string BuffHint()
    {
        return "";
    }

    public virtual void TriggerEffect()
    {

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

    private int GetID()
    {
        return (int)gameObject.name[0];
    }
}
