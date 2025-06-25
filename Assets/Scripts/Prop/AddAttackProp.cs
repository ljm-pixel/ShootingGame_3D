using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAttackProp : Prop
{
    public float increaseAmplitude = 0.5f;
    public override void TriggerEffect()
    {
        GameData.Instance.player.Attack += increaseAmplitude;
        GameUI.Instance.SetBuffHint(BuffHint());
    }

    public override string BuffHint()
    {
        return "攻击力+" + increaseAmplitude;
    }
}
