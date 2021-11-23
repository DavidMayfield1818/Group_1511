using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    public Tilemap map;
    MouseInput mouseInput;
    private Vector3 destination;
    [SerializeField] private float moveSpeed = 5.0f;

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
        Vector2 mousePos = (mouseInput.Mouse.MousePosition.ReadValue<Vector2>());
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        // make sure we are clicking the cell
        Vector3Int gridPos = map.WorldToCell(mousePos);
        //if (map.HasTile(gridPos)){
        destination = map.GetCellCenterWorld(gridPos);
        Debug.Log(destination);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f && Vector3.Distance(transform.position, destination) < 3.0f){
            transform.position = Vector3.MoveTowards(transform.position, destination, moveSpeed * Time.deltaTime);
        }
       // Debug.Log(mousePos);
    }
}
