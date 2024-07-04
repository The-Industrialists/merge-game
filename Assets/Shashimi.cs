using UnityEngine;
using System.Collections.Generic;

public class Shashimi : MonoBehaviour
{
    public GameObject CarollPrefab; // Assign the Tempura prefab in the inspector
    private static List<Shashimi> shashimiList = new List<Shashimi>();
    private bool hasCombined = false; // Flag to check if the shrimp has been combined

    private void OnEnable()
    {
        shashimiList.Add(this);
    }

    private void OnDisable()
    {
        shashimiList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Shashimi otherShashimi = collision.gameObject.GetComponent<Shashimi>();
        if (otherShashimi != null && otherShashimi != this && !this.hasCombined && !otherShashimi.hasCombined)
        {
            CombineShashimi(this, otherShashimi);
        }
    }

    private void CombineShashimi(Shashimi shashimi1, Shashimi shashimi2)
    {
        if (shashimi1 != null && shashimi2 != null)
        {
            Vector2 midPoint = (shashimi1.transform.position + shashimi2.transform.position) / 2;

            // Instantiate the Tempura at the midpoint
            Instantiate(CarollPrefab, midPoint, Quaternion.identity);

            // Set the flags to true to prevent further combination
            shashimi1.hasCombined = true;
            shashimi2.hasCombined = true;

            // Destroy the two shrimp
            Destroy(shashimi1.gameObject);
            Destroy(shashimi2.gameObject);
        }
    }
}
