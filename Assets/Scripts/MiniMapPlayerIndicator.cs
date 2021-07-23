using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapPlayerIndicator : MonoBehaviour
{
    private GameObject track, miniMap;
    private SpriteRenderer trackRend;
    private RectTransform miniMapRend;
    private Canvas canvas;
    private Vector2 initPos;
    private float trackToMapScale;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        track = GameObject.Find("Track");
        miniMap = GameObject.Find("MiniMap");
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();

        trackRend = track.GetComponent<SpriteRenderer>();
        miniMapRend = miniMap.GetComponent<RectTransform>();

        determineScale();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * (track.GetComponent<Track>().GetSpeed() / trackToMapScale) * Time.deltaTime);
    }

    public void resetPos()
    {
        transform.position = initPos;
        determineScale();
    }

    void determineScale()
    {
        trackToMapScale = trackRend.bounds.size.y / ((miniMapRend.rect.height - GetComponent<RectTransform>().rect.height) * canvas.scaleFactor);
    }
}
