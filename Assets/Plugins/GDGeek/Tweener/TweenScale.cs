

//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2013 Tasharen Entertainment
//----------------------------------------------

using System;
using UnityEngine;

/// <summary>
/// Tween the object's local scale.
/// </summary>

namespace GDGeek{
	public class TweenScale : Tween
	{
		public Vector3 from = Vector3.one;
		public Vector3 to = Vector3.one;
		public bool updateTable = false;

		Transform mTrans;
	//	UITable mTable;

		public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }

		public Vector3 scale { get { return cachedTransform.localScale; } set { cachedTransform.localScale = value; } }

		override protected void OnUpdate (float factor, bool isFinished)
		{	
			cachedTransform.localScale = from * (1f - factor) + to * factor;

			
		}

		/// <summary>
		/// Start the tweening operation.
		/// </summary>

		static public TweenScale Begin (GameObject go, float duration, Vector3 scale)
		{
			TweenScale comp = Tween.Begin<TweenScale>(go, duration);
			comp.from = comp.scale;
			comp.to = scale;

			if (duration <= 0f)
			{
				comp.Sample(1f, true);
				comp.enabled = false;
			}
			return comp;
		}

        public void PlayForward()
        {
            throw new NotImplementedException();
        }

        public void PlayReverse()
        {
            throw new NotImplementedException();
        }
    }
}