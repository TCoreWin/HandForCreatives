using System.IO;

namespace SquareDino.HandForCreatives
{
    public static class HandForCreativesEditorUtility
    {
        private static string m_PackagePath;

        public static string packageRelativePath
        {
            get
            {
                if (string.IsNullOrEmpty(m_PackagePath))
                    m_PackagePath = GetPackageRelativePath();

                return m_PackagePath;
            }
        }

        private static string GetPackageRelativePath()
        {
            // Check for potential UPM package
            string packagePath = Path.GetFullPath("Packages/com.squaredino.handforcreatives");
            if (Directory.Exists(packagePath))
            {
                return "Packages/com.squaredino.handforcreatives";
            }

            packagePath = Path.GetFullPath("Assets/..");
            if (Directory.Exists(packagePath))
            {
                // Search default location for development package
                if (Directory.Exists(packagePath + "/Assets/Packages/com.squaredino.HandForCreatives/Editor Resources"))
                {
                    return "Assets/Packages/com.squaredino.HandForCreatives";
                }
            }

            return null;
        }
    }
}