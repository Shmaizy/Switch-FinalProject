using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int maxMana = 30;
    public int currentMana;

    public ManaController manaBar;
    public void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    public void ReduceMana (int mana)
    {
        if (currentMana > 0)
        {
            currentMana = currentMana - mana;
            manaBar.SetMana(currentMana);
            Debug.Log(currentMana);
        }

    }


}
