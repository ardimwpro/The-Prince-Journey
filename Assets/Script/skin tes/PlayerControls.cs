//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/Script/skin tes/PlayerControls.inputactions
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
            ""name"": ""Land"",
            ""id"": ""40a79631-c6e1-4a63-b0a0-8072ff136406"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d64884a0-48f0-41ff-9205-ba0de9cce7e2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""6ffdcfb6-d9c0-4432-8520-00fc72be31f6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""74bec549-8ff7-46f4-9b2c-ffde671c8f53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5b452f1c-acd4-4037-a03b-4de0258c47f7"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c6126521-4749-4cee-8d0b-1c04d2365879"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""405d79bf-34b9-4767-aefe-7e36b15b4d24"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""49df4ee0-07cc-4ad3-ad78-f5e7ae2b03a3"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""04ed8bc5-72d6-4d14-be99-0764c06f4e96"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""dd4200cc-8bc0-43a1-9c94-a1cfdbbaac50"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""2e711282-a539-4c8c-80d3-6f3ec41e3e7f"",
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
                    ""id"": ""0f3db7f8-2e7f-4c11-8f27-2de05f4d5d29"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8b47ce7-c321-4e74-9119-5b8059a64a54"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Land
        m_Land = asset.FindActionMap("Land", throwIfNotFound: true);
        m_Land_Move = m_Land.FindAction("Move", throwIfNotFound: true);
        m_Land_Jump = m_Land.FindAction("Jump", throwIfNotFound: true);
        m_Land_Run = m_Land.FindAction("Run", throwIfNotFound: true);
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

    // Land
    private readonly InputActionMap m_Land;
    private List<ILandActions> m_LandActionsCallbackInterfaces = new List<ILandActions>();
    private readonly InputAction m_Land_Move;
    private readonly InputAction m_Land_Jump;
    private readonly InputAction m_Land_Run;
    public struct LandActions
    {
        private @PlayerControls m_Wrapper;
        public LandActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Land_Move;
        public InputAction @Jump => m_Wrapper.m_Land_Jump;
        public InputAction @Run => m_Wrapper.m_Land_Run;
        public InputActionMap Get() { return m_Wrapper.m_Land; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LandActions set) { return set.Get(); }
        public void AddCallbacks(ILandActions instance)
        {
            if (instance == null || m_Wrapper.m_LandActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_LandActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Run.started += instance.OnRun;
            @Run.performed += instance.OnRun;
            @Run.canceled += instance.OnRun;
        }

        private void UnregisterCallbacks(ILandActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Run.started -= instance.OnRun;
            @Run.performed -= instance.OnRun;
            @Run.canceled -= instance.OnRun;
        }

        public void RemoveCallbacks(ILandActions instance)
        {
            if (m_Wrapper.m_LandActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ILandActions instance)
        {
            foreach (var item in m_Wrapper.m_LandActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_LandActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public LandActions @Land => new LandActions(this);
    public interface ILandActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
    }
}
