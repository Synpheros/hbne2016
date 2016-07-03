using UnityEngine;
using System.Collections.Generic;

public class Plot_Map_Firstentry : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject director = GameObject.Find("Director");

        List<SequenceNode> sequence = new List<SequenceNode>();

        sequence.Add(new SequenceNode("Tú: Que facilidad tengo para perderme...", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: ¿Dónde estará la Escuela de Danza?", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: Quizá esa chica lo sepa...", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: Hola, voy a la Escuela de Danza... ¿No sabrás dónde está?", new int[] { 1, -1, 0 }));
        sequence.Add(new SequenceNode("Chica: Ahora mismo voy allí para practicar.", new int[] { 1, -1, -1 }));
        sequence.Add(new SequenceNode("Tú: Jajajaja, ¡Qué casualidad! Te acompaño.", new int[] { -1, -1, 0 }));
        sequence.Add(new SequenceNode("Tú: ¿Cómo te llamas?", new int[] { 1, 0, -1 }));
        sequence.Add(new SequenceNode("Alicia: Alicia.", new int[] { 1, 0, -1 }));
        sequence.Add(new SequenceNode("Tú: ¡Encantado Alicia!", new int[] { 1, 0, -1 }));

        SequenceManager.S.current_sequence = sequence;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
