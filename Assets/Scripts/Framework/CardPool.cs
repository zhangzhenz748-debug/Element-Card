using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
public class CardPool : MonoBehaviour
{
    public int date;//卡牌的可选数量
    public GameObject game;//卡牌预制体
    public Transform activeRoot;//目前使用的
    public Transform poolRoot;//目前没有使用的
    public ObjectPool<GameObject> pool;
    //public List<GameObject> games;//归还卡牌列表
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateGame, GetGame, RelaseGame, DestroyGame);
    }
    void A()
    {
        GameObject game=pool.Get();
    }
    //要使用对象池添加可选卡牌
    public GameObject CreateGame()
    {
        var obj = Instantiate(game);//实例化
        return obj;
    }
    public void GetGame(GameObject game)
    {
        //切换父对象
        game.transform.SetParent(activeRoot, false);
        game.SetActive(true);
        Card card = game.GetComponent<Card>();
        if (card != null)
        {
            // 如果你使用了 CanvasGroup 控制拖拽，记得重置
            if (card.GetComponent<CanvasGroup>())
                card.GetComponent<CanvasGroup>().blocksRaycasts = true;
            // 确保 Image 开启了射线检测
            if (card.image != null) card.image.raycastTarget = true;
        }
    }
    public void RelaseGame(GameObject game)
    {
        //切换父对象
        game.transform.SetParent(poolRoot, false);
        game.SetActive(false);
    }
    public void DestroyGame(GameObject game)
    {
        Destroy(game);
    }
}
