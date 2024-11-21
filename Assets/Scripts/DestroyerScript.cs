using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Transform parentTransform = collision.gameObject.transform.parent;
        GameObject.Destroy(collision.gameObject);
        if(parentTransform != null)
        {
            GameObject.Destroy(parentTransform.gameObject);
        }
    }
}
