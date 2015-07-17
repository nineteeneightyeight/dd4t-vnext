﻿//using System;
//using System.Runtime.Caching;
//using System.Timers;
//using DD4T.ContentModel.Contracts.Caching;
//using DD4T.Utils;
//using DD4T.ContentModel.Contracts.Configuration;
//using DD4T.ContentModel.Contracts.Logging;

//namespace DD4T.Utils.Caching
//{
//    /// <summary>
//    /// Implementation of ChangeMonitor (part of System.Runtime.Caching API introduced in .NET 4).
//    /// Monitors the publication date of an item, and drops it from the cache if the item has been republished. The actual logic to look up the publish date is delegated to the class that instantiates this monitor (e.g. the DefaultCacheAgent, which in turn gets the delegate from the factory).
//    /// </summary>
//    public class LastPublishDateChangeMonitor : ChangeMonitor
//    {
//        public const int DefaultCallBackInterval = 60; // configured in seconds

//        private string _key;
//        private object _cachedItem;
//        private DateTime _lastPublished;
//        private Timer _timer;
//        private GetLastPublishDate _getLastPublishDateCallBack;
//        private readonly IDD4TConfiguration _configuration;
//        private readonly ILogger LoggerService;

//        //public LastPublishDateChangeMonitor(IDD4TConfiguration configuration, ILogger logger)
//        //{
//        //    if (configuration == null)
//        //        throw new ArgumentNullException("configuration");

//        //    if (logger == null)
//        //        throw new ArgumentNullException("logger");

//        //    LoggerService = logger;
//        //    _configuration = configuration;
//        //}

//        public LastPublishDateChangeMonitor(IDD4TConfiguration configuration, ILogger logger, string key, object cachedItem, GetLastPublishDate getLastPublishDateCallBack)
//        {
//            LoggerService = logger;
//            _configuration = configuration;
//            LoggerService.Debug(">>LastPublishDateChangeMonitor({0}, {1})", key, cachedItem.ToString());

//            this._key = key;
//            this._cachedItem = cachedItem;
//            _getLastPublishDateCallBack = getLastPublishDateCallBack;

//            bool initializationComplete = false;
//            try
//            {
//                _lastPublished = _getLastPublishDateCallBack(key, cachedItem);

//                _timer = new Timer();

//                int interval = DefaultCallBackInterval;
//                int configuredInterval = _configuration.CacheCallBackInterval;
//                if (configuredInterval != int.MinValue)
//                {
//                    interval = Convert.ToInt32(configuredInterval);
//                }

//                _timer.Interval = interval * 1000; // interval is configured in seconds but must be set in milliseconds!
//                _timer.Elapsed += new ElapsedEventHandler(CheckForChanges);
//                _timer.Enabled = true;
//                _timer.Start();
//                initializationComplete = true;
//            }
//            finally
//            {
//                base.InitializationComplete();
//                if (!initializationComplete)
//                {
//                    Dispose(true);
//                }
//            }
//            base.InitializationComplete();
//        }



//        /// <summary> 
//        ///	Check if underlying item has been republished/unpublished.
//        /// </summary> 
//        /// <returns> 
//        ///	Returns true if the data is republished otherwise false 
//        /// </returns> 
//        public void CheckForChanges(object sender, System.Timers.ElapsedEventArgs args)
//        {
//            DateTime lastPublishedNow = _getLastPublishDateCallBack(_key, _cachedItem);
//            if (_lastPublished.CompareTo(lastPublishedNow) < 0)
//            {

//                // stop the timer, otherwise the check will continue
//                _timer.Stop();
//                _timer.Dispose();

//                // one of the items has been republished in Tridion
//                base.OnChanged(null);
//            }
//        }

//        #region ChangeMonitor members
//        protected override void Dispose(bool disposing)
//        {
//            _cachedItem = null;
//            _key = null;
//            if (_timer != null)
//            {
//                _timer.Stop();
//                _timer = null;
//            }
//        }

//        public override string UniqueId
//        {
//            get { return new Guid().ToString(); }
//        }
//        #endregion
//    }
//}
