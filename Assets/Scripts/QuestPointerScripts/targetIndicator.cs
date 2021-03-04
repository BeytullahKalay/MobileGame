using UnityEngine;

public class targetIndicator : MonoBehaviour
{
    public GameObject target;
    public float HideDistance;
    private Transform _targetTransform;
    public GameObject _dialog;
    private bool _dialogActivated;

    private void Start()
    {
        if (target !=null && target.active)
        {
            _targetTransform = target.transform;
        }
    }
    private void Update()
    {
        if (_dialog.active)
            _dialogActivated = true;

        if (target != null && target.active && _dialogActivated)
        {
            gameObject.SetActive(true);
            var dir = _targetTransform.position - transform.position;
            if (dir.magnitude < HideDistance)
            {
                SetChildrenActive(false);
            }
            else
            {
                foreach (Transform child in transform)
                {
                    SetChildrenActive(true);
                }
                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else
        {
            gameObject.SetActive(false);
            return;
        }

    }

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
