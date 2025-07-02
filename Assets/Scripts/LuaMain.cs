using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuaMain : MonoBehaviour
{
    void Start()
    {
        LuaMgr.GetInstance().Init();
        LuaMgr.GetInstance().DoLuaFile("Main");
    }
}
