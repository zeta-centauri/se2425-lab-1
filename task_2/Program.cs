﻿using System;
using System.Reflection;
using task_2;

class Program
{
    static void Main()
    {
        Type type = typeof(Manager);
        Console.WriteLine("Конструкторы класса Manager:");
        ConstructorInfo[] constructors = type.GetConstructors(
            BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic
        );

        foreach (var constructor in constructors)
        {
            Console.Write("Модификатор доступа: ");
            Console.WriteLine(
                constructor.IsPublic ? "public"
                : constructor.IsPrivate ? "private"
                : "protected"
            );

            Console.Write("Параметры: ");
            ParameterInfo[] parameters = constructor.GetParameters();
            foreach (var param in parameters)
            {
                Console.Write($"{param.ParameterType.Name} {param.Name}, ");
            }
            Console.WriteLine();
        }

        object managerInstance = Activator.CreateInstance(type, "Иван", "АУС")!;

        Console.WriteLine("Методы класса Manager:");
        MethodInfo[] methods = type.GetMethods(
            BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
        );
        foreach (var method in methods)
        {
            Console.WriteLine(method.Name);
        }

        MethodInfo privateMethod = type.GetMethod(
            "Work",
            BindingFlags.NonPublic | BindingFlags.Instance
        )!;
        privateMethod?.Invoke(managerInstance, null);

        Console.WriteLine("\nАтрибуты класса Manager:");
        var classAttributes = type.GetCustomAttributes(false);
        foreach (var attr in classAttributes)
        {
            if (attr is CompanyInfoAttribute companyAttr)
            {
                Console.WriteLine($"CompanyInfo: {companyAttr.CompanyName}, {companyAttr.Country}");
            }
        }

        // Вывод информации об атрибутах свойства Bonus
        Console.WriteLine("\nАтрибуты свойства Bonus:");
        var bonusProperty = type.GetProperty("Bonus");
        var propertyAttributes = bonusProperty!.GetCustomAttributes(false);
        foreach (var attr in propertyAttributes)
        {
            if (attr is SecretInfoAttribute secretAttr)
            {
                Console.WriteLine(
                    $"SecretInfo: {secretAttr.Description}, Security Level: {secretAttr.SecurityLevel}"
                );
            }
        }
    }
}
