using UnityEngine;

public class DeactivateObject : MonoBehaviour
{
    public GameObject _dialog;
    public GameObject _Scene;

    private bool _dialogActivated;

    private void Update()
    {
        if (_dialog.active)
            _dialogActivated = true;

        if (_dialogActivated && !_Scene.active)
            gameObject.SetActive(false);
    }
}
