using UnityEngine;
using System.Collections.Generic;

public class Shrimp : MonoBehaviour
{
    public GameObject tempuraPrefab; // Assign the Tempura prefab in the inspector
    private static List<Shrimp> shrimpList = new List<Shrimp>();
    private bool hasCombined = false; // Flag to check if the shrimp has been combined

    private void OnEnable()
    {
        shrimpList.Add(this);
    }

    private void OnDisable()
    {
        shrimpList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Shrimp otherShrimp = collision.gameObject.GetComponent<Shrimp>();
        if (otherShrimp != null && otherShrimp != this && !this.hasCombined && !otherShrimp.hasCombined)
        {
            CombineShrimp(this, otherShrimp);
        }
    }

    private void CombineShrimp(Shrimp shrimp1, Shrimp shrimp2)
    {
        if (shrimp1 != null && shrimp2 != null)
        {
            Vector2 midPoint = (shrimp1.transform.position + shrimp2.transform.position) / 2;

            // Instantiate the Tempura at the midpoint
            Instantiate(tempuraPrefab, midPoint, Quaternion.identity);

            // Set the flags to true to prevent further combination
            shrimp1.hasCombined = true;
            shrimp2.hasCombined = true;

            // Destroy the two shrimp
            Destroy(shrimp1.gameObject);
            Destroy(shrimp2.gameObject);
        }
    }
}
