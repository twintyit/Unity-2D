using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * 300);
        }

        this.transform.eulerAngles = new Vector3 (0f, 0f, 2.5f * rb2d.linearVelocityY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Game Over");
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Pipe +1");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Mobe"))
        {
            Transform parentTransform = collision.gameObject.transform.parent;
            GameObject.Destroy(collision.gameObject);
            if (parentTransform != null)
            {
                GameObject.Destroy(parentTransform.gameObject);
            }
        }
    }
}
