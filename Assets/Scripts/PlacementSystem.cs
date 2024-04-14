using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab; 
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Grid grid;
    [SerializeField] private GameObject mouseIndicator, cellIndicator;

    private GameObject arrowPrefabricator; 
    private float arrowRotationAngle; 

    private void Update()
    {
    
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        
        if (Input.GetMouseButtonDown(1)) 
        {
            PlaceArrowPrefabricator();
        }

        if (Input.GetMouseButtonDown(0) &&
            arrowPrefabricator != null) 
        {
            PlaceArrow();
        }
    }

    private void PlaceArrowPrefabricator()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
       
        if (!IsArrowPrefabricatorAlreadyPlaced(gridPosition))
        {
          
            arrowPrefabricator = Instantiate(arrowPrefab, grid.CellToWorld(gridPosition), Quaternion.identity);
        }
    }

   
    private void PlaceArrow()
    {
        Vector3Int gridPosition = grid.WorldToCell(arrowPrefabricator.transform.position);
        GameObject arrowObject = Instantiate(arrowPrefab, grid.CellToWorld(gridPosition),
            arrowPrefabricator.transform.rotation);
        Destroy(arrowPrefabricator);
        arrowPrefabricator = null;
    }

    private bool IsArrowPrefabricatorAlreadyPlaced(Vector3Int gridPosition)
    {
        return false; 
    }
}
