using UnityEngine;
using System.Collections.Generic;

public class Hosomaki : MonoBehaviour
{
    public GameObject hamachiPrefab; 
    private static List<Hosomaki> hosomakiList = new List<Hosomaki>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        hosomakiList.Add(this);
    }

    private void OnDisable()
    {
        hosomakiList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hosomaki otherHosomaki = collision.gameObject.GetComponent<Hosomaki>();
        if (otherHosomaki != null && otherHosomaki != this && !this.hasCombined && !otherHosomaki.hasCombined)
        {
            CombineHosomaki(this, otherHosomaki);
        }
    }

    private void CombineHosomaki(Hosomaki hosomaki1, Hosomaki hosomaki2)
    {
        if (hosomaki1 != null && hosomaki2 != null)
        {
            Vector2 midPoint = (hosomaki1.transform.position + hosomaki2.transform.position) / 2;


            Instantiate(hamachiPrefab, midPoint, Quaternion.identity);


            hosomaki1.hasCombined = true;
            hosomaki2.hasCombined = true;


            Destroy(hosomaki1.gameObject);
            Destroy(hosomaki2.gameObject);
        }
    }
}
