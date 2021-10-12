using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlUpStats : MonoBehaviour
{
    public int level = 1;
    public float experience { get; private set; }
    public Text lvlText;
    public Image expBarImage;


    private static int ExpNeedToLvlUp(int currentLvl)
    {
        if (currentLvl == 0)
        {
            return 0;
        }

        return (currentLvl * currentLvl) * 5;
    }

    public void SetExperience(float exp)
    {
        experience += exp;

        float expNeeded = ExpNeedToLvlUp(level);
        float previousExperience = ExpNeedToLvlUp(level - 1);


        if (experience > expNeeded)
        {
            LevelUp();
            expNeeded = ExpNeedToLvlUp(level);
            Debug.Log(expNeeded);
            previousExperience = ExpNeedToLvlUp(level - 1);
        }

        expBarImage.fillAmount = (experience - previousExperience) / (expNeeded - previousExperience);

        if (expBarImage.fillAmount == 1)
        {
            expBarImage.fillAmount = 0;
        }
    }

    public void LevelUp()
    {
        level++;
        lvlText.text = level.ToString("");
    }
}
