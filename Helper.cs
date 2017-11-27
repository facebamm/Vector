using System;
using System.Linq;

public static class Helper {
    public static double Sqr<T>(this T d) {
        if (double.TryParse(d.ToString(), out double p)) {
            return Math.Pow(p, 2);
        }
        throw new Exception("Convert Error");
    }
}

public static class ConvertHelper {
    public static double ToDouble<T>(this T value) {
        if (double.TryParse(value.ToString(), out double p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static int ToInt<T>(this T value) {
        if (int.TryParse(value.ToString(), out int p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static uint ToUInt<T>(this T value) {
        if (uint.TryParse(value.ToString(), out uint p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static float ToFloat<T>(this T value) {
        if (float.TryParse(value.ToString(), out float p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static Single ToSingle<T>(this T value) {
        if (Single.TryParse(value.ToString(), out Single p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static decimal Todecimal<T>(this T value) {
        if (decimal.TryParse(value.ToString(), out decimal p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static byte ToByte<T>(this T value) {
        if (byte.TryParse(value.ToString(), out byte p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
    public static SByte ToSByte<T>(this T value) {
        if (SByte.TryParse(value.ToString(), out SByte p)) {
            return p;
        }
        throw new Exception("Convert Error");
    }
}
