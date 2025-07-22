using UnityEngine;

public class GrappleHook : MonoBehaviour
{
    public float grappleRadius = 5f;
    public LayerMask grappleLayer;

    private Rigidbody2D rb;
    private DistanceJoint2D joint;
    private Transform currentGrapplePoint;
    private LineRenderer line;
    private PlayerMovement _playerMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        joint = GetComponent<DistanceJoint2D>();
        _playerMove = GetComponent<PlayerMovement>();
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        
        joint.enabled = false;

        
        line.positionCount = 0;
    }

    void Update()
    {
        if (joint.enabled && currentGrapplePoint != null && !_playerMove.IsGrounded())
        {
            line.positionCount = 2;
            line.SetPosition(0, transform.position);
            line.SetPosition(1, currentGrapplePoint.position);
        }
        else
        {
            line.positionCount = 0;
        }
    }

    public void OnJumpButtonDown()
    {
        currentGrapplePoint = FindNearestGrapple();
        if (currentGrapplePoint != null && !_playerMove.IsGrounded())
        {
            joint.enabled = true;
            joint.connectedAnchor = currentGrapplePoint.position;
            joint.distance = Vector2.Distance(transform.position, currentGrapplePoint.position);
            rb.gravityScale = 1.5f;
        }
    }

    public void OnJumpButtonUp()
    {
        joint.enabled = false;
        currentGrapplePoint = null;
        line.positionCount = 0;
    }

    Transform FindNearestGrapple()
    {
        Collider2D[] grapples = Physics2D.OverlapCircleAll(transform.position, grappleRadius, grappleLayer);
        Transform closest = null;
        float minDist = Mathf.Infinity;

        foreach (var g in grapples)
        {
            float dist = Vector2.Distance(transform.position, g.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = g.transform;
            }
        }
        return closest;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, grappleRadius);
    }
}
