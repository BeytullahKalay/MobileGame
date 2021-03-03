using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneHolder : MonoBehaviour
{
    public GameObject[] _cutScenes;
    private bool _touchTaken;
    //private bool _mainSceneExist;

    void Update()
    {
        TakeFirstTouch();

        if (_touchTaken)
        {
            for (int i = 0; i < _cutScenes.Length; i++)
            {
                if (_cutScenes[i].GetComponent<CutScene>()._mainScene && i != 0 && i != _cutScenes.Length - 1)
                {
                    _cutScenes[i + 1].SetActive(true);
                    _cutScenes[i - 1].SetActive(true);

                    for (int j = 0; j < _cutScenes.Length; j++)
                    {
                        if (_cutScenes[j] != _cutScenes[i] && _cutScenes[j] != _cutScenes[i - 1] && _cutScenes[j] != _cutScenes[i + 1])
                        {
                            _cutScenes[j].SetActive(false);
                        }
                    }
                }
                else if (_cutScenes[i].GetComponent<CutScene>()._mainScene && i == 0)
                {
                    _cutScenes[i + 1].SetActive(true);

                    for (int j = 0; j < _cutScenes.Length; j++)
                    {
                        if (_cutScenes[j] != _cutScenes[i] && _cutScenes[j] != _cutScenes[i + 1])
                        {
                            _cutScenes[j].SetActive(false);
                        }
                    }
                }
                else if (_cutScenes[i].GetComponent<CutScene>()._mainScene && i == _cutScenes.Length - 1)
                {
                    _cutScenes[i - 1].SetActive(true);

                    for (int j = 0; j < _cutScenes.Length; j++)
                    {
                        if (_cutScenes[j] != _cutScenes[i] && _cutScenes[j] != _cutScenes[i - 1])
                        {
                            _cutScenes[j].SetActive(false);
                        }
                    }
                }
            }
        }
    }

    private void TakeFirstTouch()
    {
        for (int i = 0; i < _cutScenes.Length; i++)
        {
            if (_cutScenes[i].GetComponent<CutScene>()._firstTocuh)
            {
                _touchTaken = true;
                continue;
            }
        }
    }
}
