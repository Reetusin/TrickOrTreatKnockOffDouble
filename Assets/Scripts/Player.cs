using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;

    public AudioClip hitSound;

    public AudioClip piperSound;

    public AudioClip jojo;

    public Move move;

    public GameObject spawnerjojo;

    public AudioClip main;

    public TextMeshProUGUI scoreBoard;

    public Sprite deadSprite;

    public AudioClip augh;

    public GameObject spawner;

    private AudioSource bcc;

    public GameObject pauseMessage;

    private int score = 0;

    private SpriteRenderer spriteRenderer;

    public GameObject playAgainButton;

    private bool isPaused = false;

    void Start()
    {
        bcc = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playAgainButton.SetActive(false);
        bcc.PlayOneShot(main);

        if (pauseMessage != null)
            pauseMessage.SetActive(false);
    }

    void Update()
    {
        if (score >= 20)
        {
            bcc.time = 0;
            Jojos();
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TogglePause();
        }

        if (!isPaused)
        {
            scoreBoard.text = score.ToString("D4");

            float moveInput = 0f;

            if (Input.GetKey("a"))
            {
                moveInput = -1f;
            }
            else if (Input.GetKey("d"))
            {
                moveInput = 1f;
            }

            Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, 0);
            transform.position += (Vector3)moveVelocity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            bcc.PlayOneShot(augh);
            Destroy(other.gameObject);
            score += 10;
        }
        if (other.gameObject.CompareTag("Jojo"))
        {
            bcc.PlayOneShot(augh);
            spriteRenderer.sprite = deadSprite;
            moveSpeed = 0f;
            playAgainButton.SetActive(true);
            Destroy(other.gameObject);

            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            bcc.PlayOneShot(hitSound);
            spriteRenderer.sprite = deadSprite;
            Destroy(other.gameObject);
            spawner.SetActive(false);
            moveSpeed = 0f;
            playAgainButton.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Pipe"))
        {
            bcc.PlayOneShot(piperSound);
            spriteRenderer.sprite = deadSprite;
            Destroy(other.gameObject);
            spawner.SetActive(false);
            moveSpeed = 0f;
            playAgainButton.SetActive(true);
        }
    }

    public void Jojos()
    {
        bcc.PlayOneShot(jojo);

        if (move != null)
        {
            move.ChangeSpeed(10f);
        }
        spawner.SetActive(false);
        spawnerjojo.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;

        if (pauseMessage != null)
            pauseMessage.SetActive(isPaused);
    }
}
