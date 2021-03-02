using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public float acceleration;
    public float maxSpeed;

    //hold a reference to the rigidbody component that's attached to Player
    private Rigidbody rigidBody;
    //arrary of keycodes to detect input
    private KeyCode[] inputKeys;
    //array of vector3 variables to hold directional data
    private Vector3[] directionsForKeys;
    
    // Start is called before the first frame update
    void Start () {
        inputKeys = new KeyCode[] { KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D };
        directionsForKeys = new Vector3[] { Vector3.forward, Vector3.left, Vector3.back, Vector3.right };
        rigidBody = GetComponent<Rigidbody>();
    }


    void FixedUpdate () {
        for (int i = 0; i < inputKeys.Length; i++){
            var key = inputKeys[i];

            // 2
            if(Input.GetKey(key)) {
            // 3
            Vector3 movement = directionsForKeys[i] * acceleration * Time.deltaTime;
            movePlayer(movement);
            }
        }
    }

    void movePlayer(Vector3 movement) {
        if(rigidBody.velocity.magnitude * acceleration > maxSpeed) {
            rigidBody.AddForce(movement * -1);
        } else {
            rigidBody.AddForce(movement);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
