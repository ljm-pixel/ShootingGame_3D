using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{
    public RectTransform minHealthPos;
    public RectTransform maxHealthPos;
    public RectTransform healthPos;
    private bool isAtk = false;
    private bool isTime = false;

    protected float speed = 1f;
    protected float damage = 2f;
    protected float maxHealth;
    private float currentHealth;
    private Transform playerPos;
    private NavMeshAgent agent;
    private Animator animator;

    private float time = 0;
    private float timer = 0;

    public GameObject atkObj;

    protected virtual void Initialize()
    {
        maxHealth = GameData.Instance.MonsterHealth * 5f;
        damage = GameData.Instance.MonsterAttack * 2f;
        speed = GameData.Instance.MonsterSpeed * 1.5f;
    }
    private void Awake()
    {
        // 通过标签查找玩家（确保玩家对象有 "Player" 标签）
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            playerPos = playerObj.transform;
        }
        else
        {
            Debug.LogError("未找到玩家对象！");
        }
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        animator = GetComponent<Animator>();

        //atkObj = this.transform.Find("ATK").gameObject;
    }

    private void OnEnable()
    {
        Initialize();
        currentHealth = maxHealth;
        healthPos.position = maxHealthPos.position;
        gameObject.GetComponent<Collider>().enabled = true;
        
        atkObj.GetComponent<MonsATK>().Damage = damage;
        atkObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerPos.transform.position);
        if ((transform.position - playerPos.position).magnitude < 2f)
        {
            animator.SetTrigger("Attack");
            if (time == 0 && !isTime)
            {
                time = animator.GetCurrentAnimatorStateInfo(0).length;
                isTime = true;
            }
                
            //if(animator.GetCurrentAnimatorStateInfo(0).length)//  获取当前动画状态的长度
        }

        if (time != 0)
        {
            timer += Time.deltaTime;
            if(timer >= time*0.8 && timer <= time)
                atkObj.SetActive(true);
            if (timer >= time)
            {
                time = 0;
                timer = 0;
                isAtk = false;
                isTime = false;
                atkObj.SetActive(false);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthPos.position -= (maxHealthPos.position - minHealthPos.position) * (damage / maxHealth);
        animator.SetTrigger("TakeDamage");
        if (currentHealth <= 0)
        {
            if(Random.Range(0, 100) < 25)
                PropSpawner.Instance.SpawnerPropPrefabs(transform);
            gameObject.GetComponent<Collider>().enabled = false;
            animator.SetTrigger("Die");
            //Die();
            Invoke("Die", 1.3f);
        }
        //StopMone(animator.GetCurrentAnimatorStateInfo(0).length);
    }
    public void Die()
    {
        ObjectPool.Instance.PushObject(gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    //if (!isAtk)
    //    //    return;
    //    if (other.CompareTag("Player"))
    //    {
    //        print("Player-1");
    //        GameData.Instance.player.TakeDamage(damage);
    //        atkObj.SetActive(false);
    //    }
    //}
}
