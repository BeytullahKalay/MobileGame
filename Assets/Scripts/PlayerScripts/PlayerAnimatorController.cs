using UnityEngine;


public class PlayerAnimatorController : MonoBehaviour
{


    Animator anim;
    Movement MovementScript;
    Rigidbody2D rb;

    public float _velocityControlValue;


    public ParticleSystem Attack1_Dust;

    void Start()
    {
        anim = GetComponent<Animator>();
        MovementScript = GetComponent<Movement>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        if (MovementScript.input == 0)              //Running
            anim.SetBool("isRunning", false);
        else
            anim.SetBool("isRunning", true);

        if (rb.velocity.y > _velocityControlValue && !MovementScript.isGrounded)                      //Jumping
            anim.SetBool("isJumping", true);
        else
            anim.SetBool("isJumping", false);

        if (rb.velocity.y < -_velocityControlValue && !MovementScript.isGrounded)                      //Falling
            anim.SetBool("isFalling", true);
        else
            anim.SetBool("isFalling", false);

        if (MovementScript.isDashing)               //Dashing
            anim.SetBool("Dash", true);
        else
            anim.SetBool("Dash",false);

    }

    public void PlayAttackAnim()
    {
        if (!GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack1") //Checking the animations for restarting attack anim
            && !GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            anim.SetTrigger("Attack1");
    }

    public void PlaySwordDustPS()
    {
        Attack1_Dust.Play();
    }

}
