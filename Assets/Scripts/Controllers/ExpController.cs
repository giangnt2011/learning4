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
        set { Level = value; txtLevel.text = "Lv." + Level; }
    }
    public void CollectEXP(float exp)
    {
        ChangeValue(currentValue + exp);
        if (currentValue == maxValue) 
        {
            SetLevel(Level+1);
            txtLevel.text = "Lv." + Level;
        }
    }

    public void SetLevel(int level)
    {
        ChangeValue(0);
        this.level = level;
        if(upLevel != null)
        {
            upLevel(level);
        }
        txtLevel.text = "Lv." + Level;
    }
}
