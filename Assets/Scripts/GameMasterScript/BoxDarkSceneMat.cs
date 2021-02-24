using UnityEngine;

public class BoxDarkSceneMat : MonoBehaviour
{

    public GameObject _boxPrefab;
    public Transform _camPosition;
    public GameObject _darkScene;
    public Material _urpMaterial;
    public Material _defaultMaterial;

    private CamTransitionScript _camTransitionScript;
    private SpriteRenderer _boxSpriteRenderer;
    void Start()
    {
        _camTransitionScript = _darkScene.GetComponent<CamTransitionScript>();
        _boxSpriteRenderer = _boxPrefab.GetComponent<SpriteRenderer>();

        _boxSpriteRenderer.material = _defaultMaterial;
    }

    void Update()
    {
        if (_camPosition.transform.position == _darkScene.transform.position)
            _boxSpriteRenderer.material = _urpMaterial;
        else
            _boxSpriteRenderer.material = _defaultMaterial;
    }
}
