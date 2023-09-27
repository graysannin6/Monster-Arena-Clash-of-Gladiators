using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitInterfaceController : MonoBehaviour
{
    [SerializeField] CurrencyManager currencyManager;
    [SerializeField] UnitSpawner playerUnitSpawner;
    [SerializeField] GameObject objectSpawnPositionGhost;
    bool isUnitSelected = false;
    GameObject selectedUnit = null;
    float selectedUnitCost = 0;
    [SerializeField] float zMax = -4f;
    [SerializeField] float zMin = 4f;
    [SerializeField]private float xMin;
    [SerializeField]private float xMax;


    // Start is called before the first frame update
    void Start()
    {
        objectSpawnPositionGhost.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isUnitSelected)
        {
            RunSpawnInterface();
        }
    }

    void RunSpawnInterface()
    {
        Vector3 mouseWorldPoint = GetMouseRayHitPosition();

        if (mouseWorldPoint.z > zMax) mouseWorldPoint.z = zMax;
        if (mouseWorldPoint.z < zMin) mouseWorldPoint.z = zMin;
        if (mouseWorldPoint.x > xMax) mouseWorldPoint.x = xMax;
        if (mouseWorldPoint.x < xMin) mouseWorldPoint.x = xMin;

        objectSpawnPositionGhost.transform.position = mouseWorldPoint;

        if (Input.GetMouseButtonUp(0))
        {
            if (GetMouseRayHitPosition() != Vector3.zero)
            {
                currencyManager.SpendCurrency(selectedUnitCost);
                playerUnitSpawner.SpawnUnit(selectedUnit,mouseWorldPoint);
            }
            isUnitSelected = false;
            objectSpawnPositionGhost.SetActive(false);
        }
    }

    Vector3 GetMouseRayHitPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Physics.Raycast(ray,out hit,100);

        return hit.point;
    }

    public void PrepareUnitForSpawn(GameObject spawnUnitPrefab, float cost)
    {
        selectedUnit = spawnUnitPrefab;
        selectedUnitCost = cost;
        isUnitSelected = true;
        objectSpawnPositionGhost.SetActive(true);
    }

    public void CancelUnitSpawn()
    {
        isUnitSelected = false;
        objectSpawnPositionGhost.SetActive(false);
    }
}
