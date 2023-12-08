using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class RebindManager : MonoBehaviour
{
    //Singleton
    private static RebindManager _instance = null;
    public static RebindManager Instance => _instance;
    //

    public PlayerInput playerInput;
    public TMP_Dropdown dropDown;
    private RebindUI rebindUI;
    public Rebind rebind;
    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
        
        playerInput = GetComponent<PlayerInput>();
        rebindUI = GetComponent<RebindUI>();
        rebind = GetComponent<Rebind>();
    }

    public void ChangeTheMap()
    {
        string dropdownText = dropDown.options[dropDown.value].text;

        Object[] _allButton = rebindUI.SearchAllButton(dropdownText);

        if (dropdownText != "None")
        {
            playerInput.SwitchCurrentActionMap(dropdownText);
            /* for(int i = 0;  i < _allButton.Length; i++)
             {

             }
             foreach (GameObject button in _allButton)
             {

             }*/
            rebind.InitBindToButton();
        }
        
        

        

        /*
        switch (_nameOfTheMap)
        {
            case "Quiz":
                playerInput.currentActionMap = 
                break;

            case "SlimeJump":
                break;

            case "RocketRide":
                break;

            case "BTBloc":
                break;
        }*/
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
