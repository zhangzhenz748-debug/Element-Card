using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class CardMove : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{//卡牌移动
    public bool Move;//移动
    public bool click;//点击
    private Vector2 pos;//点击位置
    private Vector2 Trans;//
    private int UI;
    private Vector3 originalScale;
    private CanvasGroup canvasGroup;
    public bool move;

    void Awake()
    {
        // 记录初始大小，防止多次缩放后回不到准确数值
        originalScale = transform.localScale;
        move=false;
    }
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        pos = eventData.position;
        Trans = transform.position;
        move=true;
        UI=canvasGroup.transform.GetSiblingIndex();
        canvasGroup.transform.SetAsLastSibling();//移动开始时，设置在所有卡牌上面
        //移动结束后，设置回来
        transform.localRotation = Quaternion.Euler(0, 0, 0);

        canvasGroup.blocksRaycasts = false;
        //print("开始拖拽");
    }//IBeginDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 dir = eventData.position - pos;
        transform.position = Trans + dir;
        //print("移动中");
    }//IDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.transform.SetSiblingIndex(UI);
        move=false;
        CardLayout.Instance.CardPos();
        //print("结束拖拽");
    }//IEndDragHandler
    public void OnDrop(PointerEventData eventData)//融合功能
    {
        Debug.Log("融合");
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameObject obj = eventData.pointerDrag;
        if (obj != null)
        {
            CardMove uINature = obj.GetComponent<CardMove>();
            if (uINature != null && uINature.move)
            {
                transform.localScale = transform.localScale*1.2f;
            }
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale=originalScale;
        print("离开");//IPointerExitHandler
    }
}