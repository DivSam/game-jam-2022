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

    private Vector3 initPos;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        initPos = transform.position;

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

        if (transform.position.y <= -100f)
        {
            SceneController.Instance.LoadNextScene();
        }

        Vector3 diffVector = new Vector3(initPos.x - transform.position.x, initPos.y - transform.position.y, initPos.z - transform.position.z);
        distance = diffVector.magnitude;
    }

    public float getCurrentDistanceFromSpawn()
    {
        return distance;
    }
}
