using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStarSpawner : MonoBehaviour
{
    public GameObject toSpawn;
    public float minDelay;
    public float range;
    public float minYOffset = 25f;
    public float minXOffset = -44f;
    public float maxYOffset = 40f;
    public float maxXOffset = 44f;
    public float minShrinkFactor = 0.5f;
    public float maxShrinkFactor = 2f;

    public float minYSpeed = -5f;
    public float maxYSpeed = -2f;

    public float maxXspeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStars());
    }
    IEnumerator SpawnStars()
    {
        while (true)
        {
            Vector3 offset = new Vector3(Random.Range(minXOffset, maxXOffset), Random.Range(minYOffset, maxYOffset), 0);
            Vector3 starPos = GameManager.Instance.playerPos + offset;
            
            GameObject newStar = Instantiate(toSpawn, starPos, Quaternion.identity);
            newStar.transform.localScale = newStar.transform.localScale * (Random.Range(minShrinkFactor, maxShrinkFactor));

            float yvelocity = Random.Range(minYSpeed, maxYSpeed);
            float xvelocity;

            if (offset.x > 0)
            {
                xvelocity = Random.Range(-maxXspeed, 0);
            }
            else
            {
                xvelocity = Random.Range(0, maxXspeed);
            }
            Rigidbody rigidBody = newStar.GetComponent<Rigidbody>();
            rigidBody.velocity = new Vector3(xvelocity, yvelocity, 0);
            yield return new WaitForSeconds(Random.Range(minDelay, minDelay + range));
        }

    }
}
