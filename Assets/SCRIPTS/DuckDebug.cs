using UnityEngine;

public class DuckDebug : MonoBehaviour
{
    private bool spacePressed = false;
    private float spacePressTime = 0f;
    private float waitTime = 0.3f;

    public float minY = 0f;
    public float maxY = 5f;

    public float pressMoveDistance = 1f;
    public float holdMoveDistance = 1f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
            spacePressTime = Time.time;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            spacePressed = false;
            if (Time.time - spacePressTime <= waitTime)
            {
                ConfirmFunction();
            }
        }

        if (spacePressed && Time.time - spacePressTime > waitTime + 0.02f)
        {
            HoldFunction();
        }
    }

    void ConfirmFunction()
    {
        Debug.Log("Funktion bestätigt!");
        float newY = Mathf.Clamp(transform.position.y + pressMoveDistance, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void HoldFunction()
    {
        Debug.Log("Space-Taste gehalten!");
        float newY = Mathf.Clamp(transform.position.y - holdMoveDistance, minY, maxY);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}