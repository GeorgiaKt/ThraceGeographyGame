using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour
{
   public GameObject uiObject;
   
   void Start(){
        uiObject.SetActive(false);
   }

   //Update is called once per frame
   void OnTriggerEnter (Collider other){
		if(other.gameObject.tag=="Player"){
			uiObject.SetActive(true);
		}
   }
   
   void OnTriggerExit(Collider other){
	   uiObject.SetActive(false);
   }

}