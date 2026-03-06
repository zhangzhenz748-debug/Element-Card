using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;
using System;
[Serializable]
public class MonsterM
{
    //敌人类型
    public int MaxHP;//最大生命值
    public int Block;//护盾
    public int CurrentHP;//当前生命值
    public Sprite image;//图片
    [SerializeReference]
    public AttackInterface attack;//攻击方式
}
public class MonsterDeath : MonoBehaviour
{
    public GameObject game;//敌人基础模板
    public List<MonsterM> monsterMs;//敌人属性列表
    public Transform living;//活着的
    public Transform Death;//死亡
    //对象池
    private ObjectPool<GameObject> pool;
    private int Monsterdata;//敌人数量
    //回收
    void Start()
    {
        pool = new ObjectPool<GameObject>(CreateGame, GetGame, RelaseGame, DestroyGame);
        EventCenter.Instance.AddEvent<GameObject>("死亡",DeathEnemies);
        EventCenter.Instance.AddEvent<MonsterBase>("创建敌人",MakeEnemies);
    }
    public GameObject CreateGame()
    {
        var obj = Instantiate(game);//实例化
        return obj;
    }
    public void GetGame(GameObject game)//拿取
    {
        //切换父对象
        game.transform.SetParent(living, false);
        game.SetActive(true);
    }
    public void RelaseGame(GameObject game)//归还
    {
        //切换父对象
        game.transform.SetParent(Death, false);
        game.SetActive(false);
    }
    public void DestroyGame(GameObject game)
    {
        Destroy(game);
    }
    //创建敌人
    public void MakeEnemies(MonsterBase monster)
    {
        if(monster is MonsterGame<int> game)
        {
            Monsterdata=game.Value;
            for(int i=0;i<game.Value;i++)
            {
                GameObject Monst=pool.Get();
                MonsterTrait Trait=Monst.GetComponent<MonsterTrait>();
                //根据种子来创建敌人
                Trait.init(monsterMs[0]);
            }
        }
        Debug.Log("创建敌人");
    }
    //敌人死亡
    public void DeathEnemies(GameObject game)
    {
        if(game==null)
        {
            return;
        }
        Monsterdata--;
        pool.Release(game);
        if(Monsterdata==0)
        {
            //胜利
            EventCenter.Instance.EventTrigger("胜利");
            EventCenter.Instance.EventTrigger("回合结束");
            Debug.Log("胜利");
            MonsterGame<int> monster=new MonsterGame<int>(2);
            MakeEnemies(monster);
        }
        //全部敌人死亡就胜利
        //进入结算画面
    }
    public void Attack()
    {
        //所有敌人执行攻击
        EventCenter.Instance.EventTrigger("攻击");
    }
}
