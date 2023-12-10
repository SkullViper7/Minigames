using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreen : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    private GameObject leftArrow;
    [SerializeField]
    private GameObject rightArrow;

    private void Start()
    {
        animator = GetComponent<Animator>();
        RebindManager.Instance.ChangeTheMap(GetMapName());
    }

    public void ClickArrow(int _index)
    {
        animator.SetInteger("ScreenIndex", animator.GetInteger("ScreenIndex") + _index);
        if (animator.GetInteger("ScreenIndex") <= 0)
        {
            animator.SetInteger("ScreenIndex", 0);
            leftArrow.SetActive(false);
        }
        else if(animator.GetInteger("ScreenIndex") >= 3)
        {
            animator.SetInteger("ScreenIndex", 3);
            rightArrow.SetActive(false);
        }
        
        RebindManager.Instance.ChangeTheMap(GetMapName());
    }

    string GetMapName() 
    {
        string _mapName = "";
        switch (animator.GetInteger("ScreenIndex"))
        {
            case 0:
                _mapName = "Quiz";
                break;
            case 1:
                _mapName = "SlimeJump";
                break;
            case 2:
                _mapName = "RocketRide";
                break;
            case 3:
                _mapName = "BTBloc";
                break;
        }
        return _mapName;
    }
}
