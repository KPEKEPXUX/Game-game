using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public int fps;
    public Resolution resolution;
    public int money;
    
    public GameData()
    {
        money = 0;
        fps = 120;
        resolution = new Resolution();
        resolution.x = 1920;
        resolution.y = 1080;
    }
}
public class Resolution
{
    public int x,
               y;
}
