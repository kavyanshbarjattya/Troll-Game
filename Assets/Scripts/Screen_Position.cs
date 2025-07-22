using UnityEngine;

public class Screen_Position : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.position = new Vector3(-collision.transform.position.x, collision.transform.position.y, collision.transform.position.z);
        }
    }
}
