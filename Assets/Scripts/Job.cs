using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Job
{
    public string name;
    public List<ValidMove> classSkills = new List<ValidMove>();
    public List<ValidMove> learnedSkills = new List<ValidMove>();

    public Job(string inName)
    {
        name = inName;
    }

}