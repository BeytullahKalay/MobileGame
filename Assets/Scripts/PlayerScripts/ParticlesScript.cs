using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject LandingEffect;
    public GameObject PlayerDashClone;

    Animator anim;
    Movement MovementScript;
    GameObject cloneSmoke;


    private Queue<GameObject> smokes = new Queue<GameObject>();


    Vector2 ParticlePosition;
    private float fallTime = 0;
    private float groundTime = 0;


    public float timeBetweenDashDusts = 0.06f;
    private float dashDutsTimeCounter;

    public float timeBetweenPlayerClones = 0.01f;
    private float playerClonesTimeCounter;

    void Start()
    {
        anim = GetComponent<Animator>();
        MovementScript =Player.GetComponent<Movement>();
        anim = Player.GetComponent<Animator>();
        dashDutsTimeCounter = timeBetweenDashDusts;
        playerClonesTimeCounter = timeBetweenPlayerClones;
    }

    void Update()
    {
        #region Landing Dust Effect Codes
        ParticlePosition = new Vector2(Player.transform.position.x, Player.transform.position.y-1.5f);
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Fall"))
            fallTime += Time.deltaTime;


        if (fallTime > 0.5f && MovementScript.isGrounded)
        {
            cloneSmoke =  Instantiate(LandingEffect, ParticlePosition, Quaternion.Euler(-90, 0, 0));
            smokes.Enqueue(cloneSmoke);
            StartCoroutine(DestroyLandingEffect(smokes.Dequeue()));
            fallTime = 0;
        }
        else if (MovementScript.isGrounded)
            fallTime = 0;

        #endregion

        #region Jump Dust Effect Codes
        if (MovementScript.isGrounded)
            groundTime += Time.deltaTime;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && groundTime > 0)
        {
            cloneSmoke = Instantiate(LandingEffect, ParticlePosition, Quaternion.Euler(-90, 0, 0));
            smokes.Enqueue(cloneSmoke);
            StartCoroutine(DestroyLandingEffect(smokes.Dequeue()));
            groundTime = 0;
        }

        #endregion

        #region Dash Dust Effect Codes
        if (MovementScript.isGrounded && MovementScript.isDashing && dashDutsTimeCounter <= 0)
        {
            cloneSmoke = Instantiate(LandingEffect, ParticlePosition, Quaternion.Euler(-90, 0, 0));
            smokes.Enqueue(cloneSmoke);
            dashDutsTimeCounter = timeBetweenDashDusts;
            StartCoroutine(DestroyLandingEffect(smokes.Dequeue()));
        }
        else
            dashDutsTimeCounter -= Time.deltaTime;
        #endregion

        if (MovementScript.isDashing && playerClonesTimeCounter <= 0)
        {
            cloneSmoke = Instantiate(PlayerDashClone, Player.transform.position, Player.transform.rotation);
            smokes.Enqueue(cloneSmoke);
            playerClonesTimeCounter = timeBetweenPlayerClones;
            StartCoroutine(DestroyLandingEffect(smokes.Dequeue()));
        }
        else
            playerClonesTimeCounter -= Time.deltaTime;



    }

    private IEnumerator DestroyLandingEffect( GameObject cloneSmoke)
    {
        yield return new WaitForSeconds(1f);
        Destroy(cloneSmoke);
    }
}
