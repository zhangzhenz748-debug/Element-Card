using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MonsterTrait : MonoBehaviour
{
    public int MaxHP;//最大生命值
    public int Block;//护盾
    public int CurrentHP;//当前生命值
    public Image image;//图片
    public AttackInterface attack;//攻击方式
    private MonsterEvent Monster;
    void Start()
    {
        Monster = GetComponent<MonsterEvent>();
        Monster.TriggerSignal<(int, int)>("血条", (CurrentHP, MaxHP));
        EventCenter.Instance.AddEvent("攻击", StartAttack);
    }
    public void init(MonsterM monster)
    {
        Monster = GetComponent<MonsterEvent>();
        MaxHP = monster.MaxHP;//最大生命值
        Block = monster.Block;//护盾
        CurrentHP = monster.CurrentHP;//当前生命值
        if (image)
            image.sprite = monster.image;//图片
        Monster.TriggerSignal<(int, int)>("血条", (CurrentHP, MaxHP));
    }
    public void TakeDamage(MonsterBase monster)
    {
        if (monster is MonsterGame<int> packet)
        {
            var total = packet.Value;
            //先扣护盾，在扣血
            if (total != 0 && Block != 0)
            {
                Block += total;
                //发送护盾变化
            }
            if (Block < 0)
            {
                CurrentHP += Block;
                Block = 0;
                //发送血条变化
            }
            else
            {
                CurrentHP += total;
            }
            Monster.TriggerSignal<(int, int)>("血条", (CurrentHP, MaxHP));
            if (CurrentHP <= 0)
            {
                //死亡，回收
                Death();
            }
        }
        else
        {
            // 如果传错了包（比如传了个字符串包），这里可以报错提醒
            Debug.LogWarning($"{gameObject.name} 收到错误类型的信号数据！");
        }
    }
    public void Death()
    {
        EventCenter.Instance.EventTrigger<GameObject>("死亡", gameObject);
    }
    public void SetMaxHP(MonsterBase monster)//最大血量值变化
    {
        if (monster is MonsterGame<int> packet)
        {
            int total = packet.Value;
            MaxHP += total;
            Monster.TriggerSignal<(int, int)>("血条", (CurrentHP, MaxHP));
        }
        else
        {
            // 如果传错了包（比如传了个字符串包），这里可以报错提醒
            Debug.LogWarning($"{gameObject.name} 收到错误类型的信号数据！");
        }
    }
    //血量
    public void SetCurrentHP(MonsterBase monster)
    {
        if (monster is MonsterGame<int> packet)
        {
            int total = packet.Value;
            //防止超过最大血量
            if (CurrentHP + total > MaxHP)
            {
                CurrentHP = MaxHP;
            }
            else
            {
                CurrentHP += total;
            }
        }
        else
        {
            // 如果传错了包（比如传了个字符串包），这里可以报错提醒
            Debug.LogWarning($"{gameObject.name} 收到错误类型的信号数据！");
        }
    }
    //护盾
    public void SetBlock(MonsterBase monster)
    {
        if (monster is MonsterGame<int> packet)
        {
            var total = packet.Value;
            if (total != 0)
            {
                Block += total;
            }
        }
        else
        {
            // 如果传错了包（比如传了个字符串包），这里可以报错提醒
            Debug.LogWarning($"{gameObject.name} 收到错误类型的信号数据！");
        }
    }
    /// <summary>
    /// 执行攻击方式
    /// </summary>
    public void StartAttack()
    {
        attack.Attack();
    }
}
