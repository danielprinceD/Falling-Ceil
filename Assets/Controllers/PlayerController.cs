using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 3;
    float WidthInWorldUnits;
    void Start()
    {
        WidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + (gameObject.transform.localScale.x * 0.5f);

    }

    void Update()
    {
        Vector2 vector = Vector2.right * Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        gameObject.transform.Translate(vector);

        if(gameObject.transform.position.x < -WidthInWorldUnits)
        {
            gameObject.transform.position = new Vector2( WidthInWorldUnits , gameObject.transform.position.y);
        }
        if(gameObject.transform.position.x > WidthInWorldUnits)
        {
            gameObject.transform.position = new Vector2( -WidthInWorldUnits , gameObject.transform.position.y);
        }
    }
}
