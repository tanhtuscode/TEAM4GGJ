using UnityEditor;
using UnityEngine;
using Game._01_Scripts.GameMechanic.Deck.Card;

public class CardSOGenerator : EditorWindow
{
    [SerializeField] private Sprite[] cardSprites; // Drag sprites here
    private string outputFolder = "Assets/Cards"; // Default folder to save the CardSO assets

    [MenuItem("Tools/Card SO Generator")]
    public static void ShowWindow()
    {
        GetWindow<CardSOGenerator>("Card SO Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("Card SO Generator", EditorStyles.boldLabel);

        // Input fields for sprites
        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty spritesProperty = serializedObject.FindProperty("cardSprites");
        EditorGUILayout.PropertyField(spritesProperty, new GUIContent("Card Sprites"), true);

        // Output folder field with a button to browse
        GUILayout.BeginHorizontal();
        EditorGUILayout.TextField("Output Folder", outputFolder);
        if (GUILayout.Button("Select Folder", GUILayout.Width(100)))
        {
            string selectedPath = EditorUtility.OpenFolderPanel("Select Output Folder", "Assets", "");
            if (!string.IsNullOrEmpty(selectedPath))
            {
                // Convert absolute path to relative path
                outputFolder = FileUtil.GetProjectRelativePath(selectedPath);
                if (string.IsNullOrEmpty(outputFolder))
                {
                    Debug.LogError("Selected path must be within the project!");
                    outputFolder = "Assets/Cards"; // Reset to default if invalid
                }
            }
        }
        GUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();

        // Generate button
        if (GUILayout.Button("Generate CardSOs"))
        {
            GenerateCardSOs();
        }
    }

    private void GenerateCardSOs()
    {
        if (cardSprites == null || cardSprites.Length == 0)
        {
            Debug.LogError("No sprites provided!");
            return;
        }

        if (!AssetDatabase.IsValidFolder(outputFolder))
        {
            Debug.LogError($"Invalid output folder: {outputFolder}");
            return;
        }

        foreach (var sprite in cardSprites)
        {
            CreateCardSO(sprite);
        }

        Debug.Log($"Generated {cardSprites.Length} CardSO assets in {outputFolder}");
    }

    private void CreateCardSO(Sprite sprite)
    {
        string assetName = sprite.name;
        string assetPath = $"{outputFolder}/{assetName}.asset";

        // Create a new CardSO instance
        CardSO cardSO = ScriptableObject.CreateInstance<CardSO>();
        cardSO.Name = assetName;
        cardSO.Sprite = sprite;
        cardSO.CardType = CardType.Normal; // Default to Normal
        cardSO.Value = 0; // Default value
        cardSO.IsUsed = false;

        // Save the CardSO asset
        AssetDatabase.CreateAsset(cardSO, assetPath);
        AssetDatabase.SaveAssets();
    }
}
