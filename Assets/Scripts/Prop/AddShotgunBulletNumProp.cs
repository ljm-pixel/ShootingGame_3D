using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddShotgunBulletNumProp : Prop
{
    private int addNum;
    private int maxNum;
    public override void Init()
    {
        addNum = (int)GameData.Instance.propData.dataDic[4].value;
        maxNum = (int)GameData.Instance.propData.dataDic[4].maxValue;
    }
    public override void TriggerEffect()
    {
        if (GameData.Instance.player.ShotgunBulletNum <= maxNum)
        {
            GameUI.Instance.SetBuffHint("霰弹枪的发射子弹提高");
            GameData.Instance.player.ShotgunBulletNum += addNum;
        }
        else
        {
            GameUI.Instance.SetBuffHint("霰弹枪的子弹已经达到最大");
        }
    }
    public override string BuffHint()
    {
        Init();
        if (GameData.Instance.player.ShotgunBulletNum <= maxNum)
        {
            return "霰弹枪的发射子弹提高";
        }
        else
        {
            return "霰弹枪的子弹已经达到最大";
        }
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[4].id;
    }
}
