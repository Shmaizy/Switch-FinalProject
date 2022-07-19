using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    public static AnimationEvents instance;
    [SerializeField] Animator animator;

    private void Awake()
    {
        instance = this;
    }
    public IEnumerator AnimationEndPoint (string varName, bool boolValue, string animationName)
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;

        float animationLength = 0;

        foreach (var clip in clips)
        {
            if(clip.name == animationName)
            {
                animationLength = clip.length;
            }

        }

        Debug.Log(animationLength);
        Debug.Log(animationName);

        yield return new WaitForSeconds(animationLength);

        animator.SetBool(varName, boolValue);

    }
    



}
