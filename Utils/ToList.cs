namespace Utils;

public static class Utils
{
    public static List<T2> toList<T1, T2>(IQueryable<T1> q, Func<T1, T2> conv)
    {
        var l = new List<T2>();

        foreach (var item in q)
            l.Add(conv(item));
    
        return l;

    }
    public static List<T> toList<T>(IQueryable<T> q)
    {
        var l = new List<T>();

        foreach (var item in q)
            l.Add(item);
    
        return l;

    }


}