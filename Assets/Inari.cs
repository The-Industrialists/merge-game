using UnityEngine;
using System.Collections.Generic;

public class Inari : MonoBehaviour
{
    public GameObject tune_rollPrefab; 
    private static List<Inari> inariList = new List<Inari>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        inariList.Add(this);
    }

    private void OnDisable()
    {
        inariList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Inari otherInari = collision.gameObject.GetComponent<Inari>();
        if (otherInari != null && otherInari != this && !this.hasCombined && !otherInari.hasCombined)
        {
            CombineShrimp(this, otherInari);
        }
    }

    private void CombineShrimp(Inari inari1, Inari inari2)
    {
        if (inari1 != null && inari2 != null)
        {
            Vector2 midPoint = (inari1.transform.position + inari2.transform.position) / 2;


            Instantiate(tempuraPrefab, midPoint, Quaternion.identity);


            inari1.hasCombined = true;
            inari2.hasCombined = true;


            Destroy(inari1.gameObject);
            Destroy(inari2.gameObject);
        }
    }
}
