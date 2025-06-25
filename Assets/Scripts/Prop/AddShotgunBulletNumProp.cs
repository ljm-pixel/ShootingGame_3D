using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShotgunBulletNumProp : Prop
{
    public int addNum = 1;
    public override void TriggerEffect()
    {
        if(GameData.Instance.player.ShotgunBulletNum <= 8)
        {
            GameData.Instance.player.ShotgunBulletNum += addNum;
            GameUI.Instance.SetBuffHint("霰弹枪的发射子弹提高");
        }
        else
        {
            GameUI.Instance.SetBuffHint("霰弹枪的子弹已经达到最大");
        }
    }
    public override string BuffHint()
    {
        if (GameData.Instance.player.ShotgunBulletNum <= 8)
        {
            return "霰弹枪的发射子弹提高";
        }
        else
        {
            return "霰弹枪的子弹已经达到最大";
        }
    }
}
