using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private BoxCollider boxCollider;
    private ContactPoint[] contacts;

    private bool grounded;
    public float jumpVelocity = 5f;
    public float moveVelocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();

        grounded = true;
    }

    void OnCollisionEnter()
    {
        Debug.Log("enter");
        grounded = true;
    }

    void OnCollisionExit()
    {
        Debug.Log("exit");
        grounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        float xspeed = Input.GetAxis("Horizontal") * moveVelocity;
        float yspeed = rigidBody.velocity.y;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            yspeed = jumpVelocity;
        }
        rigidBody.velocity = new Vector3(xspeed, yspeed, rigidBody.velocity.z);

        if (transform.position.y <= -20f)
        {
            SceneController.Instance.LoadNextScene();
        }
    }
}
