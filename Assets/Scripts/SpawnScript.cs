using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class SpawnScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] TextMeshProUGUI ballsCountText;

    [SerializeField] GameObject Prefab;
    [SerializeField] Transform Spawnpoint;
    [SerializeField] AudioSource audioSource;

    public int Count;
    RectTransform TextTransform;

    void Start()
    {
        TextTransform = ballsCountText.gameObject.GetComponent<RectTransform>();
        Vector2 positionT = Camera.main.WorldToScreenPoint(transform.position);
        TextTransform.position = positionT + new Vector2(0, 80);
        Count = Data.BallCount;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        BeginSpawn();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        EndSpawn();
    }

    public void BeginSpawn()
    {
        if (!IsInvoking(nameof(BallSpawn)))
        {
            InvokeRepeating(nameof(BallSpawn), 0, 0.15f);
        }
    }

    public void EndSpawn()
    {
        CancelInvoke(nameof(BallSpawn));
    }

    void BallSpawn()
    {
        if (Count <= 0)
        {
            Invoke(nameof(DefeatCheck), 0.7f);
            CancelInvoke(nameof(BallSpawn));
            return;
        }

        Vector2 ForcePoint = new Vector2(Spawnpoint.position.x - transform.position.x, Spawnpoint.position.y - transform.position.y);
        GameObject.Instantiate(Prefab, Spawnpoint.position, Spawnpoint.localRotation, Spawnpoint).GetComponent<Rigidbody2D>().AddForce(ForcePoint * 20f, ForceMode2D.Impulse);

        audioSource.PlayOneShot(audioSource.clip);

        Count--;
        ballsCountText.text = string.Format("{0}", Count);
    }

    void DefeatCheck()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
