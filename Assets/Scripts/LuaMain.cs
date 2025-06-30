using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaMain : MonoBehaviour
{
    // private static LuaMain Instance;

    // void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestroyOnLoad(gameObject); // 首次创建时标记
    //     }
    //     else
    //     {
    //         Destroy(gameObject); // 销毁重复实例
    //     }
    // }

    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");

        // this.transform.SetParent(GameObject.Find("UI").transform.Find("GameUI").transform, false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            LuaMgr.GetInstance().DoLuaFile("MainPanel");
        }
        {
            
        }
    }
}
