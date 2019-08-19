using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    Defender currentDefender;
    bool selected = false; 

    private void OnMouseDown()
    {
        currentDefender = FindObjectOfType<DefenderSpawner>().GetCurrentDefender();

        if (selected == true && currentDefender == defenderPrefab)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab, false);

            selected = false;
        }
        else
        {
            var buttons = FindObjectsOfType<DefenderButton>();

            foreach (DefenderButton button in buttons)
            {
                button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
            }

            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab, true);

            selected = true;
        }
     }
}
