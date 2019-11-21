using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour
{
	private CharacterController controller;
	private float speed = 5.0f;
	private Vector3 moveVector=Vector3.zero;
	private float verticalVelocity=0.0f;
	private float gravity = 10.0f;
	private float animationDuration = 3.0f;
    private float startTime;

    private bool isDead = false;

    public GameObject scoreObj;

    public float jumpSpeed=7.0f;

    public Text coinText;
    private float coin = 0.0f;
    public GameObject coin1;
    public GameObject coin2;
    public GameObject coin3;
    public GameObject coin4;
    public GameObject coin5;
    public GameObject coin6;
    public GameObject coin7;
    public GameObject coin8;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController> ();
        startTime = Time.time;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
            return;

    	if(Time.time - startTime < animationDuration)
    	{
    		controller.Move(Vector3.forward * speed * Time.deltaTime);
    		return;
    	}

   //  	if(controller.isGrounded)
   //      {
			// verticalVelocity = -0.5f;
   //      }
   //      else
   //      {
   //      	verticalVelocity -= gravity * Time.deltaTime;
   //      }

    	//Calculate x,y and z value
    	moveVector.x = Input.GetAxisRaw("Horizontal")*speed;
        if(Input.GetMouseButton (0))
        {
            if(Input.mousePosition.x > Screen.width/2)
                moveVector.x = speed;
            else
                moveVector.x = -speed;
        }

        if (controller.isGrounded && Input.GetButton("Jump")) 
        {
            moveVector.y = jumpSpeed;
        }
        
        moveVector.y -= gravity * Time.deltaTime;

        //moveVector.y = verticalVelocity; //Input.GetAxisRaw("Vertical")*speed;
    	moveVector.z = speed;

        //To jump
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        // }

        controller.Move(moveVector * Time.deltaTime);
    }
    public void setSpeed(float changer)
    {
        speed = 7.0f + changer;   
    }

    //called everytime when the player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Debug.Log("hit point "+hit.point.z);
        // Debug.Log("player position "+transform.position.z);
        if ((hit.point.z > transform.position.z) & (hit.gameObject.tag == "Obstacle")) //(controller.radius/2)
        {
            // Debug.Log(hit.gameObject.tag);
            Death();
        }
        else if(hit.gameObject.tag == "coin1")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin1.SetActive(false);
        }
        // else if(hit.gameObject.tag == "coin1")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin2.SetActive(false);
        // }
        // else if(hit.gameObject.tag == "coin2")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin3.SetActive(false);
        // }
        // else if(hit.gameObject.tag == "coin3")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin4.SetActive(false);
        // }
        // else if(hit.gameObject.tag == "coin4")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin5.SetActive(false);
        // }
        // else if(hit.gameObject.tag == "coin5")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin6.SetActive(false);
        // }
        // else if(hit.gameObject.tag == "coin6")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin7.SetActive(false);
        // }
        // else if(hit.gameObject.tag == "coin7")
        // {
        //     coin = coin + 1;
        //     coinText.text = ((int)coin).ToString();
        //     // Destroy();
        //     coin8.SetActive(false);
        // }
    }

    private void Death()
    {
        // Debug.Log("GameOver");
        isDead = true;
        GetComponent<Score>().OnDeath();
        scoreObj.SetActive(false);
    }
}
