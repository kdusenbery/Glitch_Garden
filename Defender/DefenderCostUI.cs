using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderCostUI : MonoBehaviour
{
    [SerializeField] Defender defender;
    
    bool starAmount = false;
    int defenderCost;

    // Start is called before the first frame update
    void Start()
    {
        defenderCost = defender.GetStarCost();
    }

    // Update is called once per frame
    void Update()
    {
        starAmount = FindObjectOfType<StarDisplay>().HaveEnoughStars(defenderCost);
        ChangeCostColor();
    }

    private void ChangeCostColor()
    {
        if (starAmount == true)
        {
            gameObject.GetComponent<Text>().color = new Color32(237, 235, 55, 255);
        }
        else
        {
            gameObject.GetComponent<Text>().color = new Color32(43, 43, 43, 255);
        }
    }
}
