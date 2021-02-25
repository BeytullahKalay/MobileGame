using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    private Collider2D _col;

    [HideInInspector] public bool _mainScene;
    [HideInInspector] public bool _firstTocuh;
    public Collider2D _playerCollider;

    void Start()
    {
        _col = GetComponentInChildren<CompositeCollider2D>();
    }

    void Update()
    {
        if (_col.IsTouching(_playerCollider))
        {
            _firstTocuh = true;
            _mainScene = true;
        }
        else
        {
            _mainScene = false;
        }
    }
}
