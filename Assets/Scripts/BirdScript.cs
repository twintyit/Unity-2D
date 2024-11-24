using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BirdScript : MonoBehaviour
{
    public static int score;
    private Rigidbody2D rb2d;

    void Start()
    {
        score = 0;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Time.timeScale == 0.0f) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 300);
        }

        this.transform.eulerAngles = new Vector3(0f, 0f, 2.5f * rb2d.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Object.FindFirstObjectByType<ModalScript>().TriggerGameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            score++;
            Debug.Log("Score: " + score);
        }
    }
}
