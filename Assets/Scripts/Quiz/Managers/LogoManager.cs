using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoManager : MonoBehaviour
{
    private void Start()
    {
        if (GameManager.Instance.isOnKeyboard)
        {
            gameObject.SetActive(false);
        }
    }
}
