using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ClockManager : MonoBehaviour
{
    public TMP_Text time;

    private void Start()
    {
        StartCoroutine(TimeDecrease());
    }

    IEnumerator TimeDecrease()
    {
        time.text = "10";
        yield return new WaitForSeconds(1);
        time.text = "9";
        yield return new WaitForSeconds(1);
        time.text = "8";
        yield return new WaitForSeconds(1);
        time.text = "7";
        yield return new WaitForSeconds(1);
        time.text = "6";
        yield return new WaitForSeconds(1);
        time.text = "5";
        yield return new WaitForSeconds(1);
        time.text = "4";
        yield return new WaitForSeconds(1);
        time.text = "3";
        yield return new WaitForSeconds(1);
        time.text = "2";
        yield return new WaitForSeconds(1);
        time.text = "1";
        yield return new WaitForSeconds(1);
        time.text = "0";
        yield return new WaitForSeconds(3);

        StartCoroutine(TimeDecrease());
    }
}