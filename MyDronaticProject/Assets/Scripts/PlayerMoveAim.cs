using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMoveAim : MonoBehaviour
{
		public float moveSpeed = 5f;
		public Rigidbody2D rb;
		public Text countText;
		public Text timerText;
		public Camera cam;
		public Button exitEarly;
		public Button playAgain;
		public Button exit;
		Vector2 movement;
		Vector2 mousePos;
		private int count;
		public float countdown = 60.0f;
		
		void Awake()
		{
			  //assign rigidbody2D and camera to variables
			  rb = GetComponent<Rigidbody2D>();
			  cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>() as Camera;
				count = 0;
				SetCountText();
		}
		
		void Update()
		{
				if (gameObject != null)
				{
						//for position, get axis inputs
						movement.x = Input.GetAxisRaw("Horizontal");
						movement.y = Input.GetAxisRaw("Vertical");
						//for rotation: get mouse position 
						mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            
						Timer();
						
				}
		}

		void FixedUpdate()
		{
				//actual movement uses Rigidbody, so goes in FixedUpdate
				rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
				//actual rotation uses vector math to calculate angle, and then rotates character towards mouse
				Vector2 lookDir = mousePos - rb.position;
				float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
				rb.rotation = angle;
		}
		
		void OnTriggerEnter2D(Collider2D col)
		{
			  if (col.gameObject.name == "Coin(Clone)") {
						count++;
						Destroy(col.gameObject);
						SetCountText();
				}
		}
		
		void OnCollisionEnter2D(Collision2D col)
		{
			  if (col.gameObject.name == "Drone(Clone)") {
					 if (count > 0) {
							 count--;
							 SetCountText();
					 }
				}
		}
		
		void SetCountText()
		{
			  countText.text = "Score: " + count.ToString();
		}
		
		void Timer()
		{
				if (countdown > 0)
				{
						countdown -= Time.deltaTime;
						timerText.text = "Time: " + (countdown).ToString("0");
				} else {
						exitEarly.gameObject.SetActive(false);
						playAgain.gameObject.SetActive(true);
						exit.gameObject.SetActive(true);
				}
		}
		
}