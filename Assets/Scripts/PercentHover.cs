using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PercentHover : MonoBehaviour
{
    private static PercentHover instance;
    private Text hoverText;
    private RectTransform backgroundRectTransform;
    
    [SerializeField] private Camera uiCamera;
    // Start is called before the first frame update
    private void Awake() {
        instance = this;
        backgroundRectTransform = transform.Find("background").GetComponent<RectTransform>();
        hoverText = transform.Find("text").GetComponent<Text>();
        print("hello World");
        // ShowHover(90);
    }
    private void ShowHover(int shotPercent){
        float textPadding = 4f;
        gameObject.SetActive(true);

        hoverText.text =  "Shot Chance " + shotPercent.ToString();
        Vector2 backgroundSize = new Vector2(hoverText.preferredWidth + textPadding *2f, hoverText.preferredHeight + textPadding *2f);
        backgroundRectTransform.sizeDelta = backgroundSize;
    }

    private void HideHover(){
        gameObject.SetActive(false);
    }

    void Update() {
        // Vector2 localPoint;
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponent<RectTransform>(),Input.mousePosition, uiCamera, out localPoint);
        // transform.localPosition = localPoint;
    }

   public static void ShowHover_Static(int shotPercent){
       instance.ShowHover(shotPercent);

   }
   public static void HideHover_Static(){
       instance.HideHover();
   }
}
