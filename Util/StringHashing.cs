namespace Util;
public class StringHash {
    private int n;
    private string s;
    private Int64 p = 1238473;
    private Int64 mod = (1 << 61) - 1;
    private List<Int64> h, pot;
 
    private Int64 mulmod(Int64 a, Int64 b) {
        Int64 q = (Int64)((double)a*b/mod);
        Int64 r = a * b - mod * q;
        while(r < 0) r += mod;
        while(r >= mod) r -= mod;
        return r;
        // return (a * (__int128)1 * b) % mod;
    }
    private void build_hash() {
        h[0] = s[0];
        pot[0] = 1;
        for(int i = 1; i < n; ++i) {
            this.h[i] = (mulmod(h[i - 1], p) + s[i]);
            h[i] -= (h[i] >= mod ? mod : 0);
            pot[i] = mulmod(pot[i - 1], p);
        }
    }
 
    public Int64 atRange (int l, int r) {
        if(l == 0) return h[r];
        Int64 hash_val = (h[r] - mulmod(h[l - 1], pot[r - l + 1]));
        if(hash_val < 0) hash_val += mod;
        return hash_val;
    }
 
    public Int64 getHash() => atRange(0, n-1);

    public StringHash(string _s) {
        s = _s;
        n = s.Length;
        
        h.Capacity = n;
        pot.Capacity = n;
        build_hash();
    }
};