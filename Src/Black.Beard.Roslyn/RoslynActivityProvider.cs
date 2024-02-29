using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Bb
{

    /// <summary>
    /// Managing initialize activity source. this class implement unit of work pattern
    /// </summary>
    public static class RoslynActivityProvider
    {

        /// <summary>
        /// Initialize the activity source
        /// </summary>
        /// <param name="version"></param>
        public static void Initialize(Version version = null)
        {
            var assembly = Assembly.GetCallingAssembly().GetName();
            RoslynActivityProvider._source = new ActivitySource(assembly.Name, assembly.Version.ToString());
        }

        /// <summary>
        /// Initialize the activity source
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        public static void Initialize(string name, Version version = null)
        {
            RoslynActivityProvider._source = new ActivitySource(name, version != null ? version.ToString() : null);
        }


        /// <summary>
        /// Gets the <see cref="ActivitySource"/> object for the current execution context.
        /// </summary>
        public static ActivitySource Source
        {
            get
            {
                if (_source == null)
                    Initialize();
                return _source;
            }
        }


        /// <summary>
        /// Adds a tag to the current Activity object for the current execution context.
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set(this Activity self, Action<Activity> action)
        {
            if (self != null && action != null)
                action(self);
        }

        /// <summary>
        /// Gets the current Activity object for the current execution context.
        /// </summary>
        /// <param name="action"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Set(Action<Activity> action)
        {

            if (_currentActivity != null && action != null)
                action(_currentActivity);

        }


        /// <summary>
        /// Gets the current Activity object for the current execution context.
        /// </summary>
        public static Activity? CurrentActivity => _currentActivity;

        #region CreateActivity

        /// <summary>
        /// Check if there is any listeners for this ActivitySource.
        /// This property can be helpful to tell if there is no listener, then no need to create Activity object
        /// and avoid creating the objects needed to create Activity (e.g. ActivityContext)
        /// Example of that is http scenario which can avoid reading the context data from the wire.
        /// </summary>
        public static bool HasListeners()
        {
            return Source.HasListeners();
        }

        /// <summary>
        /// Creates a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any event listener.</returns>
        /// <remarks>
        /// If the Activity object is created, it will not start automatically. Callers need to call <see cref="Activity.Start()"/> to start it.
        /// </remarks>
        public static Activity? CreateActivity(string name, ActivityKind kind)
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.CreateActivity(name, kind);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;
        }

        /// <summary>
        /// Creates a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// If the Activity object is created, it will not automatically start. Callers will need to call <see cref="Activity.Start()"/> to start it.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="idFormat">The default Id format to use.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <remarks>
        /// If the Activity object is created, it will not start automatically. Callers need to call <see cref="Activity.Start()"/> to start it.
        /// </remarks>
        public static Activity? CreateActivity(string name, ActivityKind kind, ActivityContext parentContext, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.CreateActivity(name, kind, parentContext, tags, links, idFormat);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;

        }

        /// <summary>
        /// Creates a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentId">The parent Id to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="idFormat">The default Id format to use.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        /// <remarks>
        /// If the Activity object is created, it will not start automatically. Callers need to call <see cref="Activity.Start()"/> to start it.
        /// </remarks>
        public static Activity? CreateActivity(string name, ActivityKind kind, string parentId, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, ActivityIdFormat idFormat = ActivityIdFormat.Unknown)
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.CreateActivity(name, kind, parentId, tags, links, idFormat);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;

        }
        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any event listener.</returns>
        public static Activity? StartActivity([CallerMemberName] string name = "", ActivityKind kind = ActivityKind.Internal)
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.StartActivity(name, kind);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity events, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="startTime">The optional start timestamp to set on the created Activity object.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        public static Activity? StartActivity(string name, ActivityKind kind, ActivityContext parentContext, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, DateTimeOffset startTime = default)
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.StartActivity(name, kind, parentContext, tags, links, startTime);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity events, returns null otherwise.
        /// </summary>
        /// <param name="name">The operation name of the Activity.</param>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentId">The parent Id to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="startTime">The optional start timestamp to set on the created Activity object.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        public static Activity? StartActivity(string name, ActivityKind kind, string parentId, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, DateTimeOffset startTime = default)
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.StartActivity(name, kind, parentId, tags, links, startTime);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;

        }

        /// <summary>
        /// Creates and starts a new <see cref="Activity"/> object if there is any listener to the Activity events, returns null otherwise.
        /// </summary>
        /// <param name="kind">The <see cref="ActivityKind"/></param>
        /// <param name="parentContext">The parent <see cref="ActivityContext"/> object to initialize the created Activity object with.</param>
        /// <param name="tags">The optional tags list to initialize the created Activity object with.</param>
        /// <param name="links">The optional <see cref="ActivityLink"/> list to initialize the created Activity object with.</param>
        /// <param name="startTime">The optional start timestamp to set on the created Activity object.</param>
        /// <param name="name">The operation name of the Activity.</param>
        /// <returns>The created <see cref="Activity"/> object or null if there is no any listener.</returns>
        public static Activity? StartActivity(ActivityKind kind, ActivityContext parentContext = default, IEnumerable<KeyValuePair<string, object?>>? tags = null, IEnumerable<ActivityLink>? links = null, DateTimeOffset startTime = default, [CallerMemberName] string name = "")
        {

            if (RoslynActivityProvider._currentActivity != null)
                throw new InvalidOperationException("An activity is already in progress.");

            var result = Source.StartActivity(kind, parentContext, tags, links, startTime, name);
            if (result != null)
                RoslynActivityProvider._currentActivity = result;

            return result;

        }


        #endregion


        private static ActivitySource _source;

        [ThreadStatic]
        private static Activity _currentActivity;

    }

}
