using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class putTrigger : MonoBehaviour
{
    #region Fields

    [SerializeField] private Image _bar;
    public float cowNum, tigerNum, sheepNum, chickenNum, strawNum;
    public enum Farms { farm1, farm2, farm3, farm4 };
    public Farms farms;

    [Header("Lists")]
    public List<GameObject> points = new List<GameObject>(4);
    public List<GameObject> liste = new List<GameObject>(4);

    #endregion

    private void Start()
    {
        //At the beginning of the game, I pull the farm objects that we put in the game manager over the enum numbers I assigned.
        switch (farms)
        {
            case Farms.farm1:
                for (int i = 0; i < 4; i++)
                {
                    liste.RemoveAt(i);
                    liste.Insert(i, GameManager.Instance.farm1[i]);
                }
                break;
            case Farms.farm2:
                for (int i = 0; i < 4; i++)
                {
                    liste.RemoveAt(i);
                    liste.Insert(i, GameManager.Instance.farm2[i]);
                }
                break;
            case Farms.farm3:
                for (int i = 0; i < 4; i++)
                {
                    liste.RemoveAt(i);
                    liste.Insert(i, GameManager.Instance.farm3[i]);
                }
                break;
            case Farms.farm4:
                for (int i = 0; i < 4; i++)
                {
                    liste.RemoveAt(i);
                    liste.Insert(i, GameManager.Instance.farm4[i]);
                }
                break;
            default:
                break;
        }
        AnimalNumbers();
    }
    private void Update()
    {
        #region CompleteCheck
        if (GameManager.Instance.cow == cowNum)
        {
            GameManager.Instance.cowCompleted = true;
        }
       
        if (GameManager.Instance.tiger == tigerNum)
        {
            GameManager.Instance.tigerCompleted = true;
        }
        
        if (GameManager.Instance.chicken == chickenNum)
        {
            GameManager.Instance.chickenCompleted = true;
        }
        if (GameManager.Instance.sheep == sheepNum)
        {
            GameManager.Instance.sheepCompleted = true;
        }
        if (GameManager.Instance.straw == strawNum)
        {
            GameManager.Instance.strawCompleted = true;
        }
        #endregion
    }

    #region Triggers
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.Instance.t = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(GameManager.Instance.animal != null && GameManager.Instance.isExit)
            {
                GameManager.Instance.t += Time.deltaTime;
                _bar.fillAmount = GameManager.Instance.t / 2; //This way it will take 2 seconds for the slider to fill.

                if (_bar.fillAmount == 1)
                { 
                    PutAnimals();
                }
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _bar.fillAmount = 0;
        }
        

    }
    #endregion
    #region Methods
    void PutAnimals()
    {
        // I use this system to find out how many of which animals are on the farms.
        for (int i = 0; i < liste.Count; i++)
        {
            if(liste[i] == null)
            {
                Debug.Log("oldu");
                if (GameManager.Instance.animal.CompareTag("Cow"))
                {
                    cowNum++;
                }
                if (GameManager.Instance.animal.CompareTag("Sheep"))
                {
                   sheepNum++;
                }
                if (GameManager.Instance.animal.CompareTag("Chicken"))
                {
                    chickenNum++;
                }
                if (GameManager.Instance.animal.CompareTag("Tiger"))
                {
                    tigerNum++;
                }
                if (GameManager.Instance.animal.CompareTag("Straw"))
                {                
                    strawNum++;
                }
                liste.RemoveAt(i); //In order not to change the total number of indexes in the list, I first remove the null index.
                liste.Insert(i, GameManager.Instance.animal);
                GameManager.Instance.animal.transform.parent = null;
                GameManager.Instance.animal = null;
                liste[i].transform.position = new Vector3(points[i].transform.position.x,0f, points[i].transform.position.z);
                liste[i].transform.rotation = points[i].transform.rotation;
            }
            
            
        }
        
    }
    // At the beginning of the game, I use this method to find animals on farms
    void AnimalNumbers()
    {
        for (int i = 0; i < liste.Count; i++)
        {
            if (liste[i] != null)
            {
                if (liste[i].gameObject.CompareTag("Cow"))
                {
                    cowNum++;
                }
                if (liste[i].gameObject.CompareTag("Sheep"))
                {
                    sheepNum++;
                }
                if(liste[i].gameObject.CompareTag("Tiger"))
                {
                    tigerNum++;
                }
                if (liste[i].gameObject.CompareTag("Chicken"))
                {
                    chickenNum++;
                }
                if (liste[i].gameObject.CompareTag("Straw"))
                {
                    strawNum++;
                }
            }
        }       
    }
    #endregion

}
