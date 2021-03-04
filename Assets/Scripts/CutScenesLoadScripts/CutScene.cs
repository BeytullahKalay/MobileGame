using UnityEngine;

public class CutScene : MonoBehaviour
{


    private Collider2D[] _col;
    public bool _mainScene;
    /*[HideInInspector]*/ public bool _firstTocuh;
    public Collider2D _playerCollider;
    private GameObject[] _cutScenes;

    private void Start()
    {
        _col = GetComponentsInChildren<CompositeCollider2D>();
        _cutScenes = GetComponentInParent<CutSceneHolder>()._cutScenes;
    }

    private void Update()
    {
        FirstTouchControl();

        MainSceneControl();

    }

    private void FirstTouchControl()
    {
        _firstTocuh = GetComponentInParent<CutSceneHolder>()._touchTaken;
        if (!_firstTocuh)
        {
            for (int i = 0; i < _col.Length; i++)
            {
                if (_col[i].IsTouching(_playerCollider))
                {
                    _firstTocuh = true;
                }
            }
        }
    }

    private void MainSceneControl()
    {
        for (int i = 0; i < _col.Length; i++)
        {
            if (_col[i].IsTouching(_playerCollider))
            {
                for (int j = 0; j < _cutScenes.Length; j++)
                {
                    if (_cutScenes[j].GetComponent<CutScene>() != this.gameObject)
                    {
                        if (_cutScenes[j].GetComponent<CutScene>()._mainScene)
                        {
                            _cutScenes[j].GetComponent<CutScene>()._mainScene = false;
                        }
                    }   
                }
                _mainScene = true;
                break;
            }
            else
                _mainScene = false;
        }
    }
}