using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaController : MonoBehaviour
{
    [Header("ManaBar")]
    public Slider slider;

    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;
    }

    public void SetMana(int mana)
    {
        slider.value = mana;
    }

}
