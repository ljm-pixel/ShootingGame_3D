using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : BasePanel<EndGame>
{
    public Button button;

    public override void Init()
    {
        HideMe();
        button.onClick.AddListener(() =>
        {
            ObjectPool.Instance.Clear();// 清空对象池
            HideMe();
            //加载下一场景
            SceneManager.LoadScene(1);
        });
    }

    private void OnEnable()
    {
        OpenMouse();
    }
}
