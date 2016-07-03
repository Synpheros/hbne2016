using UnityEngine;
using System.Collections.Generic;

public class Plot_Medium : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject director = GameObject.Find("Director");

        List<SequenceNode> sequence = new List<SequenceNode>();

        sequence.Add(new SequenceNode("Tú: Bueno, hoy es nuestra primera actuación... ¿Nerviosa?", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Alicia: Pues, la verdad... Un poquito jeje", new int[] { 1, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: No te preocupes, siempre podemos bailar la macarena.", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Alicia: Jajajaja, ¡No seas tonto!", new int[] { 1, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Me encanta tu sonrisa.", new int[] { 1, -1, 0 }));

        SequenceManager.S.current_sequence = sequence;
    }




    // Update is called once per frame
    void Update()
    {

    }

}
