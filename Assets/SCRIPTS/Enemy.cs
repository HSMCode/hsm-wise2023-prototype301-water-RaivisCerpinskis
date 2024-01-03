using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector2 speedRange = new Vector2(3f, 8f);
    private float currentSpeed;

    void Start()
    {
        SetRandomSpeed();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 newPosition = transform.position + Vector3.back * currentSpeed * Time.deltaTime;

        transform.position = newPosition;
    }

    void SetRandomSpeed()
    {
        currentSpeed = Random.Range(speedRange.x, speedRange.y);
    }
}