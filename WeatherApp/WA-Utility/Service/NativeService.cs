namespace WA_Utility.Service;

public class NativeService
{
    [DllImport("Loading.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
    private static extern void Loading(StringBuilder str, int strlen);

    public String GetString()
    {
        StringBuilder str = new(15);

        Loading(str, 15);
        return str.ToString();
    }
}
