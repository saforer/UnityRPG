using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mob {
	string name;
	int Level;

	//Base Stats
	int Strength;
	int Agility;
	int Constitution;
	int Intelligence;
	int Dexterity;
	int Luck;

	//Equipment Stats
	List<Equipment> equipped;
	int Weapon;
	int Mastery;
	int Armor;
	int MArmor;
	int ShieldPenalty;

	//Derived Stats
	int MaxHP;
	int MaxMP;
	int MeleeAtk;
	int RangeAtk;
	int MagicAtk;
	int ArmorDef;
	int StatDef;
	int ArmorMDef;
	int StatMDef;
	int Accuracy;
	int NormalDodge;
	int LuckyDodge;
	int Crit;
	int AtkSpeed;
	int HPRecovery;
	int MPRecovery;
	int CastTime;
	int Slots;


	public Mob(string inName, int inLevel, int inStrength, int inAgility, int inConstitution, int inIntelligence, int inDexterity, int inLuck, List<Equipment> inEquip)
	{
		name = inName;
		Level = inLevel;

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
		LuckyDodge = Mathf.FloorToInt ((Luck * .1f) + 1) * 100;
		Crit = Mathf.FloorToInt(Luck * .03f) * 100;
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

		Debug.Log (
			"Name: " + name + " " +
			"Level: " + Level + " " +
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
			"MaxHP: " + MaxHP + " " + 
			"MaxMP: " + MaxMP + " " + 
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
			"Crit: " + Crit + " " +
			"Attack Speed: " + AtkSpeed + " " +
			"HP Recov: " + HPRecovery + " " +
			"MP Recov: " + MPRecovery + " " +
			"Cast Time: " + CastTime + " " +
			"Slots: " + Slots
			);

			

	}
	
}
