using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float BulletDamage;
    public bool FromSelf = true;

    void StartWithParameters(float time) {
        StartCoroutine(Cleanup(time));
    }

    IEnumerator Cleanup(float time) {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision obj) {
        Debug.Log("Collision");
        foreach (ContactPoint contact in obj.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        if ((obj.gameObject.name == "Player") && (FromSelf == false) ) { //Set  [FromSelf == false] To [FromSelf == true] to enable self damage
            Debug.Log(obj.gameObject.name + "is hit" ); // in debuing message
            obj.gameObject.SendMessage("ApplyDamage", BulletDamage);
        }
        else if (obj.gameObject.tag == "AI") {
            Debug.Log(obj.gameObject.name + "is hit" ); // in debuing message
            obj.gameObject.SendMessage("ApplyDamage", BulletDamage);
        }

        Destroy(gameObject);
    }
}
