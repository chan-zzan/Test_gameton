using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_E : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // ???? ȹ??
            Destroy(this.gameObject);
            GameManager_E.Instance.Player.GetTreasure();
        }
    }
}
