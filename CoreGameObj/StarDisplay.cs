using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starValTxt;

    // Start is called before the first frame update
    void Start()
    {
        starValTxt = GetComponent<Text>();
        UpdateStars();
    }

    private void UpdateStars()
    {
        starValTxt.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateStars();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateStars();
        }
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount;
    }
}
