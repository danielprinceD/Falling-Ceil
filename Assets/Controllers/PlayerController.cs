using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed = 3;
    Camera camera;
    void Start()
    {
        camera = FindFirstObjectByType<Camera>();
    }

    void Update()
    {
        Vector3 vector = Vector3.right * Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime;
        gameObject.transform.Translate(vector);

    }
}
