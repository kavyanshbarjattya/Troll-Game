using UnityEngine;

public class JetPack_System : MonoBehaviour
{
    [SerializeField] float _upwardForce = 10f;
    [SerializeField] GameObject _tempGround;
    private Rigidbody2D _rb;
    private bool _isHolding = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        TempControl();
        if (_isHolding)
        {
            _rb.AddForce(Vector2.up * _upwardForce, ForceMode2D.Force);
            _tempGround.SetActive(false);

        }

    }


    void TempControl()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _isHolding = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _isHolding= false;
        }

    }
    public void OnButtonDown()
    {
        _isHolding = true;

    }

    public void OnButtonUp()
    {
        _isHolding = false;
    }
}
