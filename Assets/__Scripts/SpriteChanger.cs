using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{

    public List<Sprite> spritesSequence = new List<Sprite>();
    int currentsprite = 0;
    Image image;

    void Start()
    {
        this.image = this.GetComponent<Image>();
        move(moves[0]);
    }

    float lastupdate = 0;
    float lastturn = 0;

    bool left = false;

    Vector2 start_pos, end_pos;
    float progress = 0.0f;
    float player_speed = 1f;
    float speed = 0f;

    public bool turn = true;

    int currentpos = 1;

    void Update()
    {
        lastupdate += Time.deltaTime;
        

        if (lastupdate >= 1.5f)
        {
            lastupdate = 0;
            currentsprite = (currentsprite + 1) % spritesSequence.Count;
            this.image.sprite = spritesSequence[currentsprite];
        }

        if (turn) {
            lastturn += Time.deltaTime;

            if (lastturn >= 0.75f)
            {
                lastturn = 0;

                if (left)
                {
                    left = false;
                    this.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    left = true;
                    this.transform.eulerAngles = new Vector3(0, 180, 0);
                }
            }
        }
        

        if (moving && progress < 1.0f)
        {
            Vector2 newpos = Vector2.Lerp(start_pos, end_pos, progress);
            this.GetComponent<_WavyEffect>().move(newpos);
            progress += Time.deltaTime * speed;
        }
        else if (moves.Count > 0)
        {
            currentpos = (currentpos + 1) % moves.Count;
            move(moves[currentpos]);
        }
        else if (moving && moves.Count <= 0)
        {
            moving = false;
        }
    }

    bool moving = false;
    public List<Vector2> moves = new List<Vector2>();

    void move(Vector2 point)
    {
        moving = true;
        progress = 0.0f;

        this.start_pos = this.transform.localPosition;
        this.end_pos = new Vector2(point.x, point.y);

        speed = player_speed * (50 / Vector2.Distance(start_pos, end_pos));
    }
}
