using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private float time = 0;
    private bool isSpawn = false;
    public GameObject[] monsterPrefab;  // 怪物预制体（需拖入）
    public Transform player;          // 玩家Transform（需拖入）
    public float maxSpawnInterval = 6f;  // 生成max间隔（秒）
    public float minSpawnInterval = 4f;  // 生成min间隔（秒）
    private float spawnInterval;  // 生成间隔（秒）
    public float minRadius = 5f;      // 生成最小半径（玩家中心外）
    public float maxRadius = 10f;     // 生成最大半径
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject obj = new GameObject("MonsterSpawner");
        //obj.AddComponent<MonsterSpawner>();
        //StartCoroutine(SpawnMonsters());
    }

    public void StartSpawner()
    {
        isSpawn = true;
        time = CountdownTimer.Instance.GetTotalTime();
        StartCoroutine(SpawnMonsters());
    }
    public void StopSpawner()
    {
        //isSpawning = false;
        isSpawn = false;
    }

    private void Update()
    {
        //if (isSpawning)
        //{
        //    StartCoroutine(SpawnMonsters());
        //    isSpawning = false;
        //}

        time -= Time.deltaTime;
        if (time <= 0) 
            isSpawn = false;
    }

    IEnumerator SpawnMonsters()
    {
        while (isSpawn) // 无限循环生成
        {
            spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            // 计算生成位置
            Vector3 spawnPos = GetRandomPositionAroundPlayer();
            int monsterIndex = Random.Range(0, monsterPrefab.Length);
            // 生成怪物
            GameObject monster = ObjectPool.Instance.GetObject(monsterPrefab[monsterIndex]);
            //print("生成+");
            if(monster != null)
            {
                monster.transform.position = spawnPos;
                monster.transform.rotation = Quaternion.identity;
                //Instantiate(monsterPrefab, spawnPos, Quaternion.identity);
                // monster.transform.parent = this.transform;
            }
            
            SoundManager.Instance.Play3DSound(0, spawnPos, 0.7f);
            // 等待间隔时间
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    Vector3 GetRandomPositionAroundPlayer()
    {
        Vector3 spawnPos;
        bool positionValid = false;
        int attempts = 0; // 防止无限循环

        do
        {
            float angle = Random.Range(0f, 360f);
            float radius = Random.Range(minRadius, maxRadius);
            Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            spawnPos = player.position + dir * radius;
            spawnPos.y = 0f;

            // 检测该位置是否可通行（无碰撞体）
            positionValid = !Physics.CheckSphere(spawnPos, 1f);
            attempts++;
        } while (!positionValid && attempts < 10);

        return spawnPos;
    }

}
