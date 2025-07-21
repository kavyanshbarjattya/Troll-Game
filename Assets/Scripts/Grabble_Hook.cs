using UnityEngine;

public class Grabble_Hook : MonoBehaviour
{
    [SerializeField] float _detectionRange;
    [SerializeField] LayerMask _grabbleHook;
    [SerializeField] DistanceJoint2D _distanceJoint;
    [SerializeField] LineRenderer _lineRenderer;

    private void Start()
    {
        _distanceJoint.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _lineRenderer.SetPosition(0, mousePos);
            _lineRenderer.SetPosition(1,transform.position);
            _distanceJoint.connectedAnchor = mousePos;
            _distanceJoint.enabled = true;
            _lineRenderer.enabled = true;
        }
        else if(Input.GetMouseButtonUp(0)) 
        {
            _lineRenderer.enabled = false;
            _distanceJoint.enabled = false;
        }

        if (_distanceJoint.enabled)
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }

}
