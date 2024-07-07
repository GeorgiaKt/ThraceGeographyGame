using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public BoxCollider borderEvros;
    public BoxCollider borderRodopi;
    public BoxCollider odigies;
    public TMP_Text infoCount;
    public GameObject uiObject;

    public static int collisions = 0;
    // List to keep track of triggered colliders
    private List<BoxCollider> triggeredColliders = new List<BoxCollider>();

   void Start(){
        uiObject.SetActive(false);
        collisions = 0;
   }

    // OnTriggerEnter is called when the player enters a collider
    private void OnTriggerEnter(Collider other)
    {
        uiObject.SetActive(true);


        // Check if the collider is a box collider
        BoxCollider boxCollider = other.GetComponent<BoxCollider>();

        if (boxCollider != null)
        {
            // Check if the collider has already been triggered
            if ((!triggeredColliders.Contains(boxCollider)) && boxCollider != borderEvros && boxCollider != borderRodopi && boxCollider != odigies)
            {
                collisions++;
                //Debug.Log(collisions);

                // Add the collider to the triggered list
                triggeredColliders.Add(boxCollider);

                if(collisions >= 9)
                    borderEvros.isTrigger = true;
                if(collisions >= 18)
                    borderRodopi.isTrigger =  true;


                if(collisions == 9 || collisions == 18)
                {
                    infoCount.color = Color.yellow;
                    infoCount.text = "Πλήθος Πληροφοριών: " + collisions + "\n Ξεκλειδώθηκε το επόμενο επίπεδο!";
                }
                else
                {
                    infoCount.color = Color.black;
                    infoCount.text = "Πλήθος Πληροφοριών: " + collisions;
                }

            } 
            
        }
    }
}
