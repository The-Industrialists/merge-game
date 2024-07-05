using UnityEngine;
using System.Collections.Generic;

public class Uramaki : MonoBehaviour
{
    public GameObject temakiPrefab; 
    private static List<Uramaki> uramakiList = new List<Uramaki>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        uramakiList.Add(this);
    }

    private void OnDisable()
    {
        uramakiList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Uramaki otherUramaki = collision.gameObject.GetComponent<Uramaki>();
        if (otherUramaki != null && otherUramaki != this && !this.hasCombined && !otherUramaki.hasCombined)
        {
            CombineUramkai(this, otherUramaki);
        }
    }

    private void CombineUramkai(Uramaki uramaki1, Uramaki uramaki2)
    {
        if (uramaki1 != null && uramaki2 != null)
        {
            Vector2 midPoint = (uramaki1.transform.position + uramaki2.transform.position) / 2;


            Instantiate(temakiPrefab, midPoint, Quaternion.identity);


            uramaki1.hasCombined = true;
            uramaki2.hasCombined = true;


            Destroy(uramaki1.gameObject);
            Destroy(uramaki2.gameObject);
        }
    }
}
