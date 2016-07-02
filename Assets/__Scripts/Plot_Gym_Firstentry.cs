using UnityEngine;
using System.Collections.Generic;

public class Plot_Gym_Firstentry : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject director = GameObject.Find("Director");

        List<SequenceNode> sequence = new List<SequenceNode>();

        sequence.Add(new SequenceNode("Tú: ¡Qoah!", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: ¡Qué gran día de entrenamiento!", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: Gracias a este gimnasio evitaré lesionarme.", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: ...de nuevo...", new int[] { -1, -1, 0 }));

        SequenceManager.S.current_sequence = sequence;
    }




    // Update is called once per frame
    void Update()
    {

    }

}
