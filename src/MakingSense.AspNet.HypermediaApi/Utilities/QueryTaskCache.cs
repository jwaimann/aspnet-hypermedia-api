﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakingSense.AspNet.HypermediaApi.Utilities
{
	public class QueryTasksCache<TKey, TResult>
	{
		private Dictionary<TKey, Task<TResult>> _cachedTasks = new Dictionary<TKey, Task<TResult>>();

		public Task<TResult> Set(TKey key, Task<TResult> task)
			=> _cachedTasks[key] = task;

		public Task<TResult> Set(TKey key, TResult value)
			=> _cachedTasks[key] = Task.FromResult(value);

		public Task<TResult> Get(TKey key, Func<Task<TResult>> fallback)
		{
			Task<TResult> cached;
			if (!_cachedTasks.TryGetValue(key, out cached))
			{
				cached = Set(key, fallback());
			}
			return cached;
		}

		public Task<TResult> Get(TKey key, Func<TKey, Task<TResult>> fallback)
			=> Get(key, () => fallback(key));

		public Task<TResult> Get(TKey key, Func<TResult> fallback)
			=> Get(key, () => Task.FromResult(fallback()));

		public Task<TResult> Get(TKey key, Func<TKey, TResult> fallback)
			=> Get(key, () => Task.FromResult(fallback(key)));

		public void Remove(TKey key)
			=> _cachedTasks.Remove(key);

		public void Clear()
			=> _cachedTasks.Clear();

		public bool Contains(TKey key)
			=> _cachedTasks.ContainsKey(key);
	}

	public class QueryTasksCache<T1, T2, TResult> : QueryTasksCache<Tuple<T1, T2>, TResult>
	{
		public Task<TResult> Set(T1 key1, T2 key2, Task<TResult> task)
			=> Set(new Tuple<T1, T2>(key1, key2), task);

		public Task<TResult> Set(T1 key1, T2 key2, TResult value)
			=> Set(new Tuple<T1, T2>(key1, key2), value);

		public Task<TResult> Get(T1 key1, T2 key2, Func<Task<TResult>> fallback)
			=> Get(new Tuple<T1, T2>(key1, key2), fallback);

		public Task<TResult> Get(T1 key1, T2 key2, Func<T1, T2, Task<TResult>> fallback)
			=> Get(key1, key2, () => fallback(key1, key2));

		public Task<TResult> Get(T1 key1, T2 key2, Func<TResult> fallback)
			=> Get(key1, key2, () => Task.FromResult(fallback()));

		public Task<TResult> Get(T1 key1, T2 key2, Func<T1, T2, TResult> fallback)
			=> Get(key1, key2, () => Task.FromResult(fallback(key1, key2)));

		public void Remove(T1 key1, T2 key2)
			=> Remove(new Tuple<T1, T2>(key1, key2));

		public bool Contains(T1 key1, T2 key2)
			=> Contains(new Tuple<T1, T2>(key1, key2));
	}

	public class QueryTasksCache<T1, T2, T3, TResult> : QueryTasksCache<Tuple<T1, T2, T3>, TResult>
	{
		public Task<TResult> Set(T1 key1, T2 key2, T3 key3, Task<TResult> task)
			=> Set(new Tuple<T1, T2, T3>(key1, key2, key3), task);

		public Task<TResult> Set(T1 key1, T2 key2, T3 key3, TResult value)
			=> Set(new Tuple<T1, T2, T3>(key1, key2, key3), value);

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, Func<Task<TResult>> fallback)
			=> Get(new Tuple<T1, T2, T3>(key1, key2, key3), fallback);

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, Func<T1, T2, T3, Task<TResult>> fallback)
			=> Get(key1, key2, key3, () => fallback(key1, key2, key3));

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, Func<TResult> fallback)
			=> Get(key1, key2, key3, () => Task.FromResult(fallback()));

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, Func<T1, T2, T3, TResult> fallback)
			=> Get(key1, key2, key3, () => Task.FromResult(fallback(key1, key2, key3)));

		public void Remove(T1 key1, T2 key2, T3 key3)
			=> Remove(new Tuple<T1, T2, T3>(key1, key2, key3));

		public bool Contains(T1 key1, T2 key2, T3 key3)
			=> Contains(new Tuple<T1, T2, T3>(key1, key2, key3));
	}

	public class QueryTasksCache<T1, T2, T3, T4, TResult> : QueryTasksCache<Tuple<T1, T2, T3, T4>, TResult>
	{
		public Task<TResult> Set(T1 key1, T2 key2, T3 key3, T4 key4, Task<TResult> task)
			=> Set(new Tuple<T1, T2, T3, T4>(key1, key2, key3, key4), task);

		public Task<TResult> Set(T1 key1, T2 key2, T3 key3, T4 key4, TResult value)
			=> Set(new Tuple<T1, T2, T3, T4>(key1, key2, key3, key4), value);

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, T4 key4, Func<Task<TResult>> fallback)
			=> Get(new Tuple<T1, T2, T3, T4>(key1, key2, key3, key4), fallback);

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, T4 key4, Func<T1, T2, T3, T4, Task<TResult>> fallback)
			=> Get(key1, key2, key3, key4, () => fallback(key1, key2, key3, key4));

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, T4 key4, Func<TResult> fallback)
			=> Get(key1, key2, key3, key4, () => Task.FromResult(fallback()));

		public Task<TResult> Get(T1 key1, T2 key2, T3 key3, T4 key4, Func<T1, T2, T3, T4, TResult> fallback)
			=> Get(key1, key2, key3, key4, () => Task.FromResult(fallback(key1, key2, key3, key4)));

		public void Remove(T1 key1, T2 key2, T3 key3, T4 key4)
			=> Remove(new Tuple<T1, T2, T3, T4>(key1, key2, key3, key4));

		public bool Contains(T1 key1, T2 key2, T3 key3, T4 key4)
			=> Contains(new Tuple<T1, T2, T3, T4>(key1, key2, key3, key4));
	}
}
