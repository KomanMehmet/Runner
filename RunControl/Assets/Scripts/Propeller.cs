using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public Animator _animator;
    public float duration;
    public BoxCollider wind;

    public void Animation_State(string state)
    {
        if (state == "true")
        {
            _animator.SetBool("Work", true);
            wind.enabled = true;
        }
        else
        {
            _animator.SetBool("Work", false);
            wind.enabled = false;
        }

        StartCoroutine(Animation_Trigger());
    }

    IEnumerator Animation_Trigger()
    {
        yield return new WaitForSeconds(duration);
        Animation_State("true");
    }
}
