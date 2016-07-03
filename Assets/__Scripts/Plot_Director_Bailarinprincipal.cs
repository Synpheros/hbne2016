using UnityEngine;
using System.Collections.Generic;

public class Plot_Director_Bailarinprincipal : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject director = GameObject.Find("Director");

        List<SequenceNode> sequence = new List<SequenceNode>();

        sequence.Add(new SequenceNode("Tú: ...estás mejorano a un ritmo increible Alicia.", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Alicia: Gracias, tu siempre eres muy atento.", new int[] { -1, 1, -1 }));
        sequence.Add(new SequenceNode("Alicia: ¿Quieres ser bailarin principal?", new int[] { -1, 1, -1 }));
        sequence.Add(new SequenceNode("Tú: Estoy esperando mi oportunidad.", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Por cierto, esta tarde voy al parque. ¿Te vienes?.", new int[] { 0, -1, -1 }));
        sequence.Add(new SequenceNode("Alicia: ¡De acuerdo!", new int[] { -1, 1, -1 }));
        sequence.Add(new SequenceNode("Antonio: Os aviso que tendremos audiciones para bailarin principal dentro de tres meses.", new int[] { -1, -1, 2 }));
        sequence.Add(new SequenceNode("Tú: ¡Ésta es mi oportunidad! Tendré que prepararme.", new int[] { 0, -1, -1 }));

        SequenceManager.S.current_sequence = sequence;
    }




    // Update is called once per frame
    void Update()
    {

    }

}
