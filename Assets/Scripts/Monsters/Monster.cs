using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class Monster : MonoBehaviour
{
    protected float speed;
    protected float damage;
    protected float maxHealth;

    public RectTransform minHealthPos;
    public RectTransform maxHealthPos;
    public RectTransform healthPos;
    private bool isAtk = false;
    private bool isTime = false;

    private float currentHealth;
    private Transform playerPos;
    private NavMeshAgent agent;
    private Animator animator;

    private float time = 0;
    private float timer = 0;

    public GameObject atkObj;

    // 初始化数据
    protected virtual void Initialize() { }

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
        
        animator = GetComponent<Animator>();

        //atkObj = this.transform.Find("ATK").gameObject;
    }

    private void OnEnable()
    {
        Initialize();
        currentHealth = maxHealth;
        healthPos.position = maxHealthPos.position;
        gameObject.GetComponent<Collider>().enabled = true;
        
        agent.speed = speed;

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
            if(Random.Range(0, 100) < 50)
                PropSpawner.Instance.SpawnerPropPrefabs(transform);
            gameObject.GetComponent<Collider>().enabled = false;
            animator.SetTrigger("Die");
            StartCoroutine(StopMone(1.3f));
        }
        //StopMone(animator.GetCurrentAnimatorStateInfo(0).length);
    }
    IEnumerator StopMone(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectPool.Instance.PushObject(gameObject);
    }
}
