using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardLayout : MonoBehaviour//卡牌排序，使用单例模式
{
    //排序
    public int CarMax;//最大卡牌数
    public float CardWith;//宽度
    public float damp = 10f;//阻尼
    public float mass = 1f;//质量
    public float spring = 800f;//弹力
    public static CardLayout Instance { get; private set; }//单例
    private CardLayout() { }
    private List<Vector3> Velcity = new List<Vector3>();//加速度

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //Debug.Log("CardLayout 单例初始化成功！物体名：" + gameObject.name);
    }
    void Start()
    {
        CardPos();
        EventCenter.Instance.AddEvent("卡牌排序",CardPos);
    }
    public Vector3 Spring(Vector3 current, Vector3 target, int index, float time)//弹簧公式
    {
        if (index >= Velcity.Count) return Vector3.zero;
        Vector3 Vel = Velcity[index];
        // 弹簧公式：受力 = 距离 * 弹性 - 速度 * 阻尼
        Vector3 F_spring = (target - current) * spring - damp * Vel;
        Vector3 F = F_spring / mass;
        Velcity[index] += F * time;
        return Velcity[index] * time;
    }
    public void CardPos()//卡牌的排序
    {
        int date = transform.childCount;
        if (date == 0) return;
        for (int i = 0; i < date; i++)
        {
            Transform child = transform.GetChild(i);
            float t = date > 1 ? (float)i / (date - 1) : 0.5f;
            child.transform.localPosition = new Vector3(t * CardWith - CardWith / 2, 0, 0);
        }
    }
}
