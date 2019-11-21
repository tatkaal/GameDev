using UnityEngine;
public class Jump : MonoBehaviour {
    // public bool isGrounded;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up*7, ForceMode.Impulse);
        }
    }
}