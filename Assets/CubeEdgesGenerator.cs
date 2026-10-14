using UnityEngine;

public class CubeEdgesGenerator : MonoBehaviour
{
    public float thickness = 0.03f;
    public Material materialArestas;

    void Start()
    {
        GenerateEdges();
    }

    void GenerateEdges()
    {
        // Arestas horizontais
        CreateEdge("Aresta_X1", new Vector3(0, 0.5f, 0.5f), Quaternion.identity);
        CreateEdge("Aresta_X2", new Vector3(0, 0.5f, -0.5f), Quaternion.identity);
        CreateEdge("Aresta_X3", new Vector3(0, -0.5f, 0.5f), Quaternion.identity);
        CreateEdge("Aresta_X4", new Vector3(0, -0.5f, -0.5f), Quaternion.identity);

        // Arestas verticais
        Quaternion rotacaoY = Quaternion.Euler(0, 0, 90);

        CreateEdge("Aresta_Y1", new Vector3(0.5f, 0, 0.5f), rotacaoY);
        CreateEdge("Aresta_Y2", new Vector3(0.5f, 0, -0.5f), rotacaoY);
        CreateEdge("Aresta_Y3", new Vector3(-0.5f, 0, 0.5f), rotacaoY);
        CreateEdge("Aresta_Y4", new Vector3(-0.5f, 0, -0.5f), rotacaoY);

        // Arestas de profundidade
        Quaternion rotacaoZ = Quaternion.Euler(0, 90, 0);

        CreateEdge("Aresta_Z1", new Vector3(0.5f, 0.5f, 0), rotacaoZ);
        CreateEdge("Aresta_Z2", new Vector3(0.5f, -0.5f, 0), rotacaoZ);
        CreateEdge("Aresta_Z3", new Vector3(-0.5f, 0.5f, 0), rotacaoZ);
        CreateEdge("Aresta_Z4", new Vector3(-0.5f, -0.5f, 0), rotacaoZ);
    }

    void CreateEdge(string nome, Vector3 posicao, Quaternion rotacao)
    {
        GameObject aresta = GameObject.CreatePrimitive(PrimitiveType.Cube);

        aresta.name = nome;

        aresta.transform.SetParent(transform, false);
        aresta.transform.localPosition = posicao;
        aresta.transform.localRotation = rotacao;
        aresta.transform.localScale = new Vector3(1f, thickness, thickness);

        Renderer renderer = aresta.GetComponent<Renderer>();

        if (renderer != null && materialArestas != null)
        {
            renderer.material = materialArestas;
        }

        Collider collider = aresta.GetComponent<Collider>();

        if (collider != null)
        {
            Destroy(collider);
        }
    }
}