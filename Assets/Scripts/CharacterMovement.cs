using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    public Tilemap map;
    MouseInput mouseInput;
    private Vector3 destination;
    public bool curTurn = false;
    public bool takenTurn = false;
    public bool hasBall = false;
    [SerializeField] private float moveSpeed = 5.0f;

    public Transform hoop; 
    // public GameObject playerClass;  


    private void Awake() {
        mouseInput = new MouseInput();
        
        
    }

    private void OnEnable(){
        mouseInput.Enable();
    }

    private void OnDisable(){
        mouseInput.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        //this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick() {
        if(curTurn)
        {
            //this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            Vector2 mousePos = (mouseInput.Mouse.MousePosition.ReadValue<Vector2>());
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            // hit.collider store rigidbody and gameobject clicked 
            if (hit.collider != null){
                if(hasBall){
                    hit.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 0;
                    Debug.Log(hit.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder);
                    this.hasBall = false;
                    this.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
                }
                Debug.Log("clicked player");

                //hasBall = true;
            }


            if (hit.collider == null){
                Debug.Log("clicked to move");
                // make sure we are clicking the cell
                Vector3Int gridPos = map.WorldToCell(mousePos);
                destination = map.GetCellCenterWorld(gridPos);
            }
            
            
            
            //change the hasMoved variable to true
            /*
            switch(gameObject.tag){
                case guard:
                    Guard.hasMoved = true;
                    break;
                case forward:
                    Forward.hasMoved = true;
                    break;
                case center:
                    Center.hasMoved = true;
                    break;    
            }*/
            
            if (Vector3.Distance(transform.position, destination) > 0.1f && Vector3.Distance(transform.position, destination) < 3.0f){
                takenTurn = true;

            }



        }
        
    }

    private bool canShoot(){
        var distance = Vector3.Distance(transform.position, hoop.position);
        // print(distance);
        //check if the current player is close enough to shoot. (4.5 is right around the midpoint between the half court and the 3 point line) 
        if(distance < 4.5f ){
            return true;
        }
        else{
            return false; 
        }
    }
    private void shotPercentage(){

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f && Vector3.Distance(transform.position, destination) < 3.0f){
            // check if destination has a unit on the tile already before moving
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
            // print(canShoot());
            
        }
        if (curTurn){
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        } else {
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        }

        if (this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder == 0){
            hasBall = true;
        } 

        if (hasBall){
            this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 0;
        } else {
            this.gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = -4;
        }

        if(GetComponent<SpriteRenderer>().enabled){
            //this.hasBall = true;
        }
    }
}
