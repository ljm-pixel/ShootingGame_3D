using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlotUI : BasePanel<PlotUI>
{
    public Button XButton;

    public override void Init()
    {
        HideMe();//  隐藏
        XButton.onClick.AddListener(() =>
        {
            HideMe();
        });
    }
}
