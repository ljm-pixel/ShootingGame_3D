using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float time = 1f;
    private float stopTime;

    private void Awake()
    {
        stopTime = time;
    }

    // Update is called once per frame
    void Update()
    {
        stopTime -= Time.deltaTime;
        if (stopTime <= 0)
        {
            stopTime = time;
            ObjectPool.Instance.PushObject(gameObject);
        }
    }
}
