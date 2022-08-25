using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
public class TrashBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ballsCollectedText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioSource audioWinSource;

    public GameObject NextLevelPanel;

    int Score;
    
    private void Start()
    {
        Score = 0;
        NextLevelPanel = MenuHolder.Prefab;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CountBalls();
        collision.sharedMaterial = null;
        collision.attachedRigidbody.sharedMaterial = null;
    }
    public void CountBalls()
    {
        Score++;
        ballsCollectedText.text = string.Format("{0}/20", Score);

        audioSource.pitch = Random.Range(0.5f, 1.1f);
        audioSource.PlayOneShot(audioSource.clip);

        if (Score >= Data.WinCount)
        {
            audioWinSource.PlayOneShot(audioWinSource.clip);
            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));
            NextLevelPanel.SetActive(true);
        }
    }
}
