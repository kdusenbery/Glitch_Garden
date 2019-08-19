using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 50f;
    [SerializeField] GameObject dieVFX;
    [SerializeField] float dieVFXDuration = 1f;
    [SerializeField] AudioClip dieSFX;
    [SerializeField] [Range(0f,2f)] float dieSFXVolume = 2f;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if (dieVFX) {
                TriggerDeathFX();
            } 
            Destroy(gameObject);
        }
    }

    private void TriggerDeathFX()
    {
        GameObject dieVFXObj = Instantiate(dieVFX, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(dieSFX, Camera.main.transform.position, dieSFXVolume);

        Destroy(dieVFXObj, dieVFXDuration);
    }
}
