﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class NewBehaviourScript : MonoBehaviour
{
    public FixedJoystick MoveJoyStick;
    public FixedButton JumpButton;
    public FixedTouchField TouchField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var fps = GetComponent<RigidbodyFirstPersonController>();
        fps.RunAxis = MoveJoyStick.Direction;
        fps.JumpAxis = JumpButton.Pressed;
        fps.mouseLook.LookAxis = TouchField.TouchDist;
    }
}
