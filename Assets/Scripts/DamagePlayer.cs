using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        DealDamage(collision);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DealDamage(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DealDamage(collision);
    }

    private void DealDamage(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerHealthController.instance.Damage();
        }
    }

    private void DealDamage(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealthController.instance.Damage();
        }
    }
}
