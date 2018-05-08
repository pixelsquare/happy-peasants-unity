
using System;
using System.Collections.Generic;

namespace PixelSquare.Events
{
	internal sealed class EventBroadcaster
	{
		private static EventBroadcaster s_instance 					= null;
		public static EventBroadcaster Instance
		{
			get
			{
				if(null == s_instance)
				{
					s_instance = new EventBroadcaster();
				}

				return s_instance;
			}
		}

		private Dictionary<string, EventListener> m_eventListener 	= null;

		private EventBroadcaster()
		{
			m_eventListener = new Dictionary<string, EventListener>();
		}

		public void addObserver(string p_eventName, Action p_callback, int p_priority = -1)
		{
			EventListener listener = null;

			if(m_eventListener.ContainsKey(p_eventName))
			{
				listener = m_eventListener[p_eventName];
				listener.addObserver(p_callback, p_priority);
			}
			else
			{
				listener = new EventListener();
				listener.addObserver(p_callback, p_priority);
				m_eventListener.Add(p_eventName, listener);
			}
		}

		public void addObserver(string p_eventName, Action<EventParameters> p_callback, int p_priority = -1)
		{
			EventListener listener = null;
			
			if(m_eventListener.ContainsKey(p_eventName))
			{
				listener = m_eventListener[p_eventName];
				listener.addObserver(p_callback, p_priority);
			}
			else
			{
				listener = new EventListener();
				listener.addObserver(p_callback, p_priority);
				m_eventListener.Add(p_eventName, listener);
			}
		}

		public void removeObserver(string p_eventName, Action p_callback)
		{
			if(m_eventListener.ContainsKey(p_eventName))
			{
				EventListener listener = m_eventListener[p_eventName];
				listener.removeObserver(p_callback);
			}
		}

		public void removeObserver(string p_eventName, Action<EventParameters> p_callback)
		{
			if(m_eventListener.ContainsKey(p_eventName))
			{
				EventListener listener = m_eventListener[p_eventName];
				listener.removeObserver(p_callback);
			}
		}

		public void notifyObservers(string p_eventName)
		{
			if(m_eventListener.ContainsKey(p_eventName))
			{
				EventListener listener = m_eventListener[p_eventName];
				listener.notifyObservers();
			}
		}

		public void notifyObservers(string p_eventName, EventParameters p_eventParams)
		{
			if(m_eventListener.ContainsKey(p_eventName))
			{
				EventListener listener = m_eventListener[p_eventName];
				listener.notifyObservers(p_eventParams);
			}
		}

		public void clearObserver(string p_eventName)
		{
			if(m_eventListener.ContainsKey(p_eventName))
			{
				EventListener listener = m_eventListener[p_eventName];
				listener.clear();
				m_eventListener.Remove(p_eventName);
			}
		}

		public int observerCount(string p_eventName)
		{
			if(m_eventListener.ContainsKey(p_eventName))
			{
				EventListener listener = m_eventListener[p_eventName];
				return listener.count();
			}

			return 0;
		}

		public void clearBroadcaster()
		{			
			foreach(EventListener listener in m_eventListener.Values)
			{
				if(null != listener)
				{
					listener.clear();
				}
			}

			m_eventListener.Clear();
		}

		public int broadcasterCount()
		{
			int count = 0;

			foreach(EventListener listener in m_eventListener.Values)
			{
				if(null != listener)
				{
					count += listener.count();
				}
			}

			return count;
		}
	}
}

