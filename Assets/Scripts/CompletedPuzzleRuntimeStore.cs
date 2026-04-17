using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class CompletedPuzzleRuntimeStore
{
    private static readonly Dictionary<string, GameObject> completedPuzzles = new Dictionary<string, GameObject>();
    private static readonly Dictionary<string, string> puzzleAliases = new Dictionary<string, string>
    {
        { "Painting_Fish_Example", "PlacedPiecesParent_Fish" },
        { "Painting_Fish_Example Variant", "PlacedPiecesParent_Fish" },
        { "Painting_FishPiece Variant", "PlacedPiecesParent_Fish" },
        { "PlacedPiecesParent_Fish Variant", "PlacedPiecesParent_Fish" },
        { "PlacedPiecesParent_Painting Variant", "PlacedPiecesParent_Painting" },
        { "PlacedPiecesParent_Bouquet Variant", "PlacedPiecesParent_Bouquet" },
        { "PlacedPiecesParent_Dessert Variant", "PlacedPiecesParent_Dessert" }
    };

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
    private static void Reset()
    {
        completedPuzzles.Clear();
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void StartWatchingSceneLoads()
    {
        SceneManager.sceneLoaded -= ApplyCompletedPuzzles;
        SceneManager.sceneLoaded += ApplyCompletedPuzzles;
        ApplyCompletedPuzzles(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    public static void Register(GameObject completedPuzzle)
    {
        if (completedPuzzle == null)
        {
            return;
        }

        string puzzleName = CleanName(completedPuzzle.name);
        if (string.IsNullOrEmpty(puzzleName))
        {
            return;
        }

        if (completedPuzzles.TryGetValue(puzzleName, out GameObject existingTemplate) && existingTemplate != null)
        {
            Object.Destroy(existingTemplate);
        }

        GameObject template = Object.Instantiate(completedPuzzle);
        template.name = puzzleName;
        template.SetActive(false);
        Object.DontDestroyOnLoad(template);
        completedPuzzles[puzzleName] = template;
    }

    public static void ApplyTo(GameObject target)
    {
        if (target == null)
        {
            return;
        }

        ApplyToTransformAndChildren(target.transform);
    }

    private static void ApplyCompletedPuzzles(Scene scene, LoadSceneMode mode)
    {
        if (completedPuzzles.Count == 0 || !scene.IsValid())
        {
            return;
        }

        GameObject[] roots = scene.GetRootGameObjects();
        foreach (GameObject root in roots)
        {
            ApplyToTransformAndChildren(root.transform);
        }
    }

    private static void ApplyToTransformAndChildren(Transform target)
    {
        string targetName = CleanName(target.name);
        string sourceName = ResolveSourceName(targetName);
        if (completedPuzzles.TryGetValue(sourceName, out GameObject source) && source != null)
        {
            CopyChildrenVisualState(source.transform, target);
        }

        for (int i = 0; i < target.childCount; i++)
        {
            ApplyToTransformAndChildren(target.GetChild(i));
        }
    }

    private static void CopyChildrenVisualState(Transform sourceRoot, Transform targetRoot)
    {
        int childCount = Mathf.Min(sourceRoot.childCount, targetRoot.childCount);
        for (int i = 0; i < childCount; i++)
        {
            CopyTransformAndSprite(sourceRoot.GetChild(i), targetRoot.GetChild(i));
        }
    }

    private static void CopyTransformAndSprite(Transform source, Transform target)
    {
        target.localPosition = source.localPosition;
        target.localRotation = source.localRotation;
        target.localScale = source.localScale;

        SpriteRenderer sourceRenderer = source.GetComponent<SpriteRenderer>();
        SpriteRenderer targetRenderer = target.GetComponent<SpriteRenderer>();
        if (sourceRenderer != null && targetRenderer != null)
        {
            targetRenderer.sprite = sourceRenderer.sprite;
            targetRenderer.color = sourceRenderer.color;
            targetRenderer.flipX = sourceRenderer.flipX;
            targetRenderer.flipY = sourceRenderer.flipY;
            targetRenderer.sortingLayerID = sourceRenderer.sortingLayerID;
            targetRenderer.sortingOrder = sourceRenderer.sortingOrder;
        }

        int childCount = Mathf.Min(source.childCount, target.childCount);
        for (int i = 0; i < childCount; i++)
        {
            CopyTransformAndSprite(source.GetChild(i), target.GetChild(i));
        }
    }

    private static string ResolveSourceName(string targetName)
    {
        if (puzzleAliases.TryGetValue(targetName, out string sourceName))
        {
            return sourceName;
        }

        return targetName;
    }

    private static string CleanName(string objectName)
    {
        if (string.IsNullOrEmpty(objectName))
        {
            return string.Empty;
        }

        return objectName.Replace(" (Clone)", "").Replace("(Clone)", "");
    }
}
