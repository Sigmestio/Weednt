using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject cellIndicator;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Grid grid;
    [SerializeField] private LayerMask wall;

    private Vector3Int gridPosition;
    private bool isMoving = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (!isMoving)
        {
            HandleMovementInput();
        }
    }

    private void HandleMovementInput()
    {
        Vector3 movementInput = inputManager.GetSelectedMapPosition();
        if (movementInput != Vector3.zero)
        {
            StartCoroutine(MoveToNextCell(movementInput));
        }
    }

    private IEnumerator MoveToNextCell(Vector3 movementInput)
    {
        isMoving = true;

        Vector3 newPosition = transform.position + movementInput;
        gridPosition = grid.WorldToCell(newPosition);
        UpdateCellIndicatorPosition(newPosition);

        while (transform.position != newPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }

    private void UpdateCellIndicatorPosition(Vector3 playerPosition)
    {
        Vector3Int gridPosition = grid.WorldToCell(playerPosition);
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

}
