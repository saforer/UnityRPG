using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Mobs
{
	Skeleton,
	Player
}

public enum EquipLocations {
	upperhead,
	middlehead,
	lowerhead,
	chest,
	lefthand,
	righthand,
	legs,
	feet
}

public class MobManager {

	public static Mob GetMob(Mobs wantMob)
	{
		Mob output;
	
		List<Equipment> equipList = BlankEquipmentList();

		switch (wantMob)
		{
		case Mobs.Skeleton:

			output = new Mob("Skeleton",1,9,1,9,1,9,1,equipList);
			break;
		default:
			equipList[3] = EquipmentManager.GetEquipment(Equipments.cotton_shirt);
			equipList[4] = EquipmentManager.GetEquipment(Equipments.cutter);
			output = new Mob("Varnull",1,5,5,5,5,5,5,equipList);
			break;
		}
		return output;
	}

	static List<Equipment> BlankEquipmentList()
	{
		List<Equipment> outputList = new List<Equipment>();
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankhat));     //0
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankface));    //1
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankchin));    //2
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankchest));   //3
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankweapon));  //4
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankshield));  //5
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blanklegs));    //6
		outputList.Add(EquipmentManager.GetEquipment(Equipments.blankfeet));    //7
		return outputList;
	}
}
