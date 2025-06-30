using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlare : MonoBehaviour
{
    public float stopTime = 0.5f;
    private void OnEnable()
    {
        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
