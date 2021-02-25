using UnityEngine;

[ExecuteInEditMode]
public class CamTransitionScript : MonoBehaviour
{
    public Transform camPosIter;
    private Vector3 cuberVectors;
    public float x, y, z;
    public TimeManagerScript timeManager;

    public Transform PlayerObject;
    [HideInInspector] public bool playerInRange;

    public float cameMoveSpeed = 5f;
    [HideInInspector] public bool activeScene;

    private void Start()
    {
        if (Physics2D.OverlapBox(transform.position, cuberVectors, 0f, LayerMask.GetMask("Player"))
        || Physics2D.OverlapBox(transform.position, cuberVectors, 0f, LayerMask.GetMask("Hurted")))
            playerInRange = true;
        else
            playerInRange = false;
    }

    private void Update()
    {
        if (Physics2D.OverlapBox(transform.position, cuberVectors, 0f, LayerMask.GetMask("Player"))
        || Physics2D.OverlapBox(transform.position, cuberVectors, 0f, LayerMask.GetMask("Hurted")))
            playerInRange = true;
        else
            playerInRange = false;


        cuberVectors = new Vector3(x, y, z);

        if (playerInRange)
            camPosIter.transform.position = Vector3.MoveTowards(camPosIter.transform.position, this.gameObject.transform.position, cameMoveSpeed);
        else
            activeScene = false;

        if (playerInRange && !activeScene)
        {
            timeManager.DoSlowmotion();
            activeScene = true;
        }

        if (!playerInRange && activeScene)
            timeManager.DoSlowmotion();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, cuberVectors);
    }
}
