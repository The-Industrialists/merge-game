using UnityEngine;
using System.Collections.Generic;

public class CA_Roll : MonoBehaviour
{
    public GameObject NigiriPrefab; // Assign the caroll prefab in the inspector
    private static List<CA_Roll> ca_rollList = new List<CA_Roll>();
    private bool hasCombined = false; // Flag to check if the shrimp has been combined

    private void OnEnable()
    {
        ca_rollList.Add(this);
    }

    private void OnDisable()
    {
        ca_rollList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CA_Roll otherCA_Roll = collision.gameObject.GetComponent<CA_Roll>();
        if (otherCA_Roll != null && otherCA_Roll != this && !this.hasCombined && !otherCA_Roll.hasCombined)
        {
            CombineCA_Roll(this, otherCA_Roll);
        }
    }

    private void CombineCA_Roll(CA_Roll ca_roll1, CA_Roll ca_roll2)
    {
        if (ca_roll1 != null && ca_roll2 != null)
        {
            Vector2 midPoint = (ca_roll1.transform.position + ca_roll2.transform.position) / 2;

            // Instantiate the Tempura at the midpoint
            Instantiate(NigiriPrefab, midPoint, Quaternion.identity);

            // Set the flags to true to prevent further combination
            ca_roll1.hasCombined = true;
            ca_roll2.hasCombined = true;

            // Destroy the two shrimp
            Destroy(ca_roll1.gameObject);
            Destroy(ca_roll2.gameObject);
        }
    }
}
