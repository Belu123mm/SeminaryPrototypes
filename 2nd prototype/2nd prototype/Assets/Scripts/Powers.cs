using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour {
    public UIController UIContr;
    public string actualSeason;
    public Powerspell powerPrefab;
    public List<vSpell> visual;
    ISpell _spellsInterface;
    vSpell _spellView;
    Dictionary<string, ISpell> behaviourSpells;
    Dictionary<string, vSpell> viewSpells;
    public bool shoot;
    public float timer;
    public float spellduration;
    public int maxMana;
    public int currentMana;
    public int spellValue;
    public int fillingValue;
    public bool filling;
    //Este valor es el que tard en redisparar, que no varia segun el hechizo. Lo que los limita es el mana asi que :3
    public float timeToPow;

    public void Start() {
        UIContr = FindObjectOfType<UIController>();
        behaviourSpells = new Dictionary<string, ISpell>();
        viewSpells = new Dictionary<string, vSpell>();
        behaviourSpells.Add("shield", new ShieldSpell());
        behaviourSpells.Add("rock", new  RockSpell());
        behaviourSpells.Add("wind", new WindSpell());
        behaviourSpells.Add("plant", new PlantSpell());

        for ( int i = 0; i < visual.Count; i++ ) {
            viewSpells.Add(visual [ i ].spellName, visual [ i ]);
        }

        SetPowerType("shield");   //Default

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
        newspell.avatar = this.transform;
        newspell.spellInterface = _spellsInterface;
        newspell.spellView = _spellView;

        currentMana -= newspell.spellView.mana;
        UIContr.SetMana(currentMana);
        filling = false;
    }
    public void PowerShoot() {
        _spellsInterface.PowerShoot();
    }
    public void SetPowerType(string newSeason) {
        actualSeason = newSeason;
        _spellsInterface = behaviourSpells [ actualSeason ];
        _spellView = viewSpells [ actualSeason ];
        UIContr.SetSeason(_spellsInterface.ReturnSeasonID());
    }
}
