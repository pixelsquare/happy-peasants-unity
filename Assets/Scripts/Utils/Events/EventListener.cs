
using System;
using System.Collections.Generic;

namespace PixelSquare.Events
{
	internal sealed class EventListener
	{
		private List<Action<EventParameters>> m_paramEvents		= null;
		private List<Action> m_noParamEvents					= null;

		internal EventListener()
		{
			m_paramEvents 		= new List<Action<EventParameters>>();
			m_noParamEvents 	= new List<Action>();
		}

		public void addObserver(Action p_callback, int p_priority = -1)
		{
			if(p_priority >= 0)
			{
				int idx = p_priority;
				m_noParamEvents.Insert(idx, p_callback);

				return;
			}

			m_noParamEvents.Add(p_callback);
		}

		public void addObserver(Action<EventParameters> p_callback, int p_priority = -1)
		{
			if(p_priority >= 0)
			{
				int idx = p_priority;
				m_paramEvents.Insert(idx, p_callback);

				return;
			}

			m_paramEvents.Add(p_callback);
		}

		public void removeObserver(Action p_callback)
		{
			m_noParamEvents.Remove(p_callback);
		}

		public void removeObserver(Action<EventParameters> p_callback)
		{
			m_paramEvents.Remove(p_callback);
		}

		public void notifyObservers()
		{
			for(int i = 0; i < m_noParamEvents.Count; i++)
			{
				Action callback = m_noParamEvents[i];

				if(null != callback)
				{
					callback();
				}
			}
		}

		public void notifyObservers(EventParameters p_eventParams)
		{
			for(int i = 0; i < m_paramEvents.Count; i++)
			{
				Action<EventParameters> callback = m_paramEvents[i];

				if(null != callback)
				{
					callback(p_eventParams);
				}
			}
		}

		public void clear()
		{
			m_paramEvents.Clear();
			m_noParamEvents.Clear();
		}

		public int count()
		{
			return m_paramEvents.Count + m_noParamEvents.Count;
		}
	}
}
