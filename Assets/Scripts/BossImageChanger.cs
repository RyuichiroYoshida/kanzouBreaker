using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;

public class BossImageChanger : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;

    Image _image;

    BossController _controller;
    void Start()
    {
        Image _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        //BossSwitch(_controller._bossLife);
    }

    /*public string BossSwitch(int bosslife)
    {
        string i = null;
        return i switch
        {
            int bosslife when x == x -1 => i = "10",

            _ => throw new ArgumentOutOfRangeException(nameof(bosslife))
        };
    }*/
}
