using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHider : MonoBehaviour
{
    [SerializeField] private Material material;

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            material.color = new Color(1, 1, 1, 0.5f);

            Debug.Log("Player in kitchen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            material.color = new Color(1, 1, 1, 1);

            Debug.Log("Player is not in kitchen");
        }
    }
}
