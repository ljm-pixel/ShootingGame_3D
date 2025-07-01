using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCurativeDoseProp : Prop
{
    public float curativeDose;
    public override void Init()
    {
        curativeDose = GameData.Instance.propData.dataDic[3].value;
    }
    public override void TriggerEffect()
    {
        GameUI.Instance.SetBuffHint(BuffHint());
        GameData.Instance.player.CurativeDose += curativeDose;
    }
    public override string BuffHint()
    {
        Init();
        return "治疗量提高" + curativeDose;
    }
    public override int GetID()
    {
        return GameData.Instance.propData.dataDic[3].id;
    }
}
