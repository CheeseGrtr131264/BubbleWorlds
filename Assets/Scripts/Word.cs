using System;

public struct Word : IEquatable<Word>
{
    public string WordString;
    public Word(string wordString)
    {
        WordString = wordString.ToLower();
    }

    public bool Equals(Word other)
    {
        return WordString.ToLower() == other.WordString.ToLower();
    }

    public override bool Equals(object obj)
    {
        return obj is Word other && Equals(other);
    }

    public override int GetHashCode()
    {
        return (WordString != null ? WordString.GetHashCode() : 0);
    }
    public static bool operator ==(Word lhs, Word rhs)
    {
        // if (lhs is null)
        // {
        //     if (rhs is null)
        //     {
        //         return true;
        //     }
        //
        //     // Only the left side is null.
        //     return false;
        // }
        // Equals handles case of null on right side.
        return lhs.Equals(rhs);
    }
    
    public static bool operator !=(Word lhs, Word rhs)
    {
        return !lhs.Equals(rhs);
    }
}
