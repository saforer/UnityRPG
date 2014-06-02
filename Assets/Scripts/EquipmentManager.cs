using UnityEngine;
using System.Collections;

public enum EquipTypes {
	blank,
	upperhead,
	middlehead,
	lowerhead,
	chest,
	weapon,
	shield,
	legs,
	feet
}

public enum Equipments
{
	cotton_shirt,
	cutter,
	knife,

	//blank stuff
	blankhat,
	blankface,
	blankchin,
	blankchest,
	blankweapon,
	blankshield,
	blanklegs,
	blankfeet
}

public class EquipmentManager  {

	public static Equipment GetEquipment(Equipments inEquip)
	{
		string name = "Broken!";
		EquipTypes type = EquipTypes.blank;
		int Attack = 0;
		int Mastery = 0;
		int Armor = 0;
		int MArmor = 0;
		int ShieldPenalty = 0;
		int StrengthBonus = 0;
		int AgilityBonus = 0;
		int ConstitutionBonus = 0;
		int IntelligenceBonus = 0;
		int DexterityBonus = 0;
		int LuckBonus = 0;
		int MaxHPBonus = 0;
		int MaxMPBonus = 0;

		switch (inEquip)
		{
		case Equipments.cotton_shirt:
			name = "Cotton Shirt";
			type = EquipTypes.chest;
			Armor = 1;
			break;
		case Equipments.cutter:
			name = "Cutter";
			type = EquipTypes.weapon;
			Attack = 30;
			break;
		case Equipments.knife:
			name = "Knife";
			type = EquipTypes.weapon;
			Attack = 12;
			break;

			//Blank Equipment
		case Equipments.blankchest:
			type = EquipTypes.chest;
			break;
		case Equipments.blankchin:
			type = EquipTypes.lowerhead;
			break;
		case Equipments.blankface:
			type = EquipTypes.middlehead;
			break;
		case Equipments.blankfeet:
			type = EquipTypes.feet;
			break;
		case Equipments.blankhat:
			type = EquipTypes.upperhead;
			break;
		case Equipments.blanklegs:
			type = EquipTypes.legs;
			break;
		case Equipments.blankshield:
			type = EquipTypes.shield;
			break;
		case Equipments.blankweapon:
			type = EquipTypes.weapon;
			break;
		}
		Equipment output = new Equipment(name,Attack,Mastery,Armor,MArmor,ShieldPenalty,StrengthBonus,AgilityBonus,ConstitutionBonus,IntelligenceBonus,DexterityBonus,LuckBonus,MaxHPBonus,MaxMPBonus,type);
		return output;
	}
}
