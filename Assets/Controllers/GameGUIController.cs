using System.Collections.Generic;
using UnityEngine;

public class GameGUIController : MonoBehaviour
{
    float WidthInWorldUnits;
    float HeightInWorldUnits;

    public float SpawnTimeDelay = 0;
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
        float WorldWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float WorldHeight = Camera.main.orthographicSize;
        WidthInWorldUnits = WorldWidth - (FallingObject.transform.localScale.x * 0.5f);
        HeightInWorldUnits = WorldHeight + (FallingObject.transform.localScale.y * 0.5f);
        gameObject.transform.position = new Vector2(0 , 0);
        gameObject.transform.localScale = new Vector2( WorldWidth * 2 , WorldHeight * 2 );
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if( Time.time > nextSpawnTime)
        {
            Vector2 position = new Vector2(Random.Range(-WidthInWorldUnits , WidthInWorldUnits) , HeightInWorldUnits );
            Instantiate(FallingObject , position , Quaternion.identity );
            nextSpawnTime += SpawnTimeDelay;
        }

    }

}
