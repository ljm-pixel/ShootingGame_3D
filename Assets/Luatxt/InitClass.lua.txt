--常用别名都在这里面定位
--面向对象相关
require("Object")
--字符串拆分
require("SplitTools")

--Unity相关的
GameObject = CS.UnityEngine.GameObject
Resources = CS.UnityEngine.Resources
Transform = CS.UnityEngine.Transform
RectTransform = CS.UnityEngine.RectTransform
TextAsset = CS.UnityEngine.TextAsset
--图集对象类
SpriteAtlas = CS.UnityEngine.U2D.SpriteAtlas

Vector3 = CS.UnityEngine.Vector3
Vector2 = CS.UnityEngine.Vector2

--UI相关
UI = CS.UnityEngine.UI
Image = UI.Image
Text = UI.Text
Button = UI.Button
Toggle = UI.Toggle
ScrollRect = UI.ScrollRect
UIBehaviour = CS.UnityEngine.EventSystems.UIBehaviour

--Canvas 
BagUI = GameObject.Find("BagUI").transform

--自己写的C#脚本相关
ABMgr = CS.ABMgr.GetInstance()
LuaLifeFun = CS.LuaLifecycleFunMgr.GetInstance()
--得到输入
Input = CS.UnityEngine.Input
KeyCode = CS.UnityEngine.KeyCode

GameData = CS.GameData.Instance
