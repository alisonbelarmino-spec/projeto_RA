using UnityEngine;
using UnityEngine.InputSystem;

public class CubeInteraction : MonoBehaviour
{
    public float rotationSpeed = 0.3f;
    public float zoomSpeed = 0.01f;
    public float minScale = 0.5f;
    public float maxScale = 5.2f;

    void Update()
    {
        // =========================
        // PC - MOUSE
        // =========================

        if (Mouse.current != null && Mouse.current.leftButton.isPressed)
        {
            Vector2 movimento = Mouse.current.delta.ReadValue();

            transform.Rotate(
                movimento.y * rotationSpeed,
                -movimento.x * rotationSpeed,
                0f,
                Space.World
            );
        }

        if (Mouse.current != null)
        {
            float scroll = Mouse.current.scroll.ReadValue().y;

            if (scroll != 0)
            {
                AlterarEscala(scroll * zoomSpeed);
            }
        }


        // =========================
        // ANDROID - TOQUE
        // =========================

        if (Touchscreen.current == null)
            return;

        var toque1 = Touchscreen.current.touches[0];
        var toque2 = Touchscreen.current.touches[1];

        // 1 dedo = rotação
        if (toque1.press.isPressed && !toque2.press.isPressed)
        {
            Vector2 movimento = toque1.delta.ReadValue();

            transform.Rotate(
                movimento.y * rotationSpeed,
                -movimento.x * rotationSpeed,
                0f,
                Space.World
            );
        }

        // 2 dedos = zoom
        if (toque1.press.isPressed && toque2.press.isPressed)
        {
            Vector2 pos1 = toque1.position.ReadValue();
            Vector2 pos2 = toque2.position.ReadValue();

            Vector2 delta1 = toque1.delta.ReadValue();
            Vector2 delta2 = toque2.delta.ReadValue();

            float distanciaAtual = Vector2.Distance(pos1, pos2);

            float distanciaAnterior = Vector2.Distance(
                pos1 - delta1,
                pos2 - delta2
            );

            float diferenca = distanciaAtual - distanciaAnterior;

            AlterarEscala(diferenca * zoomSpeed);
        }
    }

    void AlterarEscala(float valor)
    {
        float escala = transform.localScale.x;

        escala += valor;

        escala = Mathf.Clamp(
            escala,
            minScale,
            maxScale
        );

        transform.localScale = Vector3.one * escala;
    }
}