namespace ExtensionMethods;

public static class IntExtension
{
    // lag en metode som sjekker om en int er et par-tall
    public static bool IsEven(this int number) // => number % 2 == 0; (kan skrive sånn også)
    {
        return number % 2 == 0;
    }
}