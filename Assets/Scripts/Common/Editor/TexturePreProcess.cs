using UnityEditor;

public class TexturePreProcess : AssetPostprocessor
{
    private void OnPreprocessTexture()
    {
        TextureImporter textureImporter = (TextureImporter)assetImporter;
        if (textureImporter != null)
        {
            if (assetPath.Contains("Sprites"))
            {
                textureImporter.mipmapEnabled = false;
                textureImporter.textureType = TextureImporterType.Sprite;

                if(!assetPath.Contains("UnPacked"))
                {
                    if(string.IsNullOrEmpty(textureImporter.spritePackingTag))
                    {
                        string path = assetPath;
                        path = path.Replace("Assets/Sprites/", "");
                        string[] pathSplit = path.Split('/');
                        textureImporter.spritePackingTag = pathSplit[0];
                    }

                }
                
            }
        }
    }
}