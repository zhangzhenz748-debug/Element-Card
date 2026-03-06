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
        EventCenter.Instance.AddEvent("卡牌排序", CardPos);
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
    public float sortDuration = 0.3f; // 排序动画持续时间

    public void CardPos()
    {
        int count = transform.childCount;
        if (count == 0) return;

        for (int i = 0; i < count; i++)
        {
            Transform child = transform.GetChild(i);

            // 1. 计算目标位置 (End Position)
            float t = count > 1 ? (float)i / (count - 1) : 0.5f;
            Vector3 targetPos = new Vector3(t * CardWith - CardWith / 2, 0, 0);

            // 2. 开启协程让它滑过去，而不是瞬移
            StopCoroutine("MoveToTarget"); // 防止上一次排序还没完，重叠冲突
            StartCoroutine(MoveToTarget(child, targetPos));
        }
    }

    private IEnumerator MoveToTarget(Transform item, Vector3 target)
    {
        float elapsed = 0f;
        Vector3 startPos = item.localPosition;

        while (elapsed < sortDuration)
        {
            elapsed += Time.deltaTime;
            float percent = elapsed / sortDuration;

            // 使用 Lerp 进行平滑插值
            item.localPosition = Vector3.Lerp(startPos, target, percent);

            yield return null; // 等待下一帧
        }

        item.localPosition = target; // 确保最终位置精准对齐
    }
}
