using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job {
    public string name;
    public List<ValidMoves> classSkills = new List<ValidMoves>();
    public List<ValidMoves> learnedSkills = new List<ValidMoves>();
    public Job (string inName)
    {
        name = inName;
    }

}
