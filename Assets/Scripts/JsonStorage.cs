using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class JsonStorage : MonoBehaviour//保存文件
{
    public static void Save(Object game)
    {
        var json = JsonUtility.ToJson(game);
        string filePath = Application.persistentDataPath + "/PlayerSave.json";
        //写入硬盘 (这一步才是真正的“存到文件里”) 
        File.WriteAllText(filePath, json);
        //存储当前牌局退出时的
    }
    public static T Load<T>(string str)
    {
        string filePath = Application.persistentDataPath + "/PlayerSave.json";
        var json = File.ReadAllText(filePath);
        T data = JsonUtility.FromJson<T>(json);
        return data;
    }
}
