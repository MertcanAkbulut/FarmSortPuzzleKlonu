using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalControl : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        //When the animals leave the farm, I make sure that they leave the list in that farm and the variable we keep their number decreases.
        if (other.gameObject.CompareTag("FarmBox"))
        {

            for (int i = 0; i < other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().liste.Count; i++)
            {
                if (this.gameObject == other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().liste[i])
                {
                    if(this.gameObject.CompareTag("Tiger"))
                    {
                        other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().tigerNum--;
                    }
                    if (this.gameObject.CompareTag("Sheep"))
                    {
                        other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().sheepNum--;
                    }
                    if (this.gameObject.CompareTag("Cow"))
                    {
                        other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().cowNum--;
                    }
                    if (this.gameObject.CompareTag("Chicken"))
                    {
                        other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().chickenNum--;
                    }
                    if (this.gameObject.CompareTag("Straw"))
                    {
                        other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().strawNum--;
                    }

                    other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().liste.RemoveAt(i);
                    other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().liste.Insert(i, null);
                }
                
            }
            GameManager.Instance.isExit = true;
        }
    }

}
