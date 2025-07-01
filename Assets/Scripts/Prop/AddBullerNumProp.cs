using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddBullerNumProp : Prop
{
    public int addNum;
    public override void Init()
    {
        addNum = (int)GameData.Instance.propData.dataDic[2].value;
    }
    public override void TriggerEffect()
    {
        GameUI.Instance.SetBuffHint(BuffHint());
        GameData.Instance.player.NumBullet += addNum;
    }
    public override string BuffHint()
    {
        Init();
        return "获得" + addNum + "颗子弹";
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[2].id;
    }
}
