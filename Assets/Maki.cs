using UnityEngine;
using System.Collections.Generic;

public class Maki : MonoBehaviour
{
    public GameObject gunkanPrefab; 
    private static List<Maki> makiList = new List<Maki>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        makiList.Add(this);
    }

    private void OnDisable()
    {
        shrimpList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Maki otherMaki = collision.gameObject.GetComponent<Maki>();
        if (otherMaki != null && otherMaki != this && !this.hasCombined && !otherMaki.hasCombined)
        {
            CombineMaki(this, otherMaki);
        }
    }

    private void CombineMaki(Maki maki1, Maki maki2)
    {
        if (maki1 != null && maki2 != null)
        {
            Vector2 midPoint = (maki1.transform.position + maki2.transform.position) / 2;


            Instantiate(gunkanPrefabPrefab, midPoint, Quaternion.identity);


            maki1.hasCombined = true;
            maki2.hasCombined = true;


            Destroy(maki1.gameObject);
            Destroy(maki2.gameObject);
        }
    }
}
