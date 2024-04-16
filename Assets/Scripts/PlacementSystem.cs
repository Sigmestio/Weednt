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
            ShowArrowPrefabricator(mousePosition);
        }

        if (Input.GetMouseButtonDown(0) && arrowPrefabricator != null) 
        {
            PlaceArrow();
        }

        RotateArrow();
    }

    private void ShowArrowPrefabricator(Vector3 position)
    {
        Vector3Int gridPosition = grid.WorldToCell(position);
        if (!IsArrowPrefabricatorAlreadyPlaced(gridPosition))
        {
            arrowPrefabricator = Instantiate(arrowPrefab, grid.CellToWorld(gridPosition), Quaternion.identity);
        }
    }

    private void RotateArrow()
    {
        if (arrowPrefabricator != null)
        {
            float mouseXMovement = Input.GetAxis("Mouse X");
            arrowRotationAngle += mouseXMovement * 45f;
            arrowPrefabricator.transform.GetChild(0).rotation = Quaternion.Euler(0f, arrowRotationAngle, 0f);
        }
    }

    private void PlaceArrow()
    {
        //save rotation tba
    }

    private bool IsArrowPrefabricatorAlreadyPlaced(Vector3Int gridPosition)
    {
        return false; 
    }
}


