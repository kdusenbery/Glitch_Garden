using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float damage = 25f;
    [SerializeField] float holdTime = 1f;
    [SerializeField] float moveSpeed = 3f;
    //[SerializeField] float rotateSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(fireProjectile());
    }

    IEnumerator fireProjectile()
    {
        yield return new WaitForSeconds(holdTime);
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Health health = otherCollider.GetComponent<Health>();
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
