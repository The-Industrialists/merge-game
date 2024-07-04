using UnityEngine;
using System.Collections.Generic;

public class Nigri : MonoBehaviour
{
    public GameObject makiPrefab; // Assign the Tempura prefab in the inspector
    private static List<Nigri> nigriList = new List<Nigri>();
    private bool hasCombined = false; // Flag to check if the shrimp has been combined

    private void OnEnable()
    {
        nigriList.Add(this);
    }

    private void OnDisable()
    {
        nigriList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Nigri otherNigri = collision.gameObject.GetComponent<Nigri>();
        if (otherNigri != null && otherNigri != this && !this.hasCombined && !otherNigri.hasCombined)
        {
            CombineNigri(this, otherNigri);
        }
    }

    private void CombineNigri(Nigri nigri1, Nigri nigri2)
    {
        if (nigri1 != null && nigri2 != null)
        {
            Vector2 midPoint = (nigri1.transform.position + nigri2.transform.position) / 2;

            // Instantiate the maki at the midpoint
            Instantiate(makiPrefabPrefab, midPoint, Quaternion.identity);

            // Set the flags to true to prevent further combination
            nigri1.hasCombined = true;
            nigri2.hasCombined = true;

            // Destroy the two shrimp
            Destroy(nigri1.gameObject);
            Destroy(nigri2.gameObject);
        }
    }
}
