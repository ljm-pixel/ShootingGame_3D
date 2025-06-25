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
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
}
