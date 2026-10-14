using UnityEngine;

public class CubeVerticesGenerator : MonoBehaviour
{
    public float tamanho = 0.08f;

    void Start()
    {
        CriarVertices();
    }

    void CriarVertices()
    {
        CriarVertice("Vertice_1", new Vector3(0.5f, 0.5f, 0.5f));
        CriarVertice("Vertice_2", new Vector3(0.5f, 0.5f, -0.5f));
        CriarVertice("Vertice_3", new Vector3(0.5f, -0.5f, 0.5f));
        CriarVertice("Vertice_4", new Vector3(0.5f, -0.5f, -0.5f));

        CriarVertice("Vertice_5", new Vector3(-0.5f, 0.5f, 0.5f));
        CriarVertice("Vertice_6", new Vector3(-0.5f, 0.5f, -0.5f));
        CriarVertice("Vertice_7", new Vector3(-0.5f, -0.5f, 0.5f));
        CriarVertice("Vertice_8", new Vector3(-0.5f, -0.5f, -0.5f));
    }

    void CriarVertice(string nome, Vector3 posicao)
    {
        GameObject vertice = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        vertice.name = nome;

        vertice.transform.SetParent(transform, false);
        vertice.transform.localPosition = posicao;
        vertice.transform.localScale = Vector3.one * tamanho;

        Collider collider = vertice.GetComponent<Collider>();

        if (collider != null)
        {
            Destroy(collider);
        }
    }
}