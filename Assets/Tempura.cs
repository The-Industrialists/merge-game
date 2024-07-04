using UnityEngine;
using System.Collections.Generic;

public class Tempura : MonoBehaviour
{
    public GameObject shashimiPrefab; // Assign the Tempura prefab in the inspector
    private static List<Tempura> tempuraList = new List<Tempura>();
    private bool hasCombined = false; // Flag to check if the tempura has been combined

    private void OnEnable()
    {
        tempuraList.Add(this);
    }

    private void OnDisable()
    {
        tempuraList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tempura otherTempura = collision.gameObject.GetComponent<Tempura>();
        if (otherTempura != null && otherTempura != this && !this.hasCombined && !otherTempura.hasCombined)
        {
            CombineTempura(this, otherTempura);
        }
    }

    private void CombineTempura(Tempura tempura1, Tempura tempura2)
    {
        if (tempura1 != null && tempura2 != null)
        {
            Vector2 midPoint = (tempura1.transform.position + tempura2.transform.position) / 2;

            // Instantiate the shashimi at the midpoint
            Instantiate(shashimiPrefab, midPoint, Quaternion.identity);

            // Set the flags to true to prevent further combination
            tempura1.hasCombined = true;
            tempura2.hasCombined = true;

            // Destroy the two tempura
            Destroy(tempura1.gameObject);
            Destroy(tempura2.gameObject);
        }
    }
}
