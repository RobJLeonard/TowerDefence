using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color CantAffordColor;

    buildManager buildManager;

    [Header("Optional")]
    public GameObject turret;


    private Renderer rend;
    private Color startColor;
    public Vector3 buildOffset;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = buildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + buildOffset;
    }

    private void OnMouseDown()
    {
        // exit if over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;


        if(turret != null)
        {
            //TODO: Display on screen
            Debug.Log("Can't build here");
            return;
        }

        //Build a turret
        buildManager.BuildTurretOn(this);
        //Deselect the turret unless shift is held
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            buildManager.DeselectTurret();
        }
    }

    void OnMouseEnter()
    {
        // exit if over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (buildManager.TurretSelected())
        {
            if(buildManager.CanAfford)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = CantAffordColor;
            }
            
        }
        
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
