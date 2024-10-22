
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public AudioClip hitSound;
    public End end;
    private AudioSource bcc;
    public TextMeshProUGUI scoreBoard;
    private int score = 0;
    void Start()
    {
        bcc = GetComponent<AudioSource>();
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

        // Move the player
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, 0);
        transform.position += (Vector3)moveVelocity * Time.deltaTime;




    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Destroy(other.gameObject);
            bcc.PlayOneShot(hitSound);
            score += 10;
        }
        else if (other.gameObject.CompareTag("Bomb"))
        {
            end.EndScene();
        }
    }


}

