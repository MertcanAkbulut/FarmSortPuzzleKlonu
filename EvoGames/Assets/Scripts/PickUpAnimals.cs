using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAnimals : MonoBehaviour
{
    #region Fields
    public bool isExit;

    [Header("Transforms")]
    [SerializeField] private Transform animalSlot;
    [SerializeField] private Transform player;
    #endregion

    #region Collisions

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tiger" || other.gameObject.tag == "Sheep" || other.gameObject.tag == "Cow" || other.gameObject.tag == "Chicken" || other.gameObject.tag == "Straw")
        {
            if (GameManager.Instance.animal == null)
            {
                GameManager.Instance.animal = other.gameObject;

                // I'm assigning the Animal object as the child object of the player, this way we will be able to move the object.
                other.gameObject.transform.position = animalSlot.position;
                other.transform.parent = player.transform;
                other.transform.rotation = player.transform.rotation;
                GameManager.Instance.isExit = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("FarmBox"))
        {
            //I wrote the losing conditions here.
            if (other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().tigerNum >= 1 && other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().cowNum >= 1)
            {
                Debug.Log("kaybettin");
                GameManager.Instance.LoseGame();
            }
            if (other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().tigerNum >= 1 && other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().sheepNum >= 1)
            {
                Debug.Log("kaybettin");
                GameManager.Instance.LoseGame();
            }
            if (other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().strawNum >= 1 && other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().sheepNum >= 1)
            {
                Debug.Log("kaybettin");
                GameManager.Instance.LoseGame();
            }
            if (other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().strawNum >= 1 && other.gameObject.transform.GetChild(0).GetComponent<putTrigger>().cowNum >= 1)
            {
                Debug.Log("kaybettin");
                GameManager.Instance.LoseGame();
            }
            
        }
    }
    #endregion
}
