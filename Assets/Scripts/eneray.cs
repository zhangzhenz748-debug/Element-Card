using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class eneray : MonoBehaviour
{
    public static eneray _eneray;//单例
    public int Eneray=4;
    public Text text;
    public GameObject game;
    void Awake()
    {
        if (_eneray != null && _eneray != this)
        {
            Destroy(gameObject);
        }
        _eneray = this;
    }
    void Start()
    {
        EventCenter.Instance.AddEvent("恢复能量",Text);
    }
    public void Text()
    {
        Eneray=4;
        text.text=Eneray.ToString();
    }
    public bool SetText(int date)
    {
        if(Eneray-date<0)
        {
            Debug.Log("能量不够");
            StartCoroutine(Show());
        }
        else
        {
            Eneray-=date;
            text.text=Eneray.ToString();
            return true;
        }
        return false;
    }
    public IEnumerator Show()
    {
        game.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        game.SetActive(false);
    }
    // Start is called before the first frame update
}
