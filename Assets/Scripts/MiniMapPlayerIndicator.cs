using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMapPlayerIndicator : MonoBehaviour
{
    private GameObject track, miniMap;
    private SpriteRenderer trackRend;
    private RectTransform miniMapRend;
    private float trackToMapScale;

    // Start is called before the first frame update
    void Start()
    {
        track = GameObject.Find("Track");
        miniMap = GameObject.Find("MiniMap");

        trackRend = track.GetComponent<SpriteRenderer>();
        miniMapRend = miniMap.GetComponent<RectTransform>();

        trackToMapScale = trackRend.bounds.size.y / (miniMapRend.rect.height - (GetComponent<RectTransform>().rect.height));

        Debug.Log(miniMapRend.rect.height);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * (track.GetComponent<Track>().GetSpeed() / trackToMapScale) * Time.deltaTime);
    }
}
