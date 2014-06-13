using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Job {
    public string name;
    public List<ValidMove> classMove;
    public List<ValidMove> learnedMove;


    public Job(string inName, List<ValidMove> inClassMoves, List<ValidMove> inDefaultMoves)
    {
        name = inName;
        classMove = inClassMoves;
        learnedMove = inDefaultMoves;
    }
}
