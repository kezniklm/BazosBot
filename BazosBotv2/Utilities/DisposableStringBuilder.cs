﻿using System.Text;

namespace BazosBotv2.Utilities;

internal class DisposableStringBuilder : IDisposable
{
    private readonly StringBuilder _stringBuilder;

    private DisposableStringBuilder(int capacity) => _stringBuilder = new StringBuilder(capacity);

    private DisposableStringBuilder() => _stringBuilder = new StringBuilder();

    public void Dispose() => _stringBuilder.Clear();

    public void Append(string text) => _stringBuilder.Append(text);

    public void Append(char character) => _stringBuilder.Append(character);

    public void Replace(string oldString, string newString) => _stringBuilder.Replace(oldString, newString);

    public void Replace(char oldChar, char newChar) => _stringBuilder.Replace(oldChar, newChar);

    public new string ToString() => _stringBuilder.ToString();

    public static string StringQuick(string text)
    {
        using var stringBuilder = Get();
        stringBuilder.Append(text);
        return stringBuilder.ToString();
    }

    public static DisposableStringBuilder Get() => new();

    public static DisposableStringBuilder Get(int capacity) => new(capacity);
}