using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedProp : Prop
{
    public float increaseAmplitude;
    private float maxAttackSpeed;
    public override void Init()
    {
        increaseAmplitude = GameData.Instance.propData.dataDic[5].value;
        maxAttackSpeed = GameData.Instance.propData.dataDic[5].maxValue;
    }
    public override void TriggerEffect()
    {
        GameUI.Instance.SetBuffHint(BuffHint());
        if (GameData.Instance.player.AttackSpeed < maxAttackSpeed)
            GameData.Instance.player.AttackSpeed += increaseAmplitude;
    }

    public override string BuffHint()
    {
        Init();
        if (GameData.Instance.player.AttackSpeed >= maxAttackSpeed)
            return "攻击速度已经达到最大";
        return "攻击速度+" + increaseAmplitude;
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[5].id;
    }
}
