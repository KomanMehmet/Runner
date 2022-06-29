using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlot : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSeconds(4f);
        gameObject.SetActive(false);
    }
}
