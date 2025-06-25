using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullerNumProp : Prop
{
    public int addNum = 50;
    public override void TriggerEffect()
    {
        GameData.Instance.player.NumBullet += addNum;
        GameUI.Instance.SetBuffHint(BuffHint());
    }
    public override string BuffHint()
    {
        return "获得" + addNum + "颗子弹";
    }
}
