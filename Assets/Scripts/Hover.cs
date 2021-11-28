using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text;
    void Start(){
        Debug.Log("What's up");
        // text.SetActive(false);
    }
    public void OnMouseOver()
    {
        text.SetActive(true);
        print("This is over the object");
        Debug.Log("This is over the object");
    }

    public void OnMouseExit(){
        text.SetActive(false);
        print("This is no longer on the object");
    }
}
