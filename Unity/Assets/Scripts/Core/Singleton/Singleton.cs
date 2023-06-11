﻿using System;

namespace ET
{
    public interface ISingleton: IDisposable
    {
        void Register();
        void Destroy();
        bool IsDisposed();
    }
    
    public abstract class Singleton<T>: ISingleton where T: Singleton<T>, new()
    {
        private bool isDisposed; 
        [ThreadStatic]
        [StaticField]
        private static T instance;

        public static T Instance
        {
            get
            {
                return instance;
            }
        }

        void ISingleton.Register()
        {
            instance = (T)this;
        }

        void ISingleton.Destroy()
        {
            if (this.isDisposed)
            {
                return;
            }
            this.isDisposed = true;
            
            instance.Dispose();
            instance = null;
        }

        bool ISingleton.IsDisposed()
        {
            return this.isDisposed;
        }

        public virtual void Dispose()
        {
        }
    }
}