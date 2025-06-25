using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashbomb : Prop
{
    public GameObject flashbombPanel;
    private Animator animator;

    void Start()
    {
        animator = flashbombPanel.GetComponent<Animator>();
    }

    public override void TriggerEffect()
    {
        animator.SetTrigger("isTrigger");
        GameUI.Instance.SetBuffHint(BuffHint());
    }

    public override string BuffHint()
    {
        return "闪光弹";
    }
}
