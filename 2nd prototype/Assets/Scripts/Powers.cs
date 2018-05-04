using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {
    public ISpell spells;
    public UIController UIContr;
    public string actualSeason;
    public Dictionary<string, ISpell> spellInterface;
    public void Start() {
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
    public void SetPowerType(string newSeason) {
        actualSeason = newSeason;
        spells = spellInterface [ actualSeason ];
        UIContr.SetUI(spells.ReturnSeasonID());
    }
}
