using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Copyright (C) Xenfinity LLC - All Rights Reserved
 * Unauthorized copying of this file, via any medium is strictly prohibited
 * Proprietary and confidential
 * Written by Bilal Itani <bilalitani1@gmail.com>, June 2017
 */

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
    }

	void Update ()
    {

        // Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        // rb.AddForce(movement * speed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
        }
    }
}
