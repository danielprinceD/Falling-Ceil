using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 3;
    float WidthInWorldUnits;
    // float HeightInWorldUnits;
    void Start()
    {
        WidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + (gameObject.transform.localScale.x * 0.5f);
        // HeightInWorldUnits = Camera.main.orthographicSize - (gameObject.transform.localScale.y * 0.5f);
    }

    void Update()
    {
        Vector2 vector = (Vector2.right * Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime ) ;
        // Vector2 forYAxis = (Vector2.up * Input.GetAxis("Vertical") * speed * Time.fixedDeltaTime);
        gameObject.transform.Translate(vector);

        if(gameObject.transform.position.x < -WidthInWorldUnits)
        {
            gameObject.transform.position = new Vector2( WidthInWorldUnits , gameObject.transform.position.y);
        }
        if(gameObject.transform.position.x > WidthInWorldUnits)
        {
            gameObject.transform.position = new Vector2( -WidthInWorldUnits , gameObject.transform.position.y);
        }

        // if(gameObject.transform.position.y < -HeightInWorldUnits)
        // {
        //     gameObject.transform.position = new Vector2( gameObject.transform.position.x , -HeightInWorldUnits);
        // }
        // if(gameObject.transform.position.y > HeightInWorldUnits)
        // {
        //     gameObject.transform.position = new Vector2( gameObject.transform.position.x , HeightInWorldUnits);
        // }

    }
}
