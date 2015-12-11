using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(PlatformerCharacter2D))]
public class MarioMovement : MonoBehaviour {

    private PlatformerCharacter2D character;
    private bool jump;
    public TetrisScoreCounter scoreCounter;

    private void Awake()
    {
        character = GetComponent<PlatformerCharacter2D>();
    }

    private void Update()
    {
        if (!jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
            if (jump)
            {
                scoreCounter.PlayJumpSound();
            }
        }
    }

    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = 0; //CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        if (Input.GetKey(KeyCode.A))
        {
            h = -1;
        }
        if(Input.GetKey(KeyCode.D))
        {
            h = 1;
        }
        character.Move(h, crouch, jump);
        jump = false;
    }
}