using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		//private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			
			// Get input from the arrow keys or WASD
			float horizontalInput = Input.GetAxis("Horizontal"); //"Horizontal" for keys: A,D, left & right arrow keys
			float verticalInput = Input.GetAxis("Vertical"); //"Vertical" for keys: W, S, up & arrow keys

			// Calculate the movement direction
			Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

			// Normalize the movement vector to prevent faster diagonal movement
			movement.Normalize();
			
			//Checking if there was any input from the user
			if (horizontalInput !=0 || verticalInput!=0)
				anim.SetInteger ("AnimationPar", 1); //Animation for walking
			else
				anim.SetInteger ("AnimationPar", 0); //Animation for being still
			
			
			if (movement != Vector3.zero) //Vector.zero means the player is moving
			{
				Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up); //Based on the input, finds the direction it has to rotate
				transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, turnSpeed * Time.deltaTime); //rotating towards the direction found in toRotate
			}
			
			
			if (controller.isGrounded) //Checking if player's last move was on the ground
			{
				movement.y = 0f; // Reset the vertical movement when on the ground
			}
			else
			{
				movement.y -= gravity * Time.deltaTime; // Apply gravity when in the air
			}
			
			
			controller.Move(movement * Time.deltaTime * speed); //Move the gameObject
			
			
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				//code for saving statistics and score !!
				SceneManager.LoadScene("Menu");
			}


		}
	}
}
