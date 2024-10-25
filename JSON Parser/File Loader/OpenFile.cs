using System.Runtime.InteropServices;

namespace JSON_Parser.File_Loader
{
    public class OpenFile
    {
        // From https://www.pinvoke.net/default.aspx/comdlg32/GetOpenFileName.html
        [DllImport("comdlg32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool GetOpenFileName(ref OpenFileNameStruct ofn);

        public static string? Open()
        {
            OpenFileNameStruct ofn = new();
            ofn.lStructSize = Marshal.SizeOf(ofn);
            ofn.lpstrFilter = "JSON Files\0*.json\0All Files\0*.*\0";
            ofn.lpstrFile = new string(new char[256]);
            ofn.nMaxFile = ofn.lpstrFile.Length;
            ofn.lpstrFileTitle = new string(new char[64]);
            ofn.nMaxFileTitle = ofn.lpstrFileTitle.Length;
            ofn.lpstrTitle = "Open File Dialog...";

            if (GetOpenFileName(ref ofn))
            {
                return ofn.lpstrFile;
            }

            return null;
        }
    }
}
