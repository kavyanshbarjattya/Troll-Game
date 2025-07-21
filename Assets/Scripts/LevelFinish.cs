using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    [SerializeField] Vector3 _targetScale;
    [SerializeField] float _squeezeTime;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, _squeezeTime);
            Debug.Log("Level Finished");
        }        
    }
}

