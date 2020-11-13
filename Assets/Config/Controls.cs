// GENERATED AUTOMATICALLY FROM 'Assets/Config/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Spider"",
            ""id"": ""dbeb539e-d6b5-43d1-8a8e-056bc85d11f1"",
            ""actions"": [
                {
                    ""name"": ""Web"",
                    ""type"": ""Button"",
                    ""id"": ""fa8f3748-1fab-46ec-bb6d-4bd2ae231323"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)""
                },
                {
                    ""name"": ""Swing"",
                    ""type"": ""PassThrough"",
                    ""id"": ""ad6bf5dc-4030-4cdd-abcc-cf34ca64b445"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Slide"",
                    ""type"": ""PassThrough"",
                    ""id"": ""77930f46-60fb-430c-b897-9c11fb9a7046"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""47cab2d2-fe0b-4654-ba83-9a7e48d3c415"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""81dec88f-92a8-4b90-8e4c-37cc1d03bc60"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Web"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ccb2910c-693c-49ff-84b4-88c6f27f04a7"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""36eb9219-2ca3-4e61-b5be-d991a4679db1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""3125b681-0de6-491b-9ddc-98122b0ac2f6"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""107028a9-cd71-43d1-a17e-bd201ff3e3c1"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Swing"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""8ade8ea2-ca50-49e4-9744-a1c914729fc9"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""25aa8fb6-7b0a-47ec-b2d1-390298aecc52"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Swing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""71d27809-d2d4-4a06-b1b1-8dd53c487b4c"",
                    ""path"": ""1DAxis(whichSideWins=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""a0ee85de-95f8-42ab-9826-25a5455aa956"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""7aadc83c-8533-48e2-87b3-055ae54f8d31"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""c4be5312-a682-4dbd-905f-38a0b91e858b"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Slide"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""16b6c847-9913-476d-9402-3036fe653a9e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""13848b96-a98e-46de-be9d-9a1676d980ec"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""Slide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Spider
        m_Spider = asset.FindActionMap("Spider", throwIfNotFound: true);
        m_Spider_Web = m_Spider.FindAction("Web", throwIfNotFound: true);
        m_Spider_Swing = m_Spider.FindAction("Swing", throwIfNotFound: true);
        m_Spider_Slide = m_Spider.FindAction("Slide", throwIfNotFound: true);
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

    // Spider
    private readonly InputActionMap m_Spider;
    private ISpiderActions m_SpiderActionsCallbackInterface;
    private readonly InputAction m_Spider_Web;
    private readonly InputAction m_Spider_Swing;
    private readonly InputAction m_Spider_Slide;
    public struct SpiderActions
    {
        private @Controls m_Wrapper;
        public SpiderActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Web => m_Wrapper.m_Spider_Web;
        public InputAction @Swing => m_Wrapper.m_Spider_Swing;
        public InputAction @Slide => m_Wrapper.m_Spider_Slide;
        public InputActionMap Get() { return m_Wrapper.m_Spider; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpiderActions set) { return set.Get(); }
        public void SetCallbacks(ISpiderActions instance)
        {
            if (m_Wrapper.m_SpiderActionsCallbackInterface != null)
            {
                @Web.started -= m_Wrapper.m_SpiderActionsCallbackInterface.OnWeb;
                @Web.performed -= m_Wrapper.m_SpiderActionsCallbackInterface.OnWeb;
                @Web.canceled -= m_Wrapper.m_SpiderActionsCallbackInterface.OnWeb;
                @Swing.started -= m_Wrapper.m_SpiderActionsCallbackInterface.OnSwing;
                @Swing.performed -= m_Wrapper.m_SpiderActionsCallbackInterface.OnSwing;
                @Swing.canceled -= m_Wrapper.m_SpiderActionsCallbackInterface.OnSwing;
                @Slide.started -= m_Wrapper.m_SpiderActionsCallbackInterface.OnSlide;
                @Slide.performed -= m_Wrapper.m_SpiderActionsCallbackInterface.OnSlide;
                @Slide.canceled -= m_Wrapper.m_SpiderActionsCallbackInterface.OnSlide;
            }
            m_Wrapper.m_SpiderActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Web.started += instance.OnWeb;
                @Web.performed += instance.OnWeb;
                @Web.canceled += instance.OnWeb;
                @Swing.started += instance.OnSwing;
                @Swing.performed += instance.OnSwing;
                @Swing.canceled += instance.OnSwing;
                @Slide.started += instance.OnSlide;
                @Slide.performed += instance.OnSlide;
                @Slide.canceled += instance.OnSlide;
            }
        }
    }
    public SpiderActions @Spider => new SpiderActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface ISpiderActions
    {
        void OnWeb(InputAction.CallbackContext context);
        void OnSwing(InputAction.CallbackContext context);
        void OnSlide(InputAction.CallbackContext context);
    }
}
