using UnityEngine;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    private Animator animator;
    private DuckDebug duckDebugScript;

    public GameObject Restart;
   
    private int points = 0;
    public TextMeshProUGUI pointsText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Die();
        }
        else if (other.CompareTag("Collectable"))
        {
            CollectPoint();
            Destroy(other.gameObject);
        }
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        duckDebugScript = GetComponent<DuckDebug>();

        UpdatePointsText();
    }

    void Die()
    {
        if (duckDebugScript != null)
        {
            duckDebugScript.enabled = false;
        }

        if (animator != null)
        {
            animator.SetTrigger("Die");
        }

        Invoke("DeactivatePlayer", 2.0f);
    }

    void DeactivatePlayer()
    {
        Restart.SetActive(true);
        gameObject.SetActive(false);
    }

    void CollectPoint()
    {
        points++;

        UpdatePointsText();
    }

    void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points.ToString();
        }
    }
}