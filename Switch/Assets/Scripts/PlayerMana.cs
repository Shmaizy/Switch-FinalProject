using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int maxMana = 30;
    public int currentMana;
    int mana = 10;

    public ManaController manaBar;
    public void Start()
    {
        currentMana = maxMana;
        manaBar.SetMaxMana(maxMana);
    }

    public void ReduceMana ()
    {
        if (currentMana > 0)
        {
            currentMana = currentMana - mana;
            manaBar.SetMana(currentMana);
            Debug.Log(currentMana);
        }

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Mana Potion") && currentMana < 30)
        {
            FindObjectOfType<AudioManager>().Play("Mana potion");
            currentMana = currentMana + mana;
            manaBar.SetMana(currentMana);
            Destroy(col.gameObject);
            Debug.Log(currentMana);
        }
    }



}
