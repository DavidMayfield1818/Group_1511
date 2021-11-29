using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    // Start is called before the first frame update
      public GameObject text;
      public GameObject background;
    void Awake(){
        text.SetActive(false);
        background.SetActive(false);
    }
    public void OnMouseOver()
    {
        text.SetActive(true);
        background.SetActive(true);
        PercentHover.ShowHover_Static(90);
    }

    public void OnMouseExit(){
        text.SetActive(false);
        background.SetActive(false);

    }
}
