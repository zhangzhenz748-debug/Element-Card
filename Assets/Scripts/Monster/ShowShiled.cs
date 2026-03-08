using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowShiled : MonoBehaviour
{
    public GameObject game;
    public Text text;
    private MonsterTrait Monster;
    void Start()
    {
        Monster=GetComponent<MonsterTrait>();
    }
    public void Shiled(MonsterBase monster)
    {
        if(Monster==null)
        return;
        if (monster is MonsterGame<int> packet)
        {
            if (Monster.Block > 0)
            {
                game.SetActive(true);
                text.text=Monster.Block.ToString();
            }
            else
            {
                text.text=Monster.Block.ToString();
                game.SetActive(false);
            }
        }
    }
}
