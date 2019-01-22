using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomHealthBar : MonoBehaviour
{
    [SerializeField]
    private Image redBar;
    
    GameObject healthBarCanvas;

    private float maxHealth = 100;
    private float currentHealth = 100;

    public void SetMaxHealth(int mh)
    {
        maxHealth = mh;
        redBar.fillAmount = currentHealth / maxHealth;
    }

    public void SetCurrentHealth(int ch)
    {
        currentHealth = (float) ch;
        redBar.fillAmount = currentHealth / maxHealth;
    }

    public void SetCurrentHealth(float ch)
    {
        currentHealth = ch;
        redBar.fillAmount = currentHealth / maxHealth;
    }

    // Start is called before the first frame update
    void Awake()
    {
        healthBarCanvas = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(healthBarCanvas.transform.parent.tag == "Enemy")
        {
            healthBarCanvas.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(currentHealth <= 0)
        {
            Destroy(healthBarCanvas);
        }
    }
}
