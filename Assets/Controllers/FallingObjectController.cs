using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingObjectController : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        
    }

    void Update()
    {
        // float lerpped = Difficulty.getLerpValue( 7 , 30 , 1 , 60);
        speed = Mathf.Lerp( 10 , 30 , Difficulty.getDifficultyPercentage());

        Vector2 position = Vector2.down * speed * Time.deltaTime;
        gameObject.transform.Translate(position);
        
        if(gameObject != FindFirstObjectByType<GameGUIController>().FallingObject && -(Camera.main.orthographicSize * 2) + gameObject.transform.localScale.y > gameObject.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
