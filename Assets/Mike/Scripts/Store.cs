using System.Collections;
using System.Collections.Generic;
using TarodevController;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    [SerializeField] Items storeSlot1;
    //[SerializeField] Items storeSlot2;
    //[SerializeField] Items storeSlot3;
    //[SerializeField] Items storeSlot4;

    TooltipTrigger trigger;

    [SerializeField] GameObject effectIconPrefab;
    [SerializeField] Image iconToDisplay;
    [SerializeField] GameObject effectBar;

    //they need to be public to be accessed from another script
    public Image imgCooldown;
    public TextMeshProUGUI txtCooldown;

    public bool isCooldown = false;
    public float cooldownTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

        txtCooldown.gameObject.SetActive(false);
        imgCooldown.fillAmount = 0f;

        if (effectBar == null && storeSlot1.hasEffects)
        {
            effectBar = GameObject.FindGameObjectWithTag("EffectBar");
        }
        else
        {
            return;
        }


        if (iconToDisplay == null && !storeSlot1.hasEffects)
        {
            return;
        }
        else
        {
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            if(storeSlot1.price <= GetComponent<ScoreHolder>().gold)
            {
                StartCoroutine(JumpForceChange());

                
            }
        }
        else
        {
            Debug.Log("Not enough gold to buy " + storeSlot1.itemName);
            
        }

        if (isCooldown)
        {
            ApplyCooldown();
        }




    }

    IEnumerator JumpForceChange()
    {

        if (isCooldown)
        {
            Debug.Log("Skill in cooldown");
        }
        else
        {

            if(storeSlot1 != null)
            {
                isCooldown = true;

                storeSlot1.ApplyPoints();

                txtCooldown.gameObject.SetActive(true);
                //Set the cooldown time to the skillcooldown value of the skill assigned 
                cooldownTimer = storeSlot1.duration;

                PlayerController playerStats = FindObjectOfType<PlayerController>();

                iconToDisplay.sprite = storeSlot1.icon;


                trigger = iconToDisplay.GetComponent<TooltipTrigger>();
                trigger.content = storeSlot1.DefineContent();

                GameObject icon = Instantiate(effectIconPrefab, effectBar.transform);
                float tempValueHolder = playerStats._stats.JumpPower;


                playerStats._stats.JumpPower *= storeSlot1.boostMultiplier;
                Debug.Log("Effect applied");

                yield return new WaitForSeconds(storeSlot1.duration);

                playerStats._stats.JumpPower = tempValueHolder;

                Destroy(icon);
                //restore original values here

                Debug.Log("effect ended");
            }
            else if (storeSlot1 == null)
            {
                Debug.Log("You have no item equipped on this slot");
            }

           
        }
        
    }


    void ApplyCooldown()
    {
        //Subtrack time since last called
        cooldownTimer -= Time.deltaTime;

        //Condition to make the text and the filler of the image active according to the status of the skill
        if (cooldownTimer < 0.0f)
        {
            isCooldown = false;
            txtCooldown.gameObject.SetActive(false);
            imgCooldown.fillAmount = 0.0f;
        }
        else
        {
            txtCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imgCooldown.fillAmount = cooldownTimer / storeSlot1.duration;
        }

    }
}
