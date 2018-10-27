namespace Todo.Common.Helpers
{
    public static class Preferences
    {
        public static readonly string AppName = "NSU GO";

        public static readonly string AnalyticsTrackingId = "UA-104891454-1";

        public static readonly string AppId = "edu.nova.nsugo";

        public static readonly string DatabaseFileName = "localStorageDB.db3";

        public static readonly string[] SpreadsheetExtensions = 
        { 
            "xls","xlsx","xlsm","xlsb","csv","xls2003","ods"
        };

        public static readonly string[] WordDocumentExtentions =
        {
            "doc","docm","docx","dot","dotm","dotx","rtf","txt","odt","ott"
        };

        public static readonly string[] PresentationDocumentExtensions =
        {
            "ppt","pps","pptx","ppsx","odp"
        };

        public static readonly string[] ImageDocumentExtensions =
        {
            "tiff","tif","jpeg","jpg","png","gif","bmp","ico","svg"
        };

        public static readonly string[] OtherDocumentExtensions =
        {
            "xps","htm","html","mht","psd","mpt","mpp","msg","eml","emlx","vsd",
            "vsdx","vss","vst","vsx","vtx","vdw","vdx","dxf","dwg"
        };

        public static readonly string[] PortableFileDocumentExtensions =
        {
            "pdf"
        };

        public static readonly string FeedbackEmailAddress = "mobilehelp@nova.edu";

        public static readonly string SupportEmailAddress = "mobilehelp@nova.edu";


        public static readonly int RecentGradesLifetimeInDays = 30;

        public static readonly int RecentAnnouncementsLifetimeInDays = 7;

        public static readonly int PrimaryCacheLifetimeInDays = 1;

        public static readonly int SecondaryCacheLifetimeInDays = 30;

        public static readonly int UserSessionLifetimeInHours = 24;

        public static readonly int CriticalDataUpdateIntervalInMinutes = 15;

        public static readonly int AllDataUpdateIntervalInHours = 24;

        public static readonly string ApiBaseAddress = "https://api.stage.nova.edu/";

        public static readonly string LMS = "cv";

    }
}
