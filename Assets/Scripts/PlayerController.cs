using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private BoxCollider boxCollider;
    private ContactPoint[] contacts;

    private bool grounded;
    private int timeSinceGrounded = 0;

    public int maxTimeInAirBeforeDeath = 3000;
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
        GameManager.Instance.originalLightColor = GetComponentInChildren<Light>().color;
        GameManager.Instance.originalLightIntensity = GetComponentInChildren<Light>().intensity;
        grounded = true;
    }

    void OnCollisionEnter()
    {

        grounded = true;
        timeSinceGrounded = 0;
    }

    void OnCollisionExit()
    {
        grounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!grounded) timeSinceGrounded += 1;
        float xspeed = Input.GetAxis("Horizontal") * moveVelocity;
        float yspeed = rigidBody.velocity.y;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            yspeed = jumpVelocity;
        }
        rigidBody.velocity = new Vector3(xspeed, yspeed, rigidBody.velocity.z);

        if (timeSinceGrounded >= maxTimeInAirBeforeDeath) Die();

        Vector3 diffVector = new Vector3(initPos.x - transform.position.x, initPos.y - transform.position.y, initPos.z - transform.position.z);
        distance = diffVector.magnitude;
        GameManager.Instance.playerPos = transform.position;
    }

    public void Die()
    {
        GameManager.Instance.SaveScore(distance);
        SceneController.Instance.LoadNextScene();
    }
    public float getCurrentDistanceFromSpawn()
    {
        return distance;
    }
}
