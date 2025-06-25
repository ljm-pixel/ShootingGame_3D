using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProp : Prop
{
    private float curative = 1;

    //private void OnEnable()
    //{
    //    curative = GameData.Instance.CurativeDose;
    //}
    public override void TriggerEffect()
    {
        curative = GameData.Instance.player.CurativeDose;
        GameData.Instance.player.MaxHealth += curative;
        GameData.Instance.player.CurrentHealth += curative;
        GameUI.Instance.SetBuffHint(BuffHint());
        //Destroy(this.gameObject);
    }

    public override string BuffHint()
    {
        return "生命值+" + GameData.Instance.player.CurativeDose;
    }
}
