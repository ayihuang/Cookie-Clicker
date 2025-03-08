using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;


public class Setup : MonoBehaviour
{
    public TextMeshProUGUI clicksText;
    public TextMeshProUGUI up1Text;
    public TextMeshProUGUI up2Text;
    public TextMeshProUGUI up3Text;

    public GameObject cookie;
    public GameObject up1;
    public GameObject up2;
    public GameObject up3;

    private int clicks = 0;

    private float gameTime = 0;

    private bool up1used = false;
    private bool up2used = false;
    private bool up3used = false;

    // Start is called before the first frame update
    void Start()
    {
        // set all upgrades invisible 
        up1.SetActive(false);
        up1Text.SetText("");
        up2.SetActive(false);
        up2Text.SetText("");
        up3.SetActive(false);
        up3Text.SetText("");
        up3.SetActive(false);
        up3Text.SetText("");
    }
    public void clickCookie() // when cookie is clicked
    {
        clicks++;
    }
    public void up1Click() // upgrade 1 button
    {
        clicks -= 20;
        up1used = true;
    }
    public void up2Click() // upgrade 2 button
    {
        clicks -= 1000;
        up2used = true;
    }
    public void up3Click() // upgrade 3 button
    {
        clicks -= 5000;
        up3used = true;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime += Time.deltaTime; 
        clicksText.SetText(clicks.ToString());

        // upgrade 1 button
        if (clicks >= 20 && up1used == false)  // enough cookies and not used before
        {
            up1.SetActive(true);
            up1Text.SetText("20 Biscuits. Clicks a lot of times every 10 seconds");
        }
        else
        {
            up1.SetActive(false);
            up1Text.SetText("");
        }
        if (up1used == true) // every 10 seconds actiavte automatically clicking for that second
        {
            if (Mathf.Round(gameTime % 10) == 0) 
            {
                clickCookie();
            }
        }

        //upgrade 2 button
        if (clicks >=1000 && up2used == false)
        {
            up2.SetActive(true);
            up2Text.SetText("1000 Biscuits. Clicks a lot of times every 5 seconds");
        }
        else
        {
            up2.SetActive(false);
            up2Text.SetText("");
        }
        if (up2used == true) // every 5 seconds
        {
            if (Mathf.Round(gameTime % 5) == 0)
            {
                clickCookie();
            }
        }

        // upgrade 3 button
        if (clicks >= 5000 && up3used == false)
        {
            up3.SetActive(true);
            up3Text.SetText("5000 Biscuits. Clicks a lot of times every 2 seconds");
        }
        else
        {
            up3.SetActive(false);
            up3Text.SetText("");
        }
        if (up3used == true) // every two seconds
        {
            if (Mathf.Round(gameTime % 2) == 0)
            {
                clickCookie();
            }
        }

    }
}
