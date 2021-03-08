using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EasySurvivalScripts
{
    

    public class butcheredPlayerMovement : MonoBehaviour
    {
        public PlayerStates playerStates;

        [Header("Inputs")]
        public string HorizontalInput = "Horizontal";
        public string VerticalInput = "Vertical";
        public string RunInput = "Run";
        public string JumpInput = "Jump";

        [Header("Player Motor")]
        [Range(1f, 15f)]
        public float walkSpeed;
        [Range(1f, 15f)]
        public float runSpeed;
        [Range(1f, 15f)]
        public float JumpForce;
        public Transform FootLocation;

        

        CharacterController characterController;

        

        // Use this for initialization
        void Start()
        {
            characterController = GetComponent<CharacterController>();
            
        }

        // Update is called once per frame
        void Update()
        {
            //handle controller
            HandlePlayerControls();

           

           
        }

        void HandlePlayerControls()
        {
            float hInput = Input.GetAxisRaw(HorizontalInput);
            float vInput = Input.GetAxisRaw(VerticalInput);

            Vector3 fwdMovement = characterController.isGrounded == true ? transform.forward * vInput : Vector3.zero;
            Vector3 rightMovement = characterController.isGrounded == true ? transform.right * hInput : Vector3.zero;

            float _speed = Input.GetButton(RunInput) ? runSpeed : walkSpeed;
            characterController.SimpleMove(Vector3.ClampMagnitude(fwdMovement + rightMovement, 1f) * _speed);

            if (characterController.isGrounded)
                Jump();

            //Managing Player States
            if (characterController.isGrounded)
            {
                if (hInput == 0 && vInput == 0)
                    playerStates = PlayerStates.Idle;
                else
                {
                    if (_speed == walkSpeed)
                        playerStates = PlayerStates.Walking;
                    else
                        playerStates = PlayerStates.Running;

                    
                }
            }
            else
                playerStates = PlayerStates.Jumping;
        }

        void Jump()
        {
            if (Input.GetButtonDown(JumpInput))
            {
               
            }
        }

        IEnumerator PerformJumpRoutine()
        {
            //play jump sound
            

            float _jump = JumpForce;

            do
            {
                characterController.Move(Vector3.up * _jump * Time.deltaTime);
                _jump -= Time.deltaTime;
                yield return null;
            }
            while (!characterController.isGrounded);

            //play land sound
            

        }

        

        bool onGround()
        {
            bool retVal = false;

            if (Physics.Raycast(FootLocation.position, Vector3.down, 0.1f))
                retVal = true;
            else
                retVal = false;

            return retVal;
        }

        

    }
}
