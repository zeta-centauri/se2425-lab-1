﻿using System.Reflection;
using System.Xml.Serialization;
using task_1;

// a
GetTypeInfo(typeof(Manager));

// b
GenerateHtmlDocumentation(typeof(Manager));

static void GenerateHtmlDocumentation(Type type)
{
    string template = File.ReadAllText("template.html");

    string constructors = GetFormattedList(
        type.GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
    );
    string fields = GetFormattedList(
        type.GetFields(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
        )
    );
    string properties = GetFormattedList(
        type.GetProperties(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
        )
    );
    string methods = GetFormattedList(
        type.GetMethods(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.DeclaredOnly
        )
    );

    string result = template
        .Replace("{{CLASS_NAME}}", type.Name)
        .Replace("{{CONSTRUCTORS}}", constructors)
        .Replace("{{FIELDS}}", fields)
        .Replace("{{PROPERTIES}}", properties)
        .Replace("{{METHODS}}", methods);

    File.WriteAllText($"{type.Name}.html", result);
}

static string GetFormattedList(MemberInfo[] members)
{
    if (members.Length == 0)
        return "<li>Нет данных</li>";

    string list = "";
    foreach (var member in members)
    {
        list += $"<li>{member}</li>\n";
    }
    return list;
}

static void GetTypeInfo(Type type)
{
    Console.WriteLine($"Класс: {type.Name}");

    Console.WriteLine("Конструкторы:");
    foreach (
        var constructor in type.GetConstructors(
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
        )
    )
    {
        Console.WriteLine($"  - {constructor}");
    }

    Console.WriteLine("\nПоля:");
    foreach (
        var field in type.GetFields(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
        )
    )
    {
        Console.WriteLine($"  - {field}");
    }

    Console.WriteLine("\nСвойства:");
    foreach (
        var prop in type.GetProperties(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
        )
    )
    {
        Console.WriteLine($"  - {prop}");
    }

    Console.WriteLine("\nМетоды:");
    foreach (
        var method in type.GetMethods(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
                | BindingFlags.DeclaredOnly
        )
    )
    {
        Console.WriteLine($"  - {method}");
    }
}
