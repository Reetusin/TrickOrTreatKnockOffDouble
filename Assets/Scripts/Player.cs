using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public AudioClip hitSound;
    public AudioClip piperSound;
    public TextMeshProUGUI scoreBoard;
    public GameObject spawner;
    private AudioSource bcc;
    private int score = 0;
    public Sprite deadSprite;

    private SpriteRenderer spriteRenderer;
    public GameObject playAgainButton;

    void Start()
    {
        bcc = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playAgainButton.SetActive(false);
    }

    void Update()
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Destroy(other.gameObject);
            score += 10;
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            bcc.PlayOneShot(hitSound);

            spriteRenderer.sprite = deadSprite;

            Destroy(other.gameObject);

            spawner.SetActive(false);

            playAgainButton.SetActive(true);
        }
        else if (other.gameObject.CompareTag("Pipe"))
        {
            bcc.PlayOneShot(piperSound);
        }
    }


    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
