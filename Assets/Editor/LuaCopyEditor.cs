using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class LuaCopyEditor : Editor
{
    [MenuItem("Lua/CopyLuaToTxt")]
    public static void CopyLuaToTxt()
    {
        string path = Application.dataPath + "/Lua/";
        if (!Directory.Exists(path))
            return;

        string[] strs = Directory.GetFiles(path, "*.lua"); // 获取所有.lua后缀的文件
        string newPath = Application.dataPath + "/Luatxt/"; // Copy的目标路径

        if (!Directory.Exists(newPath))
            Directory.CreateDirectory(newPath); // 创建文件夹
        else
        {
            string[] oldFileStrs = Directory.GetFiles(newPath, "*.txt");
            // 删除所有txt文件
            for (int i = 0; i < oldFileStrs.Length; i++)
            {
                File.Delete(oldFileStrs[i]);
            }
        }
        List<string> newFileNames = new List<string>();
        string fileName;
        for (int i = 0; i < strs.Length; i++)
        {
            // strs[i].LastIndexOf("/") 当字符串中存在多个 "/" 时，返回 最后一个 "/" 的索引位置（索引从 0 开始计算）。如果字符串中不存在 "/"，返回 -1。
            fileName = newPath + strs[i].Substring(strs[i].LastIndexOf("/") + 1) + ".txt";
            newFileNames.Add(fileName);
            File.Copy(strs[i], fileName);
        }
        AssetDatabase.Refresh(); // 刷新project窗口

        //刷新过后再来改制定包 因为 如果不刷新 第一次改变 会没用
        for (int i = 0; i < newFileNames.Count; i++)
        {
            //Unity API
            //改API传入的路径 必须是 相对Assets文件夹的 Assets/..../....
            AssetImporter importer = AssetImporter.GetAtPath( newFileNames[i].Substring(newFileNames[i].IndexOf("Assets")));
            if(importer != null)
                importer.assetBundleName = "lua"; // 设置AssetBundle的名字
        }
    }
}
