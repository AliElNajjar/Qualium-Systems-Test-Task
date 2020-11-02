using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    private static Vector3 bounds;
    private static readonly float sidesOffset = Screen.width * 1/25;
    private static readonly float topBotOffset = Screen.height * 1/15;

    public static float left { get { return -bounds.x + sidesOffset; } }
    public static float right { get { return bounds.x - sidesOffset; } }
    public static float top { get { return bounds.y - topBotOffset; } }
    public static float bottom { get { return -bounds.y + topBotOffset; } }

    // Start is called before the first frame update
    void Start()
    {
        bounds = GetScreenBounds();
    }


    private static Vector3 GetScreenBounds()
    {
        Vector3 screenVector = new Vector3(Screen.width - sidesOffset, Screen.height -topBotOffset, Camera.main.transform.position.z);

        return Camera.main.ScreenToWorldPoint(screenVector);
    }

    public static bool OutOfBounds(Vector2 position)
    {
        float x = Mathf.Abs(position.x);
        float y = Mathf.Abs(position.y);

        return (x > bounds.x || y > bounds.y);
    }
}
