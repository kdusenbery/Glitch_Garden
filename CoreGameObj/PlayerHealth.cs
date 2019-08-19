using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 200;
    int lowHealth;
    Text healthTxt;

    // Start is called before the first frame update
    void Start()
    {
        healthTxt = GetComponent<Text>();
        healthTxt.text = health.ToString();
        lowHealth = health / 4;
    }

    public void LoseHealth(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
            healthTxt.text = health.ToString();

            FindObjectOfType<LevelController>().HandleLostCondition();
        }
        else
        {
            if (health <= lowHealth)
            {
                healthTxt.color = new Color32(255, 0, 18, 255);
            }

            healthTxt.text = health.ToString();
        }
    }
 }
