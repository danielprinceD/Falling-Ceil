using System.Collections.Generic;
using UnityEngine;

public class GameGUIController : MonoBehaviour
{
    float WidthInWorldUnits;
    float HeightInWorldUnits;

    public float MinimumFallingObjectSize = 1f;
    public float MaximumFallingObjectSize = 5f;

    public float SpawnTimeDelay = 1;
    float nextSpawnTime;

    bool isGameOver = false;

    public void setGameOver()
    {
        FallingObjectController[] fallingObjectController = FindObjectsByType<FallingObjectController>(FindObjectsSortMode.None);
        foreach(FallingObjectController fallingObj in fallingObjectController)
        {
            fallingObj.setGameOver();
        }
        isGameOver = true;
    }

    public GameObject FallingObject;
    void Start()
    {
        nextSpawnTime = SpawnTimeDelay;
        WidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize;
        HeightInWorldUnits = Camera.main.orthographicSize;
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if( Time.time > nextSpawnTime)
        {
            float spawnSize = Random.Range(MinimumFallingObjectSize , MaximumFallingObjectSize);
            Vector2 position = new Vector2(Random.Range(-WidthInWorldUnits + (spawnSize * 0.5f) , WidthInWorldUnits - (spawnSize * 0.5f) ) , HeightInWorldUnits + (spawnSize * 0.5f) );
            GameObject newFallingObj = Instantiate(FallingObject , position , Quaternion.identity );
            newFallingObj.transform.localScale = new Vector2(spawnSize , spawnSize);
            nextSpawnTime += SpawnTimeDelay;
            print(Mathf.Clamp01(Time.time / 60));
        }

    }

}
