using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if(i == popUpIndex)
            {
                popUps[i].SetActive(true); 
            }

            else
            {
                popUps[i].SetActive(false);
            }
        }

        if (popUpIndex == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                popUpIndex++;
            }

        }

        else if (popUpIndex == 1)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.E))
            {
                popUpIndex++;
            }
        }

        else if (popUpIndex == 2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
        
    }
}
