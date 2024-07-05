using UnityEngine;
using System.Collections.Generic;

public class Temaki : MonoBehaviour
{
    public GameObject chopstickPrefab; 
    private static List<Temaki> temakiList = new List<Temaki>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        temakiList.Add(this);
    }

    private void OnDisable()
    {
        temakiList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Temaki otherTemaki = collision.gameObject.GetComponent<Temaki>();
        if (otherTemaki != null && otherTemaki != this && !this.hasCombined && !otherTemaki.hasCombined)
        {
            CombineTemaki(this, otherTemaki);
        }
    }

    private void CombineTemaki(Temaki temaki1, Temaki temaki2)
    {
        if (temaki1 != null && temaki2 != null)
        {
            Vector2 midPoint = (temaki1.transform.position + temaki2.transform.position) / 2;


            Instantiate(chopstickPrefab, midPoint, Quaternion.identity);


            temaki1.hasCombined = true;
            temaki2.hasCombined = true;


            Destroy(temaki1.gameObject);
            Destroy(temaki2.gameObject);
        }
    }
}
