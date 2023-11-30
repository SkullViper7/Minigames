//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputActions/InputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @InputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Quiz"",
            ""id"": ""b367ded1-594a-4f60-a7c5-3c1aa9a7422e"",
            ""actions"": [
                {
                    ""name"": ""Answer1"",
                    ""type"": ""Button"",
                    ""id"": ""ecf77f68-2b06-464d-b669-32970e80871a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Answer2"",
                    ""type"": ""Button"",
                    ""id"": ""d88dbff7-250b-4db9-9d6a-f0e8d97037a8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Answer3"",
                    ""type"": ""Button"",
                    ""id"": ""39f05e20-bd5e-4073-9641-4becbdeee6de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Answer4"",
                    ""type"": ""Button"",
                    ""id"": ""5e101298-20f2-440b-a2cc-1b3fcd87ed7f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2129a886-c6d6-42eb-a8df-b9eaff2320d0"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fdd924f-f5e1-44e9-9f4b-4583de4dab03"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69b27bd6-84cd-41e0-a835-759aef1dd8a2"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""07c1eab5-ec8a-4415-9635-6a0a26c670f2"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6a968d5e-b9b5-4a89-abd7-01042c63ffc9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f6359a0-55de-4e93-a067-241e9cc79ec3"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""26d7ad73-6dfa-460a-9d05-8b4706d047dd"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4b642a96-0113-4e86-bc55-ae2f0cc6a129"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Answer4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""RocketRide"",
            ""id"": ""b1d9430f-ddb6-4063-a74e-df468b268ce5"",
            ""actions"": [
                {
                    ""name"": ""PropulsionGamepad"",
                    ""type"": ""Button"",
                    ""id"": ""2a121e6a-d251-4f6d-9d50-aae351ec8dd0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PropulsionKeyboardP1"",
                    ""type"": ""Button"",
                    ""id"": ""4363792f-6695-4d1d-8269-5bd9e3666baf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PropulsionKeyboardP2"",
                    ""type"": ""Button"",
                    ""id"": ""83f54abb-051f-448a-a0fa-5649af00f619"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PropulsionKeyboardP3"",
                    ""type"": ""Button"",
                    ""id"": ""f55f9983-58f3-43cb-9fdf-63d66f804982"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""PropulsionKeyboardP4"",
                    ""type"": ""Button"",
                    ""id"": ""c9c81450-ac33-45e0-94a9-b3c5cdd05051"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OrientationGamepad"",
                    ""type"": ""Value"",
                    ""id"": ""3d9be43c-8caf-4d4f-a981-8a487a94247b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""OrientationKeyboardP1"",
                    ""type"": ""Button"",
                    ""id"": ""c4f79c94-3a82-41b2-8693-3c2112f0d53d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OrientationKeyboardP2"",
                    ""type"": ""Button"",
                    ""id"": ""23b32fd2-e7b5-4ce4-a922-4e642b9b0d29"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OrientationKeyboardP3"",
                    ""type"": ""Button"",
                    ""id"": ""6503acd9-b168-425d-97a0-f44068a8b921"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""OrientationKeyboardP4"",
                    ""type"": ""Button"",
                    ""id"": ""e4cd63bb-47be-42d0-a8db-0ae2bf950f02"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""80bd8602-ab63-4719-80bb-cb551e338bca"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PropulsionGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5ee303bb-7cdc-4aae-ac61-8460c4f28819"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b878c0a1-cd23-4241-8f46-1ced89601e39"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5ba3637-e45d-45a9-943d-64ce0c1107d9"",
                    ""path"": ""<Keyboard>/numpadEnter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PropulsionKeyboardP4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6b9d0af-f28f-49ae-b3c1-1a6b87b27bdf"",
                    ""path"": ""<Keyboard>/alt"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PropulsionKeyboardP1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4667555c-d34e-46f9-8a05-22cd2faf0a8e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PropulsionKeyboardP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3921956-a323-4880-8382-49da58c00c3f"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PropulsionKeyboardP3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a1ca6d72-8533-4ba2-a9cd-1711d6154948"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb038d5c-72ce-44fe-a50d-3e635395c5c4"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eac7bea7-2d2a-40c1-8506-74a829817eed"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9eef4445-cbc4-48aa-8ca9-b98b63b35a88"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""60711620-08ce-4d3e-84a8-e6cd79d3910f"",
                    ""path"": ""<Keyboard>/numpad4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cc058fd-1f39-487e-9516-58ce95496b67"",
                    ""path"": ""<Keyboard>/numpad6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationKeyboardP4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b55f4219-1907-46dd-b7db-0c6487a604b1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OrientationGamepad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Quiz
        m_Quiz = asset.FindActionMap("Quiz", throwIfNotFound: true);
        m_Quiz_Answer1 = m_Quiz.FindAction("Answer1", throwIfNotFound: true);
        m_Quiz_Answer2 = m_Quiz.FindAction("Answer2", throwIfNotFound: true);
        m_Quiz_Answer3 = m_Quiz.FindAction("Answer3", throwIfNotFound: true);
        m_Quiz_Answer4 = m_Quiz.FindAction("Answer4", throwIfNotFound: true);
        // RocketRide
        m_RocketRide = asset.FindActionMap("RocketRide", throwIfNotFound: true);
        m_RocketRide_PropulsionGamepad = m_RocketRide.FindAction("PropulsionGamepad", throwIfNotFound: true);
        m_RocketRide_PropulsionKeyboardP1 = m_RocketRide.FindAction("PropulsionKeyboardP1", throwIfNotFound: true);
        m_RocketRide_PropulsionKeyboardP2 = m_RocketRide.FindAction("PropulsionKeyboardP2", throwIfNotFound: true);
        m_RocketRide_PropulsionKeyboardP3 = m_RocketRide.FindAction("PropulsionKeyboardP3", throwIfNotFound: true);
        m_RocketRide_PropulsionKeyboardP4 = m_RocketRide.FindAction("PropulsionKeyboardP4", throwIfNotFound: true);
        m_RocketRide_OrientationGamepad = m_RocketRide.FindAction("OrientationGamepad", throwIfNotFound: true);
        m_RocketRide_OrientationKeyboardP1 = m_RocketRide.FindAction("OrientationKeyboardP1", throwIfNotFound: true);
        m_RocketRide_OrientationKeyboardP2 = m_RocketRide.FindAction("OrientationKeyboardP2", throwIfNotFound: true);
        m_RocketRide_OrientationKeyboardP3 = m_RocketRide.FindAction("OrientationKeyboardP3", throwIfNotFound: true);
        m_RocketRide_OrientationKeyboardP4 = m_RocketRide.FindAction("OrientationKeyboardP4", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Quiz
    private readonly InputActionMap m_Quiz;
    private List<IQuizActions> m_QuizActionsCallbackInterfaces = new List<IQuizActions>();
    private readonly InputAction m_Quiz_Answer1;
    private readonly InputAction m_Quiz_Answer2;
    private readonly InputAction m_Quiz_Answer3;
    private readonly InputAction m_Quiz_Answer4;
    public struct QuizActions
    {
        private @InputActions m_Wrapper;
        public QuizActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Answer1 => m_Wrapper.m_Quiz_Answer1;
        public InputAction @Answer2 => m_Wrapper.m_Quiz_Answer2;
        public InputAction @Answer3 => m_Wrapper.m_Quiz_Answer3;
        public InputAction @Answer4 => m_Wrapper.m_Quiz_Answer4;
        public InputActionMap Get() { return m_Wrapper.m_Quiz; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QuizActions set) { return set.Get(); }
        public void AddCallbacks(IQuizActions instance)
        {
            if (instance == null || m_Wrapper.m_QuizActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_QuizActionsCallbackInterfaces.Add(instance);
            @Answer1.started += instance.OnAnswer1;
            @Answer1.performed += instance.OnAnswer1;
            @Answer1.canceled += instance.OnAnswer1;
            @Answer2.started += instance.OnAnswer2;
            @Answer2.performed += instance.OnAnswer2;
            @Answer2.canceled += instance.OnAnswer2;
            @Answer3.started += instance.OnAnswer3;
            @Answer3.performed += instance.OnAnswer3;
            @Answer3.canceled += instance.OnAnswer3;
            @Answer4.started += instance.OnAnswer4;
            @Answer4.performed += instance.OnAnswer4;
            @Answer4.canceled += instance.OnAnswer4;
        }

        private void UnregisterCallbacks(IQuizActions instance)
        {
            @Answer1.started -= instance.OnAnswer1;
            @Answer1.performed -= instance.OnAnswer1;
            @Answer1.canceled -= instance.OnAnswer1;
            @Answer2.started -= instance.OnAnswer2;
            @Answer2.performed -= instance.OnAnswer2;
            @Answer2.canceled -= instance.OnAnswer2;
            @Answer3.started -= instance.OnAnswer3;
            @Answer3.performed -= instance.OnAnswer3;
            @Answer3.canceled -= instance.OnAnswer3;
            @Answer4.started -= instance.OnAnswer4;
            @Answer4.performed -= instance.OnAnswer4;
            @Answer4.canceled -= instance.OnAnswer4;
        }

        public void RemoveCallbacks(IQuizActions instance)
        {
            if (m_Wrapper.m_QuizActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IQuizActions instance)
        {
            foreach (var item in m_Wrapper.m_QuizActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_QuizActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public QuizActions @Quiz => new QuizActions(this);

    // RocketRide
    private readonly InputActionMap m_RocketRide;
    private List<IRocketRideActions> m_RocketRideActionsCallbackInterfaces = new List<IRocketRideActions>();
    private readonly InputAction m_RocketRide_PropulsionGamepad;
    private readonly InputAction m_RocketRide_PropulsionKeyboardP1;
    private readonly InputAction m_RocketRide_PropulsionKeyboardP2;
    private readonly InputAction m_RocketRide_PropulsionKeyboardP3;
    private readonly InputAction m_RocketRide_PropulsionKeyboardP4;
    private readonly InputAction m_RocketRide_OrientationGamepad;
    private readonly InputAction m_RocketRide_OrientationKeyboardP1;
    private readonly InputAction m_RocketRide_OrientationKeyboardP2;
    private readonly InputAction m_RocketRide_OrientationKeyboardP3;
    private readonly InputAction m_RocketRide_OrientationKeyboardP4;
    public struct RocketRideActions
    {
        private @InputActions m_Wrapper;
        public RocketRideActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @PropulsionGamepad => m_Wrapper.m_RocketRide_PropulsionGamepad;
        public InputAction @PropulsionKeyboardP1 => m_Wrapper.m_RocketRide_PropulsionKeyboardP1;
        public InputAction @PropulsionKeyboardP2 => m_Wrapper.m_RocketRide_PropulsionKeyboardP2;
        public InputAction @PropulsionKeyboardP3 => m_Wrapper.m_RocketRide_PropulsionKeyboardP3;
        public InputAction @PropulsionKeyboardP4 => m_Wrapper.m_RocketRide_PropulsionKeyboardP4;
        public InputAction @OrientationGamepad => m_Wrapper.m_RocketRide_OrientationGamepad;
        public InputAction @OrientationKeyboardP1 => m_Wrapper.m_RocketRide_OrientationKeyboardP1;
        public InputAction @OrientationKeyboardP2 => m_Wrapper.m_RocketRide_OrientationKeyboardP2;
        public InputAction @OrientationKeyboardP3 => m_Wrapper.m_RocketRide_OrientationKeyboardP3;
        public InputAction @OrientationKeyboardP4 => m_Wrapper.m_RocketRide_OrientationKeyboardP4;
        public InputActionMap Get() { return m_Wrapper.m_RocketRide; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RocketRideActions set) { return set.Get(); }
        public void AddCallbacks(IRocketRideActions instance)
        {
            if (instance == null || m_Wrapper.m_RocketRideActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_RocketRideActionsCallbackInterfaces.Add(instance);
            @PropulsionGamepad.started += instance.OnPropulsionGamepad;
            @PropulsionGamepad.performed += instance.OnPropulsionGamepad;
            @PropulsionGamepad.canceled += instance.OnPropulsionGamepad;
            @PropulsionKeyboardP1.started += instance.OnPropulsionKeyboardP1;
            @PropulsionKeyboardP1.performed += instance.OnPropulsionKeyboardP1;
            @PropulsionKeyboardP1.canceled += instance.OnPropulsionKeyboardP1;
            @PropulsionKeyboardP2.started += instance.OnPropulsionKeyboardP2;
            @PropulsionKeyboardP2.performed += instance.OnPropulsionKeyboardP2;
            @PropulsionKeyboardP2.canceled += instance.OnPropulsionKeyboardP2;
            @PropulsionKeyboardP3.started += instance.OnPropulsionKeyboardP3;
            @PropulsionKeyboardP3.performed += instance.OnPropulsionKeyboardP3;
            @PropulsionKeyboardP3.canceled += instance.OnPropulsionKeyboardP3;
            @PropulsionKeyboardP4.started += instance.OnPropulsionKeyboardP4;
            @PropulsionKeyboardP4.performed += instance.OnPropulsionKeyboardP4;
            @PropulsionKeyboardP4.canceled += instance.OnPropulsionKeyboardP4;
            @OrientationGamepad.started += instance.OnOrientationGamepad;
            @OrientationGamepad.performed += instance.OnOrientationGamepad;
            @OrientationGamepad.canceled += instance.OnOrientationGamepad;
            @OrientationKeyboardP1.started += instance.OnOrientationKeyboardP1;
            @OrientationKeyboardP1.performed += instance.OnOrientationKeyboardP1;
            @OrientationKeyboardP1.canceled += instance.OnOrientationKeyboardP1;
            @OrientationKeyboardP2.started += instance.OnOrientationKeyboardP2;
            @OrientationKeyboardP2.performed += instance.OnOrientationKeyboardP2;
            @OrientationKeyboardP2.canceled += instance.OnOrientationKeyboardP2;
            @OrientationKeyboardP3.started += instance.OnOrientationKeyboardP3;
            @OrientationKeyboardP3.performed += instance.OnOrientationKeyboardP3;
            @OrientationKeyboardP3.canceled += instance.OnOrientationKeyboardP3;
            @OrientationKeyboardP4.started += instance.OnOrientationKeyboardP4;
            @OrientationKeyboardP4.performed += instance.OnOrientationKeyboardP4;
            @OrientationKeyboardP4.canceled += instance.OnOrientationKeyboardP4;
        }

        private void UnregisterCallbacks(IRocketRideActions instance)
        {
            @PropulsionGamepad.started -= instance.OnPropulsionGamepad;
            @PropulsionGamepad.performed -= instance.OnPropulsionGamepad;
            @PropulsionGamepad.canceled -= instance.OnPropulsionGamepad;
            @PropulsionKeyboardP1.started -= instance.OnPropulsionKeyboardP1;
            @PropulsionKeyboardP1.performed -= instance.OnPropulsionKeyboardP1;
            @PropulsionKeyboardP1.canceled -= instance.OnPropulsionKeyboardP1;
            @PropulsionKeyboardP2.started -= instance.OnPropulsionKeyboardP2;
            @PropulsionKeyboardP2.performed -= instance.OnPropulsionKeyboardP2;
            @PropulsionKeyboardP2.canceled -= instance.OnPropulsionKeyboardP2;
            @PropulsionKeyboardP3.started -= instance.OnPropulsionKeyboardP3;
            @PropulsionKeyboardP3.performed -= instance.OnPropulsionKeyboardP3;
            @PropulsionKeyboardP3.canceled -= instance.OnPropulsionKeyboardP3;
            @PropulsionKeyboardP4.started -= instance.OnPropulsionKeyboardP4;
            @PropulsionKeyboardP4.performed -= instance.OnPropulsionKeyboardP4;
            @PropulsionKeyboardP4.canceled -= instance.OnPropulsionKeyboardP4;
            @OrientationGamepad.started -= instance.OnOrientationGamepad;
            @OrientationGamepad.performed -= instance.OnOrientationGamepad;
            @OrientationGamepad.canceled -= instance.OnOrientationGamepad;
            @OrientationKeyboardP1.started -= instance.OnOrientationKeyboardP1;
            @OrientationKeyboardP1.performed -= instance.OnOrientationKeyboardP1;
            @OrientationKeyboardP1.canceled -= instance.OnOrientationKeyboardP1;
            @OrientationKeyboardP2.started -= instance.OnOrientationKeyboardP2;
            @OrientationKeyboardP2.performed -= instance.OnOrientationKeyboardP2;
            @OrientationKeyboardP2.canceled -= instance.OnOrientationKeyboardP2;
            @OrientationKeyboardP3.started -= instance.OnOrientationKeyboardP3;
            @OrientationKeyboardP3.performed -= instance.OnOrientationKeyboardP3;
            @OrientationKeyboardP3.canceled -= instance.OnOrientationKeyboardP3;
            @OrientationKeyboardP4.started -= instance.OnOrientationKeyboardP4;
            @OrientationKeyboardP4.performed -= instance.OnOrientationKeyboardP4;
            @OrientationKeyboardP4.canceled -= instance.OnOrientationKeyboardP4;
        }

        public void RemoveCallbacks(IRocketRideActions instance)
        {
            if (m_Wrapper.m_RocketRideActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IRocketRideActions instance)
        {
            foreach (var item in m_Wrapper.m_RocketRideActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_RocketRideActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public RocketRideActions @RocketRide => new RocketRideActions(this);
    public interface IQuizActions
    {
        void OnAnswer1(InputAction.CallbackContext context);
        void OnAnswer2(InputAction.CallbackContext context);
        void OnAnswer3(InputAction.CallbackContext context);
        void OnAnswer4(InputAction.CallbackContext context);
    }
    public interface IRocketRideActions
    {
        void OnPropulsionGamepad(InputAction.CallbackContext context);
        void OnPropulsionKeyboardP1(InputAction.CallbackContext context);
        void OnPropulsionKeyboardP2(InputAction.CallbackContext context);
        void OnPropulsionKeyboardP3(InputAction.CallbackContext context);
        void OnPropulsionKeyboardP4(InputAction.CallbackContext context);
        void OnOrientationGamepad(InputAction.CallbackContext context);
        void OnOrientationKeyboardP1(InputAction.CallbackContext context);
        void OnOrientationKeyboardP2(InputAction.CallbackContext context);
        void OnOrientationKeyboardP3(InputAction.CallbackContext context);
        void OnOrientationKeyboardP4(InputAction.CallbackContext context);
    }
}
