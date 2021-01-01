using UnityEngine;

public class SlowTimeWhileDashing : MonoBehaviour
{
    public TimeManagerScript timeManager;
    public float dashSlowdownLenght = 1.5f;
    private float currentdashSlowdownLenght;

    private bool slowMotionActivated = false;

    private void Start()
    {
        currentdashSlowdownLenght = timeManager.slowdownLenght;
    }

    private void Update()
    {
        if (GetComponent<Movement>().isDashing && !slowMotionActivated)
        {
            currentdashSlowdownLenght = timeManager.slowdownLenght;
            timeManager.slowdownLenght = dashSlowdownLenght;

            timeManager.DoSlowmotion();
            slowMotionActivated = true;
        }
        else if (!GetComponent<Movement>().isDashing)
        {
            timeManager.slowdownLenght = currentdashSlowdownLenght;
            slowMotionActivated = false;
        }
    }
}
