using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttackProp : Prop
{
    public float increaseAmplitude;
    public override void Init()
    {
        increaseAmplitude = GameData.Instance.propData.dataDic[1].value;
    }
    public override void TriggerEffect()
    {
        GameUI.Instance.SetBuffHint(BuffHint());
        GameData.Instance.player.Attack += increaseAmplitude;
    }

    public override string BuffHint()
    {
        Init();
        return "攻击力+" + increaseAmplitude;
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[1].id;
    }
}
