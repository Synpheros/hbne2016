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

        sequence.Add(new SequenceNode("Tú: ...mi recuperación va segun lo esperado...", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Ahora quiero centrarme en mi audición como bailarin solista.", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: A penas me queda un mes.", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Hora de descansar pues mañana me espera un gran día.", new int[] { 0, -1, -1 }));

        SequenceManager.S.current_sequence = sequence;
    }




    // Update is called once per frame
    void Update()
    {

    }

}
