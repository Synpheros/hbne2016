using UnityEngine;
using System.Collections.Generic;

public class Plot_FinalScene : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject director = GameObject.Find("Director");

        List<SequenceNode> sequence = new List<SequenceNode>();

        sequence.Add(new SequenceNode("Tú: Madre mía... Al fín ha llegado el gran día.", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: Hoy es mi actuación como bailarín principal.", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Alicia: Me alegro tanto, te lo has ganado con tu esfuerzo.", new int[] { 1, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: ¿Tú crees?", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Alicia: Por supuesto. Eres el mejor bailarín que conozco.", new int[] { 1, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Sabes...", new int[] { 1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: Nada de esto habría sido posible...", new int[] { 1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: Sin ti.", new int[] { 1, -1, 0 }));
        sequence.Add(new SequenceNode("...", new int[] { 1, -1, 0 }));
        sequence.Add(new SequenceNode("...", new int[] { -1, 1, 0 }));
        sequence.Add(new SequenceNode("...", new int[] { -1, -1, 3 }));

        SequenceManager.S.current_sequence = sequence;
    }




    // Update is called once per frame
    void Update()
    {

    }

}
