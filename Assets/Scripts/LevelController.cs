using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    private const float PLAYER_DISTANCE_FROM_SPAWN = 100f;

    [SerializeField] private Transform startPoint;

    [SerializeField] private Transform subsequentPoint;

    [SerializeField] private Transform player;

    private Vector3 lastEndPosition;
    private void Awake()
    {
        lastEndPosition = startPoint.Find("Endpoint").position;

        int parts = 5;

        for (int i = 0; i<parts; i++)
        {
            SpawnLevelPart();
        }
    }

    private void Update()
    {
        if(Vector3.Distance(player.position,lastEndPosition) < PLAYER_DISTANCE_FROM_SPAWN)
        {
            SpawnLevelPart();
        }
    }


    private void SpawnLevelPart()
    {
        Transform lastPartTransform = SpawnNewPart(lastEndPosition);

        lastEndPosition = lastPartTransform.Find("Endpoint").position + new Vector3(Random.Range(-2,2),Random.Range(-2,2));
    }

    private Transform SpawnNewPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(subsequentPoint, spawnPosition, Quaternion.identity);

        return levelPartTransform;

    }
}
