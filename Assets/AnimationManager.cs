using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public IEnumerator CrossFadeWhite(){
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
