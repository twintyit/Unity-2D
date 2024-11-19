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
}
