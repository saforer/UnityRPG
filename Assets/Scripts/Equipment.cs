using UnityEngine;
using System.Collections;


public class Equipment {
	//Normal Weapon Stuff
	public string weaponName;
	public EquipTypes type;
	public int Attack = 0;
	public int Mastery = 0;
	public int Armor = 0;
	public int MArmor = 0;
	public int ShieldPenalty = 0;

	//WeaponStatStuff
	public int StrengthBonus = 0;
	public int AgilityBonus = 0;
	public int ConstitutionBonus = 0;
	public int IntelligenceBonus = 0;
	public int DexterityBonus = 0;
	public int LuckBonus = 0;
	public int MaxHPBonus = 0;
	public int MaxMPBonus = 0;


	public Equipment (string inName, int inAtk, int inMastery, int inArmor, int inMArmor, int inShieldPenalty, int inStrengthBonus,
	                  int inAgilityBonus, int inConstitutionBonus, int inIntelligenceBonus, int inDexterityBonus, int inLuckBonus,
	                  int inMaxHPBonus, int inMaxMPBonus, EquipTypes inEquip)
	{
		type = inEquip;
		weaponName = inName;
		Attack = inAtk;
		Mastery = inMastery;
		Armor = inArmor;
		MArmor = inMArmor;
		ShieldPenalty = inShieldPenalty;
		StrengthBonus = inStrengthBonus;
		AgilityBonus = inAgilityBonus;
		ConstitutionBonus = inConstitutionBonus;
		IntelligenceBonus = inIntelligenceBonus;
		DexterityBonus = inDexterityBonus;
		LuckBonus = inLuckBonus;
		MaxHPBonus = inMaxHPBonus;
		MaxMPBonus = inMaxMPBonus;
	}
}
