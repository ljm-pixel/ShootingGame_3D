using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShell : MonoBehaviour
{
    public float speed;
    public float stopTime = 1f;
    public float fadeSpeed = .01f;
    new private Rigidbody rigidbody;

    //private SpriteRenderer sprite;//  用于渐隐

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        //sprite = GetComponent<SpriteRenderer>();
    }
    // 开始时，设置速度和重力
    private void OnEnable()
    {
        float angel = Random.Range(-30f, 30f);
        rigidbody.velocity = Quaternion.AngleAxis(angel, Vector3.forward) * Vector3.up * speed;

        //sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
        // 质量
        rigidbody.mass = 3;

        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(stopTime);
        rigidbody.velocity = Vector3.zero;
        rigidbody.mass = 0;

        //while (sprite.color.a > 0)
        //{
        //    sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.g, sprite.color.a - fadeSpeed);
        //    yield return new WaitForFixedUpdate();
        //}
        // Destroy(gameObject);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
