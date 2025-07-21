using UnityEngine;

public class SpikesSpawn : MonoBehaviour
{
    [SerializeField] GameObject _spikes;

    bool _isActive;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !_isActive)
        {
            _spikes.SetActive(true);
            _isActive = true;
        }
    }
}
