﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetIndicator : MonoBehaviour
{
    public Transform target;
    public float HideDistance;
    private void Update()
    {
        var dir = target.position - transform.position;
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

    void SetChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
