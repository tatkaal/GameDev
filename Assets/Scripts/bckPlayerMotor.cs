using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bckPlayerMotor : MonoBehaviour
{
	private CharacterController charactercontroller;
	private float speed = 6.0f;
	private Vector3 moveDirection = Vector3.zero;
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
        charactercontroller = GetComponent<CharacterController>();
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
    		charactercontroller.Move(Vector3.forward * speed * Time.deltaTime);
    		return;
    	}

        moveDirection.x = Input.GetAxis("Horizontal")*speed;

        if(Input.GetMouseButton (0))
            {
                if(Input.mousePosition.x > Screen.width/2)
                    moveDirection.x = speed;
                else
                    moveDirection.x = -speed;
            }

        if (Input.GetButton("Jump")) //charactercontroller.isGrounded && 
        {
            // We are grounded, so recalculate
            // move direction directly from axes
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
       
    	moveDirection.z = speed;

        charactercontroller.Move(moveDirection * Time.deltaTime);
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
        else if(hit.gameObject.tag == "coin2")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin2.SetActive(false);
        }
        else if(hit.gameObject.tag == "coin3")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin3.SetActive(false);
        }
        else if(hit.gameObject.tag == "coin4")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin4.SetActive(false);
        }
        else if(hit.gameObject.tag == "coin5")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin5.SetActive(false);
        }
        else if(hit.gameObject.tag == "coin6")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin6.SetActive(false);
        }
        else if(hit.gameObject.tag == "coin7")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin7.SetActive(false);
        }
        else if(hit.gameObject.tag == "coin8")
        {
            coin = coin + 1;
            coinText.text = ((int)coin).ToString();
            // Destroy();
            coin8.SetActive(false);
        }
    }

    private void Death()
    {
        // Debug.Log("GameOver");
        isDead = true;
        GetComponent<Score>().OnDeath();
        scoreObj.SetActive(false);
    }
}
