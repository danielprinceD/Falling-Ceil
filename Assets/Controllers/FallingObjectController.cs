using System;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObjectController : MonoBehaviour
{
    public float speed = 5;
    bool isGameOver = false;

    public void setGameOver()
    {
        isGameOver = true;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }
        speed = Mathf.Lerp( 7 , 30 , Difficulty.getDifficultyPercentage());
        Vector2 position = Vector2.down * speed * Time.deltaTime;
        gameObject.transform.Translate(position);
    }

    void OnTriggerEnter(Collider FallingObjectCollider) {
        GameGUIController gameGUIController = FindFirstObjectByType<GameGUIController>();
        gameGUIController.setGameOver();
        PlayerController playerContoller = FindAnyObjectByType<PlayerController>();
        playerContoller.setGameOver();
        print("Game Over");
    }
}
