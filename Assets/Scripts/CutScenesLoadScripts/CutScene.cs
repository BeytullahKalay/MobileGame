using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    private Collider2D _col1;
    private Collider2D _col2;
    private Collider2D _col3;

    [HideInInspector] public bool _mainScene;
    [HideInInspector] public bool _firstTocuh;
    public Collider2D _playerCollider;

    void Start()
    {
        _col1 = gameObject.transform.Find("Ground").GetComponent<CompositeCollider2D>();
        _col2 = gameObject.transform.Find("Platform").GetComponent<CompositeCollider2D>();
        _col3 = gameObject.transform.Find("Platform2").GetComponent<CompositeCollider2D>();
    }

    void Update()
    {

        if ((_col1 != null && _col1.IsTouching(_playerCollider))
            || (_col2 != null && _col2.IsTouching(_playerCollider)) 
            || (_col3 !=null && _col3.IsTouching(_playerCollider)))
        {
            _firstTocuh = true;
            _mainScene = true;
        }
        else
        {
            _mainScene = false;
        }
    }

    //private void CheckTouch(Collider2D col)
    //{
    //    if
    //}
}
