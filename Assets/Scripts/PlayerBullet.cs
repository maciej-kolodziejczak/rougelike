using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] float speed = 7.5f;
    [SerializeReference] int damage = 50;
    [SerializeField] Rigidbody2D rbody;
    [SerializeField] GameObject impactEffect;
    [SerializeField] GameObject damageEffect;

    void Update()
    {
        rbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        AudioManager.Instance.PlaySfx(4);

        if (collision.tag == "Enemy")
        {
            Instantiate(damageEffect, transform.position, transform.rotation);
            collision.GetComponent<EnemyController>().Damage(damage);
        } else
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
