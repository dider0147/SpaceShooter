using UnityEngine;

public class Background : MonoBehaviour
{
    public Renderer BackgroundRenderer;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        MoveBacckground();
    }
    private void MoveBacckground()
    {
        float BackgroundSpeed = speed * Time.deltaTime;
        BackgroundRenderer.material.mainTextureOffset += new Vector2(0, BackgroundSpeed);
    }
}
