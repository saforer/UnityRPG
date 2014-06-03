using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob {
	BattleUI currentUI;

	public string name;
	public int Level;
	public Texture battlePicture;
	public int row = 0;

	//Base Stats
	public int Strength;
	public int Agility;
	public int Constitution;
	public int Intelligence;
	public int Dexterity;
	public int Luck;

	//Equipment Stats
	public List<Equipment> equipped;
	public int Weapon;
	public int Mastery;
	public int Armor;
	public int MArmor;
	public int ShieldPenalty;

	//Derived Stats
	public int MaxHP;
	public int CurrentHP;
	public int MaxMP;
	public int CurrentMP;
	public int MeleeAtk;
	public int RangeAtk;
	public int MagicAtk;
	public int ArmorDef;
	public int StatDef;
	public int ArmorMDef;
	public int StatMDef;
	public int Accuracy;
	public int NormalDodge;
	public int LuckyDodge;
	public int critChance;
	public int AtkSpeed;
	public int HPRecovery;
	public int MPRecovery;
	public int CastTime;
	public int Slots;


	public Mob(string inName, int inLevel, int inStrength, int inAgility, int inConstitution, int inIntelligence, int inDexterity, int inLuck, List<Equipment> inEquip, Texture inPicture, int inRow)
	{
		currentUI = GameObject.FindGameObjectWithTag("GameController").GetComponent<BattleUI>();
		name = inName;
		Level = inLevel;
		battlePicture = inPicture;
		row = inRow;

		//Primary Stats
		Strength = inStrength;
		Agility = inAgility;
		Constitution = inConstitution;
		Intelligence = inIntelligence;
		Dexterity = inDexterity;
		Luck = inLuck;

		//Equipment Stats
		equipped = inEquip;
		Weapon = 0;
		Mastery = 0;
		Armor = 0;
		MArmor = 0;
		ShieldPenalty = 0;
		foreach (Equipment individualEquip in equipped)
		{
			Weapon += individualEquip.Attack;
			Mastery += individualEquip.Mastery;
			Armor += individualEquip.Armor;
			MArmor += individualEquip.MArmor;
			ShieldPenalty += individualEquip.ShieldPenalty;

			Strength += individualEquip.StrengthBonus;
			Agility += individualEquip.AgilityBonus;
			Constitution += individualEquip.ConstitutionBonus;
			Intelligence += individualEquip.IntelligenceBonus;
			Dexterity += individualEquip.DexterityBonus;
			Luck += individualEquip.LuckBonus;
		}

		//Secondary Stats
		MaxHP = Mathf.FloorToInt(((Level*5)+35)*(Mathf.Pow(1.01f,(float) Constitution)));
		MaxMP = Mathf.FloorToInt(((Level*5)+10)*(Mathf.Pow(1.01f,(float) Intelligence)));
		MeleeAtk = Mathf.FloorToInt ((Level/4)+(Luck/3)+((Strength+Dexterity)/5)) + Weapon + (Mathf.FloorToInt (Strength/200)*(Weapon)) + Mastery;
		RangeAtk = Mathf.FloorToInt ((Level/4)+(Luck/3)+((Dexterity+Dexterity)/5)) + Weapon + (Mathf.FloorToInt (Dexterity/200)*(Weapon)) + Mastery;
		MagicAtk = Mathf.FloorToInt ((Level/4)+(Luck/3)+(Intelligence*2) + Weapon + (Mathf.FloorToInt (Dexterity/200)*(Weapon)) + Mastery);
		ArmorDef = Armor;
		StatDef = Mathf.FloorToInt ( Mathf.Max (Constitution*.03f,((Constitution*Constitution)/150)-1) + Constitution/2 );
		ArmorMDef = MArmor;
		StatMDef = Mathf.FloorToInt ( (Intelligence + Constitution)/5 + Dexterity/5 + Level/4 );
		Accuracy = 175 + Level + Dexterity + Mathf.FloorToInt (Luck/3);
		NormalDodge = 100 + Level + Agility + Mathf.FloorToInt (Luck/5);
		LuckyDodge = Mathf.FloorToInt (((Luck * .1f) + 1));
		critChance = Mathf.FloorToInt(Luck * .03f) * 100;
		AtkSpeed = Mathf.FloorToInt ( (Mathf.Sqrt( Agility + (Dexterity/3) ) * 100) - ShieldPenalty );
		HPRecovery = Mathf.Max (1,Mathf.FloorToInt( MaxHP/200 ));
		MPRecovery = Mathf.Max (1,Mathf.FloorToInt( MaxMP/200 ));
		CastTime = 100 - Mathf.FloorToInt(((Dexterity * 2) + Intelligence)/5.3f);
		Slots = Mathf.FloorToInt( (2000+(30*Strength))/200 );

		foreach (Equipment individualEquip in equipped)
		{
			MaxHP += individualEquip.MaxHPBonus;
			MaxMP += individualEquip.MaxMPBonus;
		}


		CurrentHP = MaxHP;
		CurrentMP = MaxMP;
	}

	public void Attack(Mob target)
	{
		int hitChance = Accuracy - target.NormalDodge;

		bool Dodge = !isRandomInInt(hitChance);

		bool LuckyDodge = isRandomInInt(target.LuckyDodge);

		bool CritConfirm = isRandomInInt(critChance);

		bool Hit = false;

		if (CritConfirm)
			Hit = true;

		if (!Dodge && !LuckyDodge)
			Hit = true;


		if (Hit)
		{
			currentUI.recentDialogue = "Hit";
			DoDamage(CritConfirm, target);
		}
		else
		{
		if (Dodge)
				currentUI.recentDialogue = "Dodge";
		
		if (LuckyDodge)
				currentUI.recentDialogue = "Lucky Dodge";
		}
	}

	void DoDamage(bool ICrit, Mob target)
	{
		if (ICrit)
			currentUI.recentDialogue += " Crit";
		int Damage = Mathf.FloorToInt( (Random.Range(-3,3)*.1f) * MeleeAtk + MeleeAtk * ((float)(4000+target.ArmorDef+target.StatDef)/(float)( 4000+((target.ArmorDef+target.StatDef)*10) ))  );
		float CritMultiplier = .4f;
		if (ICrit)
			Damage += Mathf.FloorToInt( Damage * CritMultiplier);

		currentUI.recentDialogue += " Damage done: " + Damage;

		target.CurrentHP = target.CurrentHP - Damage;
		if (target.CurrentHP <= 0)
		{
			target.CurrentHP=0;
			currentUI.recentDialogue += " Target is Dead";
		}
		else
		{
			currentUI.recentDialogue += " HP Left: " + target.CurrentHP;
		}
	}

	bool isRandomInInt(int inChance)
	{
		int i = Random.Range (0,101);
		if (inChance > i)
			return true;

		return false;
	}

	public override string ToString()
	{
		return 
		"Name: " + name + " " +
		"Level: " + Level + " " +
		"MaxHP: " + MaxHP + " " + 
		"CurrentHP: " + CurrentHP + " " +
		"MaxMP: " + MaxMP + " " + 
		"CurrentMP: " + CurrentMP + " " +
		"Strength: " + Strength + " " +
		"Agility: " + Agility + " " +
		"Constitution: " + Constitution + " " +
		"Intelligence: " + Intelligence + " " +
		"Dexterity: " + Dexterity + " " +
		"Luck: " + Luck + " " +
		"Weapon Damage: " + Weapon + " " +
		"Mastery: " + Mastery + " " +
		"Armor: " + Armor + " " +
		"Magic Armor: " + MArmor + " " +
		"Shield Penalty: " + ShieldPenalty + " " +
		"MeleeATK: " + MeleeAtk + " " + 
		"RangeATK: " + RangeAtk + " " + 
		"MagicATK: " + MagicAtk + " " + 
		"DEF from armor: " + ArmorDef + " " + 
		"DEF from stat: " + StatDef + " " +
		"MDEF from armor: " + ArmorMDef + " " +
		"MDEF from stat: " + StatMDef + " " +
		"Accuracy: " + Accuracy + " " +
		"Normal Dodge: " + NormalDodge + " " +
		"Lucky Dodge: " + LuckyDodge + " " +
		"Crit: " + critChance + " " +
		"Attack Speed: " + AtkSpeed + " " +
		"HP Recov: " + HPRecovery + " " +
		"MP Recov: " + MPRecovery + " " +
		"Cast Time: " + CastTime + " " +
		"Slots: " + Slots;
	}
}
