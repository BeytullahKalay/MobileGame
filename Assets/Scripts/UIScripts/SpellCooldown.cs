using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpellCooldown : MonoBehaviour
{
    
    public Image dashCooldownImage;
    public Image spawnBoxCooldownImage;

    private bool isDashing;
    private float dashTime;
    private float dashTime_Counter;

    private float spawnBoxTime_Counter;
    private float spawnBoxTime;

    private void Start()
    {
        dashCooldownImage.fillAmount = 0f;
        spawnBoxCooldownImage.fillAmount = 0f;

        spawnBoxTime = GameObject.Find("Player").GetComponent<Movement>().spawnBoxTime;
    }

    private void Update()
    {
        CheckDash();
        if (isDashing)
            dashTime_Counter = dashTime;
        else
            dashTime_Counter -= Time.deltaTime;
        set_dashCooldown_Image_FillAmount();

        CheckBoxSpawn();
        set_spawnBox_Image_FillAmount();

    }

    private void CheckDash()
    {
        isDashing = GameObject.Find("Player").GetComponent<Movement>().isDashing;
        dashTime = GameObject.Find("Player").GetComponent<Movement>().dashCoolDown;
    }

    private void set_dashCooldown_Image_FillAmount()
    {
        dashCooldownImage.fillAmount = dashTime_Counter / dashTime;
    }

    private void CheckBoxSpawn()
    {
        spawnBoxTime_Counter = GameObject.Find("Player").GetComponent<Movement>().spawnBoxTime_Counter;
    }

    private void set_spawnBox_Image_FillAmount()
    {
        spawnBoxCooldownImage.fillAmount = spawnBoxTime_Counter / spawnBoxTime;
    }

}
