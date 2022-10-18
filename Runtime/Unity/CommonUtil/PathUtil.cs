namespace UGS.Runtime
{
    internal static class PathUtil
    {
        public static string GetPackagePath()
        {
            return "Packages/com.shlifedev.ugs";
        }

        public static string GetPackageRuntimePath()
        {
            return GetPackagePath() + "/Runtime";
        }

        public static string GetPackageEditorPath()
        {

            return GetPackagePath() + "/Editor";
        }

        /// <summary>
        ///     형식을 포함해야함 ex ) abc.txt
        /// </summary>
#if UNITY_EDITOR
        public static string GetPackageResourcesForEditor(string resourcePath)
        {
            return GetPackageRuntimePath() + "/Resources/" + resourcePath;
        }
#endif
    }
}