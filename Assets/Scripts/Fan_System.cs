using UnityEngine;

public class Fan_System : MonoBehaviour
{
    [SerializeField] float _upwardForce;
    [SerializeField] Rigidbody2D _rb;

    bool _isEntered;


    private void Update()
    {
        if (_isEntered)
        {
            _rb.AddForce(Vector2.up * _upwardForce, ForceMode2D.Force);
            print("Adding Force to player");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isEntered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _isEntered = false;
        }
    }
}
