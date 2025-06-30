using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using XLua;

public static class CsharpCallLuaList
{
    [CSharpCallLua]
    public static List<Type> csharpCallLuaList = new List<Type>()
    {
        typeof(UnityAction),
        typeof(UnityAction<int>),
        typeof(UnityAction<float>),
        typeof(UnityAction<bool>),
        typeof(UnityAction<string>),
        typeof(UnityAction<GameObject>)
    };

    // [LuaCallCSharp]
    // public static List<Type> luaCallCsharpList = new List<Type>()
    // {
    //     typeof(GameObject)
    // };
}
