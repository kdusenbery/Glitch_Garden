using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerGoal : MonoBehaviour
{
    [SerializeField] int damage = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);

        FindObjectOfType<PlayerHealth>().LoseHealth(damage);
    }
}
