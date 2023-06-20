using UnityEditor;

namespace CodeFramework.Editor.Scripts
{
    public class ForkMenu : EditorWindow
    {
        [MenuItem("Tools/Git/Fork")]
        public static void OpenFork()
        {
            System.Diagnostics.Process.Start( @"C:\Users\Lex\AppData\Local\Fork\Fork.exe" );
        }
    }
}
