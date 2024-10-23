using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider_Off : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(turnOff());
    }

    IEnumerator turnOff()
    {
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
    }
}
