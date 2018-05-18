using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class NewTargetedCamera : MonoBehaviour {

    public ICamera currentCamera;
    public ICamera freeCamera,targetCamera;
    public Transform follow, look;

    public CinemachineFreeLook cam;
    public Aim aimCont;
    [Header("Rangos")]
    public float startX;
    public float startY;
    //public float cameraSpeedX;
    //public float cameraSpeedY;
    public Transform middlePoint;
    public Transform avatar;

    //[HideInInspector]
    //public float currentX;
    //[HideInInspector]
    //public float currentY;
    public List<Transform> lookTargets = new List<Transform>();


    public void Start()
    {
        freeCamera = new FreeCamera();
        targetCamera = new TargetCamera();
        freeCamera.LoadData(cam, follow, look);


        //cam.m_Follow = follow;
        cam = GetComponent<CinemachineFreeLook>();
        aimCont = FindObjectOfType<Aim>();
        //currentX = startX;
        //currentY = startY;
        Debug.Log(cam.GetRig(0).GetCinemachineComponent<CinemachineComposer>().m_SoftZoneHeight);




        //AddTarget(avatar);
        cam.m_Follow = avatar;
    }
    private void LateUpdate()
    {
        //cam.m_LookAt = lookTarget();
    }

    public ISpell spells;
    public UIController UIContr;
    public string actualSeason;
    public Dictionary<string, ISpell> spellInterface;
    public void Starter() {
        spells = new FallSpell(); //Asi seteo el default
        spellInterface = new Dictionary<string, ISpell>();
        UIContr = FindObjectOfType<UIController>();
        spellInterface.Add("spring", new SpringSpell());
        spellInterface.Add("summer", new SummerSpell());
        spellInterface.Add("fall", new FallSpell());
        spellInterface.Add("winter", new WinterSpell());
    }
    public void Shoot() {
        spells.Shoot();
    }
    public void PowerShoot() {
        spells.PowerShoot();
    }
    public void SetPowerType( string newSeason ) {
        actualSeason = newSeason;
        spells = spellInterface [ actualSeason ];
        UIContr.SetUI(spells.ReturnSeasonID());
    }

}

