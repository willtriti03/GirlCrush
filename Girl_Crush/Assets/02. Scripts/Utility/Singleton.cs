﻿// Abstarct Class 
// implemented in child Class
public abstract class Singleton<T> where T : class, new()
{
	private static T instance;

	public static T GetInstance()
	{
		if (instance == null)
		{
			instance = new T();
		}

		return instance;
	}
}

