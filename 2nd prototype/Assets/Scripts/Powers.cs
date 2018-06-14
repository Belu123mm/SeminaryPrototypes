using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {
    public UIController UIContr;
    public string actualSeason;
    public Dictionary<string, ISpell> spellSwitch;
    public bool shoot;
    public float timer;
    public float spellduration;
    public Powerspell powerPrefab;
    ISpell _spellsInterface;
    public int maxMana;
    public int currentMana;
    public int spellValue;
    public int fillingValue;
    public bool filling;
    public float timeToPow;

    public void Start() {
        _spellsInterface = new FallSpell(); //Asi seteo el default
        spellSwitch = new Dictionary<string, ISpell>();
        UIContr = FindObjectOfType<UIController>();
        spellSwitch.Add("spring", new SpringSpell());
        spellSwitch.Add("summer", new SummerSpell());
        spellSwitch.Add("fall", new FallSpell());
        spellSwitch.Add("winter", new WinterSpell());
        UIContr.SetMaxMana(maxMana);
        currentMana = maxMana;
        UIContr.SetMana(currentMana);
    }
    
    public void Update() {
        if ( currentMana < maxMana )
            filling = true;
        else
            filling = false;

        if ( filling ) {
            currentMana += fillingValue;
            UIContr.SetMana(currentMana);
        }
        timer += Time.deltaTime;
        if ( timeToPow < timer ) {
            shoot = false;
        }
        

    }



    public void Shoot() {
        Powerspell newspell = Instantiate(powerPrefab);
        newspell.spellInterface = _spellsInterface;
        currentMana -= spellValue;
        UIContr.SetMana(currentMana);
        filling = false;
            }
    public void PowerShoot() {
        _spellsInterface.PowerShoot();
    }
    public void SetPowerType(string newSeason) {
        actualSeason = newSeason;
        _spellsInterface = spellSwitch [ actualSeason ];
        UIContr.SetSeason(_spellsInterface.ReturnSeasonID());
        
    }
}
