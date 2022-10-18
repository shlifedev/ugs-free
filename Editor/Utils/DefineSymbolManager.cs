﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor;

namespace UGS.Editor
{
    public static class DefineSymbolManager
    {
        public static void AddDefineSymbols(params string[] symbols)
        {
            var definesString =
                PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var allDefines = definesString.Split(';').ToList();
            if (allDefines.Count == 0)
                if (!string.IsNullOrEmpty(definesString))
                    allDefines.Add(definesString);

            allDefines.AddRange(symbols.Except(allDefines));

            PlayerSettings.SetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup,
                string.Join(";", allDefines.ToArray()));
        }

        public static bool IsUsed(string symbol)
        {
            var definesString =
                PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var allDefines = definesString.Split(';').ToList();
            var result = allDefines.Any(x => x == symbol);
            return result;
        }

        public static void RemoveDefineSymbol(params string[] symbols)
        {
            var definesString =
                PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
            var allDefines = definesString.Split(';').ToList();
            var newDefines = new List<string>();
            if (allDefines.Count == 0)
                if (!string.IsNullOrEmpty(definesString))
                    allDefines.Add(definesString);

            foreach (var define in allDefines)
            {
                var exist = symbols.ToList().Any(x => x == define);
                if (!exist)
                    newDefines.Add(define);
            }


            PlayerSettings.SetScriptingDefineSymbolsForGroup(
                EditorUserBuildSettings.selectedBuildTargetGroup,
                string.Join(";", newDefines.ToArray()));
        }
    }
}