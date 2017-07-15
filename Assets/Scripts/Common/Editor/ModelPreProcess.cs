using UnityEditor;

public class ModelPreProcess : AssetPostprocessor
{
    private void OnPreprocessModel()
    {
        var model = (ModelImporter)assetImporter;
        if (model != null)
        {
            if (assetPath.Contains("Statics"))
            {
                model.importAnimation = false;
            }
        }
    }
}