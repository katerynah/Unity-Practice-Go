using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetAnimations(AnimatorOverrideController overriderAnimatorController)
    {
        _animator.runtimeAnimatorController = overriderAnimatorController;
    }


}
