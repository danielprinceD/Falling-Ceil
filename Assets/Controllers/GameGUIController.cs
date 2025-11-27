using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameGUIController : MonoBehaviour
{
    float WidthInWorldUnits;
    float HeightInWorldUnits;

    public float MinimumFallingObjectSize = 1f;
    public float MaximumFallingObjectSize = 5f;

    public float SpawnTimeDelay = .75f;
    float nextSpawnTime;

    public GameObject FallingObject;
    void Start()
    {
        nextSpawnTime = SpawnTimeDelay;
        WidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        HeightInWorldUnits = Camera.main.orthographicSize;
    }

    void Update()
    {
        if( Time.timeSinceLevelLoad > nextSpawnTime)
        {
            float spawnSize = Random.Range(MinimumFallingObjectSize , MaximumFallingObjectSize);
            Vector2 position = new Vector2(Random.Range(-WidthInWorldUnits , WidthInWorldUnits ) , HeightInWorldUnits + (spawnSize * 0.5f) );
            GameObject newFallingObj = Instantiate(FallingObject , position , Quaternion.identity );
            newFallingObj.transform.localScale = new Vector2(spawnSize , spawnSize);
            nextSpawnTime += SpawnTimeDelay;
        }
    }

}
