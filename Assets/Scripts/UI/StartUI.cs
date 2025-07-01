using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : BasePanel<StartUI>
{
    public Button startGameButton;
    public Button quitGameButton;
    public Button recordButton;

    public override void Init()
    {
        ShowMe();
        OpenMouse();
        startGameButton.onClick.AddListener(() =>
        {
            GameUI.Instance.StartGame();
            HideMe();
        });
        quitGameButton.onClick.AddListener(() =>
        {
            Application.Quit();//退出游戏
        });
        recordButton.onClick.AddListener(() =>
        {
            PlotUI.Instance.ShowMe();
        });
    }
}
