using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public static Player player;
    void Awake()
    {
        if (player != null && player != this)
        {
            Destroy(gameObject);
        }
        player=this;
    }
}