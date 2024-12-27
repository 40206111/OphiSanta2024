//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Input/PlayerControls.inputactions
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

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""BattleControls"",
            ""id"": ""27c132c4-674a-41b8-abc8-99bb8b583865"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""feb5851c-922f-4aff-add7-afe218987f32"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Submit"",
                    ""type"": ""Button"",
                    ""id"": ""486ee6c4-0997-4f6a-811c-8a17b485016d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""cc7fe271-5f45-40b7-a26f-06c01c6356ff"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""77779d8f-334c-4d78-886f-dfc0cb555fbd"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5a3f4491-5ae4-469d-8e0a-f31e515b7de1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4a6143df-050c-46d6-a1e1-a20bf22de0cc"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""196fe2bd-7908-414c-b24f-f7fef9080c4b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ff5375bd-17f7-4e75-a83a-21b17f57bf48"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2f855b99-cfe7-4a76-a671-51a99ff0b1f8"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1106155c-f15d-4fe5-af09-e744704a5435"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0fe4f5fb-8c86-4b0b-bacc-a4713b912ff6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Submit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GameNavigation"",
            ""id"": ""a9ba5e55-6311-4f27-9b12-09255048ccb1"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""a5afc2f0-978b-43a7-b99f-05f8a9b4d89b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ddfdce48-3d38-49af-9687-a830f7617b72"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7668ba76-4a93-4a57-a6d2-02f45a078464"",
                    ""path"": ""<Keyboard>/anyKey"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BattleControls
        m_BattleControls = asset.FindActionMap("BattleControls", throwIfNotFound: true);
        m_BattleControls_Move = m_BattleControls.FindAction("Move", throwIfNotFound: true);
        m_BattleControls_Submit = m_BattleControls.FindAction("Submit", throwIfNotFound: true);
        // GameNavigation
        m_GameNavigation = asset.FindActionMap("GameNavigation", throwIfNotFound: true);
        m_GameNavigation_Restart = m_GameNavigation.FindAction("Restart", throwIfNotFound: true);
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

    // BattleControls
    private readonly InputActionMap m_BattleControls;
    private List<IBattleControlsActions> m_BattleControlsActionsCallbackInterfaces = new List<IBattleControlsActions>();
    private readonly InputAction m_BattleControls_Move;
    private readonly InputAction m_BattleControls_Submit;
    public struct BattleControlsActions
    {
        private @PlayerControls m_Wrapper;
        public BattleControlsActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_BattleControls_Move;
        public InputAction @Submit => m_Wrapper.m_BattleControls_Submit;
        public InputActionMap Get() { return m_Wrapper.m_BattleControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BattleControlsActions set) { return set.Get(); }
        public void AddCallbacks(IBattleControlsActions instance)
        {
            if (instance == null || m_Wrapper.m_BattleControlsActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_BattleControlsActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Submit.started += instance.OnSubmit;
            @Submit.performed += instance.OnSubmit;
            @Submit.canceled += instance.OnSubmit;
        }

        private void UnregisterCallbacks(IBattleControlsActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Submit.started -= instance.OnSubmit;
            @Submit.performed -= instance.OnSubmit;
            @Submit.canceled -= instance.OnSubmit;
        }

        public void RemoveCallbacks(IBattleControlsActions instance)
        {
            if (m_Wrapper.m_BattleControlsActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IBattleControlsActions instance)
        {
            foreach (var item in m_Wrapper.m_BattleControlsActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_BattleControlsActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public BattleControlsActions @BattleControls => new BattleControlsActions(this);

    // GameNavigation
    private readonly InputActionMap m_GameNavigation;
    private List<IGameNavigationActions> m_GameNavigationActionsCallbackInterfaces = new List<IGameNavigationActions>();
    private readonly InputAction m_GameNavigation_Restart;
    public struct GameNavigationActions
    {
        private @PlayerControls m_Wrapper;
        public GameNavigationActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_GameNavigation_Restart;
        public InputActionMap Get() { return m_Wrapper.m_GameNavigation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameNavigationActions set) { return set.Get(); }
        public void AddCallbacks(IGameNavigationActions instance)
        {
            if (instance == null || m_Wrapper.m_GameNavigationActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameNavigationActionsCallbackInterfaces.Add(instance);
            @Restart.started += instance.OnRestart;
            @Restart.performed += instance.OnRestart;
            @Restart.canceled += instance.OnRestart;
        }

        private void UnregisterCallbacks(IGameNavigationActions instance)
        {
            @Restart.started -= instance.OnRestart;
            @Restart.performed -= instance.OnRestart;
            @Restart.canceled -= instance.OnRestart;
        }

        public void RemoveCallbacks(IGameNavigationActions instance)
        {
            if (m_Wrapper.m_GameNavigationActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameNavigationActions instance)
        {
            foreach (var item in m_Wrapper.m_GameNavigationActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameNavigationActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameNavigationActions @GameNavigation => new GameNavigationActions(this);
    public interface IBattleControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSubmit(InputAction.CallbackContext context);
    }
    public interface IGameNavigationActions
    {
        void OnRestart(InputAction.CallbackContext context);
    }
}
