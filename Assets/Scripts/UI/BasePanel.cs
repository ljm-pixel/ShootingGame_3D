using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 面板基类 所有面板 都会继承它 方便我们的使用 节约代码量
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BasePanel<T> : MonoBehaviour where T : class
{
    private static T instance;

    public static T Instance => instance;
    public bool isFire = false; // 是否开火
    protected virtual void Awake()
    {
        instance = this as T;
    }

    void Start()
    {
        Init();
    }

    //主要用于 初始化 控件的事件监听 等等的逻辑 
    public abstract void Init();

    public virtual void ShowMe()
    {
        this.gameObject.SetActive(true);
    }

    public virtual void HideMe()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenMouse()
    {
        //显示鼠标
        Cursor.visible = true;
        //鼠标限制在窗口范围内
        Cursor.lockState = CursorLockMode.Confined;
        isFire = false; 
    }

    public void CloseMouse()
    {
        //隐藏鼠标
        Cursor.visible = false;
        isFire = true;
        //鼠标锁定在屏幕中心
        Cursor.lockState = CursorLockMode.Locked;
    }
}
