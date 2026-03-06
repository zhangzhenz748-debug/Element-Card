using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class eneray : MonoBehaviour
{
    public static eneray _eneray;
    public int Eneray=4;
    public Text text;
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
        }
        else
        {
            Eneray-=date;
            text.text=Eneray.ToString();
            return true;
        }
        return false;
    }
    // Start is called before the first frame update
}
