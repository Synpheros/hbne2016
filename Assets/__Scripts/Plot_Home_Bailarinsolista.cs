using UnityEngine;
using System.Collections.Generic;

public class Plot_Home_Bailarinsolista : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject director = GameObject.Find("Director");

        List<SequenceNode> sequence = new List<SequenceNode>();

        sequence.Add(new SequenceNode("Tú: Cada día que pasa disfruto más bailando.", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: ¡Ojalá no fuera tan agotador!", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Ahora a descansar, ¡Mañana será un gran día!", new int[] { 0, -1, -1 }));

        SequenceManager.S.current_sequence = sequence;
    }




    // Update is called once per frame
    void Update()
    {

    }

}
