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
    [SerializeField] private float moveSpeed = 5.0f;

    public Transform hoop; 
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
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick() {
        if(curTurn)
        {
            Vector2 mousePos = (mouseInput.Mouse.MousePosition.ReadValue<Vector2>());
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            // make sure we are clicking the cell
            Vector3Int gridPos = map.WorldToCell(mousePos);
            //if (map.HasTile(gridPos)){
            destination = map.GetCellCenterWorld(gridPos);
            //Debug.Log(destination);
            //}
            if (Vector3.Distance(transform.position, destination) > 0.1f && Vector3.Distance(transform.position, destination) < 3.0f){
                takenTurn = true;
            }
        }
    }

    private bool canShoot(){
        var distance = Vector3.Distance(transform.position, hoop.position);
        // print(distance);
        //check if the current player is close enough to shoot. (4.5 is right around the midpoint between the half court and the 3 point line) 
        if(distance < 4.5 ){
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
    }
}
