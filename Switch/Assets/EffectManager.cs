using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private GameObject healEffect;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private ParticleSystem blockEffect;

    public void ActivateHitEffect()
    {
        hitEffect.transform.position = hitPoint.position;
        hitEffect.SetActive(true);
    }

    public void BlockEffect(bool isBlocking)
    {
        if (isBlocking)
        {
            blockEffect.gameObject.SetActive(true);
        }
        else
        {
            blockEffect.Stop();
        }
    }

    public void HealEffect()
    {
        healEffect.SetActive(true);
    }

}
