using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLenght = 3.5f;

    public float currentTimeScale;

    private void Update()
    {
        Time.timeScale += (1f / slowdownLenght) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        currentTimeScale = Time.timeScale;
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }
}
