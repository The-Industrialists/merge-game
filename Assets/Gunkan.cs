using UnityEngine;
using System.Collections.Generic;

public class Gunkan : MonoBehaviour
{
    public GameObject inariPrefab; 
    private static List<Gunkan> gunkanList = new List<Gunkan>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        gunkanList.Add(this);
    }

    private void OnDisable()
    {
        gunkanList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Gunkan otherGunkan = collision.gameObject.GetComponent<Gunkan>();
        if (otherGunkan != null && otherGunkan != this && !this.hasCombined && !otherGunkan.hasCombined)
        {
            CombineGunkan(this, otherGunkan);
        }
    }

    private void CombineGunkan(Gunkan gunkan1, Gunkan gunkan2)
    {
        if (gunkan1 != null && gunkan2 != null)
        {
            Vector2 midPoint = (gunkan1.transform.position + gunkan2.transform.position) / 2;


            Instantiate(tempuraPrefab, midPoint, Quaternion.identity);


            gunkan1.hasCombined = true;
            gunkan2.hasCombined = true;


            Destroy(gunkan1.gameObject);
            Destroy(gunkan2.gameObject);
        }
    }
}