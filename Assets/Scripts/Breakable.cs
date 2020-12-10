using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] GameObject[] pieces;

    [Header("Droppables")]
    [SerializeField] bool canDropItems;
    [SerializeField] float dropChance;
    [SerializeField] GameObject[] dropables;

    private int minPieces = 3;
    private int maxPieces = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerController.instance.dashCounter <= 0)
                return;

            Destroy(gameObject);

            // break element
            int piecesCount = UnityEngine.Random.Range(minPieces, maxPieces);
            
            for (int i = 0; i < piecesCount; i += 1)
            {
                GameObject piece = pieces[i];
                Instantiate(piece, transform.position, transform.rotation);
            }

            // drop items
            DropItems();
        }
    }

    private void DropItems()
    {
        if (!canDropItems)
            return;

        float dropResult = Random.Range(0f, 100f);

        if (dropResult >= dropChance)
            return;

        int itemIndex = Random.Range(0, dropables.Length);
        Instantiate(dropables[itemIndex], transform.position, transform.rotation);
    }
}
