using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = new SoundManager();
    public static SoundManager Instance => instance;

    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private GameObject audioSourcePrefab; // 音效预制体
    void Awake()
    {
        instance = this;
    }

    // 动态生成并播放音效
    public void PlaySound(int audioClipNumder, Vector3 position, float volume = 0.5f)
    {
        GameObject go = new GameObject("DynamicSound");
        go.transform.position = position;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = audioClip[audioClipNumder];
        source.volume = volume;
        source.Play();
        Destroy(go, audioClip[audioClipNumder].length); // 自动销毁音效对象
    }

    public void Play3DSound(int audioClipNumder, Vector3 position, float volume = 0.5f)
    {
        GameObject go = new GameObject("3DSound");
        go.transform.position = position;
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = audioClip[audioClipNumder];
        source.volume = volume;
        source.spatialBlend = 1f; // 1 = 3D 音效
        source.maxDistance = 20f; // 最大听距
        source.Play();
        Destroy(go, audioClip[audioClipNumder].length);
    }
}
