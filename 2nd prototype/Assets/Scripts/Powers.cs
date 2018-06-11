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



    public void Start() {
        _spellsInterface = new FallSpell(); //Asi seteo el default
        spellSwitch = new Dictionary<string, ISpell>();
        UIContr = FindObjectOfType<UIController>();
        spellSwitch.Add("spring", new SpringSpell());
        spellSwitch.Add("summer", new SummerSpell());
        spellSwitch.Add("fall", new FallSpell());
        spellSwitch.Add("winter", new WinterSpell());
    }

    /*Este señor tiene que instantiar una bala, y el update tiene que tener un delegate pasandole la action
     * creo
     */


    
    public void Update() {
    }
    
    public void Shoot() {
        Powerspell newspell = Instantiate(powerPrefab);
        newspell.spellInterface = _spellsInterface;
            }
    public void PowerShoot() {
        _spellsInterface.PowerShoot();
    }
    public void SetPowerType(string newSeason) {
        actualSeason = newSeason;
        _spellsInterface = spellSwitch [ actualSeason ];
        UIContr.SetUI(_spellsInterface.ReturnSeasonID());
        
    }
}
