using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] Color32 hasPackageColor = new Color32 (1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32 (1,1,1,1);

    SpriteRenderer spriteRenderer;

    [SerializeField] float destroyTimer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package")
        {
            if(hasPackage)
            {
                Debug.Log("First deliver the first package!");
            }
            else
            {
                Debug.Log("Package Picked Up!");
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, destroyTimer);
            }
        }
        else if(other.tag == "Customer")
        {
            if(hasPackage)
            {
                Debug.Log("Thanks for the pizza man!");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
                Destroy(other.gameObject, destroyTimer);
            }
            else
            {
                Debug.Log("Go get some packages first!");
            }
        }
    }
}
