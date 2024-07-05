using UnityEngine;
using System.Collections.Generic;

public class Inarizushi : MonoBehaviour
{
    public GameObject hosomakiPrefab; 
    private static List<Inarizushi> inarizushiList = new List<Inarizushi>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        inarizushiList.Add(this);
    }

    private void OnDisable()
    {
        inarizushiList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Inarizushi otherInarizushi = collision.gameObject.GetComponent<Inarizushi>();
        if (otherInarizushi != null && otherInarizushi != this && !this.hasCombined && !otherInarizushi.hasCombined)
        {
            CombineInarizushi(this, otherInarizushi);
        }
    }

    private void CombineInarizushi(Inarizushi inarizushi1, Inarizushi inarizushi2)
    {
        if (inarizushi1 != null && inarizushi2 != null)
        {
            Vector2 midPoint = (inarizushi1.transform.position + inarizushi2.transform.position) / 2;


            Instantiate(hosomakiPrefab, midPoint, Quaternion.identity);


            inarizushi1.hasCombined = true;
            inarizushi2.hasCombined = true;


            Destroy(inarizushi1.gameObject);
            Destroy(inarizushi2.gameObject);
        }
    }
}
