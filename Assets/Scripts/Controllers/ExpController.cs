using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExpController : ProcessingController
{
    [SerializeField] TextMeshPro txtLevel;
    public delegate void UpLevel(int level);
    public UpLevel upLevel;
    int level;
    public int Level {
        get { return level; }
        set { level = value; txtLevel.text = "Lv." + level; }
    }
    public void CollectEXP(float exp)
    {
        ChangeValue(currentValue + exp);
        if (currentValue == maxValue) 
        {
            SetLevel(level+1);
        }
    }

    public void SetLevel(int level)
    {
        Debug.Log(currentValue+ " " + level);
        ChangeValue(0);
        this.level = level;
        if(upLevel != null)
        {
            upLevel(level);
        }
    }
}
