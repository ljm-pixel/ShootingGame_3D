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
            HideMe();
            //加载下一场景
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
