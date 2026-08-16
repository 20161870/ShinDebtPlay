using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System;
using UnityEngine.UIElements;

public class BlocController : MonoBehaviour
{
    public GameObject[] BloquesPF;
    private float spawnTiming =2.25f;
    public Transform spawnPad;
    public List<GameObject> activeBlocks = new();
    private bool SpawnActivo = true;

    private const int FormulaSortingOrder = 100;
    private const int DefaultSortingOrder = 0;
    //private bool GenerarBloque = true;

    private void Start()
    {
        StartCoroutine(SpawnBlocks());
    }

    private IEnumerator SpawnBlocks()
    {
        while (SpawnActivo)
        {
            List<GameObject> posiblesBloques = new();

            bool formulaBlockActivo = activeBlocks.Exists(b => b != null && b.CompareTag("FormulaBlock"));

            switch (PlayerHMInfo.Dificultad)
            {
                case 1:
                    posiblesBloques = GetBlocksByTag(new string[] { "IntBlock" });
                    break;

                case 2:
                    if (formulaBlockActivo)
                    {
                        // Si ya hay un FormulaBlock activo, solo permitimos IntBlock y FloatBlock
                        posiblesBloques = GetBlocksByTag(new string[] { "IntBlock", "FloatBlock" });
                    }
                    else
                    {
                        // Si no hay FormulaBlock activo, lo incluimos
                        posiblesBloques = GetBlocksByTag(new string[] { "IntBlock", "FloatBlock", "FormulaBlock" });
                    }
                    break;

                case 3:
                    if (formulaBlockActivo)
                    {
                        // Evitamos duplicar FormulaBlock mientras exista uno activo
                        posiblesBloques = GetBlocksByTag(new string[] { "IntBlock", "FloatBlock" });
                    }
                    else
                    {
                        // Aumentamos chance de FormulaBlock duplicando su presencia
                        posiblesBloques = GetBlocksByTag(new string[] { "IntBlock", "FloatBlock", "FormulaBlock", "FormulaBlock" });
                    }
                    break;

                default:
                    posiblesBloques = GetBlocksByTag(new string[] { "IntBlock" });
                    break;
            }

            if (posiblesBloques.Count > 0)
            {
                GameObject blockPrefab = posiblesBloques[UnityEngine.Random.Range(0, posiblesBloques.Count)];
                GameObject blockInstance = Instantiate(blockPrefab, GetRandomSpawnPosition(blockPrefab), Quaternion.identity);
                ConfigureSortingForBlock(blockInstance);
                DescendBlock descendBlock = blockInstance.AddComponent<DescendBlock>();
                descendBlock.blocController = this;

                // Ignorar colisiones con bloques ya activos
                Collider2D newCollider = blockInstance.GetComponent<Collider2D>();
                foreach (GameObject existingBlock in activeBlocks)
                {
                    if (existingBlock != null)
                    {
                        Collider2D existingCollider = existingBlock.GetComponent<Collider2D>();
                        if (existingCollider != null && newCollider != null)
                        {
                            Physics2D.IgnoreCollision(newCollider, existingCollider);
                        }
                    }
                }

                AddBlock(blockInstance);
            }
            else
            {
                Debug.LogWarning("No se encontraron bloques válidos para esta dificultad.");
            }

            yield return new WaitForSeconds(spawnTiming);
        }
    }

    private Vector3 GetRandomSpawnPosition(GameObject blockPrefab)
    {
        Renderer padRenderer = spawnPad.GetComponent<Renderer>();
        Renderer blockRenderer = blockPrefab.GetComponent<Renderer>();

        if (padRenderer == null || blockRenderer == null)
        {
            Debug.LogWarning("Faltan Renderer en el spawnPad o en el bloque.");
            return spawnPad.position;
        }

        float padWidth = padRenderer.bounds.size.x;
        float blockWidth = blockRenderer.bounds.size.x;

        float halfPadWidth = padWidth / 2f;
        float halfBlockWidth = blockWidth / 2f;

        float minX = spawnPad.position.x - halfPadWidth + halfBlockWidth;
        float maxX = spawnPad.position.x + halfPadWidth - halfBlockWidth;

        float randomX = UnityEngine.Random.Range(minX, maxX);
        float randomY = spawnPad.position.y;
        float randomZ = spawnPad.position.z;

        return new Vector3(randomX, randomY, randomZ);
    }

    public void RemoveBlock(GameObject block)
    {
        activeBlocks.Remove(block);
    }

     public void AddBlock(GameObject block)
    {
        activeBlocks.Add(block);
    }

    public void StopSpawnBlocks()
    {
        SpawnActivo = false;
    }

    public void ClearActiveBlocks()
    {
        foreach (GameObject block in activeBlocks)
        {
            if (block != null)
            {
                Destroy(block);
            }
        }
        activeBlocks.Clear();
    }

    private List<GameObject> GetBlocksByTag(string[] tags)
    {
        List<GameObject> result = new();
        foreach (string tag in tags)
        {
            foreach (GameObject prefab in BloquesPF)
            {
                if (prefab.CompareTag(tag))
                {
                    result.Add(prefab);
                }
            }
        }
        return result;
    }

    private void ConfigureSortingForBlock(GameObject block)
    {
        bool isFormula = block.CompareTag("FormulaBlock");
        int order = isFormula ? FormulaSortingOrder : DefaultSortingOrder;

        // 1) Sprites (2D)
        var spriteRenderers = block.GetComponentsInChildren<SpriteRenderer>(true);
        foreach (var sr in spriteRenderers)
        {
            sr.sortingOrder = order;
            // Si usas Sorting Layers, también puedes fijar la capa:
            // sr.sortingLayerName = isFormula ? "Front" : "Default";
        }

        // 2) TextMeshPro (3D / WorldSpace): usa MeshRenderer
        var meshRenderers = block.GetComponentsInChildren<MeshRenderer>(true);
        foreach (var mr in meshRenderers)
        {
            mr.sortingOrder = order;
            // mr.sortingLayerName = isFormula ? "Front" : "Default";
        }

        // 3) UI (Canvas / TextMeshProUGUI)
        // Si tus letras están en UI (Canvas), sube el sorting del Canvas.
        var canvases = block.GetComponentsInChildren<Canvas>(true);
        foreach (var canvas in canvases)
        {
            canvas.overrideSorting = true;        // importante para que respete sortingOrder
            canvas.sortingOrder = order;
            // canvas.sortingLayerName = isFormula ? "Front" : "Default";
        }

        // 4) Por si todo vive bajo el mismo Canvas Overlay (orden por jerarquía):
        if (isFormula && block.transform.parent != null)
        {
            // Mueve el FormulaBlock al final de sus hermanos para que se dibuje encima
            block.transform.SetAsLastSibling();
        }
    }





    }



    public class BlockInstance
{
    public GameObject BlockGameObject { get; }
    public bool IsIntBlock { get; }

    public BlockInstance(GameObject blockGameObject, bool isIntBlock)
    {
        BlockGameObject = blockGameObject;
        IsIntBlock = isIntBlock;
    }
}