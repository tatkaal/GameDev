using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupPoints : MonoBehaviour
{
    public Text coinText;
    private float coin = 0.0f;
    // public GameObject coins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //called everytime when the player hits something
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Debug.Log("hit point "+hit.point.z);
        // Debug.Log("player position "+transform.position.z);
        if(hit.gameObject.tag == "Player")
        {
            coin = coin + 1;            
            // Destroy();
            //coinText = GameObject.Find("CoinText").GetComponent<Text>();
            coinText.text = ((int)coin).ToString();
            gameObject.SetActive(false);
        }
    }
}
