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

    public Animator animator;
    public GameObject model;
    private Vector3 initPos;
    private float distance;
    private float timeIdle = 0;

    private Light spotLight;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        initPos = transform.position;
        GameManager.Instance.originalLightColor = GetComponentInChildren<Light>().color;
        GameManager.Instance.originalLightIntensity = GetComponentInChildren<Light>().intensity;
        model = GameObject.Find("Astronaut Model");
        animator = GetComponentInChildren<Animator>();
        spotLight = GetComponentInChildren<Light>();
        grounded = true;
    }

    void OnCollisionEnter()
    {
        animator.SetBool("Jumping", false);
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
        if (xspeed > 0)
        {
            model.transform.rotation = Quaternion.Euler(0, 90, 0);
            spotLight.transform.localRotation = Quaternion.Euler(spotLight.transform.rotation.eulerAngles.x, -8, spotLight.transform.rotation.eulerAngles.z);
        }

        if (xspeed < 0)
        {
            model.transform.rotation = Quaternion.Euler(0, 270, 0);
            spotLight.transform.localRotation = Quaternion.Euler(spotLight.transform.rotation.eulerAngles.x, -25, spotLight.transform.rotation.eulerAngles.z);
        }

        if (xspeed == 0)
        {
            timeIdle++;
        }
        if (xspeed != 0)
        {
            animator.SetBool("IsRunning", true);
            timeIdle = 0;
        }

        if (timeIdle > 10)
        {
            animator.SetBool("IsRunning", false);
        }
        float yspeed = rigidBody.velocity.y;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            animator.SetBool("Jumping", true);
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
