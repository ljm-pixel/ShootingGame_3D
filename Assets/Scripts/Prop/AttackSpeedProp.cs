using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedProp : Prop
{
    public float increaseAmplitude = 1f;

    public override void TriggerEffect()
    {
        if(GameData.Instance.player.AttackSpeed < 10f)
            GameData.Instance.player.AttackSpeed += increaseAmplitude;
        GameUI.Instance.SetBuffHint(BuffHint());
    }

    public override string BuffHint()
    {
        if (GameData.Instance.player.AttackSpeed >= 10f)
            return "攻击速度已经达到最大";
        return "攻击速度+" + increaseAmplitude;
    }
}
