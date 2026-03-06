using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Card : MonoBehaviour
{
    public ICardEffect cost;         // 功能逻辑
    public CardData baseData;      // 原始数据包（包含名字、图片、数值等）
    public Image image;              // 卡牌自身的 Image 组件

    private void Awake()
    {
        // 自动获取组件，防止空引用
        if (image == null) image = GetComponent<Image>();
    }

    // 由 HandPool 调用，给卡牌“注魂”
    public void InitCard(CardData data)
    {
        baseData = data;
        cost = data.cardEffect;
        
        // 直接设置图片
        if (image != null) image.sprite = data.cardImage;
    }

    public void Excute()
    {
        if (baseData == null) return;
        // 直接把数值和目标传给效果逻辑
        // 假设你的 ICardEffect.Excute 现在接受 (数值, 目标)
        //cost.Excute(); 
        // 告诉卡池：我打完了，把我回收
        HandPool.Handpool.Fold(this);
        Debug.Log("卡牌执行");
        // 重新排版剩下的手牌
        EventCenter.Instance.EventTrigger("卡牌排序");
    }
}