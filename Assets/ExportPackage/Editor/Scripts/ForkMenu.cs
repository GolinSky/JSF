using UnityEditor;

namespace CodeFramework.ExportPackage.Editor.Scripts
{
    public class ForkMenu : EditorWindow
    {
        [MenuItem("CustomTools/Git/Fork")]
        public static void OpenFork()
        {
            System.Diagnostics.Process.Start( @"C:\Users\Lex\AppData\Local\Fork\Fork.exe" );
        }
    }
}
