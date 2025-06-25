using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCurativeDoseProp : Prop
{
    public float curativeDose = 1f;
    public override void TriggerEffect()
    {
        GameData.Instance.player.CurativeDose += curativeDose;
        GameUI.Instance.SetBuffHint(BuffHint());
    }
    public override string BuffHint()
    {
        return "治疗量提高" + curativeDose;
    }
}
