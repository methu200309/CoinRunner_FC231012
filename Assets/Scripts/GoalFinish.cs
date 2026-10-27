
using UnityEngine;

public class GoalFinish : MonoBehaviour
{
    public GameObject winText;
    public GameObject playAgainButton;

    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelCompleted) return;

        if (other.GetComponent<PlayerMovement>() != null)
        {
            levelCompleted = true;

            if (winText != null)
            {
                winText.SetActive(true);
            }

            if (playAgainButton != null)
            {
                playAgainButton.SetActive(true);
            }

            Debug.Log("LEVEL COMPLETE!");
        }
    }
}
