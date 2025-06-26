using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    private float currentHealth = 50f;
    private float maxHealth = 50f;
    private float attackSpeed = 1f;
    private float attack = 10f;
    private float curativeDose = 1f;
    private int numBullet = 50;
    private int shotgunBulletNum = 3;

    public Animator animator;
    public float roundSpeed = 200f;
    public GameObject[] guns;
    private int gunNum = 0;

    //private float currentHealth;
    private Transform playerPos;
    private float beInjuredIntervalTime = 0.5f;

    public float CurrentHealth
    {
        get => currentHealth;
        set 
        {
            currentHealth = value;
            GameUI.Instance.SetHealthText(currentHealth / maxHealth);
            GameUI.Instance.SetCurrentHealthText(currentHealth);
        }
    }
    public float MaxHealth
    {
        get => maxHealth;
        set 
        {
            GameUI.Instance.SetHealthText(maxHealth);
            maxHealth = value; 
        }
    }
    public float AttackSpeed
    {
        get => attackSpeed;
        set 
        {
            attackSpeed = value;
            GameUI.Instance.SetAttackSpeedText(attackSpeed);
        }
    }
    public float Attack
    {
        get => attack;
        set 
        {
            attack = value;
            GameUI.Instance.SetAttackText(attack); 
        }
    }

    public float CurativeDose
    {
        get { return curativeDose; }
        set { curativeDose = value; }
    }
    public int NumBullet
    {
        get { return numBullet; }
        set
        {
            numBullet = value;
            GameUI.Instance.SetBulletNumText(numBullet);
        }
    }
    public int ShotgunBulletNum
    {
        get { return shotgunBulletNum; }
        set { shotgunBulletNum = value; }
    }

    public float BeInjuredIntervalTime
    {
        get { return beInjuredIntervalTime; }
        set { beInjuredIntervalTime = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameUI.Instance.SetCurrentHealthText(currentHealth);
        GameUI.Instance.SetAttackText(attack);
        GameUI.Instance.SetAttackSpeedText(attackSpeed);
        GameUI.Instance.SetBulletNumText(numBullet);
    }

    public void TakeDamage(float damage)
    {
        if (beInjuredIntervalTime <= 0)
        {
            CurrentHealth = CurrentHealth - damage;
            print("-1");
            beInjuredIntervalTime = 0.5f;
        }
        if (CurrentHealth <= 0)
        {
            print("结束了");
            EndGame.Instance.ShowMe();
            GameUI.Instance.StopGame();
            ExplodeProp explodeProp = new ExplodeProp();
            explodeProp.TriggerEffect();
        }
    }

    public void SetbeInjuredIntervalTime()
    {
        beInjuredIntervalTime = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        //移动动作的变换 由于动作有位移  我们也应用了动作的位移  所以只要改变这两个值 就会有动作的变化 和 速度的变化
        animator.SetFloat("VSpeed", Input.GetAxis("Vertical"));
        animator.SetFloat("HSpeed", Input.GetAxis("Horizontal"));
        //旋转
        this.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * roundSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetLayerWeight(1, 1);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            animator.SetLayerWeight(1, 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
            animator.SetTrigger("Roll");

        if (Input.GetMouseButtonDown(0))
            animator.SetTrigger("Fire");

        if (beInjuredIntervalTime > 0)
            beInjuredIntervalTime -= Time.deltaTime;
    }
}
