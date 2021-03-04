using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public Transform _startPos;
    public Transform _pressedPoss;
    [SerializeField] private float _moveSpeed = 2f;

    private bool _isTouching;
    public float _buttonUpTime;
    private float _nextCheckTime = -10f;

    [HideInInspector] public bool _buttonPressed;

    private void Start()
    {
        transform.position = _startPos.position;
    }

    private void Update()
    {
        TimeCountIssues();
        ButtonMovement();

        if (transform.position == _pressedPoss.position)
            _buttonPressed = true;
        else
            _buttonPressed = false;

    }

    private void TimeCountIssues()
    {
        if (_isTouching)
        {
            _nextCheckTime = Time.time + _buttonUpTime;
        }
    }

    private void ButtonMovement()
    {
        if (Time.time < _nextCheckTime)
            transform.position = Vector3.MoveTowards(transform.position, _pressedPoss.position, _moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _startPos.position, _moveSpeed * Time.deltaTime);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Box")
            _isTouching = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Box")
            _isTouching = false;
    }


    [ExecuteAlways]
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_startPos.position, _pressedPoss.position);
    }
}