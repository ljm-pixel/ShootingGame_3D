using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LuaLifecycleFunMgr : SingletonAutoMono<LuaLifecycleFunMgr>
{
    public UnityAction LuaStart;
    public UnityAction LuaUpdate;

    // Start is called before the first frame update
    void Start()
    {
        LuaStart?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        LuaUpdate?.Invoke();
    }
}
