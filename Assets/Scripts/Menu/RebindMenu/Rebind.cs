using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class Rebind : MonoBehaviour
{
    /*
    [SerializeField] private InputActionReference jumpAction = null;
    [SerializeField] private InputActionReference mouvementAction = null;
    [SerializeField] private InputActionReference attackAction = null;
    [SerializeField] private InputActionReference changeTimeAction = null;
    [SerializeField] private TMP_Text jumpDisplayNameText = null;
    [SerializeField] private TMP_Text upDisplayNameText = null;
    [SerializeField] private TMP_Text downDisplayNameText = null;
    [SerializeField] private TMP_Text rightDisplayNameText = null;
    [SerializeField] private TMP_Text leftDisplayNameText = null;
    [SerializeField] private TMP_Text attackDisplayNameText = null;
    [SerializeField] private TMP_Text changeTimeDisplayNameText = null;
    [SerializeField] private GameObject JumpButton = null;
    [SerializeField] private GameObject UpButton = null;
    [SerializeField] private GameObject DownButton = null;
    [SerializeField] private GameObject RightButton = null;
    [SerializeField] private GameObject LeftButton = null;
    [SerializeField] private GameObject AttackButton = null;
    [SerializeField] private GameObject ChangeTimeButton = null;
    [SerializeField] private GameObject startRebindObject = null;
    
    */

    public GameObject waitingForInputObject = null;

    private string currentMapAction;

    private InputActionRebindingExtensions.RebindingOperation rebindingOperation;

    private const string RebindsKey = "rebinds";

    private GameObject startRebindObject;

    public void TheActionToRebind (string _nameOfTheAction, Button _button)
    {
        startRebindObject = _button.gameObject;
        StartRebinding(_nameOfTheAction);
    }

    public void InitBindToButton()
    {

    }

    // Start is called before the first frame update
    /*void Start()
    {
        RebindManager.Instance.playerInput.SwitchCurrentActionMap("PlayerActions");

        // En utilisant un tuto de DapperDino
        string rebinds = PlayerPrefs.GetString(RebindsKey, string.Empty);

        if (string.IsNullOrEmpty(rebinds))
        {
            return;
        }
        RebindManager.Instance.playerInput.actions.LoadBindingOverridesFromJson(rebinds);


        jumpDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            jumpAction.action.bindings[jumpAction.action.GetBindingIndexForControl(jumpAction.action.controls[0])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        attackDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            attackAction.action.bindings[attackAction.action.GetBindingIndexForControl(attackAction.action.controls[0])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        changeTimeDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            changeTimeAction.action.bindings[changeTimeAction.action.GetBindingIndexForControl(changeTimeAction.action.controls[0])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        upDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            mouvementAction.action.bindings[mouvementAction.action.GetBindingIndexForControl(mouvementAction.action.controls[0])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        downDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            mouvementAction.action.bindings[mouvementAction.action.GetBindingIndexForControl(mouvementAction.action.controls[1])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        rightDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            mouvementAction.action.bindings[mouvementAction.action.GetBindingIndexForControl(mouvementAction.action.controls[2])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
        leftDisplayNameText.text = QwertyToAzerty(InputControlPath.ToHumanReadableString(
            mouvementAction.action.bindings[mouvementAction.action.GetBindingIndexForControl(mouvementAction.action.controls[3])].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice));
    }*/

    public void Save()
    {
        string rebinds = RebindManager.Instance.playerInput.actions.SaveBindingOverridesAsJson();

        PlayerPrefs.SetString(RebindsKey, rebinds);
    }
    public void StartRebinding(string ButtonRebind)
    {
        Debug.Log("start");
        int controlsFromActions = 0;
        // InputActionForRebind.action = new InputAction(expectedControlType: "Vector2");
        currentMapAction = RebindManager.Instance.playerInput.currentActionMap.name;
        startRebindObject.SetActive(false);
        waitingForInputObject.transform.position = startRebindObject.transform.position;
        waitingForInputObject.SetActive(true);
        Debug.Log(RebindManager.Instance.playerInput.currentActionMap);
        List<InputAction> _actions = new List<InputAction>();
        foreach (InputAction _action in RebindManager.Instance.playerInput.currentActionMap.actions)
        {
            _actions.Add(_action);
        }
            
        RebindManager.Instance.playerInput.SwitchCurrentActionMap("Rebind");
        
        foreach (InputAction _action in _actions)
        {
            Debug.Log(_action.name);
            Debug.Log(ButtonRebind);
            if(_action.name == ButtonRebind)
            {
                rebindingOperation = _action.PerformInteractiveRebinding(controlsFromActions)
                .WithControlsExcluding("Mouse")
                .OnMatchWaitForAnother(0.1f)
                .OnComplete(operation => RebindComplete(_action, controlsFromActions, startRebindObject.transform.GetChild(0).GetComponent<TMP_Text>()))
                .Start();
            }
        }
        

        /*
        switch (ButtonRebind)
        {
            case "jump":
                InputActionForRebind = jumpAction;
                bindingDisplayNameText = jumpDisplayNameText;
                startRebindObject = JumpButton;
                break;
            case "up":
                InputActionForRebind = mouvementAction;
                bindingDisplayNameText = upDisplayNameText;
                startRebindObject = UpButton;
                break;
            case "down":
                InputActionForRebind = mouvementAction;
                controlsFromActions = 1;
                bindingDisplayNameText = downDisplayNameText;
                startRebindObject = DownButton;
                break;
            case "right":
                InputActionForRebind = mouvementAction;
                controlsFromActions = 3;
                bindingDisplayNameText = rightDisplayNameText;
                startRebindObject = RightButton;
                break;
            case "left":
                InputActionForRebind = mouvementAction;
                controlsFromActions = 2;
                bindingDisplayNameText = leftDisplayNameText;
                startRebindObject = LeftButton;
                break;
            case "attack":
                InputActionForRebind = attackAction;
                bindingDisplayNameText = attackDisplayNameText;
                startRebindObject = AttackButton;
                break;
            case "changeTime":
                InputActionForRebind = changeTimeAction;
                bindingDisplayNameText = changeTimeDisplayNameText;
                startRebindObject = ChangeTimeButton;
                break;
        }

        
        
        

        
        if (InputActionForRebind == mouvementAction)
        {
            rebindingOperation = InputActionForRebind.action.PerformInteractiveRebinding(controlsFromActions + 1)
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(InputActionForRebind, controlsFromActions, bindingDisplayNameText))
            .Start();
        }
        else
        {
            rebindingOperation = InputActionForRebind.action.PerformInteractiveRebinding(controlsFromActions)
            .WithControlsExcluding("Mouse")
            .OnMatchWaitForAnother(0.1f)
            .OnComplete(operation => RebindComplete(InputActionForRebind, controlsFromActions, bindingDisplayNameText))
            .Start();
        }
        */
    }
    private void RebindComplete(InputAction ActionForRebind, int TheControlsFromActions, TMP_Text bindingDisplayNameText)
    {
        Debug.Log("complete");
        int bindingIndex = ActionForRebind.GetBindingIndexForControl(ActionForRebind.controls[TheControlsFromActions]);

        string QwertyCaracter = InputControlPath.ToHumanReadableString(
            ActionForRebind.bindings[bindingIndex].effectivePath,
            InputControlPath.HumanReadableStringOptions.OmitDevice);
        bindingDisplayNameText.text = QwertyToAzerty(QwertyCaracter);
        rebindingOperation.Dispose();
        
        startRebindObject.SetActive(true);
        waitingForInputObject.SetActive(false);
        
        RebindManager.Instance.playerInput.SwitchCurrentActionMap(currentMapAction);
        Save();
    }

    private string QwertyToAzerty(string QwertyCaracterToAzerty)
    {

        switch (QwertyCaracterToAzerty)
        {
            case "Q":
                QwertyCaracterToAzerty = "A";
                break;
            case "W":
                QwertyCaracterToAzerty = "Z";
                break;
            case "A":
                QwertyCaracterToAzerty = "Q";
                break;
            case ";":
                QwertyCaracterToAzerty = "M";
                break;
            case "Z":
                QwertyCaracterToAzerty = "W";
                break;
            case "M":
                QwertyCaracterToAzerty = ",";
                break;
        }
        return QwertyCaracterToAzerty;
    }
  
}
