using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectCard : MonoBehaviour,IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //获取卡牌信息
        Card card=GetComponent<Card>();
        string name=card.baseData.cardName;
        EventCenter.Instance.EventTrigger<string>("选中卡牌",name);

        print(name);//IPointerClickHandler
    }
}
