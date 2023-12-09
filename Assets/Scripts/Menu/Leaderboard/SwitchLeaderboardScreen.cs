using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLeaderboardScreen : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ClickArrow(int _index)
    {
        animator.SetInteger("ScreenIndex", animator.GetInteger("ScreenIndex") + _index);
        if (animator.GetInteger("ScreenIndex") <= 0)
        {
            animator.SetInteger("ScreenIndex", 0);
            leftArrow.SetActive(false);
        }
        else if (animator.GetInteger("ScreenIndex") >= 3)
        {
            animator.SetInteger("ScreenIndex", 3);
            rightArrow.SetActive(false);
        }
    }
}
