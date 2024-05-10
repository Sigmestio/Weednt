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
    private bool rotateArrowEnabled = true;
    private bool placeArrowOnNextClick = false;

    private void Update()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);
        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (placeArrowOnNextClick)
            {
                placeArrowOnNextClick = false;
                PlaceArrow();
            }
            else
            {
                ShowArrowPrefabricator(mousePosition);
            }
        }
        
        if (rotateArrowEnabled)
        {
            RotateArrow();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            DeleteArrowUnderMouse();
        }
    }

    private void ShowArrowPrefabricator(Vector3 position)
    {
        Vector3Int gridPosition = grid.WorldToCell(position);
        if (!IsArrowPrefabricatorAlreadyPlaced(gridPosition))
        {
            arrowPrefabricator = Instantiate(arrowPrefab, grid.CellToWorld(gridPosition), Quaternion.identity);
            rotateArrowEnabled = true;
            placeArrowOnNextClick = true;
        }
    }

    private void RotateArrow()
    {
        if (arrowPrefabricator != null)
        {
            cellIndicator.SetActive(false);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 direction = grid.WorldToCell(hitInfo.point) - arrowPrefabricator.transform.position;
                direction = new Vector3(direction.x + 0.5f, 0, direction.z + 0.5f);
                direction = new Vector3(Mathf.Clamp(direction.x, -1f, 1f), 0, Mathf.Clamp(direction.z, -1f, 1f));
                if (direction != Vector3.zero)
                {
                    arrowPrefabricator.transform.GetChild(0).rotation = Quaternion.LookRotation(direction);
                }
            }
        }
    }

    private void PlaceArrow()
    {
        rotateArrowEnabled = false;
        cellIndicator.SetActive(true);
    }

    private void DeleteArrowUnderMouse()
    {
        Vector3 mousePosition = inputManager.GetSelectedMapPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        Collider[] colliders = Physics.OverlapSphere(grid.CellToWorld(gridPosition), 1f);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Arrow"))
            {
                Destroy(collider.gameObject);
            }
        }
    }
    private bool IsArrowPrefabricatorAlreadyPlaced(Vector3Int gridPosition)
    {
        return false; 
    }
}