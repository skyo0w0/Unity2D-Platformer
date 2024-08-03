using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
    {
        #region Input vars
        public const string HorizontalAxis = "Horizontal";
        public const string VerticalAxis = "Vertical";
        public const string JumpButton = "Jump";
        public const string FireButton = "Fire1";
    #endregion

    public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool JumpReleased { get; private set; }
        public bool InteractPressed { get; private set; }
        public bool FirePressed { get; private set; }

    private void Update()
        {
            Horizontal = Input.GetAxis(HorizontalAxis);
            Vertical = Input.GetAxis(VerticalAxis);
            JumpPressed = Input.GetButton(JumpButton);
            JumpReleased = Input.GetButtonUp(JumpButton);
        //InteractPressed = Input.GetKeyDown(KeyCode.E);
            FirePressed = Input.GetButtonDown(FireButton);
        }

    }
