 using UnityEngine;

public class GateScript : MonoBehaviour
{
    public Transform _pos1;
    public Transform _pos2;
    public GameObject _buttonGameObject;

    [SerializeField] private float _moveSpeed = 1f;

    private void Start()
    {
        transform.position = _pos1.position;
    }

    private void Update()
    {
        GateMovement();
    }

    private void GateMovement()
    {
        if (_buttonGameObject.GetComponent<ButtonScript>()._buttonPressed)
            transform.position = Vector3.MoveTowards(transform.position, _pos2.position, _moveSpeed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, _pos1.position, _moveSpeed * Time.deltaTime);

    }

    [ExecuteAlways]
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_pos1.position, _pos2.position);
    }
}
