using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public bool isPicked = false;

    public AudioSource Source;

    public Animator anim;

    [SerializeField] PostProcessVolume cameraVolume;

    public PostProcessProfile normalVolume;
    public PostProcessProfile mushroomVolume;

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
                    case Items.EffectType.Mushroom:
                        //StartCoroutine(SwapVolume());
                        //StartCoroutine(MushroomEffect());
                        StartCoroutine(MushroomEffectTest());
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

    IEnumerator SwapVolume()
    {
        //PlayerController playerStats = FindObjectOfType<PlayerController>();

        float timer = 0;

        float duration = item.duration;
        

        Debug.Log("mushOn");

        if (!anim.GetBool("Active"))
        {
            iconToDisplay.sprite = item.icon;

            trigger = iconToDisplay.GetComponent<TooltipTrigger>();
            trigger.content = item.DefineContent();

            GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);

            //Animation trigger fade in
            anim.SetTrigger("isActive");

            Debug.Log(cameraVolume.profile.name);

            yield return new WaitForSeconds(1f);

            cameraVolume.profile = mushroomVolume;

            Debug.Log(cameraVolume.profile.name);

            timer += Time.deltaTime;

            if (timer >= duration)
            {
                Destroy(icon);
            }


        }
        else
        {
            duration = item.duration;
        }

      


    }

    IEnumerator MushroomEffect()
    {

        float duration = item.duration - 1f;
        //PlayerController playerStats = FindObjectOfType<PlayerController>();
        if (!anim.GetBool("Active"))
        {
            anim.SetBool("Active", true);



            Debug.Log("Effect applied");

            yield return new WaitForSeconds(duration);

            cameraVolume.profile = normalVolume;

            Debug.Log(cameraVolume.profile.name);



            //animation trigger fade out
            anim.SetTrigger("isNotActive");
            anim.SetBool("Active", false);

            Debug.Log("effect ended");

            //restore original values here

        }
        else
        {
            duration = item.duration - 1;
        }

    }


    IEnumerator MushroomEffectTest()
    {

        float duration = item.duration;
        

        GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);
        Destroy(icon, item.duration);


        Debug.Log("mushOn");

        if (!anim.GetBool("Active"))
        {
            iconToDisplay.sprite = item.icon;

            trigger = iconToDisplay.GetComponent<TooltipTrigger>();
            trigger.content = item.DefineContent();

            //icon = Instantiate(effectIconPrefab, effectBar.transform);

            //Animation trigger fade in
            anim.SetTrigger("isActive");

            Debug.Log(cameraVolume.profile.name);

            yield return new WaitForSeconds(1f);

            cameraVolume.profile = mushroomVolume;

            Debug.Log(cameraVolume.profile.name);

            anim.SetBool("Active", true);

            Debug.Log("Effect applied");

            yield return new WaitForSeconds(duration-1);

            cameraVolume.profile = normalVolume;

            Debug.Log(cameraVolume.profile.name);



            //animation trigger fade out
            anim.SetTrigger("isNotActive");
            anim.SetBool("Active", false);

            Debug.Log("effect ended");
            


        }
        else
        {
            if (icon != null)
            {
                Destroy(icon);

                icon = Instantiate(effectIconPrefab, effectBar.transform);

                Destroy(icon, item.duration);
            }
        }
        

        
    }



}