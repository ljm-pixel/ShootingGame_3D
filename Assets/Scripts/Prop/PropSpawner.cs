using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject[] PropPrefabs;

    private static PropSpawner instance;
    public static PropSpawner Instance => instance;
    void Awake()
    {
        instance = this;
    }

    public GameObject SpawnerPropPrefabs(Transform pos)
    {
        GameObject PropObj = ObjectPool.Instance.GetObject(PropPrefabs[Random.Range(0, PropPrefabs.Length)]);
        PropObj.transform.position = pos.position;
        return PropObj;
    }

    public string GetBuffHint(int index)
    {
        return PropPrefabs[index].GetComponent<Prop>().BuffHint();
    }

    public void SelectBuff(int index)
    {
        PropPrefabs[index].GetComponent<Prop>().TriggerEffect();
    }
    public void Dic(int index)
    {
        ObjectPool.Instance.PushObject(PropPrefabs[index]);
    }
}
