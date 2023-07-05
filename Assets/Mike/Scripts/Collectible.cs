using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public bool isPicked = false;

    public AudioSource Source;

    

    public List<Items> possibleEffects = new List<Items>();

    [SerializeField] GameObject effectIconPrefab;
    [SerializeField] Image iconToDisplay;
    [SerializeField] GameObject effectBar;

    TooltipTrigger trigger;

    [SerializeField]
    Items item;
    //[SerializeField]
    //PlayerController player; //keep this to refer to player stats for buffs and debuffs

    private void Start()
    {
        Source = GetComponent<AudioSource>();

        if (item == null)
        {
            item = possibleEffects[Random.Range(0, possibleEffects.Count)];
        }


        if(effectBar == null && item.hasEffects)
        {
            effectBar = GameObject.FindGameObjectWithTag("EffectBar");
        }
        else
        {
            return;
        }


        if (iconToDisplay == null && !item.hasEffects)
        {
            return;
        }
        else
        {
            return;
        }


    }

    void Update()
    {
        if (isPicked)
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            spriteRenderer.enabled = false;

            Destroy(this.gameObject, item.duration+1);
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            if (isPicked == false)
            {

                Source.Play();
                item.ApplyPoints();

                switch (item.effectType)
                {
                    case Items.EffectType.CameraSpeed:
                        StartCoroutine(SpeedCamera());
                        break;
                    case Items.EffectType.JumpForceChange:
                        StartCoroutine(JumpForceChange());
                        break;
                    case Items.EffectType.MaxJumpsChange:
                        StartCoroutine(DoubleJumpsChange());
                        break;
                    case Items.EffectType.PlayerSpeedChange:
                        StartCoroutine(PlayerSpeedChange());
                        break;
                }

                isPicked = true;
            }

        }

    }

    IEnumerator SpeedCamera()
    {
        CameraMove cameraMove = FindObjectOfType<CameraMove>();
        iconToDisplay.sprite = item.icon;

        trigger = iconToDisplay.GetComponent<TooltipTrigger>();
        trigger.content = item.DefineContent();

        //Add other buffs/debuff types here with temp values holders
        GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);

        

        float tempSpeedHolder = cameraMove.moveSpeed;

        cameraMove.moveSpeed *= item.boostMultiplier; 

        Debug.Log("cameraspeed buff applied: " + cameraMove.moveSpeed);


        yield return new WaitForSeconds(item.duration);

        cameraMove.moveSpeed = tempSpeedHolder;

        Destroy(icon);

        //restore original values here

        Debug.Log("cameraspeed buff ended: " + cameraMove.moveSpeed);
    }


    IEnumerator DoubleJumpsChange()
    {
        PlayerController playerStats = FindObjectOfType<PlayerController>();
        iconToDisplay.sprite = item.icon;

        trigger = iconToDisplay.GetComponent<TooltipTrigger>();
        trigger.content = item.DefineContent();

        GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);

        int tempValueHolder = playerStats._stats.MaxAirJumps;

        //In this case the multiplier is equal to the number of jumps the player does.
        playerStats._stats.MaxAirJumps  = (int)item.boostMultiplier; 

        Debug.Log("Effect applied");

        yield return new WaitForSeconds(item.duration);

        playerStats._stats.MaxAirJumps = tempValueHolder;
        Destroy(icon);

        //restore original values here

        Debug.Log("effect ended");
    }

    IEnumerator JumpForceChange()
    {
        PlayerController playerStats = FindObjectOfType<PlayerController>();

        iconToDisplay.sprite = item.icon;

        trigger = iconToDisplay.GetComponent<TooltipTrigger>();
        trigger.content = item.DefineContent();

        GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);


        float tempValueHolder = playerStats._stats.JumpPower;

        
        playerStats._stats.JumpPower *= item.boostMultiplier; 

        Debug.Log("Effect applied");

        yield return new WaitForSeconds(item.duration);

        playerStats._stats.JumpPower = tempValueHolder;

        Destroy(icon);
        //restore original values here

        Debug.Log("effect ended");
    }

    IEnumerator PlayerSpeedChange()
    {
        PlayerController playerStats = FindObjectOfType<PlayerController>();

        iconToDisplay.sprite = item.icon;

        trigger = iconToDisplay.GetComponent<TooltipTrigger>();
        trigger.content = item.DefineContent();

        GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);

        float tempValueHolder = playerStats._stats.MaxSpeed;


        playerStats._stats.MaxSpeed *= item.boostMultiplier; 

        Debug.Log("Effect applied");

        yield return new WaitForSeconds(item.duration);

        playerStats._stats.MaxSpeed = tempValueHolder;
        Destroy(icon);
        //restore original values here

        Debug.Log("effect ended");
    }


}