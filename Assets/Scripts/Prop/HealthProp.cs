using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthProp : Prop
{
    private float curative = 1;
    public override void Init()
    {
        curative = GameData.Instance.propData.dataDic[6].value;
    }
    public override void TriggerEffect()
    {
        GameUI.Instance.SetBuffHint(BuffHint());
        curative = GameData.Instance.player.CurativeDose;
        GameData.Instance.player.MaxHealth += curative;
        GameData.Instance.player.CurrentHealth += curative;
    }

    public override string BuffHint()
    {
        Init();
        return "生命值+" + GameData.Instance.player.CurativeDose;
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[6].id;
    }
}
