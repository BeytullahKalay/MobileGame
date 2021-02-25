using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    [HideInInspector] public int _canSpawnBox;
    public bool BoxAbilityActive()
    {
        if (_canSpawnBox == 1)
        {
            return true;
        }
        else
            return false;
    }
}
